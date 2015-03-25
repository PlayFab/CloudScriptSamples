using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.Serialization.JsonFx;
using PlayFab.ClientModels;
using PlayFab.Internal;


// contains all the code required to run the game, draw the UI and connect to PlayFab
public class AsyncMultiplayer : MonoBehaviour {

	// reference to the login class
	public UI_Authentication logInController;
	
	// app states
	public enum AppStates { login = 0, debug = 1, mainMenu = 2, battleMenu = 3, viewGamesMenu = 4 }
	public AppStates appState = AppStates.login;
	
	// 'art'''
	public GUISkin skin;
	public Texture2D[] portraits; 

	//--
	#region private variables
	// filler for text input fields
	private string lfgGameToRemove = "GUID To Remove";
	private string ipGameToRemove = "GUID To Remove";
	
	// contains game information
	private Dictionary<string, GameInstanceInfo> myLFG = new Dictionary<string, GameInstanceInfo>();
	private Dictionary<string, GameInstanceInfo> myIP = new Dictionary<string, GameInstanceInfo>();
	private AsyncQueues allGames;
	private List<HistoricGameRecord> myPreviousGames = new List<HistoricGameRecord>();
	
	// the active game when viewing a game or battling
	private GameDetails currentBattleData;
	private string currentBattleId = string.Empty;
	
	// selectors for the view lobbies UI
	private int selectedGamesList = 3;
	private string selectedGameId = string.Empty;
	
	// used to contril the ping rate when fetching updates
	private float serverPollRate = 60f; 
	private float maxPollRate = 180f;
	private float minPollRate = 60f;
	private float lastPollTime = 0;
	private float pollCooldown = 10f;
	
	// scroll pos vectors
	private Vector2 gamesListScrollPos = Vector2.zero;
	private Vector2 playerGameHistory = Vector2.zero;
	private Vector2 combatTextScrollPos = Vector2.zero; 
	
	// rects for screen layouts
	private Rect centerPane;
	#endregion
	
	//-- standard unity engine functions
	#region unity engine
		// Use this for initialization
		void Start () {
			// set up the rect for the screen size
			this.centerPane = new Rect( Screen.width*.05f, Screen.height*.05f, Screen.width*.90f, Screen.height*.90f);
			
		}
		
		// Update is called once per frame
		void Update () {
		
		}
		
		void OnGUI()
		{
			GUI.skin = this.skin;
			GUI.BeginGroup(this.centerPane);
				switch(this.appState)
				{
					case AppStates.login:
						// do nothing, UI_Auth takes over
					break;
				
					case AppStates.mainMenu:
						DrawMainMenu();
					break;
					
					case AppStates.battleMenu:
						DrawBattleMenu();
					break;
					
					case AppStates.viewGamesMenu:
						DrawViewGamesMenu();
					break;
					
					case AppStates.debug:
						DrawDebugMenu();
					break;
				}
			GUI.EndGroup();
			PollForUpdates();
		}
	#endregion
	
	//------
	#region GUI Draw
	
	// contains all the UI elements that comprise the main menu
	private void DrawMainMenu()
	{
		Rect mainPaneArea = new Rect(0,0, this.centerPane.width, this.centerPane.height);
		
		// set up the left collumn -- image, main options
		GUI.DrawTexture(new Rect(mainPaneArea.width*.05f, mainPaneArea.height*.05f, mainPaneArea.width*.20f, mainPaneArea.width*.20f), this.portraits[0]);

		Rect mainMenuArea = new Rect(mainPaneArea.width*.05f, mainPaneArea.height*.05f + mainPaneArea.width*.20f, mainPaneArea.width*.20f, mainPaneArea.height*.90f - mainPaneArea.width*.20f); 
		GUI.Box(mainMenuArea, "");
		
		GUILayout.BeginArea(mainMenuArea);
			
			GUILayout.Label("");
			
			if(GUILayout.Button("Matchmake"))
			{
				Matchmake();
			}
			
			if(GUILayout.Button("View Lobbies"))
			{
				this.selectedGameId = string.Empty;
				GetGames();
			}
		GUILayout.EndArea();
		
		// content area
		Rect contentArea = new Rect(mainMenuArea.x + mainMenuArea.width + mainPaneArea.width*.05f, mainPaneArea.height*.05f, mainPaneArea.width*.85f - mainMenuArea.width, mainPaneArea.height*.90f); 
		GUI.Box(contentArea, "");
		
		GUILayout.BeginArea(contentArea);
			///-- top part
			GUILayout.Label("");
			GUILayout.BeginHorizontal();
			{
				GUILayout.FlexibleSpace();
				GUILayout.Label("Asynchronous Ship Battle");
				GUILayout.FlexibleSpace();
	
			}
			GUILayout.EndHorizontal();
			GUILayout.Label("");
			
			//-- bottom part
			GUILayout.BeginHorizontal();
				GUILayout.BeginVertical( GUILayout.MinWidth(contentArea.width*.05f));
				GUILayout.EndVertical();

				GUILayout.BeginVertical(GUILayout.MaxWidth( (contentArea.width*.90f)/2));
					if(GUILayout.Button("Battle History"))
					{
						GetPreviousGames();
					}
					this.playerGameHistory = GUILayout.BeginScrollView(this.playerGameHistory);
						foreach(var item in this.myPreviousGames)
						{
							if((item.details.winner == "Player A" && item.details.playerA.PlayFabId == PlayFabSettings.CurrentPlayerId)
			   					|| (item.details.winner == "Player B" && item.details.playerB.PlayFabId == PlayFabSettings.CurrentPlayerId))
							{
								GUI.color = Color.green;
							}
							else
							{
								GUI.color = Color.red;
							}
							
							string opponent = string.Empty;
							if(item.details.playerA.PlayFabId == PlayFabSettings.CurrentPlayerId)
							{
								opponent = item.details.playerB.Username;
							}
							else
							{
								opponent = item.details.playerA.Username;
							}
							
							DateTime utc = new DateTime(1970, 1, 1).AddTicks(item.details.endTime * 10000);
							if(GUILayout.Button("VS: " + opponent + " -- " + utc.ToLocalTime().ToString("d")))
							{
								// load battle screen
								this.currentBattleId = item.guid;
								this.currentBattleData = item.details;
								this.appState = AppStates.battleMenu;
							}
							GUI.color = Color.white;
						}
					GUILayout.EndScrollView();
				GUILayout.EndVertical();
				
				GUILayout.BeginVertical( GUILayout.MinWidth(contentArea.width*.05f));
				GUILayout.EndVertical();
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
	}
	
	// contains all the UI elements that comprise the Battle screen
	private void DrawBattleMenu()
	{
		if(!string.IsNullOrEmpty(this.currentBattleId) && this.currentBattleData != null)
		{
			Rect battlePaneArea = new Rect(0,0, this.centerPane.width, this.centerPane.height);
			
			Rect battleP1Area = new Rect(battlePaneArea.width*.025f, battlePaneArea.height*.05f, battlePaneArea.width*.25f, battlePaneArea.height*.90f); 
			GUI.Box(battleP1Area, "");

			GUILayout.BeginArea(battleP1Area);
				if(this.currentBattleData.playerA_HP <= 0)
				{
					GUI.color = Color.red;
				}
				GUILayout.Space(battleP1Area.width);
				
				GUILayout.BeginHorizontal();
					GUILayout.FlexibleSpace();
					GUILayout.Label(this.currentBattleData.playerA.TitleInfo.DisplayName);
					GUILayout.FlexibleSpace();
				GUILayout.EndHorizontal();
				
				GUILayout.BeginHorizontal();
					GUILayout.FlexibleSpace();
					GUILayout.Label("HP");
					GUILayout.TextField(this.currentBattleData.playerA_HP+"", GUILayout.MinWidth(25), GUILayout.MaxWidth(50));
					GUILayout.FlexibleSpace();
				GUILayout.EndHorizontal();
				
				GUILayout.Label("");
				
				if(this.currentBattleData.playerA.PlayFabId == PlayFabSettings.CurrentPlayerId && this.currentBattleData.gameState == "ActionOnPlayerA")
				{
				   if(GUILayout.Button("Attack!"))
					{
						Debug.Log ("Process Move!");
						ProcessMove(this.currentBattleId);
					}
				}
				
				if(this.currentBattleData.playerA_HP <= 0)
				{
					GUILayout.Label(portraits[0]);
				}
				GUI.color = Color.white;
				if(GUI.Button(new Rect(0,battleP1Area.height*.90f, battleP1Area.width, battleP1Area.height*.10f), "Main Menu"))
				{
					this.appState = AppStates.mainMenu;
				}
				
			GUILayout.EndArea();
			GUI.DrawTexture(new Rect(battleP1Area.x, battleP1Area.y, battleP1Area.width, battleP1Area.width), GetImageForShip(this.currentBattleData.playerA_HP));
			
			Rect battleCenterArea = new Rect(battlePaneArea.width*.31f, battlePaneArea.height*.10f, battlePaneArea.width*.40f, battlePaneArea.height*.70f); 
			GUI.Box(battleCenterArea, "Battle Arena -- (Auto-refresh after: " + this.serverPollRate +" sec)");
			GUILayout.BeginArea(battleCenterArea);
				GUILayout.Label("");
				GUILayout.BeginHorizontal();
					this.serverPollRate = Mathf.FloorToInt(GUILayout.HorizontalSlider(this.serverPollRate, this.minPollRate, this.maxPollRate));
					
					GUI.enabled = this.lastPollTime + this.pollCooldown > Time.time ? false : true;
					if(GUILayout.Button("Refresh", GUILayout.MaxWidth(battleCenterArea.width*.25f)))
					{
						this.lastPollTime = -600f;
					}
					GUI.enabled = true;
					
				GUILayout.EndHorizontal();
				GUILayout.Space(10);
				
			
				GUILayout.BeginHorizontal();
					GUILayout.FlexibleSpace();
					GUILayout.Label("Game Status");
					GUILayout.FlexibleSpace();
				GUILayout.EndHorizontal();
				
				GUILayout.BeginHorizontal();
					if(this.currentBattleData.gameState == "ActionOnPlayerA")
					{
						GUILayout.Space(5);
						GUILayout.Label("<<");
					}
					GUILayout.FlexibleSpace();
					GUILayout.TextField(this.currentBattleData.gameState,  GUILayout.MinWidth(battleCenterArea.width*.50f));
					GUILayout.FlexibleSpace();
					if(this.currentBattleData.gameState == "ActionOnPlayerB")
					{
						GUILayout.Label(">>");
						GUILayout.Space(5);
					}
				GUILayout.EndHorizontal();
				
				GUILayout.Label("");
				string lastMove_A = this.currentBattleData.playerA_moves.Count > 0 ? this.currentBattleData.playerA_moves[this.currentBattleData.playerA_moves.Count-1].ToString() : "#"; 
				string lastMove_B = this.currentBattleData.playerB_moves.Count > 0 ? this.currentBattleData.playerB_moves[this.currentBattleData.playerB_moves.Count-1].ToString() : "#"; 
				
			GUILayout.BeginHorizontal();
					GUILayout.FlexibleSpace();
					GUILayout.TextField(lastMove_A, GUILayout.MinHeight(50), GUILayout.MinWidth(50));
					
					if(this.currentBattleData.gameState != "ActionOnPlayerB")
					{
						GUILayout.Label("V");
						GUILayout.TextField(lastMove_B, GUILayout.MinHeight(50), GUILayout.MinWidth(50));
					}
					GUILayout.FlexibleSpace();
					
				GUILayout.EndHorizontal();
				
				GUILayout.Label("");
				
				if(!string.IsNullOrEmpty(this.currentBattleData.winner))
				{
					GUILayout.BeginHorizontal();
						GUILayout.FlexibleSpace();
						GUILayout.Label("Winner");
						GUILayout.FlexibleSpace();
					GUILayout.EndHorizontal();
					GUILayout.BeginHorizontal();
						GUILayout.FlexibleSpace();
						GUILayout.TextField(this.currentBattleData.winner, GUILayout.MinWidth(battleCenterArea.width*.50f));
						GUILayout.FlexibleSpace();
					GUILayout.EndHorizontal();
				}
				
				this.combatTextScrollPos =  GUILayout.BeginScrollView(this.combatTextScrollPos);
					DrawCombatText();
				GUILayout.EndScrollView();
			GUILayout.EndArea();
	
			Rect battleP2Area = new Rect(battlePaneArea.width*.75f, battlePaneArea.height*.05f, battlePaneArea.width*.25f, battlePaneArea.height*.90f); 
			GUI.Box(battleP2Area, "");
			GUILayout.BeginArea(battleP2Area);
				if(this.currentBattleData.playerB_HP <= 0)
				{
					GUI.color = Color.red;
				}
				GUILayout.Space(battleP1Area.width);
				
				
				string pB_displayName = this.currentBattleData.playerB != null ? this.currentBattleData.playerB.TitleInfo.DisplayName: "No Player";
			
				GUILayout.BeginHorizontal();
					GUILayout.FlexibleSpace();
					GUILayout.Label(pB_displayName);
					GUILayout.FlexibleSpace();
				GUILayout.EndHorizontal();
			
				GUILayout.BeginHorizontal();
					GUILayout.FlexibleSpace();
					GUILayout.Label("HP");
					GUILayout.TextField(this.currentBattleData.playerB_HP+"", GUILayout.MinWidth(25), GUILayout.MaxWidth(50));
					GUILayout.FlexibleSpace();
				GUILayout.EndHorizontal();
				
				GUILayout.Label("");
				
				if(this.currentBattleData.playerB != null)
				{
					if(this.currentBattleData.playerB.PlayFabId == PlayFabSettings.CurrentPlayerId && this.currentBattleData.gameState == "ActionOnPlayerB")
						{
						   if(GUILayout.Button("Attack!"))
							{
								Debug.Log ("Process Move!");
								ProcessMove(this.currentBattleId);
							}
						}
					if(this.currentBattleData.playerB_HP <= 0)
					{
						GUILayout.Label(portraits[0]);
					}							
				}
				GUI.color = Color.white;
			GUILayout.EndArea();
			//GUI.DrawTextureWithTexCoords(new Rect(battleP2Area.x, battleP2Area.y, battleP2Area.width, battleP2Area.width), this.portraits[2], new Rect(0, 0, -1, 1));
			GUI.DrawTexture(new Rect(battleP2Area.x + battleP2Area.width, battleP2Area.y + battleP2Area.width, -battleP2Area.width, -battleP2Area.width), GetImageForShip(this.currentBattleData.playerB_HP));
		}
	}

	// processes the game details to create a text log describing the battle
	private void DrawCombatText()
	{
		for(int z = 0; z < this.currentBattleData.playerB_moves.Count; z++)
		{
			if(this.currentBattleData.playerA_moves[z] > this.currentBattleData.playerB_moves[z])
			{
				if(PlayFabSettings.CurrentPlayerId == this.currentBattleData.playerA.PlayFabId)
				{
					GUI.color = Color.green;
				}
				else
				{
					GUI.color = Color.red;
				}
				GUILayout.Label( string.Format("{0} ({1}) > {2} ({3}) -- {2}'s ship takes {1} damage.",  this.currentBattleData.playerA.Username, this.currentBattleData.playerA_moves[z], this.currentBattleData.playerB.Username, this.currentBattleData.playerB_moves[z]));
				GUI.color = Color.white;
			}
			else if(this.currentBattleData.playerA_moves[z] < this.currentBattleData.playerB_moves[z])
			{
				if(PlayFabSettings.CurrentPlayerId == this.currentBattleData.playerB.PlayFabId)
				{
					GUI.color = Color.green;
				}
				else
				{
					GUI.color = Color.red;
				}
				GUILayout.Label( string.Format("{2} ({3}) > {0} ({1}) -- {0}'s ship takes {3} damage.",  this.currentBattleData.playerA.Username, this.currentBattleData.playerA_moves[z], this.currentBattleData.playerB.Username, this.currentBattleData.playerB_moves[z]));
				GUI.color = Color.white;
			}
			else
			{
				GUI.color = Color.yellow;
				GUILayout.Label(string.Format("The damage was neutralized {0} to {1}.", this.currentBattleData.playerA_moves[z], this.currentBattleData.playerB_moves[z]));
				GUI.color = Color.white;
			}
		}
		
		if(this.currentBattleData.playerA_moves.Count > this.currentBattleData.playerB_moves.Count)
		{
			GUILayout.Label(string.Format("{0} has attacked with ({1}) awaiting {2}'s attack...", this.currentBattleData.playerA.Username, this.currentBattleData.playerA_moves[this.currentBattleData.playerA_moves.Count-1], this.currentBattleData.playerB.Username));
		}
		else if(!string.IsNullOrEmpty(this.currentBattleData.winner))
		{
			if(this.currentBattleData.playerA_HP > 0)
			{
				GUILayout.Label(string.Format("{0} has won the game {1} to {2}", this.currentBattleData.playerA.Username, this.currentBattleData.playerA_HP, this.currentBattleData.playerB_HP));
			}
			else
			{
				GUILayout.Label(string.Format("{0} has won the game {1} to {2}", this.currentBattleData.playerB.Username, this.currentBattleData.playerB_HP, this.currentBattleData.playerA_HP));
			}
		}
	}
	
	// contains all the UI elements that comprise the view lobbies
	private void DrawViewGamesMenu()
	{
		Dictionary<string, GameInstanceInfo > gamesToDisplay;
		Rect viewPaneArea = new Rect(0,0, this.centerPane.width, this.centerPane.height);
		Rect viewMenuArea = new Rect(viewPaneArea.width*.05f, viewPaneArea.height*.05f, viewPaneArea.width*.40f, viewPaneArea.height*.90f); 
		GUI.Box(viewMenuArea, "");
		
		GUILayout.BeginArea(viewMenuArea);
	
				GUILayout.Label("View Games -- (Auto-refresh after: " + this.serverPollRate +" sec)");
		
				GUILayout.BeginHorizontal();
				this.serverPollRate = Mathf.FloorToInt(GUILayout.HorizontalSlider(this.serverPollRate, this.minPollRate, this.maxPollRate));
				
				GUI.enabled = this.lastPollTime + this.pollCooldown > Time.time ? false : true;
				if(GUILayout.Button("Refresh", GUILayout.MaxWidth(viewMenuArea.width*.25f)))
				{
					this.lastPollTime = -600f;
				}
				GUI.enabled = true;
				
				GUILayout.EndHorizontal();
				
				GUILayout.BeginHorizontal();
			
				if(this.selectedGamesList == 0)
				{
					GUI.color = Color.green;
				}
				if(GUILayout.Button("Open Games (" + this.allGames.LFG.Count +")"))
					{
						OnSelectGamesList(0);
					}
				GUI.color = Color.white;
				
				if(this.selectedGamesList == 3)
				{
					GUI.color = Color.green;
				}
				if(GUILayout.Button("Active Games (" + this.myIP.Count +")"))
					{
						OnSelectGamesList(3);
					}
				GUI.color = Color.white;
			GUILayout.EndHorizontal();
			
			GUILayout.Space(10);
			this.gamesListScrollPos = GUILayout.BeginScrollView(this.gamesListScrollPos, false, false, GUILayout.Width(viewMenuArea.width), GUILayout.Height(viewMenuArea.height*.75f));
				switch(this.selectedGamesList)
				{
					 case 0:
						// LFG
						gamesToDisplay = this.allGames.LFG;
					break;
					 
					 case 1:
						// IP
						gamesToDisplay = this.allGames.IP;
						break;
						
					 case 2:
						// myLFG
						gamesToDisplay = this.myLFG;
						break;
						
					 case 3:
						// myIP
						gamesToDisplay = this.myIP;
						break;
					
					default:
						gamesToDisplay = new Dictionary<string, GameInstanceInfo>();
						break;
				}
				
				int gameIndex = 0;
				foreach(var kvp in gamesToDisplay)
				{
					if(this.selectedGameId == kvp.Key)
					{
						GUI.color = Color.green;
					}
					else if(kvp.Value.gameState == "ActionOnPlayerA" && PlayFabSettings.CurrentUsername == kvp.Value.playerA)
					{
						GUI.color = Color.cyan;
					}
					else if(kvp.Value.gameState == "ActionOnPlayerB" && PlayFabSettings.CurrentUsername == kvp.Value.playerB)
					{
						GUI.color = Color.cyan;
					}
					if(GUILayout.Button(kvp.Key))
					{
						OnSelectGame(kvp.Key);
					}
					GUI.color = Color.white;
					gameIndex++;
				}
			GUILayout.EndScrollView();
				
		if(GUI.Button(new Rect(0,viewMenuArea.height*.90f, viewMenuArea.width, viewMenuArea.height*.10f), "Main Menu"))
			{
				this.appState = AppStates.mainMenu;
			}
			
		GUILayout.EndArea();
		
		
		if(!string.IsNullOrEmpty(this.selectedGameId))
		{
			Rect viewDetailsArea = new Rect(viewMenuArea.width + viewPaneArea.width*.08f, viewPaneArea.height*.05f, viewPaneArea.width*.50f, viewPaneArea.height*.50f); 
			GUI.Box(viewDetailsArea, "Selected Game Details");
			
				GUILayout.BeginArea(viewDetailsArea);
					GUILayout.Space(20);
					GUILayout.BeginHorizontal();
						GUILayout.Label(" Game State: " + gamesToDisplay[this.selectedGameId].gameState);
						GUILayout.FlexibleSpace();
						
					DateTime utc = new DateTime(1970, 1, 1).AddTicks(gamesToDisplay[this.selectedGameId].startTime * 10000);
					GUILayout.Label(" Started On: " +  utc.ToLocalTime().ToString("dd/MM/yyyy hh:mm:ss tt") + " ");
					GUILayout.Space(5);
				GUILayout.EndHorizontal();
				
				GUILayout.Label(" Player A: " + gamesToDisplay[this.selectedGameId].playerA);
				GUILayout.Label(" Player B: " + gamesToDisplay[this.selectedGameId].playerB);
				
				utc = new DateTime(1970, 1, 1).AddTicks(gamesToDisplay[this.selectedGameId].startTime * 10000);
				GUILayout.Label(" Last Move: " + utc.ToString("dd/MM/yyyy hh:mm:ss tt") + "");
			
				if(string.IsNullOrEmpty(gamesToDisplay[this.selectedGameId].playerB) 
				&& PlayFabSettings.CurrentUsername != gamesToDisplay[this.selectedGameId].playerA) 
				{
					if(GUI.Button(new Rect(0,viewDetailsArea.height*.90f, viewDetailsArea.width, viewDetailsArea.height*.10f), "Join game " + this.selectedGameId))
					{
						//GetBattleData(this.selectedGameId);
						Debug.Log ("LFG Join: " + this.selectedGameId);
						JoinGameById(this.selectedGameId);
					}
				}
				else if(!string.IsNullOrEmpty(gamesToDisplay[this.selectedGameId].playerB)
			        && (PlayFabSettings.CurrentUsername == gamesToDisplay[this.selectedGameId].playerA
			    		|| PlayFabSettings.CurrentUsername == gamesToDisplay[this.selectedGameId].playerB))
				{
					if(GUI.Button(new Rect(0,viewDetailsArea.height*.90f, viewDetailsArea.width, viewDetailsArea.height*.10f), "Join game " + this.selectedGameId))
					{
						this.currentBattleData = null;
						GetBattleData(this.selectedGameId);
						Debug.Log ("IP Join: " + this.selectedGameId);
					}
				}	
			GUILayout.EndArea();
		}
	}
	
	// some UI to access some useful helper methods when building and testing a lobby based asynchronous game. 
	private void DrawDebugMenu()
	{
		Rect debugPaneArea = new Rect(0,0, this.centerPane.width, this.centerPane.height);
		GUI.Box(debugPaneArea, "");
		
		Rect debugMenuArea = new Rect(debugPaneArea.width*.10f, debugPaneArea.height*.10f, debugPaneArea.width*.5f, debugPaneArea.height*.5f); 
		GUILayout.BeginArea(debugMenuArea);
			if(GUILayout.Button("Init Queues"))
			{
				InitializeSharedGroups();
			}
			if(GUILayout.Button("Add Admin Account"))
			{
				AddAdminAccount();
			}
			GUILayout.BeginHorizontal();
			{
				if(GUILayout.Button("Remove LFG Game"))
				{
					RemoveLFGGame();
				}
				this.lfgGameToRemove = GUILayout.TextField(this.lfgGameToRemove);
				
			}
			GUILayout.EndHorizontal();
			
			GUILayout.BeginHorizontal();
			{
				if(GUILayout.Button("Remove IP Game"))
				{
					RemoveIPGame();
				}
				this.ipGameToRemove = GUILayout.TextField(this.ipGameToRemove);
				
			}
			GUILayout.EndHorizontal();
			
			GUILayout.Label("");
			if(GUILayout.Button("Main Menu"))
			{
				this.appState = AppStates.mainMenu;
			}
		GUILayout.EndArea();
	}
	#endregion
	

	#region playfab / callbacks
	// fetches the player's previously played games histroy from their PlayerData
	void GetPreviousGames()
	{
		GetUserDataRequest request = new GetUserDataRequest();
		request.Keys = new List<string>() {"PreviousGames", "PreviousGamesPageCount"};
		PlayFabClientAPI.GetUserData(request, OnGetUserDataSuccess, OnPlayFabError);
	}
	
	// called when a game ends on the other player's turn, causing the game to end, this will fetch the archived game allowing it have all the data and to remain on screen
	void GetPreviousGamesAfterBattleDataFail()
	{
		GetUserDataRequest request = new GetUserDataRequest();
		request.Keys = new List<string>() {"PreviousGames", "PreviousGamesPageCount"};
		PlayFabClientAPI.GetUserData(request, OnGetPreviousGamesAfterBattleDataFailSuccess, OnPlayFabError);
	}
	
	// callback after a successful "GetPreviousGamesAfterBattleDataFail", updates the current battle info
	void OnGetPreviousGamesAfterBattleDataFailSuccess(GetUserDataResult result)
	{
		int pageCount = 1;
		// handles if the history is very long and exceeds 1 key-value-pair 
		if(result.Data.ContainsKey("PreviousGamesPageCount"))
		{
			pageCount = Int32.Parse(result.Data["PreviousGamesPageCount"].Value);
			if(pageCount > 1)
			{
				string pageIndex = "PreviousGames";
				GetUserDataRequest request = new GetUserDataRequest();
				request.Keys = new List<string>() { pageIndex+pageCount };
				PlayFabClientAPI.GetUserData(request, OnGetPreviousGamesLastPage, OnPlayFabError);
			}
		}
		else if(result.Data.ContainsKey("PreviousGames"))
		{
			var pg = JsonReader.Deserialize<HistroicWrapper>(result.Data["PreviousGames"].Value);
			this.myPreviousGames = pg.games;
			this.currentBattleData = this.myPreviousGames.Find(match => match.guid == this.currentBattleId).details;
		}
	}
	
	// callback after a successful "OnGetPreviousGamesAfterBattleDataFailSuccess", updates the current battle info
	void OnGetPreviousGamesLastPage(GetUserDataResult result)
	{
		foreach(var item in result.Data)
		{
			Debug.Log("K:" + item.Key + " V:" + item.Value.Value);
			var pg = JsonReader.Deserialize<HistroicWrapper>(result.Data[item.Key].Value);
			
			this.myPreviousGames.AddRange(pg.games);
		}
		this.currentBattleData = this.myPreviousGames.Find(match => match.guid == this.currentBattleId).details;
	}
	
	
	// callback after a successful "GetUserData", updates this.myPreviousGames with the most recent copy of the player's game history 
	void OnGetUserDataSuccess(GetUserDataResult result)
	{
		int pageIndex = 1;
		if(result.Data.ContainsKey("PreviousGamesPageCount"))
		{
			pageIndex = Int32.Parse(result.Data["PreviousGamesPageCount"].Value);
			if(pageIndex == 1)
			{
				if(result.Data.ContainsKey("PreviousGames"))
				{
					var pg = JsonReader.Deserialize<HistroicWrapper>(result.Data["PreviousGames"].Value);
					this.myPreviousGames = pg.games;
				}
			}
			else
			{
				var pg = JsonReader.Deserialize<HistroicWrapper>(result.Data["PreviousGames"].Value);
				this.myPreviousGames = pg.games;
				
				List<string> pages = new List<string>();
				string keyName = "PreviousGames";
				for(int z = 1; z <= pageIndex; z++)
				{
					if(z != 1)
					{
						pages.Add(keyName+z);
					}
				} 
				GetConsecutiveHistory(pages);
			}
		}
	}
	
	// called when games history exceeds 1 key-value-pair 
	void GetConsecutiveHistory(List<string> keys)
	{
		GetUserDataRequest request = new GetUserDataRequest();
		request.Keys = keys;
		PlayFabClientAPI.GetUserData(request, OnGetConsecutiveHistorySuccess, OnPlayFabError);
	}
	
	// callback after a successful "GetConsecutiveHistory", adds additional records onto this.myPreviousGames and orders by most recent (descending)
	void OnGetConsecutiveHistorySuccess(GetUserDataResult result)
	{
		foreach(var item in result.Data)
		{
			Debug.Log("K:" + item.Key + " V:" + item.Value.Value);
			var pg = JsonReader.Deserialize<HistroicWrapper>(result.Data[item.Key].Value);
			
			this.myPreviousGames.AddRange(pg.games);
		}
		this.myPreviousGames = this.myPreviousGames.OrderByDescending(x => x.details.endTime).ToList();

	}
	
	// Triggers the "ProcessMove" cloud script call
	void ProcessMove(string id)
	{
		RunCloudScriptRequest request = new RunCloudScriptRequest();
		request.ActionId = "ProcessMove";
		request.Params = new { GUID = this.currentBattleId };
		PlayFabClientAPI.RunCloudScript(request, CC_OnProcessMoveSuccess, OnPlayFabError);
	}
	
	// callback after a ProcessMove completes successfully, updates the current battle data
	void CC_OnProcessMoveSuccess(RunCloudScriptResult result)
	{
		GameDetails game = JsonReader.Deserialize<GameDetails>(result.ResultsEncoded);
		Debug.Log("LFG: " + this.currentBattleData.gameState);
		this.currentBattleData = game;
	}
	
	// Triggers the "GetAllGames" cloud script call
	void GetGames()
	{
		RunCloudScriptRequest request = new RunCloudScriptRequest();
		request.ActionId = "GetAllGames";
		PlayFabClientAPI.RunCloudScript(request, CC_OnGetGamesSuccess, OnPlayFabError);
	}
	
	// callback after a GetGames completes successfully,
	void CC_OnGetGamesSuccess(RunCloudScriptResult result)
	{
		this.allGames = JsonReader.Deserialize<AsyncQueues>(result.ResultsEncoded);
		
		if(this.selectedGamesList == 0 || this.selectedGamesList == 2 && !string.IsNullOrEmpty(this.selectedGameId))
		{
			if( !allGames.LFG.ContainsKey(this.selectedGameId))
			{
				Debug.Log("not in LFG");
				this.selectedGameId = string.Empty;
			} 
		}
		else if (!string.IsNullOrEmpty(this.selectedGameId))
		{
			if( !allGames.IP.ContainsKey(this.selectedGameId))
			{
				Debug.Log("not in IP");
				this.selectedGameId = string.Empty;
			} 
		}
		
		this.myIP = allGames.IP;
		this.myLFG = allGames.LFG;
		
		Debug.Log("LFG: " + allGames.LFG.Count + " IP: " + allGames.IP.Count);
		this.appState = AppStates.viewGamesMenu;
	}	
	
	// Triggers the "JoinGameById" cloud script call
	void JoinGameById(string id)
	{
		RunCloudScriptRequest request = new RunCloudScriptRequest();
		request.ActionId = "JoinGameById";
		request.Params = new { GUID = id };
		PlayFabClientAPI.RunCloudScript(request, CC_OnJoinGameByIdSuccess, OnPlayFabError);
	}
	
	// callback after a JoinGameById completes successfully, triggers an update on the recently joined game
	void CC_OnJoinGameByIdSuccess(RunCloudScriptResult result)
	{
		JoinGameResult game = JsonReader.Deserialize<JoinGameResult>(result.ResultsEncoded);
		GetBattleData(game.GUID);
	}
	
	// Triggers the "Matchmake" cloud script call
	void Matchmake()
	{
		RunCloudScriptRequest request = new RunCloudScriptRequest();
		request.ActionId = "Matchmake";
		PlayFabClientAPI.RunCloudScript(request, CC_OnMatchmakeSuccess, OnPlayFabError); 
	}
	
	// callback after a Matchmake completes successfully, transitions screens depending on the state of the game
	void CC_OnMatchmakeSuccess(RunCloudScriptResult result)
	{
		JoinGameResult game = JsonReader.Deserialize<JoinGameResult>(result.ResultsEncoded);
		
		if(game.gameState == "ActionOnPlayerA")
		{
			Debug.Log("Game Full, Prompt to start battle?" );
			GetBattleData(game.GUID);
		}
		else if(game.gameState == "NewGame")
		{
			Debug.Log("NewGame created, awaiting match.");
			this.selectedGamesList = 2;
			this.selectedGameId = game.GUID;
			GetGames();
		}
	}
	
	// Triggers the "GetBattleData" cloud script call
	void GetBattleData(string id)
	{
		if(this.currentBattleData == null)
		{
			RunCloudScriptRequest request = new RunCloudScriptRequest();
			request.ActionId = "GetBattleData";
			request.Params = new { GUID = id };
			PlayFabClientAPI.RunCloudScript(request, CC_OnGetBattleDataSuccess, CC_OnGetBattleDataError);
			this.currentBattleId = id;
		}
		else
		{
			if(this.currentBattleData.gameState != "Archived" && this.currentBattleData.gameState != "Complete")
			{
				RunCloudScriptRequest request = new RunCloudScriptRequest();
				request.ActionId = "GetBattleData";
				request.Params = new { GUID = id };
				PlayFabClientAPI.RunCloudScript(request, CC_OnGetBattleDataSuccess, CC_OnGetBattleDataError);
				this.currentBattleId = id;
			}
		}
	}
	
	// callback after a GetBattleData completes successfully, updates the current battle data
	void CC_OnGetBattleDataSuccess(RunCloudScriptResult result)
	{
		this.currentBattleData = JsonReader.Deserialize<GameDetails>(result.ResultsEncoded);
		
		Debug.Log("LFG: " + this.currentBattleData.gameState);
		this.appState = AppStates.battleMenu;
	}
	
	// callback after a GetBattleData fails, this is a special case to capture when games end on the remote player's turn, and the game gets archives before the client gets the last update
	void CC_OnGetBattleDataError(PlayFabError error)
	{
		Debug.Log("GetBattleData Error: " + error.ErrorMessage);
		
		GetPreviousGamesAfterBattleDataFail();	
	}
	
	// asks the server for the cloudscript web API endpoint
	void ValidateCloudScriptUrl()
	{
		if(PlayFabSettings.GetLogicURL() == null)
		{
			GetCloudScriptUrlRequest request = new GetCloudScriptUrlRequest();
			PlayFabClientAPI.GetCloudScriptUrl(request, OnGetCloudScriptUrlSuccess, OnPlayFabError );
		}
	}
	
	// a generic catch all call back for when PlayFab Calls fail
	void OnPlayFabError(PlayFabError error)
	{
		Debug.Log ("Got an error: " + error.ErrorMessage);
	}
	
	// callback after a ValidateCloudScriptUrl succeeds
	void OnGetCloudScriptUrlSuccess(GetCloudScriptUrlResult result)
	{
		Debug.Log("CloudScript URL: " + result.Url);
	}
	
	// public method that the UI_Auth script calles on a succesful login
	public void OnLoginSuccess()
	{
		ValidateCloudScriptUrl();
		this.appState = AppStates.mainMenu;
	}
	
	// public method that the UI_Auth script calles on a succesful logout
	public void OnLogoutSuccess()
	{
		this.appState = AppStates.login;
	}
	#endregion
	
	// a few methods that can be used to test and debug this game
	#region debug / callbacks

	void InitializeSharedGroups()
	{
		RunCloudScriptRequest request = new RunCloudScriptRequest();
		request.ActionId = "InitSharedGroups";
		PlayFabClientAPI.RunCloudScript(request, OnInitGroupSuccess, OnPlayFabError); 
	}
	
	void OnInitGroupSuccess(RunCloudScriptResult result)
	{
		Debug.Log(result.ActionLog);
	}
	
	void AddAdminAccount()
	{
		RunCloudScriptRequest request = new RunCloudScriptRequest();
		request.ActionId = "AddAdminAccountToGroups";
		PlayFabClientAPI.RunCloudScript(request, OnAddAdminAccountSuccess, OnPlayFabError); 
	}
	
	void OnAddAdminAccountSuccess(RunCloudScriptResult result)
	{
		Debug.Log(result.ActionLog);
	}

	void RemoveLFGGame()
	{
		RunCloudScriptRequest request = new RunCloudScriptRequest();
		request.ActionId = "RemoveFrom_openGames";
		request.Params = new {GUID = this.lfgGameToRemove };
		PlayFabClientAPI.RunCloudScript(request, OnRemoveGameSuccess, OnPlayFabError);
	}
	
	void RemoveIPGame()
	{
		RunCloudScriptRequest request = new RunCloudScriptRequest();
		request.ActionId = "RemoveFrom_fullGames";
		request.Params = new {GUID = this.ipGameToRemove };
		PlayFabClientAPI.RunCloudScript(request, OnRemoveGameSuccess, OnPlayFabError);
	}
	
	void OnRemoveGameSuccess(RunCloudScriptResult result)
	{
		Debug.Log("CloudScript: " + result.ResultsEncoded);
		Debug.Log("CloudScript Log: " + result.ActionLog);
	}
#endregion



//--
#region misc methods
	// useful for updating the portrait 
	Texture2D GetImageForShip(int hp)
	{
		if(hp < 75 && hp > 50)
		{
			return this.portraits[2];
		}
		else if (hp <= 50 && hp > 25)
		{
			return this.portraits[3];
		}
		else if(hp <= 25 && hp > 0)
		{
			return this.portraits[4];
		}
		else if(hp <= 0)
		{
			return this.portraits[5];
		}
		else
		{
			return this.portraits[1];
		}
	}

	// called to get updated on a reoccuring basis
	void PollForUpdates()
	{
		if(this.lastPollTime + this.serverPollRate <= Time.time)
		{
			if(this.appState == AppStates.battleMenu && !string.IsNullOrEmpty(this.currentBattleId))
			{
				GetBattleData(this.currentBattleId);
				Debug.Log("Polling for Battle Data Updates.");
				this.lastPollTime = Time.time;
			}
			else if(this.appState == AppStates.viewGamesMenu)
			{
				GetGames();
				Debug.Log("Polling for Game List.");
				this.lastPollTime = Time.time;
			}
		}
	}
	
	//  updates the selected game
	void OnSelectGamesList(int index)
	{
		this.selectedGamesList = index;
		OnSelectGame(string.Empty);
	}
	//  updates the selected game
	void OnSelectGame(string id)
	{
		this.selectedGameId = id;
	}
	#endregion
}


//-- classes that map to the JSON objects going to and from our cloud script environment
#region helper classes
public class AsyncQueues
{
	public Dictionary<string, GameInstanceInfo> LFG = new Dictionary<string, GameInstanceInfo>();
	public Dictionary<string, GameInstanceInfo> IP = new Dictionary<string, GameInstanceInfo>();
}
	
public class GameInstanceInfo
{
	public string gameState { get; set; }
	public Int64 startTime { get; set; }
	public Int64 lastMoveTime  { get; set; }
	public string playerA  { get; set; }
	public string playerB  { get; set; }

}

public class JoinGameResult
{
	public string GUID { get; set; }
	public string gameState { get; set; }
}


public class HistroicWrapper
{
	public List<HistoricGameRecord> games { get; set; }
}

public class HistoricGameRecord
{
	public string guid { get; set; }
	public GameDetails details { get; set; }
}


/// <summary>
/// used to map to the all inclusive game data (maybe from player data, not shared group data)
/// </summary>
public class GameDetails
{
	public string gameState { get; set; }
	public string winner { get; set; }
	public Int64 startTime { get; set; }
	public Int64 endTime { get; set; }
	public Int64 lastMoveTime { get; set; }
	
	public UserAccountInfo playerA { get; set; }
	public int playerA_HP { get; set; }
	public List<int> playerA_moves;
	
	public int playerB_HP { get; set; } 
	public UserAccountInfo playerB { get; set; }
	public List<int> playerB_moves { get; set; }
	
}
#endregion
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.Serialization.JsonFx;
using PlayFab.ClientModels;
using PlayFab.Internal;


public class startGame : MonoBehaviour {
	public UI_Authentication logInController;
	public Rect mainMenuRect;
	//public MyGames games = new MyGames();
	
	// used to track the various states a game can be in
	public enum GameStates { starting = 1, waitingOnPlayerA = 2, waitingOnPlayerB  = 3, complete = 4, pendingArchive = 5, archived = 6 };
	
	// populated after a newGame is created or a match is found. 
	public string activeGame = string.Empty;
	
	
	public GameStates gameState = GameStates.starting;
	private string LFG_SharedGroupId = "JJ_LFG_Queue"; // LFG = Looking for group / game
	private string IP_SharedGroupId = "JJ_IP_Queue"; // IP = In Progress
	private string lfgGameToRemove = "GUID To Remove";
	private string ipGameToRemove = "GUID To Remove";
	
	
	// used for debugging / setting up the inital shared groups.
	public bool debugMode = false;
	private string[] playfabAdmin = new string[] {"572C1AE46640D5C6"};
	private string[] zacsId = new string[] {"FC5704B9075819E6"};
	
	private Guid gameID;
	
	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		if(this.logInController.isLoggedIn == true && this.debugMode == true)
		{
			if(GUI.Button(new Rect(10,10,125,35), "Init SGs"))
			{
				InitializeSharedGroups();
			}
		}
		else if(this.logInController.isLoggedIn == true && this.gameState == GameStates.starting)
		{		
			GUI.BeginGroup(mainMenuRect);
				if(GUILayout.Button("Start New Game"))
				{
					StartNewGame();
				}
				if(GUILayout.Button("Matchmake"))
				{
					Matchmake();
				}
				if(GUILayout.Button("Get Shared Group Data"))
				{
					GetSharedGroupData();
				}
				
				GUILayout.BeginHorizontal();
				{
					if(GUILayout.Button("Remove LFG Game"))
					{
						RemoveLFGGame();
					}
					this.lfgGameToRemove = GUILayout.TextField(this.lfgGameToRemove, 30);
					
				}
				GUILayout.EndHorizontal();
				
				GUILayout.BeginHorizontal();
				{
					if(GUILayout.Button("Remove IP Game"))
					{
						
					}
					this.ipGameToRemove = GUILayout.TextField(this.ipGameToRemove, 30);
					
				}
				GUILayout.EndHorizontal();
				
				if(GUILayout.Button("Get My Games"))
				{
					GetMyGames();
				}
				
				if(GUILayout.Button("TEST GUID"))
				{
					Test_JSON_GUID();
				}
				
			GUI.EndGroup();
		}
		else if(this.logInController.isLoggedIn == true && this.gameState == GameStates.waitingOnPlayerA)
		{
			GUI.BeginGroup(mainMenuRect);
				if(GUILayout.Button("PlayerA to Server"))
				{
					SendMoves(true); 
				}
			GUI.EndGroup();
		}
		else if(this.logInController.isLoggedIn == true && this.gameState == GameStates.waitingOnPlayerB)
		{
			GUI.BeginGroup(mainMenuRect);
			if(GUILayout.Button("PlayerB to Server"))
			{
				SendMoves(false);
			}
			GUI.EndGroup();
		}
		else if(this.logInController.isLoggedIn == true && this.gameState == GameStates.complete)
		{
			GUI.BeginGroup(mainMenuRect);
			if(GUILayout.Button("Send moves to server"))
			{
			//	SendMoves();
			}
			GUI.EndGroup();
		}
	}
	
	
	void StartNewGame()
	{
		Guid gameID =  System.Guid.NewGuid();
		RunCloudScriptRequest request = new RunCloudScriptRequest();
		request.ActionId = "CreateNewGame";
		
		request.Params = new { GUID = gameID.ToString(), Message = "Hello" };
		//request.ParamsEncoded = 
		//Debug.Log();
		PlayFabClientAPI.RunCloudScript(request, CC_OnStartNewGameSuccess, OnPlayFabError); 
	}
	
	void Matchmake()
	{
		RunCloudScriptRequest request = new RunCloudScriptRequest();
		request.ActionId = "Matchmake";
		PlayFabClientAPI.RunCloudScript(request, CC_OnMatchmakeSuccess, OnPlayFabError); 
	}
	
	void SendMoves(bool isPlayerA)
	{
		RunCloudScriptRequest request = new RunCloudScriptRequest();
		request.ActionId = "ProcessMove"; //ProcessMove
		int amt = UnityEngine.Random.Range(1,100);
		string player = isPlayerA == true  ? "playerA" : "playerB";
		request.Params = new {GUID = this.activeGame, turn = player, move = amt};
		PlayFabClientAPI.RunCloudScript(request, CC_OnProcessMoveSuccess, OnPlayFabError); 
	}
	
	void GetSharedGroupData()
	{
		RunCloudScriptRequest request = new RunCloudScriptRequest();
		request.ActionId = "GetSharedGroupData";
		PlayFabClientAPI.RunCloudScript(request, OnGetSharedGroupDataSuccess, OnPlayFabError); 
	}
	
	void RemoveLFGGame()
	{
		RunCloudScriptRequest request = new RunCloudScriptRequest();
		request.ActionId = "RemoveFrom_LFGQueue";
		request.Params = new {GUID = this.lfgGameToRemove };
		PlayFabClientAPI.RunCloudScript(request, OnGetSharedGroupDataSuccess, OnPlayFabError);
	}
	
	void RemoveIPGame()
	{
		RunCloudScriptRequest request = new RunCloudScriptRequest();
		request.ActionId = "RemoveFrom_IPQueue";
		request.Params = new {GUID = this.ipGameToRemove };
		PlayFabClientAPI.RunCloudScript(request, OnGetSharedGroupDataSuccess, OnPlayFabError);
	}
	
	void GetMyGames()
	{
		RunCloudScriptRequest request = new RunCloudScriptRequest();
		request.ActionId = "GetMyGames";
		PlayFabClientAPI.RunCloudScript(request, CC_OnGetMyGamesSuccess, OnPlayFabError);
	}
	
	void CC_OnGetMyGamesSuccess(RunCloudScriptResult result)
	{
		Debug.Log(result.ResultsEncoded);

		
		MyGames games = new MyGames();
		games = JsonReader.Deserialize<MyGames>(result.ResultsEncoded);
		Debug.Log(games.LFG.Count + " : " + games.IP.Count);
		
	}
	
	void OnRemoveGameSuccess(RunCloudScriptResult result)
	{
		Debug.Log("CloudScript: " + result.ResultsEncoded);
		Debug.Log("CloudScript Log: " + result.ActionLog);
	}
	
	void OnGetSharedGroupDataSuccess(RunCloudScriptResult result)
	{
		Debug.Log("CloudScript: " + result.ResultsEncoded);
		Debug.Log("CloudScript Log: " + result.ActionLog);
	}
	
	public void ValidateCloudScriptUrl()
	{
		if(PlayFabSettings.GetLogicURL() == null)
		{
			GetCloudScriptUrlRequest request = new GetCloudScriptUrlRequest();
			PlayFabClientAPI.GetCloudScriptUrl(request, OnGetCloudScriptUrlSuccess, OnPlayFabError );
		}
	}
	
	void OnPlayFabError(PlayFabError error)
	{
		Debug.Log ("Got an error: " + error.ErrorMessage);
	}

	void OnGetCloudScriptUrlSuccess(GetCloudScriptUrlResult result)
	{
		Debug.Log("CloudScript: " + result.Url);
	}
	
	void CC_OnStartNewGameSuccess(RunCloudScriptResult result)
	{
		Debug.Log (result.ResultsEncoded.ToString() + " : " + result.Results.ToString());
		this.activeGame = result.ResultsEncoded.ToString();
		this.gameState = GameStates.starting;
	}
	
	void CC_OnMatchmakeSuccess(RunCloudScriptResult result)
	{
		Debug.Log("CloudScript v" + result.Version +"."+result.Revision + ":" + result.ResultsEncoded);
		Debug.Log("CloudScript Log: " + result.ActionLog);
		
	//	Debug.Log(result.ActionLog + " re: " + result.Results + " en: " + result.ResultsEncoded);
		//this.activeGame = result.ResultsEncoded.ToString();
	}
	
	void CC_OnProcessMoveSuccess(RunCloudScriptResult result)
	{
		Debug.Log("CloudScript v" + result.Version +"."+result.Revision + ":" + result.ResultsEncoded);
		Debug.Log("CloudScript Log: " + result.ActionLog);
	}	
	
	void Test_JSON_GUID()
	{

		//PlayerSaveData data = new PlayerSaveData(){Location = "Beach", TimeLeft=540, ObjectiveComplete = false};
		RunCloudScriptExample();
		
		

	}
	
	
	
	//Run CloudScript test
	void RunCloudScriptExample()
	{	
		RunCloudScriptRequest request = new RunCloudScriptRequest();
		request.ActionId = "TestReturnValue";
		request.Params = new {GUID = "000"};
		PlayFabClientAPI.RunCloudScript(request, OnRunCloudScriptExampleSuccess, OnPlayFabError);
	}
	
	//called when our Cloud Script request has been answered successfully
	void OnRunCloudScriptExampleSuccess(RunCloudScriptResult result)
	{
		Debug.Log("CloudScript Example Success");
		Debug.Log("Resutls: " + result.Results.ToString());
		Debug.Log("ResutlsEncoded: " + result.ResultsEncoded);
		Debug.Log("ActionLog: " + result.ActionLog);
	}
	
	
	
	
	
	#region debugMode methods
	void InitializeSharedGroups()
	{
		RunCloudScriptRequest request = new RunCloudScriptRequest();
		request.ActionId = "InitSharedGroups";
		PlayFabClientAPI.RunCloudScript(request, OnInitGroupSuccess, OnPlayFabError); 
		
//		CreateSharedGroupRequest request = new CreateSharedGroupRequest();
//		request.SharedGroupId = this.LFG_SharedGroupId;
//		
//		PlayFabClientAPI.CreateSharedGroup(request, OnCreateLFGroupSuccess, OnPlayFabError);
//		
//		request.SharedGroupId = this.IP_SharedGroupId;
//		PlayFabClientAPI.CreateSharedGroup(request, OnCreateIPGroupSuccess, OnPlayFabError);
	}
	
	void OnInitGroupSuccess(RunCloudScriptResult result)
	{
		Debug.Log(result.ActionLog);
	}
	
	void OnInitGroupError(PlayFabError err)
	{
		Debug.Log(err.ErrorMessage);
	}
	
	void OnCreateLFGroupSuccess(CreateSharedGroupResult result)
	{
	
		AddSharedGroupMembersRequest request = new AddSharedGroupMembersRequest();
		request.SharedGroupId = this.LFG_SharedGroupId;
		request.PlayFabIds = new List<string>(this.playfabAdmin);
		
		PlayFabClientAPI.AddSharedGroupMembers(request, OnAddLFGroupAdminSuccess, OnPlayFabError);
	}
	
	void OnAddLFGroupAdminSuccess(AddSharedGroupMembersResult result)
	{
		RemoveSharedGroupMembersRequest request = new RemoveSharedGroupMembersRequest();
		request.SharedGroupId = this.LFG_SharedGroupId;
		request.PlayFabIds = new List<string>(this.zacsId);
		
		PlayFabClientAPI.RemoveSharedGroupMembers(request,OnRemoveZacSuccess, OnPlayFabError); 
	}
	
	
	
	void OnCreateIPGroupSuccess(CreateSharedGroupResult result)
	{
		
		AddSharedGroupMembersRequest request = new AddSharedGroupMembersRequest();
		request.SharedGroupId = this.IP_SharedGroupId;
		request.PlayFabIds = new List<string>(this.playfabAdmin);
		
		PlayFabClientAPI.AddSharedGroupMembers(request, OnAddIPGroupAdminSuccess, OnPlayFabError);
	}
	
	void OnAddIPGroupAdminSuccess(AddSharedGroupMembersResult result)
	{
		RemoveSharedGroupMembersRequest request = new RemoveSharedGroupMembersRequest();
		request.SharedGroupId = this.IP_SharedGroupId;
		request.PlayFabIds = new List<string>(this.zacsId);
		
		PlayFabClientAPI.RemoveSharedGroupMembers(request,OnRemoveZacSuccess, OnPlayFabError); 
	}
	
	void OnRemoveZacSuccess(RemoveSharedGroupMembersResult result)
	{
		Debug.Log("Zac removed from Queue");
	}
	#endregion
	
	
	// called when our GetUserData request has been answered successfully
	private void OnGetUserDataSuccess(GetUserDataResult result)
	{	
		// make sure we got the PlayerData object 
		if(result.Data.ContainsKey("Data-Example-Object"))
		{
			// deserialize kvp
			PlayerSaveData data = JsonReader.Deserialize<PlayerSaveData>(result.Data["Data-Example-Object"].Value);
			
			// for completeness output re-serialized object 
			Debug.Log (JsonWriter.Serialize(data));
		}
		else
		{
			//print error
			Debug.Log ("Key not found.");
		}
	}
	
	
	
	
	
}









#region helper classes
	public class PlayerSaveData
	{
		public string Location { get; set; }
		public float TimeLeft { get; set; }
		public bool ObjectiveComplete { get; set; } 
	}
	
	
	
	
	
	
	[System.Serializable]
	public class MyGames
	{
		public Dictionary<string, GameInfo> LFG = new Dictionary<string, GameInfo>();
		public Dictionary<string, GameInfo> IP = new Dictionary<string, GameInfo>();
	}
	
	[System.Serializable]	
	public class GameInfo
	{
		public string GUID { get; set; }
		public string gameState { get; set; }
		public Int64 startTime { get; set; }
		public string playerA { get; set; }
		public string playerB { get; set; }
	}
#endregion









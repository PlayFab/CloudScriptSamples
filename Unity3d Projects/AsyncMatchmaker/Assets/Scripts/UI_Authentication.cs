using System.Text.RegularExpressions;
using UnityEngine;
using System;
using System.Collections;
using PlayFab;
using PlayFab.Internal;
using PlayFab.ClientModels;
using PlayFab.Serialization.JsonFx;

public class UI_Authentication : UI_Base {
	public Rect loginPane;
	public Rect loggedInBar;
	public Rect registerPane;
	
	public bool isLoggedIn = false;
	public bool showRegistration = false;
		
	public Texture2D gUIBackground;
	public GUIContent userNameLabel;
	public GUIContent passwordLabel;
	public GUIContent[] providerLabels;
	
	private string userName = string.Empty;
	private string password = string.Empty;
	private string errorMessage = string.Empty;
	
	private int selectedLogin = 0;
	
	private string username = string.Empty;
	private string pass1 = string.Empty;
	private string pass2 = string.Empty;
	private string email = string.Empty;
	
	private UserAccountInfo loggedInUserInfo;
	
	// Use this for initialization
	public override void Start () 
	{
		PlayFabData.LoadData ();
		this.loggedInUserInfo = new UserAccountInfo();
		this.loginPane = new Rect(Screen.width /2 -125, Screen.height /2 - 75, this.loginPane.width, this.loginPane.height);
		base.Start();
		
		if(this.loggedInBar.width == 0)
			this.loggedInBar.width = Screen.width;
			
		if (this.isLoggedIn == true) 
		{
			PlayFabSettings.CurrentPlayerId = "FC5704B9075819E6";
			PlayFabSettings.CurrentUsername = "zac01";
			PlayFabClientAPI.AuthKey = PlayFabData.AuthKey;
			gameObject.GetComponent<AsyncMultiplayer>().OnLoginSuccess();			
		}
	}
	
	public override void OnGUI()
	{
		GUI.depth = this.zDepth;
		if(this.isLoggedIn == false)
		{
			if(this.showRegistration)
			{
				this.registerPane = GUI.Window(2, this.registerPane, DrawRegisterPane, "Create a new PlayFab account");
			}
			else
			{
				this.loginPane = GUI.Window(1, this.loginPane, DrawLoginPane, "Login Pane");
			}
		}
		else
		{
			DrawLoggedInBar();
		}

		base.OnGUI();
	} 
	
	public void DrawLoggedInBar()
	{
		GUI.BeginGroup(this.loggedInBar, "");
			if(GUI.Button(new Rect(Screen.width - 75, 0, 70, this.loggedInBar.height/2), "Log Out"))
			{
				LogOut();
			}
		GUI.EndGroup();
	}
	
	public void DrawLoginPane(int id)
	{

		switch(this.selectedLogin)
		{
			// playfab
		case 0:
			GUI.Label(new Rect(5,15, this.loginPane.width/2, 50), this.userNameLabel);
			GUI.Label(new Rect(5,55, this.loginPane.width/2, 50), this.passwordLabel);
			
			this.userName = GUI.TextField(new Rect(105,27, this.loginPane.width/2, 20), this.userName);
			this.password = GUI.PasswordField(new Rect(105,67, this.loginPane.width/2, 20), this.password,'*');
			
			if(GUI.Button(new Rect(this.loginPane.width-80, 95, 75, 25), new GUIContent("Sign In", null, "Sign in using your PlayFab account")) || (Event.current.keyCode == KeyCode.Return && Event.current.type == EventType.KeyUp))
			{
				this.errorMessage = string.Empty;
				LoginWithPlayfab(this.userName, this.password);
			}
			if(GUI.Button(new Rect(this.loginPane.width-80, 120, 75, 25), new GUIContent("Register", null, "Create a new PlayFab account")))
			{
				this.showRegistration = true;
			}
			
			GUI.Label(new Rect(10, 105, 200, 50), this.errorMessage);
			break;
		default:
			GUI.Label(new Rect(5,15, this.loginPane.width/2, 50), "<< Select a login to begin");
			break;
		}
		GUI.DragWindow(new Rect(0, 0, 10000, 10000));
	}
	
	public void DrawRegisterPane(int id)
	{
		GUI.Label(new Rect(5,20, this.loginPane.width/3, 25), "Username");
		GUI.Label(new Rect(5,40, this.loginPane.width/3, 25), "Password");
		GUI.Label(new Rect(5,60, this.loginPane.width/3, 25), "Password");
		GUI.Label(new Rect(5,80, this.loginPane.width/3, 25), "Email");
		
		username = GUI.TextField(new Rect(this.loginPane.width/4, 20, this.loginPane.width/2, 20), username);
		pass1 = GUI.PasswordField(new Rect(this.loginPane.width/4, 40, this.loginPane.width/2, 20), pass1, '*');
		pass2 = GUI.PasswordField(new Rect(this.loginPane.width/4, 60, this.loginPane.width/2, 20), pass2, '*');
		email = GUI.TextField(new Rect(this.loginPane.width/4, 80, this.loginPane.width/2, 20), email);
		
		if(GUI.Button(new Rect(this.loginPane.width-55, 120, 50, 25), new GUIContent("Create", null, "Sign in using your PlayFab account")) || (Event.current.keyCode == KeyCode.Return && Event.current.type == EventType.KeyUp))
		{
			this.errorMessage = string.Empty;
			RegisterNewPlayfabAccount();
		}
		if(GUI.Button(new Rect(this.loginPane.width-55, 20, 50, 25), new GUIContent("Back", null, "Create a new PlayFab account")))
		{
			this.showRegistration = false;
		}
		
		GUI.Label(new Rect(10, 105, 210, 50), this.errorMessage);
		
		GUI.DragWindow(new Rect(0, 0, 10000, 10000));
	}
	
	
	private void RegisterNewPlayfabAccount()
	{
		Debug.Log(PlayFabData.TitleId);
		if(this.username.Length == 0 || this.pass1.Length == 0 || this.pass2.Length ==0 || this.email.Length == 0)
		{
			this.errorMessage = "All fields are required.";
			return;
		}
		
		bool passwordCheck = ValidatePassword(this.pass1, this.pass2);
		bool emailCheck = ValidateEmail(this.email);
		
		if(!passwordCheck)
		{
			this.errorMessage = "Passwords must match and be longer than 5 characters.";
			return;
		
		}
		else if(!emailCheck)
		{
			this.errorMessage = "Invalid Email format.";
			return;
		}
		else
		{
			RegisterPlayFabUserRequest request = new RegisterPlayFabUserRequest();
			request.TitleId = PlayFabData.TitleId;
			request.Username = this.username;
			request.Email = this.email;
			request.Password = this.pass1;
			
			PlayFabClientAPI.RegisterPlayFabUser(request,OnRegisterResult,OnRegisterError);
		}
	}
	
	// meet all requirments of RFCs 5321 & 5322
	const string pattern = @"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,17})$";
	private bool ValidateEmail(string em){
		return Regex.IsMatch(em, pattern);
	}
	
	private bool ValidatePassword(string p1, string p2){
		return ((p1 == p2) && p1.Length > 5); 
	}
	
	
	public void OnRegisterResult(RegisterPlayFabUserResult result){
		
		this.errorMessage = "Playfab account created! You may now log in with " + result.Username;
		this.showRegistration = false;
	}
	
	void OnRegisterError(PlayFabError error)
	{
		//returnedError = true;
		Debug.Log ("Got an error: " + error.Error);
		if ((error.Error == PlayFabErrorCode.InvalidParams && error.ErrorDetails.ContainsKey("Password")) || (error.Error == PlayFabErrorCode.InvalidPassword))
		{
			this.errorMessage = "Invalid Password";
		}
		else if ((error.Error == PlayFabErrorCode.InvalidParams && error.ErrorDetails.ContainsKey("Username")) || (error.Error == PlayFabErrorCode.InvalidUsername))
		{
			this.errorMessage = " Invalid Username";
		}
		else if (error.Error == PlayFabErrorCode.EmailAddressNotAvailable)
		{
			this.errorMessage = "Email was unavailable. Perhaps this account is registered";
		}
		else if (error.Error == PlayFabErrorCode.UsernameNotAvailable)
		{
			this.errorMessage = "Username was unavailable. Perhaps this name is taken";
		}
	}
	
	private void LoginWithPlayfab(string user, string pass)
	{
		if(user.Length>0 && pass.Length>0)
		{
			Debug.Log(PlayFabData.TitleId);
			LoginWithPlayFabRequest request = new LoginWithPlayFabRequest();
			request.Username = user;
			request.Password = pass;
			request.TitleId = PlayFabData.TitleId;
			
			PlayFabSettings.CurrentUsername = request.Username.ToLower();
			PlayFabClientAPI.LoginWithPlayFab(request,OnLoginResult,OnPlayFabError);
		}
		else
		{
			this.errorMessage = "User Name and Password cannot be blank.";
		}
	}
	
	public void LogOut()
	{
		this.isLoggedIn = false;
		gameObject.GetComponent<AsyncMultiplayer>().OnLogoutSuccess();
	}
	
	// callback function if player login is successful
	public void OnLoginResult(LoginResult result){
		
		PlayFabData.AuthKey = PlayFabClientAPI.AuthKey;
		this.loggedInUserInfo.PlayFabId = result.PlayFabId;

		this.isLoggedIn = true;
		
		PlayFabSettings.CurrentPlayerId = result.PlayFabId;
		gameObject.GetComponent<AsyncMultiplayer>().OnLoginSuccess();
		
	}
	
	// callback function if there is an error -- display appropriate error message
	void OnPlayFabError(PlayFabError error)
	{
		Debug.Log ("Got an error: " + error.Error);
		if (error.Error == PlayFabErrorCode.InvalidParams && error.ErrorDetails.ContainsKey("Password"))
		{
			this.errorMessage = "Invalid Password";
		}
		else if (error.Error == PlayFabErrorCode.InvalidParams && error.ErrorDetails.ContainsKey("Username"))
		{
			this.errorMessage = "Invalid Username";
		}
		else if (error.Error == PlayFabErrorCode.AccountNotFound)
		{
			this.errorMessage = "Account Not Found";
		}
		else if (error.Error == PlayFabErrorCode.AccountBanned)
		{
			this.errorMessage = "Account Banned";
		}
		else if (error.Error == PlayFabErrorCode.InvalidUsernameOrPassword)
		{
			this.errorMessage = "Invalid Username or Password";
		}
		else
		{
			this.errorMessage = "Unknown Error";
		}
	}
}



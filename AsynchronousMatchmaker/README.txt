
Cloud Script Example (demo_async.js):
----------------------------------------------------------------------
	This file provides Cloud Script Examples with specific implementations for use with the Unity3d (4.6.3) Example Project.

Unity Example Project (Unity3d Example):
----------------------------------------------------------------------
	This project provides a complete asychronous game example using off the shelf PlayFab components to build a matchmaker.

	Notes:
		+ This example connects to a sample playfab title, you will need to register an account when starting the sample.

		+ This game is designed to have 2 players alternating turns. This can be done by building 1 client and running the second in the editor, or you can use a Web API testing tool (such as Postman, Curl or PowerShell) to make the proper calls to progress the game. 

		+ To get started, on the first client, log in and click Matchmake (this will try to join an open game in the lobby or create a new. The scecond client can then "View Lobbies" and join the game that corresponds to your first player. 

		+ The two major functioning files are:
			-- UI_Authentication.cs: a bare-bones, sample scipt that processes the logon / registration
			-- AsyncMultiplayer.cs: an all inclusive example script that contains all UI / API and control logic for this example.

Please let us know if you have any questions or find any issues @ devrel@playfab.com
-The PlayFab Team

var openGames = "Async_LFG_Queue"; // put new and partial games here
var fullGames = "Async_IP_Queue"; // put full and complete games here


// Initialize and add a new game with the requesting player to the openGames lobby
// Returns JoinGameResult back to Unity
handlers.CreateNewGame = function(args)
{
	var startTime = Date.now();
	var uuid = CreateGUID();

	var accountInfo = server.GetUserAccountInfo({"PlayFabId" : currentPlayerId});

	var gameDetails = {};
	gameDetails[uuid] = JSON.stringify({ 
		"playerA" : accountInfo.UserInfo,
		"playerA_HP" : 100,
		"playerA_moves" : [],
		"playerB" : "",
		"playerB_HP" : 100,
		"playerB_moves" : [],
		"gameState" : "NewGame",
		"startTime" : startTime,
		"endTime" : 0,
		"lastMoveTime" : 0,
		"winner" : ""
	});

	// note that game object is a string with JSON encoding this is noted in the documentation as "string => string" 
	server.UpdateSharedGroupData({"SharedGroupId": openGames,
	 	"Data": gameDetails
	});


	var userData = server.GetUserData({"PlayFabId" : currentPlayerId, "Keys" : ["ActiveGames"]});
	var activeGames = [];

	if(!isObjectEmpty(userData.Data))
	{
		if(!isObjectEmpty(userData.Data["ActiveGames"]))
		{
			activeGames = JSON.parse(userData.Data["ActiveGames"].Value);
		}
	}
	
	activeGames.push(uuid);

	server.UpdateUserData({"PlayFabId" : currentPlayerId, "Data" : { "ActiveGames" : JSON.stringify(activeGames) }, "Permission":"Public" });


	return {"GUID" : uuid, "gameState" : "NewGame" };
}

// Attempt to match the requesting player to an appropreate openGames lobby, create a new game if no suitible matches are found 
// Returns JoinGameResult back to Unity
handlers.Matchmake = function(args)
{
	var listOfOpenGames = server.GetSharedGroupData({"SharedGroupId": openGames});

	for (var key in listOfOpenGames.Data) 
	{
	  if (listOfOpenGames.Data.hasOwnProperty(key)) 
	  	{
		    var parsed = JSON.parse(listOfOpenGames.Data[key].Value); 

			// check to make sure not playing self && that the game is ready for a 2nd player
			if(currentPlayerId != parsed.playerA.PlayFabId && parsed.gameState == "NewGame")
			{
				//assign PlayerB to the game
				var accountInfo = server.GetUserAccountInfo({"PlayFabId" : currentPlayerId});
				parsed.playerB = accountInfo.UserInfo;
				parsed.gameState = "ActionOnPlayerA";

				// remove from open lobby because the game is now full
				var args = {};
				args.GUID = key;
				handlers.RemoveFrom_openGames(args);

				// move game to ip queue // check to make sure we do not assign a game to too many people
				var json = {};
				json[key] = JSON.stringify(parsed);
				server.UpdateSharedGroupData({"SharedGroupId" : fullGames, "Data" : json});



				var userData = server.GetUserData({"PlayFabId" : currentPlayerId, "Keys" : ["ActiveGames"]});
				var activeGames = [];

				if(!isObjectEmpty(userData.Data))
				{
					if(!isObjectEmpty(userData.Data["ActiveGames"]))
					{
						activeGames = JSON.parse(userData.Data["ActiveGames"].Value);
					}
				}
				
				activeGames.push(key);

				server.UpdateUserData({"PlayFabId" : currentPlayerId, "Data" : { "ActiveGames" : JSON.stringify(activeGames) }, "Permission":"Public" });

				return {"GUID" : key , "gameState" : parsed.gameState };
		  	}
	  	}
	}

	//if we make it this far then there were no suitable matches in the lfg queue, time to create a new game
	return handlers.CreateNewGame(args);
};

// Search the lobbies to find the requested game and return its details
// Expected Params args.GUID, the ID of the game to use  
// Returns the GameDetails object back to Unity
handlers.GetBattleData = function(args)
{
	if(!isObjectEmpty(args))
	{
		var json = {};
		json.Keys = typeof args.GUID !== 'undefined' ? args.GUID : null;

		if(json.Keys != null)
		{
			json.SharedGroupId = fullGames;
			var listOfFullGames = server.GetSharedGroupData(json);

			var gameFound = {};
				
			// if (listOfOpenGames.Data.hasOwnProperty(args.GUID)) 
			// {
			// 	var parsed = JSON.parse(listOfOpenGames.Data[args.GUID].Value);
			// 	return gameFound[args.GUID] = {"gameState" : parsed.gameState, "startTime" : parsed.startTime, "lastMoveTime" : parsed.lastMoveTime, "playerA" : parsed.playerA, "playerA_HP" : parsed.playerA_HP,	"playerA_moves" : parsed.playerA_moves, "playerB" : null , "playerB_HP" : parsed.playerB_HP,	"playerB_moves" : parsed.playerB_moves, "winner" : parsed.winner };
			// }
			//else 

			if(listOfFullGames.Data.hasOwnProperty(args.GUID))
			{
				var parsed = JSON.parse(listOfFullGames.Data[args.GUID].Value);
				return gameFound[args.GUID] = {"gameState" : parsed.gameState, "startTime" : parsed.startTime, "lastMoveTime" : parsed.lastMoveTime, "playerA" : parsed.playerA, "playerA_HP" : parsed.playerA_HP,	"playerA_moves" : parsed.playerA_moves, "playerB" : parsed.playerB, "playerB_HP" : parsed.playerB_HP,	"playerB_moves" : parsed.playerB_moves, "winner" : parsed.winner };
			}
			throw  args.GUID + " -- was not found.";
		}
	}
	else
	{

	}	
};

// Generate move values and update the game data to match
// Expected Params args.GUID, the ID of the game to use 
// Returns the GameDetails object back to Unity
handlers.ProcessMove = function(args)
{
	if(!isObjectEmpty(args))
	{
		var GUID = typeof args.GUID !== 'undefined' ? args.GUID : null;

		if(GUID != null)
		{
			var json = {};
			json.SharedGroupId = fullGames;
			json.Keys = [GUID];
			var listOfFullGames = server.GetSharedGroupData(json);
		  	
		  	if (listOfFullGames.Data.hasOwnProperty(GUID)) 
		  	{
				var parsed = JSON.parse(listOfFullGames.Data[GUID].Value); 
				parsed.lastMoveTime = Date.now();
				if(currentPlayerId === parsed.playerA.PlayFabId && parsed.gameState === "ActionOnPlayerA")
				{
					var attackValue = Math.floor((Math.random() * (35 - 20) + 20));
					parsed.playerA_moves.push(attackValue);
					parsed.gameState = "ActionOnPlayerB";

					json = {};
					json[GUID] = JSON.stringify(parsed);
					server.UpdateSharedGroupData({"SharedGroupId" : fullGames, "Data" : json});

					return parsed;
				}
				else if(currentPlayerId === parsed.playerB.PlayFabId && parsed.gameState === "ActionOnPlayerB")
				{
					var attackValue = Math.floor((Math.random() * (35 - 20) + 20));
					parsed.playerB_moves.push(attackValue);
					parsed.gameState = "ActionOnPlayerA";

					var battleResult = CalcHP(GUID, parsed);
					if(battleResult.gameState == "Archived")
					{
						handlers.RemoveFrom_fullGames(args);
					}
					else
					{
						json = {};
						json[GUID] = JSON.stringify(battleResult);
						server.UpdateSharedGroupData({"SharedGroupId" : fullGames, "Data" : json});
					}
					return parsed;
				}
				else
				{
					log.info(parsed.gameState);
					log.info(currentPlayerId);
					throw "game state mismatch: It is not your turn";
				}
			}
			else
			{
				throw "Game was not found in the IP queue.";
			}
		}
	}
	else
	{
		throw "Invalid args.GUID parameter.";
	}
};




//For testing random stuff...
handlers.TestReturnValue = function(args)
{
   	//var id = "65eb2674-cfad-441f-9a9f-0551eb7cfc75";
    //var details = {"playerA":{"PlayFabId":"C4B1CEE856CF3F54","Created":"2014-08-19T00:40:18.421Z","Username":"sdktestuser1","TitleInfo":{"DisplayName":"sdktestuser1","Created":"2015-02-02T04:50:42.66Z","LastLogin":"2015-02-16T00:25:45.93Z","FirstLogin":"2015-02-02T04:50:42.66Z"}},"playerA_HP":25,"playerA_moves":[23,23,22,19,15,20,14,17,14,19,12,20],"playerB":{"PlayFabId":"FC5704B9075819E6","Created":"2014-10-27T03:03:53.151Z","Username":"zac01","TitleInfo":{"DisplayName":"zac01","Created":"2015-02-02T04:46:14.158Z","LastLogin":"2015-02-16T06:14:27.521Z","FirstLogin":"2015-02-02T04:46:14.158Z"}},"playerB_HP":-15,"playerB_moves":[19,22,22,14,17,24,13,13,18,16,16,18],"gameState":"Archived","startTime":1424067242428,"endTime":1424067405274,"lastMoveTime":1424067405274,"winner":"Player A"};
	
	//var updated = ProcessGame(id, details);	
    //log.info(args.GUID);
};




// helper functions:
// ==============================================================================================

// Saves the game data to each user's GamesPlayed record
// Expected Params: 
	// GUID, the ID of the game to use  
	// gameDetails, the game record associated to the GUID 	
// Returns the updated gameDetails object
function ProcessGame(GUID, gameDetails)
{
	var gamesHistory = {"games" : []};
	var gameRecord = {};
		gameRecord["guid"] = "";
		gameRecord["details"] = {};
	gameDetails.endTime = Date.now();
	gameDetails.gameState = "Archived";


	var gamesPerPage = 50;
	var pageIndex = 1;
	var activeGames =[];
	var pageToFetch = "PreviousGames";

// player A
	var playerData = server.GetUserData({"PlayFabId" : gameDetails.playerA.PlayFabId, "Keys" : ["PreviousGamesPageCount"]});
	if(!isObjectEmpty(playerData.Data))
	{
		if(!isObjectEmpty(playerData.Data["PreviousGamesPageCount"]))
		{
			if(playerData.Data["PreviousGamesPageCount"].Value !== "1")
			{
				pageIndex = parseInt(playerData.Data["PreviousGamesPageCount"].Value);
				pageToFetch = pageToFetch+pageIndex;
			}
		}
	}	
	else
	{
		var initalRecord = {};
		initalRecord[pageToFetch] =  JSON.stringify(gamesHistory);
		initalRecord["PreviousGamesPageCount"] = ""+pageIndex;
		server.UpdateUserData({"PlayFabId" : gameDetails.playerA.PlayFabId, "Data" : initalRecord, "Permission":"Public" });
	}

	playerData = server.GetUserData({"PlayFabId" : gameDetails.playerA.PlayFabId, "Keys" : [pageToFetch, "ActiveGames"]});
	if(!isObjectEmpty(playerData.Data))
	{
		if(!isObjectEmpty(playerData.Data[pageToFetch]))
		{
			gamesHistory = JSON.parse(playerData.Data[pageToFetch].Value);
			gameRecord["guid"] = GUID;
			gameRecord["details"] = gameDetails;
			
			if(gamesHistory.games.length >= 15)
			{
				// create a new KVP
				pageIndex++;
				pageToFetch = pageToFetch+pageIndex;
				gamesHistory = {"games" : []};
				gamesHistory.games.push(gameRecord);
			}
			else
			{
				// push to current KVP
				gamesHistory.games.push(gameRecord);
			}

			if(!isObjectEmpty(playerData.Data["ActiveGames"]))
			{
				activeGames = JSON.parse(playerData.Data["ActiveGames"].Value);
				var index = activeGames.indexOf(GUID);
				
				if(index >= 0)
				{
					activeGames.splice(index,1);
				}	
			}

			var initalRecord = {};
			initalRecord[pageToFetch] =  JSON.stringify(gamesHistory);
			initalRecord["PreviousGamesPageCount"] = ""+pageIndex;
			initalRecord["ActiveGames"] = JSON.stringify(activeGames);
			server.UpdateUserData({"PlayFabId" : gameDetails.playerA.PlayFabId, "Data" : initalRecord, "Permission":"Public" });
			
		}
		else
		{
			throw "No historic data found for page: "  + pageToFetch;
		}
	}

	pageIndex = 1;
	activeGames =[];
	pageToFetch = "PreviousGames";
	
// player B
	var playerData = server.GetUserData({"PlayFabId" : gameDetails.playerB.PlayFabId, "Keys" : ["PreviousGamesPageCount"]});
	if(!isObjectEmpty(playerData.Data))
	{
		if(!isObjectEmpty(playerData.Data["PreviousGamesPageCount"]))
		{
			if(playerData.Data["PreviousGamesPageCount"].Value !== "1")
			{
				pageIndex = parseInt(playerData.Data["PreviousGamesPageCount"].Value);
				pageToFetch = pageToFetch+pageIndex;
			}
		}
	}	
	else
	{
		var initalRecord = {};
		initalRecord[pageToFetch] =  JSON.stringify(gamesHistory);
		initalRecord["PreviousGamesPageCount"] = ""+pageIndex;
		server.UpdateUserData({"PlayFabId" : gameDetails.playerB.PlayFabId, "Data" : initalRecord, "Permission":"Public" });
	}

	playerData = server.GetUserData({"PlayFabId" : gameDetails.playerB.PlayFabId, "Keys" : [pageToFetch, "ActiveGames"]});
	if(!isObjectEmpty(playerData.Data))
	{
		if(!isObjectEmpty(playerData.Data[pageToFetch]))
		{
			gamesHistory = JSON.parse(playerData.Data[pageToFetch].Value);
			gameRecord["guid"] = GUID;
			gameRecord["details"] = gameDetails;
			
			if(gamesHistory.games.length >= 50)
			{
				// create a new KVP
				pageIndex++;
				pageToFetch = pageToFetch+pageIndex;
				gamesHistory = {"games" : []};
				gamesHistory.games.push(gameRecord);
			}
			else
			{
				// push to current KVP
				gamesHistory.games.push(gameRecord);
			}

			if(!isObjectEmpty(playerData.Data["ActiveGames"]))
			{
				activeGames = JSON.parse(playerData.Data["ActiveGames"].Value);
				var index = activeGames.indexOf(GUID);
				
				if(index >= 0)
				{
					activeGames.splice(index,1);
				}	
			}

			var initalRecord = {};
			initalRecord[pageToFetch] =  JSON.stringify(gamesHistory);
			initalRecord["PreviousGamesPageCount"] = ""+pageIndex;
			initalRecord["ActiveGames"] = JSON.stringify(activeGames);
			server.UpdateUserData({"PlayFabId" : gameDetails.playerB.PlayFabId, "Data" : initalRecord, "Permission":"Public" });
			
		}
		else
		{
			throw "No historic data found for page: "  + pageToFetch ;
		}
	}



	// gamesHistory = {"games" : []};
	// gameRecord = {};
	// 	gameRecord["guid"] = "";
	// 	gameRecord["details"] = {};

	// playerData = server.GetUserData({"PlayFabId" : gameDetails.playerB.PlayFabId, "Keys" : ["PreviousGames", "ActiveGames"]});

	// if(!isObjectEmpty(playerData.Data))
	// {
	// 	if(!isObjectEmpty(playerData.Data["PreviousGames"]))
	// 	{
	// 		gamesHistory = JSON.parse(playerData.Data["PreviousGames"].Value);
	// 		gameRecord["guid"] = GUID;
	// 		gameRecord["details"] = gameDetails;
	// 		gamesHistory.games.push(gameRecord);
	// 		server.UpdateUserData({"PlayFabId" : gameDetails.playerB.PlayFabId, "Data" : { "PreviousGames" : JSON.stringify(gamesHistory) }, "Permission":"Public" });
	// 	}
	// 	else
	// 	{

	// 	}

	// 	if(!isObjectEmpty(playerData.Data["ActiveGames"]))
	// 	{
	// 		activeGames = JSON.parse(playerData.Data["ActiveGames"].Value);
	// 		log.info(activeGames);
	// 	}
	// }
	return gameDetails;
};



// Joins the calling player to the provided game id
// Expected Params: 
	// args.GUID, the ID of the game to use  
// Returns the JoinGameResult object
handlers.JoinGameById = function(args)
{
	if(!isObjectEmpty(args))
	{
		var gameData = server.GetSharedGroupData({"SharedGroupId": openGames, "Keys" : [args.GUID]});
	  	if (gameData.Data.hasOwnProperty(args.GUID)) 
	  	{
			var parsed = JSON.parse(gameData.Data[args.GUID].Value); 

			if(currentPlayerId != parsed.playerA.PlayFabId && parsed.gameState == "NewGame")
			{
				var accountInfo = server.GetUserAccountInfo({"PlayFabId" : currentPlayerId});
				parsed.playerB = accountInfo.UserInfo;
				parsed.gameState = "ActionOnPlayerA";

				// remove from LFG queue because the game is now full
				handlers.RemoveFrom_openGames(args);

				// move game to ip queue // check to make sure we do not assign a game to too many people
				var json = {};
				json[args.GUID] = JSON.stringify(parsed);
				server.UpdateSharedGroupData({"SharedGroupId" : fullGames, "Data" : json});

				var userData = server.GetUserData({"PlayFabId" : currentPlayerId, "Keys" : ["ActiveGames"]});
				var activeGames = [];

				if(!isObjectEmpty(userData.Data))
				{
					if(!isObjectEmpty(userData.Data["ActiveGames"]))
					{
						activeGames = JSON.parse(userData.Data["ActiveGames"].Value);
					}
				}
				
				activeGames.push(args.GUID);

				server.UpdateUserData({"PlayFabId" : currentPlayerId, "Data" : { "ActiveGames" : JSON.stringify(activeGames) }, "Permission":"Public" });



				return {"GUID" : args.GUID , "gameState" : parsed.gameState };
			}
			else
			{
				throw "Player is already a member of this game, or game was full";
			}
		}
		else
		{
			throw "Game was not found in the LFG queue.";
		}
	}
	else
	{
		throw "Invalid args.GUID parameter.";
	}
};


// Calculated the players HP after a round has been completed
// Expected Params: 
	// key, the ID of the game to use  
	// gameObject, the game record associated to the GUID 	
// Returns the updated gameDetails object
function CalcHP(key, gameObject)
{
	// some log
	var a_moves = gameObject.playerA_moves.length-1;
	var b_moves = gameObject.playerB_moves.length-1; 

	if(a_moves == b_moves)
	{
		if(gameObject.playerB_moves[b_moves] > gameObject.playerA_moves[a_moves])
		{
			// B wins
			gameObject.playerA_HP -= gameObject.playerB_moves[b_moves];
		}
		else if(gameObject.playerB_moves[b_moves] < gameObject.playerA_moves[a_moves])
		{
			// A wins
			gameObject.playerB_HP -= gameObject.playerA_moves[a_moves];
		}
		else
		{
			// Tie 
		}
	}
	else
	{
		var msg =  "Move list mismatch -- a:" + a_moves + " -- b:" + b_moves;
		throw msg;
	}

	if(gameObject.playerA_HP <= 0)
	{
		gameObject.winner = "Player B";
		gameObject.gameState = "Complete";
		gameObject = ProcessGame(key, gameObject);
	}
	else if(gameObject.playerB_HP <= 0)
	{
		gameObject.winner = "Player A";
		gameObject.gameState = "Complete";
		gameObject = ProcessGame(key, gameObject);
	}

	return gameObject;
}


// Created the shared groups that will be used (like lobbies) by the matchmaker
// this fuction is only called once when setting up a shared group
handlers.InitSharedGroups = function(args)
{
	var lfg_status, ip_status;
	try
	{
		lfg_status = server.CreateSharedGroup({"SharedGroupId" : openGames});	
	}
	catch(error)
	{
		log.error(error);
	}

	try
	{
		ip_status = server.CreateSharedGroup({"SharedGroupId" : fullGames});
	}
	catch(error)
	{
		log.error(error);
	}	
};


// Saves the game data to each user's GamesPlayed record
// Expected Params: 
	// GUID, the ID of the game to use  
	// gameDetails, the game record associated to the GUID 	
// Returns the historicWrapper object
handlers.GetAllGames = function(args)
{
	var activeGames = server.GetUserData({"PlayFabId" : currentPlayerId, "Keys" : ["ActiveGames"]});
	if(!isObjectEmpty(activeGames.Data["ActiveGames"]))
	{
		activeGames = JSON.parse(activeGames.Data["ActiveGames"].Value);
		var json = {};
		var lfg_resultSet = {};
		var ip_resultSet = {}; 
		json.Keys = [];

		json.SharedGroupId = openGames;
		lfg_resultSet = server.GetSharedGroupData(json);
	
		json.Keys = activeGames;
		json.SharedGroupId = fullGames;
		ip_resultSet = server.GetSharedGroupData(json);
	}

	var myLFG = {};
		for (var key in lfg_resultSet.Data) 
		{
		  if (lfg_resultSet.Data.hasOwnProperty(key)) 
		  	{
			    var parsed = JSON.parse(lfg_resultSet.Data[key].Value);
				myLFG[key] = {"gameState" : parsed.gameState, "startTime" : parsed.startTime, "lastMoveTime" : parsed.lastMoveTime, "playerA" : parsed.playerA.TitleInfo.DisplayName, "playerB" : "" };
			}
		}

	var myIP = {};
		for (var key in ip_resultSet.Data) 
		{
		  if (ip_resultSet.Data.hasOwnProperty(key)) 
		  	{
			    var parsed = JSON.parse(ip_resultSet.Data[key].Value);
				myIP[key] = {"gameState" : parsed.gameState, "startTime" : parsed.startTime, "lastMoveTime" : parsed.lastMoveTime, "playerA" : parsed.playerA.TitleInfo.DisplayName, "playerB" : parsed.playerB.Username };
			}
	 	}	

	var returnObj = {};
	returnObj.LFG = myLFG;
	returnObj.IP = myIP;
	return returnObj;
};

// this account keeps the group open, its also the only account that can view / read / write and add other members
// this fuction is only called once to add accounts to a newly shared group
handlers.AddAdminAccountToGroups = function(args)
{
	var adminId = "572C1AE46640D5C6"; // my 'admin' account you will need to enter your own.

	// LFG Queue
	try
	{
		var json = {};
		json.SharedGroupId = openGames;
		json.PlayfabIds = []; 
		json.PlayfabIds.push(adminId);
		server.AddSharedGroupMembers(json);
	}
	catch (error)
	{
		log.error(error);
	}

	// IP Queue
	try
	{
		var json = {};
		json.SharedGroupId = fullGames;
		json.PlayfabIds = []; 
		json.PlayfabIds.push(adminId);
		server.AddSharedGroupMembers(json);
	}
	catch (error)
	{
		log.error(error);
	}
};

//Return everything in both queues, would include all game info, use for debug only
handlers.GetSharedGroupData = function(args)
{
	var returnvalue = {};

	var ip_data, lfg_data;
	try
	{
		ip_data = server.GetSharedGroupData({"SharedGroupId" : fullGames, "GetMembers" : true});
		lfg_data = server.GetSharedGroupData({"SharedGroupId" : openGames, "GetMembers" : true});
	}
	catch(error)
	{
		log.info(error);
	}

	returnvalue["fullGames"] = ip_data;
	returnvalue["openGames"] = lfg_data;

	return returnvalue;
};

// Removes a game from the openGames lobby
// Expected Params: 
	// args.GUID, the ID of the game to use  	
// Returns null set on success
handlers.RemoveFrom_openGames = function (args)
{
	//log.info(args.GUID);
	var json = {};
	json[args.GUID] = null;

	var result = server.UpdateSharedGroupData({"SharedGroupId" : openGames, "Data" : json});
	return result;
};

// Removes a game from the fullGames lobby
// Expected Params: 
	// args.GUID, the ID of the game to use  	
// Returns null set on success
handlers.RemoveFrom_fullGames = function (args)
{
	var json = {};
	json[args.GUID] = null;

	var result = server.UpdateSharedGroupData({"SharedGroupId" : fullGames, "Data" : json});
	return result;
};



// checks to see if an object has any properties
// Returns true for empty objects and false for non-empty objects
function isObjectEmpty(obj)
{
	if(typeof obj === 'undefined')
	{
		return true;
	}

	if(Object.getOwnPropertyNames(obj).length === 0)
	{
		return true;
	}
	else
	{
		return false;
	}
}

// creates a standard GUID string
function CreateGUID()
{
	//http://stackoverflow.com/questions/105034/create-guid-uuid-in-javascript
	return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {var r = Math.random()*16|0,v=c=='x'?r:r&0x3|0x8;return v.toString(16);});
}



var LevelRewards =
[
	["TestItem1"],
	["TestItem2"],
	["TestItem3"],
	["TestItem1", "TestItem2"],
	["TestItem2", "TestItem2"],
	["TestItem3", "TestItem3"]
]

handlers.onLevelComplete = function(args)
{
	var levelNum = args.level;
	
	// Do some basic input validation
	if(levelNum < 0 || levelNum >= LevelRewards.length)
	{
		log.info("Invalid level "+levelNum+" completed by "+currentPlayerId);
		return {};
	}
	
	var levelCompleteKey = "LevelCompleted"+levelNum;
	
	// Get the user's internal data
	var playerInternalData = server.GetUserInternalData(
	{
		PlayFabId: currentPlayerId,
		Keys: [levelCompleteKey]
	});
	
	// Did they already complete this level?
	if(playerInternalData.Data[levelCompleteKey])
	{
		log.info("Player "+currentPlayerId+" already completed level "+levelNum);
		return {};
	}
	
	var rewards = LevelRewards[levelNum];
	
	var resultItems = null;
	if(rewards)
	{
		// Grant reward items to player for completing the level
		var itemGrantResult = server.GrantItemsToUser(
		{
			PlayFabId: currentPlayerId,
			Annotation: "Given by completing level "+levelNum,
			ItemIds: rewards
		});
		
		resultItems = itemGrantResult.ItemGrantResults;
	}
	
	// Mark the level as being completed so they can't get the reward again
	var saveData = {};
	saveData[levelCompleteKey] = "true";
	server.UpdateUserInternalData(
	{
		PlayFabId: currentPlayerId,
		Data: saveData
	});

	// Return the results of the item grant so the client can see what they got
	return {
		rewards: resultItems
	};
}

var monsterRewards =
{
	"skrill" : { "ChumpCoins" : 100},
	"lumpur" : { "ChumpCoins" : 200}
}

var killCoolDown = 60;

function currTimeSeconds()
{
	var now = new Date();
	return now.getTime() / 1000;
}

handlers.onMonsterKilled = function(args)
{
	var monsterType = args.type;
	
	var now = currTimeSeconds();
	
	// Get the user's internal data
	var playerInternalData = server.GetUserInternalData(
	{
		PlayFabId: currentPlayerId,
		Keys: ["lastKill"]
	});
	
	// Check when the last time they killed a monster was 
	var lastKill = playerInternalData.Data["lastKill"];
	if(lastKill)
	{
		// We have a value, see when it is
		var lastKillTime = parseInt(lastKill.Value);
		if(now - lastKillTime < killCoolDown)
		{
			// In this particular game, it should not be possible to kill a monster more often than once a minute, so they might be cheating
			log.info("Player "+currentPlayerId+" killed "+monsterType+" again too quickly!");
			return {};
		}
	}
	
	var killReward = monsterRewards[monsterType];
	
	if(killReward)
	{
		for(var currency in killReward)
		{
			var amount = killReward[currency];
			server.AddUserVirtualCurrency({ PlayFabId: currentPlayerId, VirtualCurrency: currency, Amount: amount });
		}
	}
	
	// Reset the kill timer
	server.UpdateUserInternalData(
	{
		PlayFabId: currentPlayerId,
		Data: {
			"lastKill" : String(now)
		}
	});
	
	return {
		rewards: killReward
	};
}

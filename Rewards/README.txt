Cloud Script Rewards Example (CloudScript_Rewards.js):
----------------------------------------------------------------------
	This file provides basic Cloud Script examples for two reward scenarios in games:
	
	1. Player completes a game level (onLevelComplete)
	2. Player kills a monster (onMonsterKilled)
	
	In each case, the player in rewarded with inventory items or virtual currency as a result. Please note that these items need to be created in your title's Catalog prior to testing, and that a shipping title should take advantage of the server-side authority that Cloud Script enables to make validation checks on the player actions (could the player have inflicted the damage necessary in the time since the last kill, etc.).
	
	For more information on using Cloud Script in PlayFab, please refer to this guide:
		https://playfab.com/cloud-script

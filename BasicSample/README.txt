Cloud Script Basic Sample (basic_sample.js):
----------------------------------------------------------------------
This file provides basic Cloud Script examples of:

  . helloWorld - Using the currentPlayerId (the logged-in user), output logging, and returning values
  . completedLevel - Updating user statistics and user internal data (data which cannot be read or written by the client)
  . updatePlayerMove, processPlayerMove - Calling a function from within Cloud Script, reading and updating user statistics, updating user internal data, basic server-side validation (checking that the reported value is within reason)
  . RoomCreated, RoomJoined, RoomLeft, RoomClosed, RoomEventRaised - Handlers for managing webhook calls from a Photon Cloud server (see this document for more information: https://playfab.com/using-photon-playfab)

For more information on using Cloud Script in PlayFab, please refer to this guide:
	https://playfab.com/cloud-script


/// Create a clan
handlers.CreateClan = function (args)
{
    var playfabId = args.playfabId;
    var clanNameId = args.clanNameId;
    var leaderName = args.leaderName;
  
    /// Look if user is already Leader/Member of a clan.
    var userInClan = LookIfUserIsInClan(playfabId);
  	if(userInClan)return ("User already in a clan");

    /// Create a Clan
    var serverData = server.CreateSharedGroup ({
        "SharedGroupId": clanNameId
    });  
    if (serverData.code != 200 )return("Clan already exist");
  
  
    /// Flag Leader of a Clan
    server.UpdateUserInternalData ({
        "PlayFabId ": playfabId,
        "Keys": [
          "ClanLeader" : true,
          "ClanMember" : false,
        ]
    });
  
    /// Make the Leader the only one to be able to edit the clan.
    server.AddSharedGroupMembers({
        "SharedGroupId": clanNameId,
        "PlayFabIds": [playfabId]
    });
  
    /// Make the Leader seen by everyone in the Clan.
    server.UpdateSharedGroupData ({
        "SharedGroupId": clanNameId,
        "Data": {
          "LeaderName": leaderName,
          "Leader": [playfabId],
          "Members": []
         },
     		 "Permission": "Public"
        });
  
    return("Clan created");
}



///  Add member to Clan
handlers.AddMemberToClan = function (args)
{
    var clanNameId = args.clanNameId;
    var playfabId = args.playfabId;
  	
  	/// Look if user is already Leader/Member of a clan.
    var userInClan = LookIfUserIsInClan(playfabId);
  	if(userInClan)return ("User already in a clan");
    
    /// Get all the members in the clan and look if user is already in the clan.
    var membersData = server.GetSharedGroupData ({
        "SharedGroupId": clanNameId,
        "Keys": [
            "Members"
        ]
    });
    var members = membersData.data.Data.Members;
  	if (members.indexOf(playfabId) > -1) {
        return("Already a member of this clan")
    } else {
        members.push(playfabId);
    }
  
    server.UpdateSharedGroupData({
        "SharedGroupId": clanNameId,
        "Data": {
          "Members": members;
         }
        });
  return("Member added");
}

///  Remove member from Clan
handlers.RemoveMemberFromClan = function (args)
{
    var clanNameId = args.clanNameId;
    var playfabId = args.playfabId;

   /// Get all the members in the clan and look if user is already in the clan.
    var membersData = server.GetSharedGroupData ({
        "SharedGroupId": clanNameId,
        "Keys": [
            "Members"
        ]
    });
  	/// Remove member of the clan.
    var members = membersData.data.Data.Members;
    var index = array.indexOf(playfabId); 
  	if (index > -1) {
        members.splice(index, 1);
    } else {
        return("Not member of this clan");
    }
  
    server.UpdateSharedGroupData({
        "SharedGroupId": clanNameId,
        "Data": {
          "Members": members;
         }
        });
  return("Member Removed");
}

function LookIfUserIsInClan(playfabId){
  var validateLeaderData = server.GetUserInternalData({
        "PlayFabId ": playfabId,
        "Keys": [
          "ClanLeader",
          "ClanMember"
        ]
    });
    if (validateLeaderData.data.Data.ClanLeader == true || validateLeaderData.data.Data.ClanMember == true  ){
      return(true);
    } else{
      return(false);
    }
}
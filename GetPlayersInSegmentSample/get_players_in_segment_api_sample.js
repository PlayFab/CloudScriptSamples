handlers.GetPlayersInSegmentSample = function (args, context) {

    /*
        Sample code to use GetPlayersInSegment API to process player profiles in a Segment.
        GetPlayersInSegment API pages through the all the player profiles
        in the Segment in batches of size 'MaxBatchSize'.
        API Doc: https://learn.microsoft.com/en-us/rest/api/playfab/server/play-stream/get-players-in-segment?view=playfab-rest
    */

    var request =  {
     MaxBatchSize: 1000,
     SegmentId: "AAAAAAAAA" // provide your SegmentId here
    }

    // make the first GetPlayersInSegment API call
    var playersInSegmentResult =  server.GetPlayersInSegment(request);
    
    // process until continuation token is not null to get all the profiles in this Segment
    while (playersInSegmentResult.ContinuationToken != null) 
    {
        // get the current batch of player profiles
        var playerProfiles = playersInSegmentResult.PlayerProfiles;

        // TODO: Add logic here to process the above playerProfiles

        // get the next batch of player profiles in the Segment
        request =  {
            ContinuationToken: playersInSegmentResult.ContinuationToken,
            MaxBatchSize: 1000,
            SegmentId: "AAAAAAAAA" // provide your SegmentId here
        }        
        playersInSegmentResult =  server.GetPlayersInSegment(request);
    }
};


handlers.GetSegmentPlayerCountSample = function (args, context) {

    /*
        Sample code to use GetPlayersInSegment API to get the number of players in a Segment
        API Doc: https://learn.microsoft.com/en-us/rest/api/playfab/server/play-stream/get-players-in-segment?view=playfab-rest
    */

    var request =  {
     MaxBatchSize: 1,
     SegmentId: "AAAAAAAAA" // provide your SegmentId here
    }

    // make the GetPlayersInSegment API call
    var playersInSegmentResult =  server.GetPlayersInSegment(request);

    var playerCount = playersInSegmentResult.ProfilesInSegment;

    // TODO: Add logic to process the playerCount

};

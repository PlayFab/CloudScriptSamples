Cloud Script Samples README
========
1. Overview:
----
This repository contains several examples on how to use Cloud Script. 


2. Prerequisites:
----
To get the most from these samples you should be very familiar with PlayFab's Cloud Script service. Check out our Cloud Script [getting started guide](https://playfab.com/cloud-script-guide).


3. Source Code & Key Repository Components:
----
* AsynchronousMatchmaker --  a raw Unity3d (v4.6.3) project showing how a trun-based, asychonous matchmaker can be built with Cloud Script.
* Rewards/CloudScript_Rewards.js -- Cloud Script file illustrating simple methods that read and write to a player's internal data as well as grant inventory items 


4. Installation & Configuration Instructions:
----
* AsynchronousMatchmaker --  Open with Unity3d, Build to PC / Mac / Web.
* Rewards/CloudScript_Rewards.js -- Upload to a PlayFab title via the game manager > servers > cloud scripts. After uploading, you will see the uploaded code in the central pane within the webpage. 

5. Usage Instructions:
----
* AsynchronousMatchmaker --  Accompanying [blog post](https://www.playfab.com/blog/2015/03/24/creating-turn-based-asynchronous-matchmaker-without-dedicated-server) gives a good overview for learning the major game components.  
* Rewards/CloudScript_Rewards.js -- As with any Cloud Script file, you can trigger any handlers._____ method from [GetCloudScript](https://api.playfab.com/Documentation/Client/method/GetCloudScriptUrl).


6. Troubleshooting:
----
For a complete list of available APIs, check out the [online documentation](http://api.playfab.com/Documentation/).

#### Contact Us
We love to hear from our developer community! 
Do you have ideas on how we can make our products and services better? 

Our Developer Success Team can assist with answering any questions as well as process any feedback you have about PlayFab services.

[Forums, Support and Knowlage Base](https://support.playfab.com/support/home)


7. Copyright and Licensing Information:
----
  Apache License -- 
  Version 2.0, January 2004
  http://www.apache.org/licenses/

  Full details available within the LICENSE file.


8. Version History:
----
* (v1.00) Initial Release
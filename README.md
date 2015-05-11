Cloud Script Samples README
========
1. Overview:
----
This repository contains several examples on how to use Cloud Script in PlayFab.


2. Prerequisites:
----
To get the most from these samples you should be very familiar with PlayFab's Cloud Script service. Check out our Cloud Script [getting started guide](https://playfab.com/cloud-script-guide).

To connect to the PlayFab service, your machine must be running TLS v1.1 or better.
* For Windows, this means Windows 7 and above
* [Official Microsoft Documentation](https://msdn.microsoft.com/en-us/library/windows/desktop/aa380516%28v=vs.85%29.aspx)
* [Support for SSL/TLS protocols on Windows](http://blogs.msdn.com/b/kaushal/archive/2011/10/02/support-for-ssl-tls-protocols-on-windows.aspx)

3. Source Code & Key Repository Components:
----
* AsynchronousMatchmaker --  a raw Unity3d (v4.6.3) project showing how a trun-based, asychonous matchmaker can be built with Cloud Script.
* Rewards/CloudScript_Rewards.js -- Cloud Script file illustrating simple methods that read and write to a player's internal data as well as grant inventory items 


4. Installation & Configuration Instructions:
----
* AsynchronousMatchmaker --  Open with Unity3d, Build to PC / Mac / Web.
* Rewards/CloudScript_Rewards.js -- Upload it to your title via the PlayFab Game Manager by going to Servers > Cloud Scripts.
* BasicSample/basic_sample.js -- This is the default Cloud Script which all new titles created in PlayFab will have as Version 1, Revision 1 upon creation. If you would like to update a version with this script as a new revision, simply upload it to your title via the PlayFab Game Manager by going to Servers > Cloud Scripts.
* Photon-Cloud-Integration -- This is a pointer to our repro showing the full [Photon Cloud sample for PlayFab](https://github.com/PlayFab/Photon-Cloud-Integration).

5. Usage Instructions:
----
* AsynchronousMatchmaker --  Accompanying [blog post](https://www.playfab.com/blog/2015/03/24/creating-turn-based-asynchronous-matchmaker-without-dedicated-server) gives a good overview for learning the major game components.  
* Rewards/CloudScript_Rewards.js -- As with any Cloud Script file, you can trigger any handlers._____ method from [RunCloudScript](https://api.playfab.com/Documentation/Client/method/RunCloudScript). Note that you must first establish the correct URL for your Cloud Script via a call to [GetCloudScriptUrl](https://api.playfab.com/Documentation/Client/method/GetCloudScriptUrl).
* BasicSample/basic_sample.js -- As with any Cloud Script file, you can trigger any handlers._____ method from [RunCloudScript](https://api.playfab.com/Documentation/Client/method/RunCloudScript). Note that you must first establish the correct URL for your Cloud Script via a call to [GetCloudScriptUrl](https://api.playfab.com/Documentation/Client/method/GetCloudScriptUrl).
* Photon-Cloud-Integration -- Please see the [Photon Cloud sample for PlayFab](https://github.com/PlayFab/Photon-Cloud-Integration).

6. Troubleshooting:
----
For a complete list of available APIs, check out the [online documentation](http://api.playfab.com/Documentation/).

#### Contact Us
We love to hear from our developer community! 
Do you have ideas on how we can make our products and services better? 

Our Developer Success Team can assist with answering any questions as well as process any feedback you have about PlayFab services.

[Forums, Support and Knowledge Base](https://support.playfab.com/support/home)


7. Copyright and Licensing Information:
----
  Apache License -- 
  Version 2.0, January 2004
  http://www.apache.org/licenses/

  Full details available within the LICENSE file.


8. Version History:
----
* (v1.00) Initial Release

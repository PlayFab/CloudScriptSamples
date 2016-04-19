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
* BasicSample/basic_sample.js -- This is the default Cloud Script which is automatically created as revision 1 for all new titles, demonstrating basics of using Cloud Script including Photon webhook integration.
* Rewards/CloudScript_Rewards.js -- A Cloud Script file illustrating simple methods that read and write to a player's internal data as well as grant inventory items.


4. Installation & Configuration Instructions:
----
* Rewards/CloudScript_Rewards.js -- Upload it to your title via the PlayFab Game Manager by going to Servers > Cloud Script.
* BasicSample/basic_sample.js -- Upload it to your title via the PlayFab Game Manager by going to Servers > Cloud Script.
* Photon-Cloud-Integration -- This is a pointer to our repro showing the full [Photon Cloud sample for PlayFab](https://github.com/PlayFab/Photon-Cloud-Integration).

5. Usage Instructions:
----
* Rewards/CloudScript_Rewards.js -- As with any Cloud Script file, you can trigger any handlers._____ method from [RunCloudScript](https://api.playfab.com/Documentation/Client/method/RunCloudScript). Note that you must first establish the correct URL for your Cloud Script via a call to [GetCloudScriptUrl](https://api.playfab.com/Documentation/Client/method/GetCloudScriptUrl).
* BasicSample/basic_sample.js -- As with any Cloud Script file, you can trigger any handlers._____ method from [RunCloudScript](https://api.playfab.com/Documentation/Client/method/RunCloudScript). Note that you must first establish the correct URL for your Cloud Script via a call to [GetCloudScriptUrl](https://api.playfab.com/Documentation/Client/method/GetCloudScriptUrl).
* Photon-Cloud-Integration -- Please see the [Photon Cloud sample for PlayFab](https://github.com/PlayFab/Photon-Cloud-Integration).

6. Troubleshooting:
----
For a complete list of available APIs, check out the [online documentation](http://api.playfab.com/).

#### Contact Us
We love to hear from our developer community! 
Do you have ideas on how we can make our products and services better? 

Our Developer Success Team can assist with answering any questions as well as process any feedback you have about PlayFab services.

[Forums, Support and Knowledge Base](https://community.playfab.com/)


7. Copyright and Licensing Information:
----
  Apache License -- 
  Version 2.0, January 2004
  http://www.apache.org/licenses/

  Full details available within the LICENSE file.


8. Version History:
----
* (v1.00) Initial Release
* (v1.10) Updated for latest changes to examples
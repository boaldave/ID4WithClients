Authorization Flows
===================

They are called Authorization Flows, but have been used primarily for Authentication, the assumption being if an Authorization Flow authorizes a User to do something, they must be Authenticated.

Client (App) Credentials Flow
-----------------------------

This flow is intended for Client Applications where User's are not authenticated. This flow is intended only to confirm a Client Application has valid credentials. One set of Client Application Credentials serve all users.  If the credentials for a Client Application are compromised, all users are locked out of the Client Application.

This flow will not be considered in this demonstration.   

Resource Owner Password Credential Flow
---------------------------------------

This flow is intended for a situation where Client Application Credentials are unlikely to be compromised. One such sitation is where an organization runs an IdentityServer and the Client Application behind the same firewall on a private network. 

This is not the kind of security you would want to run on a public network. If a hacker was able to get access to the Client Application Credentials, they could create a bogus Client Application, for example in an App Store, and trick a valid User into installing the Client Application, logging in, then access all systems the user has access to, without the user's knowledge. 

This flow will be considered in this demonstration for ASP.Net WebForms UserProfile and ASP.Net MVC UserProfile Client Applications because both application's can ensure the security of the prvate network connecting the IdentityServer4 and the Client Applications. Even if the Client Credentials were comprmised, the Client Applications are running on Machines that are validated by MAC Address. No foreign Client Applications could access the IdentityServer on behalf of the real Client Application.

Implicit Flow
-------------

This flow is intended for JavaScript Client Applications which operate over public networks.

How it works
^^^^^^^^^^^^
The Flow operates over any Web Browser. 

Hybrid Authentication Flow
--------------------------

This flow is intended for Native Mobile Client Applications which operate over public networks.

How it works
^^^^^^^^^^^^

The Flow operates over a mobile device's native Web Browser. 

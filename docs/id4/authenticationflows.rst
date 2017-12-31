Authorization Flows
===================

Overview
--------

The specific the request/response exchange associated with these flows will be discussed in more detail, in the code implmentation sections. This section provides a high level discussion. Here are links to the code sections:

* :ref:`User Profile NG <refuserprofileng>`
* :ref:`User Profile Xamarin <refuserprofilexamarin>`
* :ref:`User Profile WebForms <refuserprofileaspwebforms>`
* :ref:`User Profile MVC <refuserprofileaspmvc>`
* :ref:`User Profile WebApi <refuserprofilewebapi>`

Authorization Flows have been used historically implicitly for Authentication, the assumption being if an Authorization Flow authorizes a User to do something, they must be Authenticated.

A flow usually starts with an Unauthenticated User asking a UI Application for a protected UI resource, and the UI checking to see if the User is Authorized, and if not routing the User to a login page. Once the User's credentials are authenticated, the UI Application receives an AccessToken from ID4, the UI validates it, then grants access to the UI Resource. The UI may also pass that AccessToken to a WebAPI Resource, who also validates it, then grants access to the WebApi Resource.

You might wonder how the validation is accomplished. When a User succesfully logs into ID4, ID4 creates and returns an AccessToken that contains Claims, which can be statements about the User, the UI Application, and/or the WebApi Application. The UI and the WebApi Applications, can query the AccessToken Claims to decide if the AccessToken is valid.

You can start to see a system that needs to contain, in addition to Users,  several other data points:

* User Claims
* UI (Client) Application Claims
* WebApi Resource Application Claims

Each time the User requests either a UI or WebApi Resource, those applications may decide to check to see if the User has logged off and/or if the AccessToken has expired, or needs to be refreshed because it is about to expire. AccessTokens need to be "destroyed". You can now see how you might need further data points like:

* AccessToken Grant History with live and expired AccessToken data

Client (App) Credentials Flow
-----------------------------

**This flow will NOT be considered in this demonstration.**  

This flow is intended for Client Applications where User's are not authenticated. This flow is intended only to confirm a Client Application has valid credentials. One set of Client Application Credentials serve all users.  If the credentials for a Client Application are compromised, all users are locked out of the Client Application.

Resource Owner Password Credential Flow
---------------------------------------

**This flow will be considered for the ASP.Net WebForms UserProfile.**

This flow is intended for a situation where Client Application Credentials are unlikely to be compromised. One such sitation is where an organization runs an IdentityServer and the Client Application behind the same firewall on a private network. 

This is not the kind of security you would want to run on a public network. If a hacker was able to get access to the Client Application Credentials, they could create a bogus Client Application, for example in an App Store, and trick a valid User into installing the Client Application, logging in, then access all systems the user has access to, without the user's knowledge. 

This flow will be considered in this demonstration for ASP.Net WebForms UserProfile and ASP.Net MVC UserProfile Client Applications because both application's can ensure the security of the prvate network connecting the IdentityServer4 and the Client Applications. Even if the Client Credentials were comprmised, the Client Applications are running on Machines that are validated by MAC Address. No foreign Client Applications could access the IdentityServer on behalf of the real Client Application.

Implicit Flow
-------------

**This flow will be considered for the Angular.io UserProfile Application.**

This flow is intended for JavaScript Client Applications which operate over public networks running on any Web Browser.

Hybrid Authentication Flow
--------------------------

**This flow will be considered for the Xamarin UserProfile Application.**

This flow is intended for Native Mobile Client Applications which operate over public networks on a mobile device's native Web Browser. 

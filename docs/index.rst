Welcome to CodeQwik's IdentityServer4 Adventures
================================================

IdentityServer4 (ID4) is an OpenID Connect and OAuth 2.0 framework for ASP.NET Core...the docs are `here. <https://identityserver4.readthedocs.io/en/release>`_

The purpose of this site is to demonstrate how to implement both server-side and client-side ID4 Authentication, in several Client Applications, using various UI technologies. Hopefully this site will help other organizations extend their knowledge of Authentication using ID4.

**PLEASE USE ANY AND ALL INFORMATION ON THIS SITE AT YOUR OWN RISK. NO SECURITY AUDITS HAVE BEEN PERFORMED, AND AT THIS VERY MOMENT, THIS DOCUMENT IS PROBABLY IN DRAFT FORM. WE INVITE YOU TO SUGGEST CORRECTIONS AS SOON AS WE GET OUR BLOG RUNNING AGAIN AT www.codeqwik.net.**

The applications built will include the following:

======================================== ================
Application                              Technology
======================================== ================
Custom Implementation of IdentityServer4 Asp.Net Core 2.0
Login UI and User Manager                Angular         
User Profile UI                          Angular         
User Profile UI                          ASP.Net MVC Core
User Profile UI                          ASP.Net WebForms
User Profile Web Service                 ASP.Net Core    
======================================== ================

The applications built will demonstrate the following ID4 Features:

Authentication as a Service
---------------------------
Centralized login logic and varying workflow for the following types of applications: Web UI (Angular.io, ASP.Net MVC, ASP.Net WebForms), Native Mobile (Xamarin), Web Services (ASP.Net Core).

Both Independent and Single Sign-on / Sign-out
----------------------------------------------
Independent sign-on (and out) is when you login to A Browser app, and also have to login to a Xamarin Mobile App app even if you run them at the same time with the same user. Single sign-on (and out) allows you to login (and out) once over multiple application types. You sign-in to one, and you are signed in to them all.

Access Control for APIs by Client Application
---------------------------------------------
Issue access tokens for APIs for various types of clients, e.g. server to server, web applications, SPAs and native/mobile apps.

Federation Gateway
------------------
Support for external identity providers like Azure Active Directory, Google, Facebook etc. This shields your applications from the details of how to connect to these external providers.

.. toctree::
   :maxdepth: 4
   :hidden:
   :caption: ID4 Implementation

   id4/overview
   id4/LOH
   id4/authenticationflows
   id4/external_authentication
   id4/interactive_login
   id4/apiaccess
   id4/ID4ConfigurationSettings

.. toctree::
   :maxdepth: 5
   :hidden:
   :caption: IdentityServer4 Database 

   Database Diagram <id4/ID4Database/DatabaseDiagramID4>
   Database Gen Script <id4/ID4Database/DatabaseGenScriptID4>
   Static Data <id4/ID4Database/StaticDataID4>

.. toctree::
   :maxdepth: 5
   :hidden:
   :caption: ASPNetIdentity Database

   Database Diagram <id4/ASPNetIdentityDatabase/DatabaseDiagramAspNetIdentity>
   Database Gen Script <id4/ASPNetIdentityDatabase/DatabaseGenScriptAspNetIdentity>
   Static Data <id4/ASPNetIdentityDatabase/StaticDataAspNetIdentity>
 
.. toctree::
   :maxdepth: 2
   :hidden:
   :caption: Login UI

   login/index

.. toctree::
   :maxdepth: 2
   :hidden:
   :caption: User Manager

   usermanager/LOH
   usermanager/index

.. toctree::
   :maxdepth: 5
   :hidden:
   :caption: User Profile UI

   userprofile/index
 
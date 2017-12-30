ID4 Implementation Overview
===========================
Since this project is intended to demonstrate 3rd Party Authentication,ID4 simply needs to be configured to Authenticate Client Applications and Users of Client Applications.

Authentication Flow by UI Technology
------------------------------------

Each of the Client Application Technologies require their own Authentication Flows to enable OpenID Connect security compliance. Here is what we have implemented:

================ ================= =================
UI Application   Technology        Auth Flow        
================ ================= =================
Login UI         Angular           Client Credential
User Manager     Angular           Client Credential
User Profile UI  Angular           Client Credential
User Profile UI  ASP.Net MVC Core  Resource Owner   
User Profile UI  ASP.Net WebForms  Resource Owner   
User Profile UI  Xamarin           Hybrid Auth Code 
================ ================= =================


Auth Flow Configuration via ID4 Database Customization
------------------------------------------------------

The ID4 QuickStart applications show you how to configure Authentication Flow by Client Application via the ASP.Net Core Startup.cs class. The other way to configure Authentication Flow for each of your Client Applications is via ID4 Database Customization (see :ref: refID4DatabaseCustomizations).


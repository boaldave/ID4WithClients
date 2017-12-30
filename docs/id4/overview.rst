ID4 Implementation Overview
===========================
This project is intended to demonstrate a single implementation of ID4 Authentication for several Client Applications. ID4 will be configured to authenticate the same User Credentials across all Client Applications.

Authentication Flow by UI Technology
------------------------------------

Each of the Client Application technologies require specific Authentication Flows to ensure security resilience. Here is what has been implemented:

================ ================= ================= ======
UI Application   Technology        Auth Flow         Spec
================ ================= ================= ======
Login UI         Angular           Implicit Flow     OpenID
User Manager     Angular           Implicit Flow     OpenID
User Profile UI  Angular           Implicit Flow     OpenID
User Profile UI  ASP.Net MVC Core  Resource Owner    OAuth2
User Profile UI  ASP.Net WebForms  Resource Owner    OAuth2
User Profile UI  Xamarin           Hybrid Auth Code  OpenID
================ ================= ================= ======

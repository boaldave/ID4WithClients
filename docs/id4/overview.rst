ID4 Implementation Overview
===========================
This project is intended to demonstrate 3rd Party Authentication, so ID4 will be configured to Authenticate Client Applications and Users of Client Applications.

Authentication Flow by UI Technology
------------------------------------

Each of the Client Application Technologies require their own Authentication Flows to enable OpenID Connect security compliance. Here is what has been implemented:

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

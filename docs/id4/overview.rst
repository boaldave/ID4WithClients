IdentityServer4 Implementation Overview
=======================================
Since this project is intended to handle only Authentication, ID4 simply needs to be configured to Authenticate Client Applications and Users of Client Applications.

Each of the Client Applications have their own Authentication Flows and require different configurations as follows:


Client Application Authentication Flow by Technology
----------------------------------------------------

Angular.io:
^^^^^^^^^^^
Login UI 
Manage Users UI
User Profile Profile 

ASP.Net MVC:
^^^^^^^^^^^^
User Profile Profile 

ASP.Net WebForms:
^^^^^^^^^^^^^^^^^
User Profile Profile 

ASP.Net Core WebApi:
^^^^^^^^^^^^^^^^^^^^
User Profile Web Service


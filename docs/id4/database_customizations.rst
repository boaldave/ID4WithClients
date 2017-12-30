.. _refID4DatabaseCustomizations:
ID4 Database Customizations
===========================
ID4 configuration settings can be hard-coded in the ASP.Net Core startup.cs file, or can be set in database tables. 

ID4 needs data for Functional Setting and for Users (if Users are not stored at an External Identity Provider). There are 2 databases required:
- IdentityServer4 - Functional Settings and Tokens Granted
- ASPNetIdentity - Users and User Settings 

Connection Strings - appsettings.json
-------------------------------------
 .. code-block:: json

    "ConnectionStrings": {
        "IdentityServerConnection": 
        "Server=ABCServer;Database=IdentityServer4;User id=SomeUser;
            Password=p@ssw0rd;MultipleActiveResultSets=true",

        "AspNetIdentityConnection": 
        "Server=ABCServer;Database=AspNetIdentity; User id=SomeUser;
            Password=p@ssw0rd;MultipleActiveResultSets=true"
    },

Database Objects:
-----------------
IdentityServer4 
^^^^^^^^^^^^^^^
:ref:`IdentityServer4 Database Diagram <refDatabaseDiagramID4>`

:ref:`Generate Script<refDatabaseGenScriptID4>`

ASPNetIdentity 
^^^^^^^^^^^^^^
:ref:`ASPNetIdentity Database Diagram <refDatabaseDiagramAspNetIdentity>`

:ref:`Generate Script<refDatabaseGenScriptAspNetIdentity>`

Data Initialization Scripts:
----------------------------
IdentityServer4
^^^^^^^^^^^^^^^
The linked scripts below set configurations to support the Authorization Flows for the various client applications considered in this project and  establish claims for users. Please note we developed a separate Authorization Service and are not using ID4 for Authorization, only Authentication.

**ClientApp Related Tables:**

:ref:`ID4 Static Data - ClientApp Tables <refStaticDataID4ClientAppTables>`

**ApiResources Related Tables:**

:ref:`ID4 Static Data - ClientApp Tables <refStaticDataID4ClientAppTables>`

**IdentityResources and Claim Related Tables:**

There is no configuration data at this time.

**PersistedGrant Table:**

There are no configuration records in the Persisted Grant table. These represent the tokens created.

ASPNetIdentity
^^^^^^^^^^^^^^
There are no configuration scripts for Users, this was a deliberate decision. We decided to start with no users in ID4, forcing users to register their existing username (''Register User'' is discussed later), but we could have imported all of our existing users from our WebForms FormsAuth Authentication system.  The catch, however, is there is no way to transfer passwords, users have to reset their password (''Password Reset'' is discussed later). When you force users to register their Username, they can use their existing password in the prior Authentication system.


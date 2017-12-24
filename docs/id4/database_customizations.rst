IdentityServer4 Database Customizations
=======================================
ID4 configuration settings can be hard-coded in the ASP.Net Core startup.cs file, or can be set in database tables. 

ID4 needs data for Functional Setting and for Users (if Users are not stored at an External Identity Provider). There are 2 databases required:
- IdentityServer4 - Functional Settings and Tokens Granted
- ASPNetIdentity - Users and User Settings 

Connection Strings - appsettings.json
-------------------------------------
    "ConnectionStrings": {
        "IdentityServerConnection": "Server=ABCServer;Database=IdentityServer4;User id=SomeUser;Password=p@ssw0rd;MultipleActiveResultSets=true",

        "AspNetIdentityConnection": "Server=ABCServer;Database=AspNetIdentity; User id=SomeUser;Password=p@ssw0rd;MultipleActiveResultSets=true"
    },

Database Objects:
---------------------------------
**IdentityServer4** 
:ref:`IdentityServer4 Database Diagram <refDatabaseDiagramID4>`
:ref:` - Generate Script<refDatabaseGenScriptID4>`

**ASPNetIdentity** 
:ref:`ASPNetIdentity Database Diagram <refDatabaseDiagramASPNetIdentity>`
:ref:` - Generate Script<refDatabaseGenScriptASPNetIdentity>`



ASPNetIdentity Database Objects:
--------------------------------



Database Data Initialization Scripts:
-------------------------------------
*IdentityServer4
The scripts below set configurations to support the Authorization Flows for the various client applications considered in this project and  establish claims for users. Please note we developed a separate Authorization Service and are not using ID4 for Authorization, only Authentication.

Client App Related Tables:

IdentityResources Related Tables:

Api Resources Related Tables:

Persisted Grant Table:

There are no configuration records in the Persisted Grant table. These represent the tokens created.
*ASPNetIdentity

Database Object Initialization Scripts:
-------------------------------------
*IdentityServer4
*ASPNetIdentity


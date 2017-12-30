ID4 Configuration Settings
==========================

Asp.Net Identity
----------------

Asp.Net Identity 4 is Microsoft's latest incarnation of User Identity implememnting both Authentication and Authorization. It  has built-in support for ID4 and can delegate Authentication to External Authentication Providers like Azure, Google, Facebook, etc.

Entity Framework
----------------

If we are going to use ASP.Net Identity and rely on ASP.Net Identity to store our User information, then we will have a dependency on EntityFramework and a database.

Database Configuration Settings
-------------------------------

Two databases will be required for the demonstration. One to store User Information (ASPNetIdentity), the other to store ID4 Configuration data (IdentityServer4).

Please note that the ID4 QuickStarts hard-coded ID4 configuration settings in the ASP.Net Core startup.cs file.  We will not be doing that and instead the settings will be set in ID4 database tables. 

Here are the Connection Strings settings that are set in the ID4 appsettings.json file.

 .. code-block:: javascript

    "ConnectionStrings": {
        "IdentityServerConnection": 
        "Server=ABCServer;Database=IdentityServer4;User id=SomeUser;
            Password=p@ssw0rd;MultipleActiveResultSets=true",

        "AspNetIdentityConnection": 
        "Server=ABCServer;Database=AspNetIdentity; User id=SomeUser;
            Password=p@ssw0rd;MultipleActiveResultSets=true"
    },

The next sections define how to initialize these two databases with the appropriate Database Objects, and how populate the Objects with the appropriate Static Data.
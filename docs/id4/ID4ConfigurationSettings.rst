ID4 Configuration Settings
==========================

ID4 configuration settings can be hard-coded in the ASP.Net Core startup.cs file, or can be set in database tables. 

Two databases must be created one for IdentityServer4 Security Settings and the other for User.  Here are the names of the databases as defined in the Connection Strings and set in the ID4 appsettings.json file.

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
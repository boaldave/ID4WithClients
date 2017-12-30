.. _refStaticDataID4:

Static Data: IdentityServer4 Database
=====================================

ClientApp Tables
----------------

Angular Client App
^^^^^^^^^^^^^^^^^^

ASP.Net Core MVC Client App
^^^^^^^^^^^^^^^^^^^^^^^^^^^

ASP.Net WebForms Client App
^^^^^^^^^^^^^^^^^^^^^^^^^^^

``LOH LOH LOH:``

   The following scripts require a lot of explanation, as they define the behavior of Identity Server 4, and every column counts.

Clients
~~~~~~~

``AbsoluteRefreshTokenLifetime`` - This defines how long a RefreshToken can be used to get an AccessToken, ``AccessTokenLifetime`` - LOH

.. code-block:: sql

    DECLARE @webFormsClientId INT = 1
    DECLARE @aspNetMvcClientId INT = 2
    DECLARE @xamarinClientId INT = 3
    DECLARE @angularClientId INT = 4

    SET IDENTITY_INSERT [dbo].[Clients] ON

    --// Xamarin Client //
	INSERT INTO [dbo].[Clients]
           (Id
           ,[AbsoluteRefreshTokenLifetime]
           ,[AccessTokenLifetime]
           ,[AccessTokenType]
           ,[AllowAccessTokensViaBrowser]
           ,[AllowOfflineAccess]

           ,[AllowPlainTextPkce]
           ,[AllowRememberConsent]
           ,[AlwaysIncludeUserClaimsInIdToken]
           ,[AlwaysSendClientClaims]
           ,[AuthorizationCodeLifetime]

           ,[ClientId]
           ,[ClientName]
           ,[ClientUri]
           ,[EnableLocalLogin]
           ,[Enabled]

           ,[IdentityTokenLifetime]
           ,[IncludeJwtId]
           ,[LogoUri]
           ,[LogoutSessionRequired]
           ,[LogoutUri]

           ,[PrefixClientClaims]
           ,[ProtocolType]
           ,[RefreshTokenExpiration]
           ,[RefreshTokenUsage]
           ,[RequireClientSecret]

           ,[RequireConsent]
           ,[RequirePkce]
           ,[SlidingRefreshTokenLifetime]
           ,[UpdateAccessTokenClaimsOnRefresh])
     VALUES
           (@webFormsClientId
           ,2592000			--<AbsoluteRefreshTokenLifetime, int,>
           ,3600			--<AccessTokenLifetime, int,>
           ,0				--<AccessTokenType, int,>
           ,0				--<AllowAccessTokensViaBrowser, bit,>
           ,1				--<AllowOfflineAccess, bit,>

           ,0				--<AllowPlainTextPkce, bit,>
           ,1				--<AllowRememberConsent, bit,>
           ,0				--<AlwaysIncludeUserClaimsInIdToken, bit,>
           ,0				--<AlwaysSendClientClaims, bit,>
           ,300 			--<AuthorizationCodeLifetime, int,>

           ,'WebFormsClient'	--<ClientId, nvarchar(200),>
           ,'WebFormsViaResourceOwnerClient)'	--<ClientName, nvarchar(200),>
           ,null			--<ClientUri, nvarchar(2000),>
           ,1				--<EnableLocalLogin, bit,>
           ,1				--<Enabled, bit,>

           ,300				--<IdentityTokenLifetime, int,>
           ,0				--<IncludeJwtId, bit,>
           ,null			--<LogoUri, nvarchar(max),>
           ,1				--<LogoutSessionRequired, bit,>
           ,null			--<LogoutUri, nvarchar(max),>

           ,1				--<PrefixClientClaims, bit,>
           ,'oidc'			--<ProtocolType, nvarchar(200),>
           ,1				--<RefreshTokenExpiration, int,>
           ,1				--<RefreshTokenUsage, int,>
           ,1				--<RequireClientSecret, bit,>

           ,1				--<RequireConsent, bit,>
           ,1				--<RequirePkce, bit,>
           ,1296000			--<SlidingRefreshTokenLifetime, int,>
           ,0)				--<UpdateAccessTokenClaimsOnRefresh, bit,>)

    SET IDENTITY_INSERT [dbo].[Clients] OFF


ClientGrantTypes
~~~~~~~~~~~~~~~~

``GrantType`` - "password" refers to OAuth2 Resource Owner Password Credentials Flow.

.. code-block:: sql

    DECLARE @webFormsClientId INT = 1
    DECLARE @aspNetMvcClientId INT = 2
    DECLARE @xamarinClientId INT = 3
    DECLARE @angularClientId INT = 4

	INSERT INTO [dbo].[ClientGrantTypes]
			   ([ClientId]
			   ,[GrantType])
		 VALUES
			   (@webFormsClientId
			   ,'password')

ClientSecrets
~~~~~~~~~~~~~

``Expiration`` - null means it never expires, ``SharedSecret`` - LOH.

.. code-block:: sql

    DECLARE @webFormsClientId INT = 1
    DECLARE @aspNetMvcClientId INT = 2
    DECLARE @xamarinClientId INT = 3
    DECLARE @angularClientId INT = 4

	INSERT INTO [dbo].[ClientSecrets]
			   ([ClientId]
			   ,[Description]
			   ,[Expiration]
			   ,[Type]
			   ,[Value])
		 VALUES
			   (@webFormsClientId --<ClientId, int,>
			   ,null			  --<Description, nvarchar(2000),>
			   ,null		      --<Expiration, datetime2(7),>
			   ,'SharedSecret'	  --<Type, nvarchar(250),>
			   ,'K7gNU3sdo+OL0wNhqoVWhr3g6s1xYv72ol/pe/Unols=')	
			       --<Value, nvarchar(2000),>) "secret".Sha256()

ClientScopes
~~~~~~~~~~~~

``Expiration`` - null means it never expires, ``SharedSecret`` - LOH.

.. code-block:: sql

    DECLARE @webFormsClientId INT = 1
    DECLARE @aspNetMvcClientId INT = 2
    DECLARE @xamarinClientId INT = 3
    DECLARE @angularClientId INT = 4

	INSERT INTO [dbo].[ClientScopes]
			   ([ClientId]
			   ,[Scope])
		 VALUES
			   (@webFormsClientId	--<ClientId, int,>
			   ,'WebFormsApp')		--<Scope, nvarchar(200),>)

Other Tables
~~~~~~~~~~~~

No Static Data.

.. code-block:: sql

    --[dbo].[ClientClaims] has no records
    --[dbo].[ClientRedirectUris] has no records
    --[dbo].[ClientPostLogoutRedirectUris] has no records
    --[dbo].[ClientCorsOrigins] has no records
    --[dbo].[ClientIdPRestrictions] has no records

Xamarin Client App
^^^^^^^^^^^^^^^^^^

Clients
~~~~~~~

``AbsoluteRefreshTokenLifetime`` - This defines how long a RefreshToken can be used to get an AccessToken, ``AccessTokenLifetime`` - LOH

.. code-block:: sql

    DECLARE @webFormsClientId INT = 1
    DECLARE @aspNetMvcClientId INT = 2
    DECLARE @xamarinClientId INT = 3
    DECLARE @angularClientId INT = 4

    INSERT INTO [dbo].[Clients]
           ([Id]
           ,[AbsoluteRefreshTokenLifetime]
           ,[AccessTokenLifetime]
           ,[AccessTokenType]
           ,[AllowAccessTokensViaBrowser]
           ,[AllowOfflineAccess]

           ,[AllowPlainTextPkce]
           ,[AllowRememberConsent]
           ,[AlwaysIncludeUserClaimsInIdToken]
           ,[AlwaysSendClientClaims]
           ,[AuthorizationCodeLifetime]

           ,[ClientId]
           ,[ClientName]
           ,[ClientUri]
           ,[EnableLocalLogin]
           ,[Enabled]

           ,[IdentityTokenLifetime]
           ,[IncludeJwtId]
           ,[LogoUri]
           ,[LogoutSessionRequired]
           ,[LogoutUri]

           ,[PrefixClientClaims]
           ,[ProtocolType]
           ,[RefreshTokenExpiration]
           ,[RefreshTokenUsage]
           ,[RequireClientSecret]

           ,[RequireConsent]
           ,[RequirePkce]
           ,[SlidingRefreshTokenLifetime]
           ,[UpdateAccessTokenClaimsOnRefresh])
     VALUES
           (@xamarinClientId
           ,2592000			--<AbsoluteRefreshTokenLifetime, int,>
           ,3600			--<AccessTokenLifetime, int,>
           ,0				--<AccessTokenType, int,>
           ,0				--<AllowAccessTokensViaBrowser, bit,>
           ,1				--<AllowOfflineAccess, bit,>

           ,0				--<AllowPlainTextPkce, bit,>
           ,1				--<AllowRememberConsent, bit,>
           ,0				--<AlwaysIncludeUserClaimsInIdToken, bit,>
           ,0				--<AlwaysSendClientClaims, bit,>
           ,300 			--<AuthorizationCodeLifetime, int,>

           ,'xamarinClient'	--<ClientId, nvarchar(200),>
           ,'XamarinViaHybridClient)'	--<ClientName, nvarchar(200),>
           ,null			--<ClientUri, nvarchar(2000),>
           ,1				--<EnableLocalLogin, bit,>
           ,1				--<Enabled, bit,>

           ,300				--<IdentityTokenLifetime, int,>
           ,0				--<IncludeJwtId, bit,>
           ,null			--<LogoUri, nvarchar(max),>
           ,1				--<LogoutSessionRequired, bit,>
           ,null			--<LogoutUri, nvarchar(max),>

           ,1				--<PrefixClientClaims, bit,>
           ,'oidc'			--<ProtocolType, nvarchar(200),>
           ,2				--<RefreshTokenExpiration, int,>
           ,1				--<RefreshTokenUsage, int,>
           ,1				--<RequireClientSecret, bit,>

           ,0				--<RequireConsent, bit,>
           ,1				--<RequirePkce, bit,>
           ,1296000			--<SlidingRefreshTokenLifetime, int,>
           ,0)				--<UpdateAccessTokenClaimsOnRefresh, bit,>)

    SET IDENTITY_INSERT [dbo].[Clients] OFF

ClientGrantTypes
~~~~~~~~~~~~~~~~

``GrantType`` - "hybrid" refers to OpenID Connect modified OAuth2 Authorization Code Flow.

.. code-block:: sql

    DECLARE @webFormsClientId INT = 1
    DECLARE @aspNetMvcClientId INT = 2
    DECLARE @xamarinClientId INT = 3
    DECLARE @angularClientId INT = 4

	INSERT INTO [dbo].[ClientGrantTypes]
			   ([ClientId]
			   ,[GrantType])
		 VALUES
			   (@xamarinClient
			   ,'hybrid'),

ClientSecrets
~~~~~~~~~~~~~

``Expiration`` - null means it never expires, ``SharedSecret`` - LOH.

.. code-block:: sql

    DECLARE @webFormsClientId INT = 1
    DECLARE @aspNetMvcClientId INT = 2
    DECLARE @xamarinClientId INT = 3
    DECLARE @angularClientId INT = 4

	INSERT INTO [dbo].[ClientSecrets]
			   ([ClientId]
			   ,[Description]
			   ,[Expiration]
			   ,[Type]
			   ,[Value])
		 VALUES
			   (@xamarinClient --<ClientId, int,>
			   ,null			  --<Description, nvarchar(2000),>
			   ,null		      --<Expiration, datetime2(7),>
			   ,'SharedSecret'	  --<Type, nvarchar(250),>
			   ,'K7gNU3sdo+OL0wNhqoVWhr3g6s1xYv72ol/pe/Unols=')	
			       --<Value, nvarchar(2000),>) "secret".Sha256()

ClientScopes
~~~~~~~~~~~~

``Expiration`` - null means it never expires, ``SharedSecret`` - LOH.

.. code-block:: sql

    DECLARE @webFormsClientId INT = 1
    DECLARE @aspNetMvcClientId INT = 2
    DECLARE @xamarinClientId INT = 3
    DECLARE @angularClientId INT = 4

	INSERT INTO [dbo].[ClientScopes]
			   ([ClientId]
			   ,[Scope])
		 VALUES
			   (
                    @xamarinClient	--<ClientId, int,>
			        ,'XamarinApp'	--<Scope, nvarchar(200),>)
               ),
			   (
                    @xamarinClient	--<ClientId, int,>
			        ,'openid'	--<Scope, nvarchar(200),>)
               ),
			   (
                    @xamarinClient	--<ClientId, int,>
			        ,'profile'	--<Scope, nvarchar(200),>)
               ),

    --[dbo].[ClientClaims] has no records

ClientRedirectUris
~~~~~~~~~~~~~~~~~~

``RedirectUri`` - LOH.

.. code-block:: sql

    DECLARE @webFormsClientId INT = 1
    DECLARE @aspNetMvcClientId INT = 2
    DECLARE @xamarinClientId INT = 3
    DECLARE @angularClientId INT = 4

    INSERT INTO [dbo].[ClientRedirectUris]
            ([ClientId]
            ,[RedirectUri])
        VALUES
            (@xamarinClient
            ,'biincofficermobile://auth')

ClientPostLogoutRedirectUris
~~~~~~~~~~~~~~~~~~~~~~~~~~~~

``RedirectUri`` - LOH.

.. code-block:: sql

    DECLARE @webFormsClientId INT = 1
    DECLARE @aspNetMvcClientId INT = 2
    DECLARE @xamarinClientId INT = 3
    DECLARE @angularClientId INT = 4

    INSERT INTO [dbo].[ClientPostLogoutRedirectUris]
            ([ClientId]
            ,[PostLogoutRedirectUri])
        VALUES
            (@xamarinClient
            ,'biincofficermobile://afterLogout')

Other Tables
~~~~~~~~~~~~~~~~

No Static Data.

.. code-block:: sql

    --[dbo].[ClientCorsOrigins] has no records
    --[dbo].[ClientIdPRestrictions] has no records
 
 
APIResources Tables
-------------------

The following scripts require a lot of explanation, as they define the behavior of Identity Server 4, and every column counts.

''LOH LOH LOH:''

   #Why do the Resource and Scope have the same name?

Here are the static data scripts::

    DECLARE @apiResourceId_SomeCompanysAPI INT = 1
    DECLARE @apiResourceId_OpenID INT = 2
    DECLARE @apiResourceId_Profile INT = 3
    DECLARE @apiScopesId_SomeCompanysAPI INT = 1
    DECLARE @apiScopesId_OpenID INT = 2
    DECLARE @apiScopesId_Profile INT = 3
    DECLARE @apiScopeId INT = 1

    SET IDENTITY_INSERT [dbo].[ApiResources] ON
    INSERT INTO [dbo].[ApiResources]
            ([Id]
            ,[Description]
            ,[DisplayName]
            ,[Enabled]
            ,[Name])
        VALUES
            (
                @apiResourceId_SomeCompanysAPI
                ,'SomeCompanysAPI'
                ,'SomeCompanysAPI'
                ,1
                ,'SomeCompanysAPI'
            ),
            (
                @apiResourceId_OpenID
                ,'Open ID'
                ,'Open ID'
                1
                'openid'
            ),
            (
                @apiResourceId_Profile
                ,'Profile'
                ,'Profile'
                1
                'profile'
            )

    SET IDENTITY_INSERT [dbo].[ApiScopes] ON
    INSERT INTO [dbo].[ApiScopes]
            ([Id]
            ,[ApiResourceId]
            ,[Description]
            ,[DisplayName]
            ,[Emphasize]
            ,[Name]
            ,[Required]
            ,[ShowInDiscoveryDocument])
        VALUES
            (@apiScopeId_SomeCompanysAPI
            ,@apiResourceId_SomeCompanysAPI
            ,'SomeCompanysAPI'
            ,'SomeCompanysAPI'
            ,0
            ,'SomeCompanysAPI'
            ,0
            ,1)
    INSERT INTO [dbo].[ApiScopes]
            ([Id]
            ,[ApiResourceId]
            ,[Description]
            ,[DisplayName]
            ,[Emphasize]
            ,[Name]
            ,[Required]
            ,[ShowInDiscoveryDocument])
        VALUES
            (@apiScopeId_OpenID
            ,@apiResourceId_OpenID
            ,'Open ID'
            ,'Open ID'
            ,0
            ,'openid'
            ,0
            ,1)
    INSERT INTO [dbo].[ApiScopes]
            ([Id]
            ,[ApiResourceId]
            ,[Description]
            ,[DisplayName]
            ,[Emphasize]
            ,[Name]
            ,[Required]
            ,[ShowInDiscoveryDocument])
        VALUES
            (@apiScopeId_Profile
            ,@apiResourceId_Profile
            ,'Profile'
            ,'Profile'
            ,0
            ,'profile'
            ,0
            ,1)

    SET IDENTITY_INSERT [dbo].[ApiScopeClaims] ON
    INSERT INTO [dbo].[ApiScopeClaims]
        ([ApiScopeId]
        ,[Type])
    VALUES
        (
            @apiScopeId_Profile
            ,'name'
        )

    SET IDENTITY_INSERT [dbo].[ApiClaims] ON
    INSERT INTO dbo.ApiClaims 
        (
            ApiResourceId, 
            Type) 
        VALUES	
        (
            @apiResourceId_SomeCompanysAPI, 
            N'UserId'
        )

    SET IDENTITY_INSERT [dbo].[ApiClaims] OFF
    SET IDENTITY_INSERT [dbo].[ApiScopeClaims] OFF
    SET IDENTITY_INSERT [dbo].[ApiScopes] OFF
    SET IDENTITY_INSERT [dbo].[ApiResources] ON

.. _refStaticDataID4ClientAppTables:
Static Data: ID4 Database ClientApp Tables:
===========================================

The following scripts require a lot of explanation, as they define the behavior of Identity Server 4, and every column counts.

Here are the static data scripts::

DECLARE @cid INT

IF (NOT EXISTS(
    SELECT * FROM [dbo].[Clients] 
    WHERE [dbo].Clients.ClientId = 'WebFormsClient'))
BEGIN 

	INSERT INTO [dbo].[Clients]

           ([AbsoluteRefreshTokenLifetime]
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
           (2592000			--<AbsoluteRefreshTokenLifetime, int,>
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

	SELECT @cid = @@IDENTITY

	INSERT INTO [dbo].[ClientGrantTypes]
			   ([ClientId]
			   ,[GrantType])
		 VALUES
			   (@cid
			   ,'password')

	INSERT INTO [dbo].[ClientScopes]
			   ([ClientId]
			   ,[Scope])
		 VALUES
			   (@cid				--<ClientId, int,>
			   ,'WebFormsApp')		--<Scope, nvarchar(200),>)

	INSERT INTO [dbo].[ClientSecrets]
			   ([ClientId]
			   ,[Description]
			   ,[Expiration]
			   ,[Type]
			   ,[Value])
		 VALUES
			   (@cid			--<ClientId, int,>
			   ,null			--<Description, nvarchar(2000),>
			   ,null			--<Expiration, datetime2(7),>
			   ,'SharedSecret'	--<Type, nvarchar(250),>
			   ,'K7gNU3sdo+OL0wNhqoVWhr3g6s1xYv72ol/pe/Unols=')	
			       --<Value, nvarchar(2000),>) "secret".Sha256()
END 
GO

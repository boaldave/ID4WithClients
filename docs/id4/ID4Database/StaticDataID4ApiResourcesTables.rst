.. _refStaticDataID4APIResourcesTables:

Static Data: ID4 Database APIResources Tables
=============================================

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

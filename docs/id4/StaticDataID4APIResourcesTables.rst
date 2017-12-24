.. _refStaticDataID4APIResourcesTables:
Static Data: ID4 Database APIResources Tables:
===========================================

The following scripts require a lot of explanation, as they define the behavior of Identity Server 4, and every column counts.

''Question:''
#Why do the Resource and Scope have the same name?

Here are the static data scripts::

    DECLARE @apiResourceId INT

    IF (NOT EXISTS(
        SELECT * FROM [dbo].[ApiResources] 
        WHERE [dbo].[ApiResources].Name = 'SomeCompanysAPI'))
    BEGIN 

        INSERT INTO [dbo].[ApiResources]
                ([Description]
                ,[DisplayName]
                ,[Enabled]
                ,[Name])
            VALUES
                ('SomeCompanysAPI'
                ,'SomeCompanysAPI'
                ,1
                ,'SomeCompanysAPI')

        SELECT @apiResourceId = @@IDENTITY

        INSERT INTO [dbo].[ApiScopes]
                ([ApiResourceId]
                ,[Description]
                ,[DisplayName]
                ,[Emphasize]
                ,[Name]
                ,[Required]
                ,[ShowInDiscoveryDocument])
            VALUES
                (@apiResourceId
                ,'SomeCompanysAPI'
                ,'SomeCompanysAPI'
                ,0
                ,'SomeCompanysAPI'
                ,0
                ,1)

    END
    GO

    IF (NOT EXISTS(
        SELECT 1 FROM dbo.ApiClaims 
        WHERE ApiResourceId = 1 AND [Type] = N'UserId'))
    BEGIN

        INSERT INTO dbo.ApiClaims 
            (ApiResourceId, Type) 
            VALUES	
            (@apiResourceId, N'UserId')
    END


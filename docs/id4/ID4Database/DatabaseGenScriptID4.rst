IdentityServer4 Database Generation Script:
===========================================

ID4 needs data for Functional Settings.

First create the IdentityServer4 Database, then run the following script to setup a Database Login Account:

.. code-block:: sql

    USE [master]
    GO
    CREATE LOGIN [ID4SystemUser] WITH PASSWORD=N'p@ssw0rd', 
        DEFAULT_DATABASE=[master], 
        DEFAULT_LANGUAGE=[us_english], 
        CHECK_EXPIRATION=ON, 
        CHECK_POLICY=ON
    GO

Next run this script to create all database objects:

.. code-block:: sql

    USE [IdentityServer4]
    GO
    CREATE USER [ID4SystemUser] FOR LOGIN [ID4SystemUser] 
        WITH DEFAULT_SCHEMA=[dbo]
    GO
    ALTER ROLE [db_datareader] ADD MEMBER [ID4SystemUser]
    GO
    ALTER ROLE [db_datawriter] ADD MEMBER [ID4SystemUser]
    GO
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    CREATE TABLE [dbo].[ApiClaims](
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [ApiResourceId] [int] NOT NULL,
        [Type] [nvarchar](200) NOT NULL,
    CONSTRAINT [PK_ApiClaims] PRIMARY KEY CLUSTERED 
    (
        [Id] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, 
        IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
        ON [PRIMARY]
    ) ON [PRIMARY]

    GO
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    CREATE TABLE [dbo].[ApiResources](
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [Description] [nvarchar](1000) NULL,
        [DisplayName] [nvarchar](200) NULL,
        [Enabled] [bit] NOT NULL,
        [Name] [nvarchar](200) NOT NULL,
    CONSTRAINT [PK_ApiResources] PRIMARY KEY CLUSTERED 
    (
        [Id] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, 
        IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
        ON [PRIMARY]
    ) ON [PRIMARY]

    GO
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    CREATE TABLE [dbo].[ApiScopeClaims](
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [ApiScopeId] [int] NOT NULL,
        [Type] [nvarchar](200) NOT NULL,
    CONSTRAINT [PK_ApiScopeClaims] PRIMARY KEY CLUSTERED 
    (
        [Id] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, 
        IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
        ON [PRIMARY]
    ) ON [PRIMARY]

    GO
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    CREATE TABLE [dbo].[ApiScopes](
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [ApiResourceId] [int] NOT NULL,
        [Description] [nvarchar](1000) NULL,
        [DisplayName] [nvarchar](200) NULL,
        [Emphasize] [bit] NOT NULL,
        [Name] [nvarchar](200) NOT NULL,
        [Required] [bit] NOT NULL,
        [ShowInDiscoveryDocument] [bit] NOT NULL,
    CONSTRAINT [PK_ApiScopes] PRIMARY KEY CLUSTERED 
    (
        [Id] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, 
        IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
        ON [PRIMARY]
    ) ON [PRIMARY]

    GO
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    CREATE TABLE [dbo].[ApiSecrets](
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [ApiResourceId] [int] NOT NULL,
        [Description] [nvarchar](1000) NULL,
        [Expiration] [datetime2](7) NULL,
        [Type] [nvarchar](250) NULL,
        [Value] [nvarchar](2000) NULL,
    CONSTRAINT [PK_ApiSecrets] PRIMARY KEY CLUSTERED 
    (
        [Id] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, 
        IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
        ON [PRIMARY]
    ) ON [PRIMARY]

    GO
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    CREATE TABLE [dbo].[ClientClaims](
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [ClientId] [int] NOT NULL,
        [Type] [nvarchar](250) NOT NULL,
        [Value] [nvarchar](250) NOT NULL,
    CONSTRAINT [PK_ClientClaims] PRIMARY KEY CLUSTERED 
    (
        [Id] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, 
        IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
        ON [PRIMARY]
    ) ON [PRIMARY]

    GO
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    CREATE TABLE [dbo].[ClientCorsOrigins](
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [ClientId] [int] NOT NULL,
        [Origin] [nvarchar](150) NOT NULL,
    CONSTRAINT [PK_ClientCorsOrigins] PRIMARY KEY CLUSTERED 
    (
        [Id] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, 
        IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
        ON [PRIMARY]
    ) ON [PRIMARY]

    GO
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    CREATE TABLE [dbo].[ClientGrantTypes](
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [ClientId] [int] NOT NULL,
        [GrantType] [nvarchar](250) NOT NULL,
    CONSTRAINT [PK_ClientGrantTypes] PRIMARY KEY CLUSTERED 
    (
        [Id] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, 
        IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
        ON [PRIMARY]
    ) ON [PRIMARY]

    GO
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    CREATE TABLE [dbo].[ClientIdPRestrictions](
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [ClientId] [int] NOT NULL,
        [Provider] [nvarchar](200) NOT NULL,
    CONSTRAINT [PK_ClientIdPRestrictions] PRIMARY KEY CLUSTERED 
    (
        [Id] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, 
        IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
        ON [PRIMARY]
    ) ON [PRIMARY]

    GO
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    CREATE TABLE [dbo].[ClientPostLogoutRedirectUris](
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [ClientId] [int] NOT NULL,
        [PostLogoutRedirectUri] [nvarchar](2000) NOT NULL,
    CONSTRAINT [PK_ClientPostLogoutRedirectUris] PRIMARY KEY CLUSTERED 
    (
        [Id] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, 
        IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
        ON [PRIMARY]
    ) ON [PRIMARY]

    GO
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    CREATE TABLE [dbo].[ClientRedirectUris](
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [ClientId] [int] NOT NULL,
        [RedirectUri] [nvarchar](2000) NOT NULL,
    CONSTRAINT [PK_ClientRedirectUris] PRIMARY KEY CLUSTERED 
    (
        [Id] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, 
        IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
        ON [PRIMARY]
    ) ON [PRIMARY]

    GO
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    CREATE TABLE [dbo].[Clients](
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [AbsoluteRefreshTokenLifetime] [int] NOT NULL,
        [AccessTokenLifetime] [int] NOT NULL,
        [AccessTokenType] [int] NOT NULL,
        [AllowAccessTokensViaBrowser] [bit] NOT NULL,
        [AllowOfflineAccess] [bit] NOT NULL,
        [AllowPlainTextPkce] [bit] NOT NULL,
        [AllowRememberConsent] [bit] NOT NULL,
        [AlwaysIncludeUserClaimsInIdToken] [bit] NOT NULL,
        [AlwaysSendClientClaims] [bit] NOT NULL,
        [AuthorizationCodeLifetime] [int] NOT NULL,
        [ClientId] [nvarchar](200) NOT NULL,
        [ClientName] [nvarchar](200) NULL,
        [ClientUri] [nvarchar](2000) NULL,
        [EnableLocalLogin] [bit] NOT NULL,
        [Enabled] [bit] NOT NULL,
        [IdentityTokenLifetime] [int] NOT NULL,
        [IncludeJwtId] [bit] NOT NULL,
        [LogoUri] [nvarchar](max) NULL,
        [LogoutSessionRequired] [bit] NOT NULL,
        [LogoutUri] [nvarchar](max) NULL,
        [PrefixClientClaims] [bit] NOT NULL,
        [ProtocolType] [nvarchar](200) NOT NULL,
        [RefreshTokenExpiration] [int] NOT NULL,
        [RefreshTokenUsage] [int] NOT NULL,
        [RequireClientSecret] [bit] NOT NULL,
        [RequireConsent] [bit] NOT NULL,
        [RequirePkce] [bit] NOT NULL,
        [SlidingRefreshTokenLifetime] [int] NOT NULL,
        [UpdateAccessTokenClaimsOnRefresh] [bit] NOT NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
    (
        [Id] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, 
        IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
        ON [PRIMARY]
    ) ON [PRIMARY]

    GO
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    CREATE TABLE [dbo].[ClientScopes](
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [ClientId] [int] NOT NULL,
        [Scope] [nvarchar](200) NOT NULL,
    CONSTRAINT [PK_ClientScopes] PRIMARY KEY CLUSTERED 
    (
        [Id] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, 
        IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
        ON [PRIMARY]
    ) ON [PRIMARY]

    GO
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    CREATE TABLE [dbo].[ClientSecrets](
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [ClientId] [int] NOT NULL,
        [Description] [nvarchar](2000) NULL,
        [Expiration] [datetime2](7) NULL,
        [Type] [nvarchar](250) NULL,
        [Value] [nvarchar](2000) NOT NULL,
    CONSTRAINT [PK_ClientSecrets] PRIMARY KEY CLUSTERED 
    (
        [Id] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, 
        IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
        ON [PRIMARY]
    ) ON [PRIMARY]

    GO
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    CREATE TABLE [dbo].[IdentityClaims](
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [IdentityResourceId] [int] NOT NULL,
        [Type] [nvarchar](200) NOT NULL,
    CONSTRAINT [PK_IdentityClaims] PRIMARY KEY CLUSTERED 
    (
        [Id] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, 
        IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
        ON [PRIMARY]
    ) ON [PRIMARY]

    GO
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    CREATE TABLE [dbo].[IdentityResources](
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [Description] [nvarchar](1000) NULL,
        [DisplayName] [nvarchar](200) NULL,
        [Emphasize] [bit] NOT NULL,
        [Enabled] [bit] NOT NULL,
        [Name] [nvarchar](200) NOT NULL,
        [Required] [bit] NOT NULL,
        [ShowInDiscoveryDocument] [bit] NOT NULL,
    CONSTRAINT [PK_IdentityResources] PRIMARY KEY CLUSTERED 
    (
        [Id] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, 
        IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
        ON [PRIMARY]
    ) ON [PRIMARY]

    GO
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    CREATE TABLE [dbo].[PersistedGrants](
        [Key] [nvarchar](200) NOT NULL,
        [ClientId] [nvarchar](200) NOT NULL,
        [CreationTime] [datetime2](7) NOT NULL,
        [Data] [nvarchar](max) NOT NULL,
        [Expiration] [datetime2](7) NULL,
        [SubjectId] [nvarchar](200) NULL,
        [Type] [nvarchar](50) NOT NULL,
    CONSTRAINT [PK_PersistedGrants] PRIMARY KEY CLUSTERED 
    (
        [Key] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, 
        IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
        ON [PRIMARY]
    ) ON [PRIMARY]

    GO
    ALTER TABLE [dbo].[ApiClaims]  WITH CHECK ADD  
        CONSTRAINT [FK_ApiClaims_ApiResources_ApiResourceId] 
        FOREIGN KEY([ApiResourceId])
        REFERENCES [dbo].[ApiResources] ([Id])
        ON DELETE CASCADE
    GO
    ALTER TABLE [dbo].[ApiClaims] CHECK 
        CONSTRAINT [FK_ApiClaims_ApiResources_ApiResourceId]
    GO
    ALTER TABLE [dbo].[ApiScopeClaims]  WITH CHECK ADD  
        CONSTRAINT [FK_ApiScopeClaims_ApiScopes_ApiScopeId] 
        FOREIGN KEY([ApiScopeId])
        REFERENCES [dbo].[ApiScopes] ([Id])
        ON DELETE CASCADE
    GO
    ALTER TABLE [dbo].[ApiScopeClaims] CHECK 
        CONSTRAINT [FK_ApiScopeClaims_ApiScopes_ApiScopeId]
    GO
    ALTER TABLE [dbo].[ApiScopes]  WITH CHECK ADD  
        CONSTRAINT [FK_ApiScopes_ApiResources_ApiResourceId] 
        FOREIGN KEY([ApiResourceId])
        REFERENCES [dbo].[ApiResources] ([Id])
        ON DELETE CASCADE
    GO
    ALTER TABLE [dbo].[ApiScopes] CHECK 
        CONSTRAINT [FK_ApiScopes_ApiResources_ApiResourceId]
    GO
    ALTER TABLE [dbo].[ApiSecrets]  WITH CHECK ADD  
        CONSTRAINT [FK_ApiSecrets_ApiResources_ApiResourceId] 
        FOREIGN KEY([ApiResourceId])
        REFERENCES [dbo].[ApiResources] ([Id])
        ON DELETE CASCADE
    GO
    ALTER TABLE [dbo].[ApiSecrets] CHECK 
        CONSTRAINT [FK_ApiSecrets_ApiResources_ApiResourceId]
    GO
    ALTER TABLE [dbo].[ClientClaims]  WITH CHECK ADD  
        CONSTRAINT [FK_ClientClaims_Clients_ClientId] 
        FOREIGN KEY([ClientId])
        REFERENCES [dbo].[Clients] ([Id])
        ON DELETE CASCADE
    GO
    ALTER TABLE [dbo].[ClientClaims] CHECK 
        CONSTRAINT [FK_ClientClaims_Clients_ClientId]
    GO
    ALTER TABLE [dbo].[ClientCorsOrigins]  WITH CHECK ADD  
        CONSTRAINT [FK_ClientCorsOrigins_Clients_ClientId] 
        FOREIGN KEY([ClientId])
        REFERENCES [dbo].[Clients] ([Id])
        ON DELETE CASCADE
    GO
    ALTER TABLE [dbo].[ClientCorsOrigins] CHECK 
        CONSTRAINT [FK_ClientCorsOrigins_Clients_ClientId]
    GO
    ALTER TABLE [dbo].[ClientGrantTypes]  WITH CHECK ADD  
        CONSTRAINT [FK_ClientGrantTypes_Clients_ClientId] 
        FOREIGN KEY([ClientId])
        REFERENCES [dbo].[Clients] ([Id])
        ON DELETE CASCADE
    GO
    ALTER TABLE [dbo].[ClientGrantTypes] CHECK 
        CONSTRAINT [FK_ClientGrantTypes_Clients_ClientId]
    GO
    ALTER TABLE [dbo].[ClientIdPRestrictions]  WITH CHECK ADD  
        CONSTRAINT [FK_ClientIdPRestrictions_Clients_ClientId] 
        FOREIGN KEY([ClientId])
        REFERENCES [dbo].[Clients] ([Id])
        ON DELETE CASCADE
    GO
        ALTER TABLE [dbo].[ClientIdPRestrictions] CHECK 
        CONSTRAINT [FK_ClientIdPRestrictions_Clients_ClientId]
    GO
    ALTER TABLE [dbo].[ClientPostLogoutRedirectUris]  WITH CHECK ADD  
        CONSTRAINT [FK_ClientPostLogoutRedirectUris_Clients_ClientId] 
        FOREIGN KEY([ClientId])
        REFERENCES [dbo].[Clients] ([Id])
        ON DELETE CASCADE
    GO
    ALTER TABLE [dbo].[ClientPostLogoutRedirectUris] CHECK 
        CONSTRAINT [FK_ClientPostLogoutRedirectUris_Clients_ClientId]
    GO
    ALTER TABLE [dbo].[ClientRedirectUris]  WITH CHECK ADD  
        CONSTRAINT [FK_ClientRedirectUris_Clients_ClientId] 
        FOREIGN KEY([ClientId])
        REFERENCES [dbo].[Clients] ([Id])
        ON DELETE CASCADE
    GO
    ALTER TABLE [dbo].[ClientRedirectUris] CHECK 
        CONSTRAINT [FK_ClientRedirectUris_Clients_ClientId]
    GO
    ALTER TABLE [dbo].[ClientScopes]  WITH CHECK ADD  
        CONSTRAINT [FK_ClientScopes_Clients_ClientId] 
        FOREIGN KEY([ClientId])
        REFERENCES [dbo].[Clients] ([Id])
        ON DELETE CASCADE
    GO
    ALTER TABLE [dbo].[ClientScopes] CHECK 
        CONSTRAINT [FK_ClientScopes_Clients_ClientId]
    GO
    ALTER TABLE [dbo].[ClientSecrets]  WITH CHECK ADD  
        CONSTRAINT [FK_ClientSecrets_Clients_ClientId] 
        FOREIGN KEY([ClientId])
        REFERENCES [dbo].[Clients] ([Id])
        ON DELETE CASCADE
    GO
    ALTER TABLE [dbo].[ClientSecrets] CHECK 
        CONSTRAINT [FK_ClientSecrets_Clients_ClientId]
    GO
    ALTER TABLE [dbo].[IdentityClaims]  WITH CHECK ADD  
        CONSTRAINT [FK_IdentityClaims_IdentityResources_IdentityResourceId] 
        FOREIGN KEY([IdentityResourceId])
        REFERENCES [dbo].[IdentityResources] ([Id])
        ON DELETE CASCADE
    GO
    ALTER TABLE [dbo].[IdentityClaims] CHECK 
        CONSTRAINT [FK_IdentityClaims_IdentityResources_IdentityResourceId]
    GO

    GRANT SELECT ON [dbo].[ApiClaims] TO ID4SystemUser;
    GRANT SELECT ON [dbo].[ApiResources] TO ID4SystemUser;
    GRANT SELECT ON [dbo].[ApiScopeClaims] TO ID4SystemUser;
    GRANT SELECT ON [dbo].[ApiScopes] TO ID4SystemUser;
    GRANT SELECT ON [dbo].[ApiSecrets] TO ID4SystemUser;
    GRANT SELECT ON [dbo].[ClientClaims] TO ID4SystemUser;
    GRANT SELECT ON [dbo].[ClientCorsOrigins] TO ID4SystemUser;
    GRANT SELECT ON [dbo].[ClientGrantTypes] TO ID4SystemUser;
    GRANT SELECT ON [dbo].[ClientIdPRestrictions] TO ID4SystemUser;
    GRANT SELECT ON [dbo].[ClientPostLogoutRedirectUris] TO ID4SystemUser;
    GRANT SELECT ON [dbo].[ClientRedirectUris] TO ID4SystemUser;
    GRANT SELECT ON [dbo].[Clients] TO ID4SystemUser;
    GRANT SELECT ON [dbo].[ClientScopes] TO ID4SystemUser;
    GRANT SELECT ON [dbo].[ClientSecrets] TO ID4SystemUser;
    GRANT SELECT ON [dbo].[IdentityClaims] TO ID4SystemUser;
    GRANT SELECT ON [dbo].[IdentityResources] TO ID4SystemUser;
    GRANT SELECT, INSERT, DELETE ON [dbo].[PersistedGrants] TO ID4SystemUser;


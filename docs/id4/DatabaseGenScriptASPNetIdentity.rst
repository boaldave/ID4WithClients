.. _refDatabaseGenScriptAspNetIdentity:
IdentityServer4 Database Generation Script:
===========================================

Before running the following script, you need to create the AspNetIdentity Database. Then you can run the following script to setup a Database Login Account::
    USE [master]
    GO
    /* For security reasons the login is created disabled and with a random password. */
    /****** Object:  Login [ID4SystemUser]    Script Date: 12/24/2017 1:46:04 PM ******/
    CREATE LOGIN [ID4SystemUser] WITH PASSWORD=N'p@ssw0rd', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
    GO


Next you can run this script to create all database objects::

    USE [AspNetIdentity]
    /****** Object:  User [ID4SystemUser]    Script Date: 12/24/2017 9:36:28 AM ******/
    CREATE USER [ID4SystemUser] FOR LOGIN [ID4SystemUser] WITH DEFAULT_SCHEMA=[dbo]
    GO
    ALTER ROLE [db_datareader] ADD MEMBER [ID4SystemUser]
    GO
    ALTER ROLE [db_datawriter] ADD MEMBER [ID4SystemUser]
    GO

    /****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 12/24/2017 9:36:29 AM ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    CREATE TABLE [dbo].[AspNetRoleClaims](
        [Id] [int] NOT NULL,
        [ClaimType] [nvarchar](max) NULL,
        [ClaimValue] [nvarchar](max) NULL,
        [RoleId] [nvarchar](450) NOT NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
    (
        [Id] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

    GO
    /****** Object:  Table [dbo].[AspNetRoles]    Script Date: 12/24/2017 9:36:29 AM ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    CREATE TABLE [dbo].[AspNetRoles](
        [Id] [nvarchar](450) NOT NULL,
        [ConcurrencyStamp] [nvarchar](max) NULL,
        [Name] [nvarchar](256) NULL,
        [NormalizedName] [nvarchar](256) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
    (
        [Id] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

    GO
    /****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 12/24/2017 9:36:29 AM ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    CREATE TABLE [dbo].[AspNetUserClaims](
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [ClaimType] [nvarchar](max) NULL,
        [ClaimValue] [nvarchar](max) NULL,
        [UserId] [nvarchar](450) NOT NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
    (
        [Id] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

    GO
    /****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 12/24/2017 9:36:29 AM ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    CREATE TABLE [dbo].[AspNetUserLogins](
        [LoginProvider] [nvarchar](450) NOT NULL,
        [ProviderKey] [nvarchar](450) NOT NULL,
        [ProviderDisplayName] [nvarchar](max) NULL,
        [UserId] [nvarchar](450) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
    (
        [LoginProvider] ASC,
        [ProviderKey] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

    GO
    /****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 12/24/2017 9:36:29 AM ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    CREATE TABLE [dbo].[AspNetUserRoles](
        [UserId] [nvarchar](450) NOT NULL,
        [RoleId] [nvarchar](450) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
    (
        [UserId] ASC,
        [RoleId] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]

    GO
    /****** Object:  Table [dbo].[AspNetUsers]    Script Date: 12/24/2017 9:36:29 AM ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    CREATE TABLE [dbo].[AspNetUsers](
        [Id] [nvarchar](450) NOT NULL,
        [AccessFailedCount] [int] NOT NULL,
        [ConcurrencyStamp] [nvarchar](max) NULL,
        [Email] [nvarchar](256) NULL,
        [EmailConfirmed] [bit] NOT NULL,
        [LockoutEnabled] [bit] NOT NULL,
        [LockoutEnd] [datetimeoffset](7) NULL,
        [NormalizedEmail] [nvarchar](256) NULL,
        [NormalizedUserName] [nvarchar](256) NULL,
        [PasswordHash] [nvarchar](max) NULL,
        [PhoneNumber] [nvarchar](max) NULL,
        [PhoneNumberConfirmed] [bit] NOT NULL,
        [SecurityStamp] [nvarchar](max) NULL,
        [TwoFactorEnabled] [bit] NOT NULL,
        [UserName] [nvarchar](256) NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
    (
        [Id] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

    GO
    /****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 12/24/2017 9:36:29 AM ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    CREATE TABLE [dbo].[AspNetUserTokens](
        [UserId] [nvarchar](450) NOT NULL,
        [LoginProvider] [nvarchar](450) NOT NULL,
        [Name] [nvarchar](450) NOT NULL,
        [Value] [nvarchar](max) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
    (
        [UserId] ASC,
        [LoginProvider] ASC,
        [Name] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

    GO
    /****** Object:  Table [dbo].[PasswordHistory]    Script Date: 12/24/2017 9:36:29 AM ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    SET ANSI_PADDING ON
    GO
    CREATE TABLE [dbo].[PasswordHistory](
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [UserId] [varchar](450) NOT NULL,
        [PasswordHash] [varchar](max) NOT NULL,
        [CreatedDate] [datetime] NOT NULL
    ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

    GO
    SET ANSI_PADDING OFF
    GO
    ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
    REFERENCES [dbo].[AspNetRoles] ([Id])
    ON DELETE CASCADE
    GO
    ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
    GO
    ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
    REFERENCES [dbo].[AspNetUsers] ([Id])
    ON DELETE CASCADE
    GO
    ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
    GO
    ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
    REFERENCES [dbo].[AspNetUsers] ([Id])
    ON DELETE CASCADE
    GO
    ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
    GO
    ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
    REFERENCES [dbo].[AspNetRoles] ([Id])
    ON DELETE CASCADE
    GO
    ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
    GO
    ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
    REFERENCES [dbo].[AspNetUsers] ([Id])
    ON DELETE CASCADE
    GO
    ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
    GO

    GRANT SELECT, DELETE, UPDATE, INSERT ON [dbo].AspNetRoleClaims TO ID4SystemUser;
    GRANT SELECT, DELETE, UPDATE, INSERT ON [dbo].[AspNetRoles] TO ID4SystemUser;
    GRANT SELECT, DELETE, UPDATE, INSERT ON [dbo].[AspNetUserClaims] TO ID4SystemUser;
    GRANT SELECT, DELETE, UPDATE, INSERT ON [dbo].[AspNetUserLogins] TO ID4SystemUser;
    GRANT SELECT, DELETE, UPDATE, INSERT ON [dbo].[AspNetUserRoles] TO ID4SystemUser;
    GRANT SELECT, DELETE, UPDATE, INSERT ON [dbo].[AspNetUsers] TO ID4SystemUser;
    GRANT SELECT, DELETE, UPDATE, INSERT ON [dbo].[AspNetUserTokens] TO ID4SystemUser;
    GRANT SELECT, DELETE, UPDATE, INSERT ON [dbo].[PasswordHistory] TO ID4SystemUser;


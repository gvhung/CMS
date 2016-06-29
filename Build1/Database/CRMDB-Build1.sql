USE [CRMDB]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Tickets__Product__693CA210]') AND parent_object_id = OBJECT_ID(N'[dbo].[Tickets]'))
ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK__Tickets__Product__693CA210]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Tickets__Created__6E01572D]') AND parent_object_id = OBJECT_ID(N'[dbo].[Tickets]'))
ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK__Tickets__Created__6E01572D]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Tickets__Compone__6A30C649]') AND parent_object_id = OBJECT_ID(N'[dbo].[Tickets]'))
ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK__Tickets__Compone__6A30C649]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Tickets__Company__6C190EBB]') AND parent_object_id = OBJECT_ID(N'[dbo].[Tickets]'))
ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK__Tickets__Company__6C190EBB]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__TicketCom__Ticke__73BA3083]') AND parent_object_id = OBJECT_ID(N'[dbo].[TicketComments]'))
ALTER TABLE [dbo].[TicketComments] DROP CONSTRAINT [FK__TicketCom__Ticke__73BA3083]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__TicketAtt__Ticke__6FE99F9F]') AND parent_object_id = OBJECT_ID(N'[dbo].[TicketAttachments]'))
ALTER TABLE [dbo].[TicketAttachments] DROP CONSTRAINT [FK__TicketAtt__Ticke__6FE99F9F]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__TicketAss__Ticke__76969D2E]') AND parent_object_id = OBJECT_ID(N'[dbo].[TicketAssignees]'))
ALTER TABLE [dbo].[TicketAssignees] DROP CONSTRAINT [FK__TicketAss__Ticke__76969D2E]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__TicketAss__Assig__778AC167]') AND parent_object_id = OBJECT_ID(N'[dbo].[TicketAssignees]'))
ALTER TABLE [dbo].[TicketAssignees] DROP CONSTRAINT [FK__TicketAss__Assig__778AC167]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ProductVe__Produ__5812160E]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProductVersions]'))
ALTER TABLE [dbo].[ProductVersions] DROP CONSTRAINT [FK__ProductVe__Produ__5812160E]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Component__Produ__38996AB5]') AND parent_object_id = OBJECT_ID(N'[dbo].[Components]'))
ALTER TABLE [dbo].[Components] DROP CONSTRAINT [FK__Component__Produ__38996AB5]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Companies__Creat__5535A963]') AND parent_object_id = OBJECT_ID(N'[dbo].[Companies]'))
ALTER TABLE [dbo].[Companies] DROP CONSTRAINT [FK__Companies__Creat__5535A963]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__Userprofi__DateC__282DF8C2]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Userprofiles] DROP CONSTRAINT [DF__Userprofi__DateC__282DF8C2]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__Userprofi__Statu__33D4B598]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Userprofiles] DROP CONSTRAINT [DF__Userprofi__Statu__33D4B598]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__Userprofi__UserT__32E0915F]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Userprofiles] DROP CONSTRAINT [DF__Userprofi__UserT__32E0915F]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__Tickets__DateCre__6D0D32F4]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [DF__Tickets__DateCre__6D0D32F4]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__Tickets__Status__6B24EA82]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [DF__Tickets__Status__6B24EA82]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TicketAtt__DateC__70DDC3D8]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TicketAttachments] DROP CONSTRAINT [DF__TicketAtt__DateC__70DDC3D8]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TicketAss__DateC__787EE5A0]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TicketAssignees] DROP CONSTRAINT [DF__TicketAss__DateC__787EE5A0]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__Companies__DateC__5441852A]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Companies] DROP CONSTRAINT [DF__Companies__DateC__5441852A]
END

GO
/****** Object:  Table [dbo].[Userprofiles]    Script Date: 6/29/2016 10:09:55 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Userprofiles]') AND type in (N'U'))
DROP TABLE [dbo].[Userprofiles]
GO
/****** Object:  Table [dbo].[Tickets]    Script Date: 6/29/2016 10:09:55 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tickets]') AND type in (N'U'))
DROP TABLE [dbo].[Tickets]
GO
/****** Object:  Table [dbo].[TicketComments]    Script Date: 6/29/2016 10:09:55 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TicketComments]') AND type in (N'U'))
DROP TABLE [dbo].[TicketComments]
GO
/****** Object:  Table [dbo].[TicketAudit]    Script Date: 6/29/2016 10:09:55 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TicketAudit]') AND type in (N'U'))
DROP TABLE [dbo].[TicketAudit]
GO
/****** Object:  Table [dbo].[TicketAttachments]    Script Date: 6/29/2016 10:09:55 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TicketAttachments]') AND type in (N'U'))
DROP TABLE [dbo].[TicketAttachments]
GO
/****** Object:  Table [dbo].[TicketAssignees]    Script Date: 6/29/2016 10:09:55 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TicketAssignees]') AND type in (N'U'))
DROP TABLE [dbo].[TicketAssignees]
GO
/****** Object:  Table [dbo].[SupportMembers]    Script Date: 6/29/2016 10:09:55 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SupportMembers]') AND type in (N'U'))
DROP TABLE [dbo].[SupportMembers]
GO
/****** Object:  Table [dbo].[StatusTypes]    Script Date: 6/29/2016 10:09:55 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StatusTypes]') AND type in (N'U'))
DROP TABLE [dbo].[StatusTypes]
GO
/****** Object:  Table [dbo].[StatusCodes]    Script Date: 6/29/2016 10:09:55 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StatusCodes]') AND type in (N'U'))
DROP TABLE [dbo].[StatusCodes]
GO
/****** Object:  Table [dbo].[ProductVersions]    Script Date: 6/29/2016 10:09:55 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProductVersions]') AND type in (N'U'))
DROP TABLE [dbo].[ProductVersions]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 6/29/2016 10:09:55 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Products]') AND type in (N'U'))
DROP TABLE [dbo].[Products]
GO
/****** Object:  Table [dbo].[Components]    Script Date: 6/29/2016 10:09:55 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Components]') AND type in (N'U'))
DROP TABLE [dbo].[Components]
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 6/29/2016 10:09:55 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Companies]') AND type in (N'U'))
DROP TABLE [dbo].[Companies]
GO
/****** Object:  StoredProcedure [dbo].[spIsEmailIdExists]    Script Date: 6/29/2016 10:09:55 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spIsEmailIdExists]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spIsEmailIdExists]
GO
/****** Object:  StoredProcedure [dbo].[spInsertUser]    Script Date: 6/29/2016 10:09:55 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertUser]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spInsertUser]
GO
/****** Object:  StoredProcedure [dbo].[IsUserExits]    Script Date: 6/29/2016 10:09:55 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IsUserExits]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[IsUserExits]
GO
/****** Object:  StoredProcedure [dbo].[IsDeactivateUser]    Script Date: 6/29/2016 10:09:55 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IsDeactivateUser]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[IsDeactivateUser]
GO
/****** Object:  StoredProcedure [dbo].[IsDeactivateUser]    Script Date: 6/29/2016 10:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IsDeactivateUser]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create proc [dbo].[IsDeactivateUser]
@UID bigint
as 
begin
	delete from Userprofiles where UID=@UID
end' 
END
GO
/****** Object:  StoredProcedure [dbo].[IsUserExits]    Script Date: 6/29/2016 10:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IsUserExits]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[IsUserExits]
@Username varchar(200),
@Password varchar(50),
@Status bit out
as
begin
   if exists(select 1 from Userprofiles where Username=@Username and Password=@Password)

   begin
   set @Status=1
   end;
   else
   begin
   set @Status=0;
   end;

end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertUser]    Script Date: 6/29/2016 10:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertUser]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[spInsertUser]

@Username varchar(200),

@Password varchar(50),

@FirstName varchar(100),

@LastName varchar(100),

@CreatedBy bigint,

@GUID uniqueidentifier,

@UserType int,

@Status int,

@CompanyId bigint

as

begin

     insert into Userprofiles (Username,Password,Firstname,Lastname,CreatedBy,GUID,UserType,Status,CompanyId) 	
	  values(@Username,@Password,@FirstName,@LastName,@CreatedBy,@GUID,@UserType,@Status,@CompanyId);

end' 
END
GO
/****** Object:  StoredProcedure [dbo].[spIsEmailIdExists]    Script Date: 6/29/2016 10:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spIsEmailIdExists]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[spIsEmailIdExists]

@EmailId varchar(200),

@Status bit out

As



Begin 

	if exists(select Username from Userprofiles where Username=@EmailId)
	begin

	set @Status=1

	 

	end;

	else

	begin

	  set @Status=0

	end;



End' 
END
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 6/29/2016 10:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Companies]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Companies](
	[CompanyId] [bigint] IDENTITY(1,1) NOT NULL,
	[ClientName] [varchar](200) NOT NULL,
	[TicketStartNumber] [bigint] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateModified] [datetime] NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CurrentTicketNumber] [bigint] NOT NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [dbo].[Components]    Script Date: 6/29/2016 10:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Components]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Components](
	[ComponentId] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductId] [bigint] NOT NULL,
	[Status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ComponentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Products]    Script Date: 6/29/2016 10:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Products]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Products](
	[ProductId] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](200) NULL,
	[CompanyId] [bigint] NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [dbo].[ProductVersions]    Script Date: 6/29/2016 10:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProductVersions]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ProductVersions](
	[ProductId] [bigint] NULL,
	[VersionId] [int] NOT NULL,
	[Version] [varchar](200) NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[VersionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [dbo].[StatusCodes]    Script Date: 6/29/2016 10:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StatusCodes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StatusCodes](
	[StatusId] [int] IDENTITY(1,1) NOT NULL,
	[StatusCode] [int] NOT NULL,
	[Description] [varchar](200) NOT NULL,
	[StatusTypeId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StatusCode] ASC,
	[StatusTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [dbo].[StatusTypes]    Script Date: 6/29/2016 10:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StatusTypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StatusTypes](
	[StatusTypeId] [int] IDENTITY(1,1) NOT NULL,
	[StatusType] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[StatusTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[StatusType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [dbo].[SupportMembers]    Script Date: 6/29/2016 10:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SupportMembers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SupportMembers](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[EmailId] [varchar](200) NOT NULL,
	[CompanyId] [bigint] NOT NULL,
	[BranchId] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [dbo].[TicketAssignees]    Script Date: 6/29/2016 10:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TicketAssignees]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TicketAssignees](
	[TicketAssigneeId] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[TicketId] [numeric](18, 0) NOT NULL,
	[AssignedTo] [bigint] NOT NULL,
	[IsPrimary] [bit] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateModified] [datetime] NULL,
	[CreatedBy] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TicketId] ASC,
	[AssignedTo] ASC,
	[IsPrimary] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[TicketAttachments]    Script Date: 6/29/2016 10:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TicketAttachments]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TicketAttachments](
	[AttacmentId] [numeric](18, 0) NOT NULL,
	[Attachment] [varbinary](1) NOT NULL,
	[TicketId] [numeric](18, 0) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateModified] [datetime] NULL,
	[CreatedBy] [bigint] NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [dbo].[TicketAudit]    Script Date: 6/29/2016 10:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TicketAudit]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TicketAudit](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[TicketId] [numeric](18, 0) NOT NULL,
	[Remarks] [varchar](200) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateModified] [datetime] NULL,
	[CreatedBy] [bigint] NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [dbo].[TicketComments]    Script Date: 6/29/2016 10:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TicketComments]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TicketComments](
	[CommentId] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[TicketId] [numeric](18, 0) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateModified] [datetime] NULL,
	[CreatedBy] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CommentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Tickets]    Script Date: 6/29/2016 10:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tickets]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Tickets](
	[TicketId] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[TicketNo] [numeric](18, 0) NOT NULL,
	[Title] [varchar](200) NOT NULL,
	[Description] [varchar](200) NULL,
	[ProductId] [bigint] NOT NULL,
	[ComponentId] [bigint] NULL,
	[Version] [varchar](50) NULL,
	[Status] [int] NOT NULL,
	[CompanyId] [bigint] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateModified] [datetime] NULL,
	[CreatedBy] [bigint] NOT NULL,
	[DateFixed] [datetime] NULL,
	[DateClosed] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[TicketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [dbo].[Userprofiles]    Script Date: 6/29/2016 10:09:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Userprofiles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Userprofiles](
	[UID] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](200) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Firstname] [varchar](200) NULL,
	[Lastname] [varchar](200) NULL,
	[Datemodified] [datetime] NULL,
	[CreatedBy] [bigint] NOT NULL,
	[GUID] [uniqueidentifier] NOT NULL,
	[UserType] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[CompanyId] [bigint] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__Companies__DateC__5441852A]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Companies] ADD  DEFAULT (((24)/(6))/(2016)) FOR [DateCreated]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TicketAss__DateC__787EE5A0]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TicketAssignees] ADD  DEFAULT (((24)/(6))/(2016)) FOR [DateCreated]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__TicketAtt__DateC__70DDC3D8]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TicketAttachments] ADD  DEFAULT (((24)/(6))/(2016)) FOR [DateCreated]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__Tickets__Status__6B24EA82]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Tickets] ADD  DEFAULT ((0)) FOR [Status]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__Tickets__DateCre__6D0D32F4]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Tickets] ADD  DEFAULT (((24)/(6))/(2016)) FOR [DateCreated]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__Userprofi__UserT__32E0915F]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Userprofiles] ADD  DEFAULT ((1)) FOR [UserType]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__Userprofi__Statu__33D4B598]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Userprofiles] ADD  DEFAULT ((0)) FOR [Status]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF__Userprofi__DateC__282DF8C2]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Userprofiles] ADD  DEFAULT (getdate()) FOR [DateCreated]
END

GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Companies__Creat__5535A963]') AND parent_object_id = OBJECT_ID(N'[dbo].[Companies]'))
ALTER TABLE [dbo].[Companies]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Userprofiles] ([UID])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Component__Produ__38996AB5]') AND parent_object_id = OBJECT_ID(N'[dbo].[Components]'))
ALTER TABLE [dbo].[Components]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ProductVe__Produ__5812160E]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProductVersions]'))
ALTER TABLE [dbo].[ProductVersions]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__TicketAss__Assig__778AC167]') AND parent_object_id = OBJECT_ID(N'[dbo].[TicketAssignees]'))
ALTER TABLE [dbo].[TicketAssignees]  WITH CHECK ADD FOREIGN KEY([AssignedTo])
REFERENCES [dbo].[SupportMembers] ([Id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__TicketAss__Ticke__76969D2E]') AND parent_object_id = OBJECT_ID(N'[dbo].[TicketAssignees]'))
ALTER TABLE [dbo].[TicketAssignees]  WITH CHECK ADD FOREIGN KEY([TicketId])
REFERENCES [dbo].[Tickets] ([TicketId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__TicketAtt__Ticke__6FE99F9F]') AND parent_object_id = OBJECT_ID(N'[dbo].[TicketAttachments]'))
ALTER TABLE [dbo].[TicketAttachments]  WITH CHECK ADD FOREIGN KEY([TicketId])
REFERENCES [dbo].[Tickets] ([TicketId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__TicketCom__Ticke__73BA3083]') AND parent_object_id = OBJECT_ID(N'[dbo].[TicketComments]'))
ALTER TABLE [dbo].[TicketComments]  WITH CHECK ADD FOREIGN KEY([TicketId])
REFERENCES [dbo].[Tickets] ([TicketId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Tickets__Company__6C190EBB]') AND parent_object_id = OBJECT_ID(N'[dbo].[Tickets]'))
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([CompanyId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Tickets__Compone__6A30C649]') AND parent_object_id = OBJECT_ID(N'[dbo].[Tickets]'))
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD FOREIGN KEY([ComponentId])
REFERENCES [dbo].[Components] ([ComponentId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Tickets__Created__6E01572D]') AND parent_object_id = OBJECT_ID(N'[dbo].[Tickets]'))
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Userprofiles] ([UID])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Tickets__Product__693CA210]') AND parent_object_id = OBJECT_ID(N'[dbo].[Tickets]'))
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO

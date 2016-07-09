USE [CRMDB]
GO
/****** Object:  StoredProcedure [dbo].[IsDeactivateUser]    Script Date: 7/9/2016 9:13:36 AM ******/
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
/****** Object:  StoredProcedure [dbo].[IsUserExits]    Script Date: 7/9/2016 9:13:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IsUserExits]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[IsUserExits]
@Username varchar(200),
@Password varchar(50),
@Status bit out,
@UID bigint out
as
begin
   if exists(select 1 from Userprofiles where Username=@Username and Password=@Password )

   begin
   set @Status=1
   select @UID=UID from Userprofiles where Username=@Username
   end;
   else
   begin
   set @Status=0;
   end;

end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[spActiveUser]    Script Date: 7/9/2016 9:13:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spActiveUser]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spActiveUser]
@guid Uniqueidentifier
as 
begin
Update UserProfiles set Status=2 where GUID=@guid
end' 
END
GO
/****** Object:  StoredProcedure [dbo].[spBindCompanies]    Script Date: 7/9/2016 9:13:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spBindCompanies]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create proc [dbo].[spBindCompanies]
as 
begin
select CompanyId,CompanyName from Companies
end' 
END
GO
/****** Object:  StoredProcedure [dbo].[spBindComponents]    Script Date: 7/9/2016 9:13:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spBindComponents]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create proc [dbo].[spBindComponents]
as 
begin
select ComponentId,ComponentName from Components
end' 
END
GO
/****** Object:  StoredProcedure [dbo].[spBindproducts]    Script Date: 7/9/2016 9:13:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spBindproducts]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create proc [dbo].[spBindproducts]
as 
begin
select ProductId,ProductName from Products
end' 
END
GO
/****** Object:  StoredProcedure [dbo].[spCreateCompany]    Script Date: 7/9/2016 9:13:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spCreateCompany]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create proc [dbo].[spCreateCompany]

@CompanyId bigint out,
@CompanyName	varchar,
@TicketStartNumber	bigint= 0,
@CreatedBy	bigint,
@CurrentTicketNumber bigint=0,
@Status	int=0
as
Begin
insert into Companies(CompanyName,TicketStartNumber,CreatedBy,CurrentTicketNumber,Status)
				values(@CompanyName,@TicketStartNumber,@CreatedBy,@CurrentTicketNumber,@Status)
				set @CompanyId=@@IDENTITY
end

' 
END
GO
/****** Object:  StoredProcedure [dbo].[spGetAllTickets]    Script Date: 7/9/2016 9:13:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spGetAllTickets]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create proc [dbo].[spGetAllTickets]
as
begin

select TicketNo,CompanyName,ProductName,ComponentName,Version,Title,Name as Assignee, tickets.DateCreated,
rank() over(order by tickets.ticketid) as R
from Companies 
left join tickets on tickets.CompanyId=Companies.CompanyId
left join products  p on tickets.ProductId=p.ProductId
left join components c on tickets.ComponentId=c.componentid
left join TicketAssignees ta on tickets.TicketId=ta.TicketId
left join SupportMembers sm on ta.AssignedTo=sm.Id
end;' 
END
GO
/****** Object:  StoredProcedure [dbo].[spgetCompanies]    Script Date: 7/9/2016 9:13:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spgetCompanies]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[spgetCompanies]
as 
begin
select CompanyId,CompanyName from Companies
end' 
END
GO
/****** Object:  StoredProcedure [dbo].[spGetProductInfo]    Script Date: 7/9/2016 9:13:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spGetProductInfo]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[spGetProductInfo]
@ProductId bigint
as
begin

select p.ProductId,ProductName,Version,p.CompanyId
from Products p
inner join Companies c on c.CompanyId=p.CompanyId
inner join ProductVersions pv on pv.ProductId=p.ProductId
where p.ProductId=@ProductId
end;' 
END
GO
/****** Object:  StoredProcedure [dbo].[spGetProducts]    Script Date: 7/9/2016 9:13:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spGetProducts]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[spGetProducts]
@startIndex bigint,
@EndIndex bigint,
@ProductName varchar(200)

 as
  begin
     select *from(
     select p.ProductId, ProductName,CompanyName,Version,rank() over (order by p.productId) as R
     from Products p
     inner join Companies c on p.CompanyId=c.CompanyId 
	 inner join ProductVersions PV on p.ProductId=pv.ProductId
     where ProductName like @ProductName +''%'') P where P.r between @startIndex and @EndIndex
 end;
' 
END
GO
/****** Object:  StoredProcedure [dbo].[spGetTickets]    Script Date: 7/9/2016 9:13:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spGetTickets]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'Create proc [dbo].[spGetTickets]
@CompanyName varchar(200),
@StartIndex bigint,
@EndIndex bigint
as
begin

select * from (
select TicketNo,CompanyName,ProductName,ComponentName,Version,Title,Name as Assignee, tickets.DateCreated,
rank() over(order by tickets.ticketid) as R
from Companies 
inner join tickets on tickets.CompanyId=Companies.CompanyId
inner join products  p on tickets.ProductId=p.ProductId
inner join components c on tickets.ComponentId=c.componentid
left join TicketAssignees ta on tickets.TicketId=ta.TicketId
left join SupportMembers sm on ta.AssignedTo=sm.Id
where CompanyName like @CompanyName+''%'') T where t.R between @StartIndex and @EndIndex;
end;' 
END
GO
/****** Object:  StoredProcedure [dbo].[spGetUserProfilebyId]    Script Date: 7/9/2016 9:13:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spGetUserProfilebyId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[spGetUserProfilebyId]
@UID bigint 
AS
Begin
select Username,Password,Firstname,Lastname,c.CompanyName from Userprofiles up join Companies c on up.CompanyId=c.CompanyId where UID=@UID
End' 
END
GO
/****** Object:  StoredProcedure [dbo].[spGetUsers]    Script Date: 7/9/2016 9:13:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spGetUsers]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[spGetUsers]
(@StartIndex bigint,
@EndIndex  bigint)

as
begin

/*
	declare @TempTable as Table(Id bigint identity(1,1), UID bigint);

	insert into @TempTable
	select UID  from userprofiles;

	select * from @temptable t 
	inner join UserProfiles u
	on t.UID=u.UID
	
	
	where id between @startindex and @endindex

	-------
	*/
	--declare @Startindex int,@endindex int
	--set @Startindex=3
	--set @endindex=10

	select t.* from (select *, Rank() over (order by UID ) as SNO from userprofiles) t
	where SNO between @Startindex and @endindex





end;' 
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertTicket]    Script Date: 7/9/2016 9:13:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spInsertTicket]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[spInsertTicket]
@TicketNo    numeric(18,0),
@Title       varchar(200),
@Description varchar(400),
@ComponentId	bigint,
@Version     varchar(50),
@ProductId   bigint,
@CompanyId    int,
@CreatedBy bigint
as
begin
     insert into Tickets(TicketNo,Title,Description,ComponentId,Version,ProductId,CompanyId,Status,DateCreated,CreatedBy)		   

	  values(@TicketNo,@Title,@Description,@ComponentId,@Version,@ProductId,@CompanyId,0,GETDATE(),@CreatedBy);
end' 
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertUser]    Script Date: 7/9/2016 9:13:36 AM ******/
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
/****** Object:  StoredProcedure [dbo].[spIsEmailIdExists]    Script Date: 7/9/2016 9:13:36 AM ******/
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
/****** Object:  StoredProcedure [dbo].[spRegisterUser]    Script Date: 7/9/2016 9:13:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spRegisterUser]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE proc [dbo].[spRegisterUser]
(@Username varchar(200),
@Password varchar(50),
@CompanyName varchar(200),
@Guid  uniqueidentifier out)
as

begin
declare @uid bigint
declare @CompanyId  bigint
	   set @Guid=newid()
		insert into userprofiles(Username, password,guid,CompanyId, CreatedBy, Usertype, Status)
		values (@Username, @Password,@guid,0,0,1,0);
		set @uid=@@identity
		

		insert into Companies(CompanyName,TicketStartNumber, CurrentTicketNumber, CreatedBy)
		values (@CompanyName,1,0, @uid);
		set @CompanyId=@@Identity

		update userprofiles set CompanyId=@CompanyId where uid=@uid





end;' 
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateUserProfile]    Script Date: 7/9/2016 9:13:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdateUserProfile]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[spUpdateUserProfile]
	@UID bigint,
	@Username varchar(200),
	@Password varchar(50),
	@FirstName varchar(100),
	@LastName varchar(100),
	--@DateModifed datetime,
	@CompanyName varchar(200)
as 
begin 
	declare @CompanyId bigint
	Update Userprofiles set
	Username=@Username,
	Password=@Password,
	Firstname=@FirstName,
	Lastname=@LastName,
	Datemodified = GETDATE()
	where UID=@UID
	select @CompanyId=CompanyId from Userprofiles where UID=@UID
	  
	Update Companies set
	CompanyName = @CompanyName,
	DateModified=GETDATE()
	Where CompanyId=@CompanyId
	
end' 
END
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 7/9/2016 9:13:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Companies]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Companies](
	[CompanyId] [bigint] NOT NULL,
	[CompanyName] [varchar](200) NOT NULL,
	[TicketStartNumber] [bigint] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateModified] [datetime] NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CurrentTicketNumber] [bigint] NOT NULL,
	[Status] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Components]    Script Date: 7/9/2016 9:13:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Components]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Components](
	[ComponentId] [bigint] NOT NULL,
	[ProductId] [bigint] NOT NULL,
	[Status] [int] NOT NULL,
	[ComponentName] [varchar](50) NULL
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Products]    Script Date: 7/9/2016 9:13:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Products]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Products](
	[ProductId] [bigint] NOT NULL,
	[ProductName] [varchar](200) NULL,
	[CompanyId] [bigint] NULL,
	[Status] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductVersions]    Script Date: 7/9/2016 9:13:36 AM ******/
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
	[Status] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StatusCodes]    Script Date: 7/9/2016 9:13:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StatusCodes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StatusCodes](
	[StatusId] [int] NOT NULL,
	[StatusCode] [int] NOT NULL,
	[Description] [varchar](200) NOT NULL,
	[StatusTypeId] [int] NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StatusTypes]    Script Date: 7/9/2016 9:13:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StatusTypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StatusTypes](
	[StatusTypeId] [int] NOT NULL,
	[StatusType] [varchar](100) NULL
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SupportMembers]    Script Date: 7/9/2016 9:13:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SupportMembers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SupportMembers](
	[Id] [bigint] NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[EmailId] [varchar](200) NOT NULL,
	[CompanyId] [bigint] NOT NULL,
	[BranchId] [bigint] NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TicketAssignees]    Script Date: 7/9/2016 9:13:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TicketAssignees]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TicketAssignees](
	[TicketAssigneeId] [numeric](18, 0) NOT NULL,
	[TicketId] [numeric](18, 0) NOT NULL,
	[AssignedTo] [bigint] NOT NULL,
	[IsPrimary] [bit] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateModified] [datetime] NULL,
	[CreatedBy] [bigint] NOT NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[TicketAttachments]    Script Date: 7/9/2016 9:13:36 AM ******/
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TicketAudit]    Script Date: 7/9/2016 9:13:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TicketAudit]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TicketAudit](
	[Id] [numeric](18, 0) NOT NULL,
	[TicketId] [numeric](18, 0) NOT NULL,
	[Remarks] [varchar](200) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateModified] [datetime] NULL,
	[CreatedBy] [bigint] NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TicketComments]    Script Date: 7/9/2016 9:13:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TicketComments]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TicketComments](
	[CommentId] [numeric](18, 0) NOT NULL,
	[TicketId] [numeric](18, 0) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateModified] [datetime] NULL,
	[CreatedBy] [bigint] NOT NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Tickets]    Script Date: 7/9/2016 9:13:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tickets]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Tickets](
	[TicketId] [numeric](18, 0) NOT NULL,
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
	[DateClosed] [datetime] NULL
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Userprofiles]    Script Date: 7/9/2016 9:13:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Userprofiles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Userprofiles](
	[UID] [bigint] NOT NULL,
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
	[DateCreated] [datetime] NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO

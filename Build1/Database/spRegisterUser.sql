USE [CRMDB]
GO

/****** Object:  StoredProcedure [dbo].[spRegisterUser]    Script Date: 7/16/2016 3:33:39 PM ******/
DROP PROCEDURE [dbo].[spRegisterUser]
GO

/****** Object:  StoredProcedure [dbo].[spRegisterUser]    Script Date: 7/16/2016 3:33:39 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




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





end;
GO



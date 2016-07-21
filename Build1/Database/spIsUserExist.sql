USE [CRMDB]
GO

/****** Object:  StoredProcedure [dbo].[IsUserExits]    Script Date: 2016-07-14 10:28:41 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Alter procedure [dbo].[IsUserExits]
@Username varchar(200),
@Password varchar(50),
@Status bit out,
@UID bigint out,
@CompanyId bigint out
as
begin
   if exists(select 1 from Userprofiles where Username=@Username and Password=@Password )

   begin
   set @Status=1
   select @UID=UID,@CompanyId=CompanyId from Userprofiles where Username=@Username
   end;

   else
   begin
   set @Status=0;
   set @CompanyId=0;
   set @UID=0;
   end;

end

GO



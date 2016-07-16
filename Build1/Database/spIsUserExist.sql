USE [CRMDB]
GO

drop proc [dbo].[IsUserExits]
/****** Object:  StoredProcedure [dbo].[IsUserExits]    Script Date: 7/16/2016 12:59:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[IsUserExits]
@Username varchar(200),
@Password varchar(50),
@Status bit out,
@UID bigint out,
@CompanyId bigint out,
@Name varchar(100) out
as
begin
   if exists(select 1 from Userprofiles where Username=@Username and Password=@Password )

   begin
   set @Status=1
   select @UID=UID,@CompanyId=CompanyId, @Name=FirstName  from Userprofiles where Username=@Username
   
   end;
   else
   begin
   set @Status=0;
   set @UID=0
   set @CompanyId=0
   set @Name=''
   end;

end


GO



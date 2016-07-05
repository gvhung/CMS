USE [CRMDB]
GO
/****** Object:  StoredProcedure [dbo].[spGetUserProfilebyId]    Script Date: 2016-07-05 5:55:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[spGetUserProfilebyId]
@UID bigint 
AS
Begin
select Username,Password,c.ClientName from Userprofiles up join Companies c on up.CompanyId=c.CompanyId where UID=@UID
End
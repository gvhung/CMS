
/****** Object:  StoredProcedure [dbo].[spGetProducts]    Script Date: 7/7/2016 11:04:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[spGetProducts]
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
     where ProductName like @ProductName +'%') P where P.r between @startIndex and @EndIndex
 end;

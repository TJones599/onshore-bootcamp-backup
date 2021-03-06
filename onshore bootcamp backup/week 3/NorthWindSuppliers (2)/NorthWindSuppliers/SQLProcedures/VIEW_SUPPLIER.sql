USE [NORTHWND]
GO
/****** Object:  StoredProcedure [dbo].[VIEW_SUPPLIER_TABLE]    Script Date: 9/21/2018 4:01:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[VIEW_SUPPLIER_TABLE]
AS
BEGIN
	SELECT [SupplierID] 
	  ,[CompanyName]
      ,[ContactName]
      ,[ContactTitle]
      ,[Address]
      ,[City]
      ,[Region]
      ,[PostalCode]
      ,[Country]
      ,[Phone]
      ,[Fax]
      ,[HomePage]
	FROM Suppliers
END
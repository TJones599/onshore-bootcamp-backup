CREATE PROCEDURE VIEW_ROW_BY_ID
(
	   @SupplierID INT
)
AS
BEGIN
SELECT [CompanyName]
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
WHERE SupplierId = @SupplierID
END
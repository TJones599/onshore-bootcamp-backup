CREATE PROCEDURE CREATE_SUPPLIER
(
	@CompanyName NVARCHAR(40),
	@ContactName NVARCHAR(30),
	@ContactTitle NVARCHAR(30),
	@Address NVARCHAR(60),
	@City NVARCHAR(15),
	@Region NVARCHAR(15),
	@PostalCode NVARCHAR(10),
	@Country NVARCHAR(15),
	@Phone NVARCHAR(24),
	@Fax NVARCHAR(24),
	@HomePage NTEXT
)
AS
BEGIN
	INSERT INTO Suppliers (
	   [CompanyName],
       [ContactName],
       [ContactTitle],
       [Address],
       [City],
       [Region],
       [PostalCode],
       [Country],
       [Phone],
       [Fax],
       [HomePage])

	VALUES (
	   @CompanyName,
       @ContactName,
       @ContactTitle,
       @Address,
       @City,
       @Region,
       @PostalCode,
       @Country,
       @Phone,
       @Fax,
       @HomePage
	)
END
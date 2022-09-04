PRINT 'Creating Model Sales Company Staging Tables'

PRINT 'Dropping staging tables if they exist'

DROP TABLE IF EXISTS stageOrderDetail;
DROP TABLE IF EXISTS stageOrder;
DROP TABLE IF EXISTS stageCustomer;
DROP TABLE IF EXISTS stageEmployee;
DROP TABLE IF EXISTS stageOffice;
DROP TABLE IF EXISTS stageProduct;
DROP TABLE IF EXISTS stageProductLine;

PRINT 'Creating stageOffice table'

CREATE TABLE stageOffice (
	officeKey			int			IDENTITY(1,1)	PRIMARY KEY,
	officeCode			varchar(10)		NOT NULL,
	city				varchar(50)		NOT NULL,
	phone				varchar(50)		NOT NULL,
	addressLine1		varchar(50)		NOT NULL,
	addressLine2		varchar(50)		NULL,
	state				varchar(50)		NULL,
	country				varchar(50)		NOT NULL,
	postalCode			varchar(15)		NOT NULL,
	territory			varchar(10)		NOT NULL
);


PRINT 'Creating stageEmployee table'

CREATE TABLE stageEmployee (
	employeeKey			int				IDENTITY(1,1)	PRIMARY KEY,
	employeeNumber		int				NOT NULL,
	lastName			varchar(50)		NOT NULL,
	firstName			varchar(50)		NOT NULL,
	extension			varchar(10)		NOT NULL,
	email				varchar(100)	NOT NULL,
	officeKey			int				NOT NULL,
	reportsToKey		int				NULL,
	jobTitle			varchar(50)		NOT NULL,
	CONSTRAINT fk_reportsToKey FOREIGN KEY(reportsToKey) REFERENCES stageEmployee(employeeKey),
	CONSTRAINT fk_officeKey FOREIGN KEY(officeKey) REFERENCES stageOffice(officeKey)
);

PRINT 'Creating stageCustomer table'

CREATE TABLE stageCustomer (
	customerKey				int				IDENTITY(1,1)	PRIMARY KEY,
	customerNumber			int				NOT NULL,
	customerName			varchar(50)		NOT NULL,
	contactLastName			varchar(50)		NOT NULL,
	contactFirstName		varchar(50)		NOT NULL,
	phone					varchar(50)		NOT NULL,
	addressLine1			varchar(50)		NOT NULL,
	addressLine2			varchar(50)		NULL,
	city					varchar(50)		NOT NULL,
	state					varchar(50)		NULL,
	postalCode				varchar(15)		NULL,
	country					varchar(50)		NOT NULL,
	creditLimit				decimal(10,2)	NULL,
	salesRepEmployeeNumber	int				NULL,
	CONSTRAINT fk_salesRep FOREIGN KEY(salesRepEmployeeNumber) REFERENCES stageEmployee(employeeKey)
);


PRINT 'Creating stageProductLine table'

CREATE TABLE stageProductLine (
	productLineKey		int				IDENTITY(1,1)	PRIMARY KEY,
	productLine			varchar(50)		NOT NULL,
	textDescription		varchar(4000)	NULL,
	HTMLDescription		text			NULL,
	productImage		image			NULL
);


PRINT 'Creating stageProduct table'

CREATE TABLE stageProduct (
	productKey			int				IDENTITY(1,1)	PRIMARY KEY,
	productCode			varchar(15)		NOT NULL,
	productName			varchar(70)		NOT NULL,
	productLineKey		int				NOT NULL,
	productScale		varchar(10)		NOT NULL,
	productVendor		varchar(50)		NOT NULL,
	productDescription	text			NOT NULL,
	quantityInStock		smallint		NOT NULL,
	buyPrice			decimal(10,2)	NOT NULL,
	MSRP				decimal(10,2)	NOT NULL,
	CONSTRAINT fk_productLineKey FOREIGN KEY (productLineKey) REFERENCES stageProductLine (productLineKey)
);

PRINT 'Creating stageOrder table'

CREATE TABLE stageOrder (
	orderKey			int				IDENTITY(1,1)	PRIMARY KEY,
	orderNumber			int				NOT NULL,
	orderDate			date			NOT NULL,
	requiredDate		date			NULL,
	shippedDate			date			NULL,
	status				varchar(15)		NOT NULL,
	comments			text			NULL,
	customerKey			int				NOT NULL,
	CONSTRAINT fk_customerKey			FOREIGN KEY (customerKey)		REFERENCES stageCustomer(customerKey),
	CONSTRAINT ch_status				CHECK (status IN ('Shipped', 'Cancelled', 'Disputed', 'In Process', 'On Hold', 'Resolved'))
	);

PRINT 'Create stageOrderDetail table'

CREATE TABLE stageOrderDetail (
	saleKey				int				IDENTITY(1,1)	PRIMARY KEY,
	orderKey			int				NOT NULL,
	productKey			int				NOT NULL,
	quantityOrdered		int				NULL,
	priceEach			decimal(10,2)	NOT NULL,
	orderLineNumber		smallint		NOT NULL,
	CONSTRAINT fk_productKey			FOREIGN KEY(productKey)			REFERENCES stageProduct(productKey),
	CONSTRAINT fk_orderKey				FOREIGN KEY(orderKey)			REFERENCES stageOrder(orderKey)
);

PRINT 'Staging tables complete'

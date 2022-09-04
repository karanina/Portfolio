PRINT 'Creating Model Sales Company Data Warehouse'

PRINT 'Dropping fact and dimension tables if they exist'

DROP TABLE IF EXISTS factSale;
DROP TABLE IF EXISTS dimCustomer;
DROP TABLE IF EXISTS dimEmployee;
DROP TABLE IF EXISTS dimProduct;
DROP TABLE IF EXISTS dimDate;
DROP TABLE IF EXISTS Numbers_Small;
DROP TABLE IF EXISTS Numbers_Big;

PRINT 'Creating and populating dimDate table'

CREATE TABLE Numbers_Small (Number INT);
INSERT INTO Numbers_Small VALUES (0),(1),(2),(3),(4),(5),(6),(7),(8),(9);

CREATE TABLE Numbers_Big (Number_Big BIGINT);
INSERT INTO Numbers_Big ( Number_Big )
SELECT thousands.number * 1000 + hundreds.number * 100 + tens.number * 10 + ones.number as number_big
FROM numbers_small thousands, numbers_small hundreds, numbers_small tens, numbers_small ones;

CREATE TABLE dimDate(
[dateKey] [int] NOT NULL PRIMARY KEY,
[date] [date] NULL,
[day] [char](10) NULL,
[dayOfWeek] [smallint] NULL,
[dayOfMonth] [smallint] NULL,
[dayOfYear] [smallint] NULL,
[weekOfYear] [smallint] NULL,
[month] [char](10) NULL,
[monthOfYear] [smallint] NULL,
[quarterOfYear] [smallint] NULL,
[year] [int] NULL
);
INSERT INTO dimDate(dateKey, date) values(-1,'9999-12-31'); -- Create dummy for a "null" date/time
INSERT INTO dimDate (dateKey, date)
SELECT number_big, DATEADD(day, number_big,  '2013-01-01') as date
FROM numbers_big
WHERE DATEADD(day, number_big,  '2013-01-01') BETWEEN '2013-01-01' AND '2016-12-31'
ORDER BY number_big;

UPDATE dimDate
SET day			= DATENAME(DW, date),
dayOfWeek		= DATEPART(WEEKDAY, date),
dayOfMonth		= DAY(date),
dayOfYear		= DATEPART(DY,date),
weekOfYear		= DATEPART(WK,date),
month			= DATENAME(MONTH,date),
monthOfYear		= MONTH(date),
quarterOfYear	= DATEPART(Q, date),
year			= YEAR(date);

DROP TABLE Numbers_Small;
DROP TABLE Numbers_Big;

Go

PRINT 'Creating dimCustomer table'

CREATE TABLE dimCustomer (
	customerKey			int				IDENTITY(1,1)	PRIMARY KEY,
	customerNumber		int				NOT NULL,
	customerName		varchar(50)		NOT NULL,
	contactLastName		varchar(50)		NOT NULL,
	contactFirstName	varchar(50)		NOT NULL,
	phone				varchar(50)		NOT NULL,
	addressLine1		varchar(50)		NOT NULL,
	addressLine2		varchar(50)		NULL,
	city				varchar(50)		NOT NULL,
	state				varchar(50)		NULL,
	postalCode			varchar(15)		NULL,
	country				varchar(50)		NOT NULL,
	creditLimit			decimal(10,2)	NULL
);

PRINT 'Creating dimEmployee table'

CREATE TABLE dimEmployee (
	employeeKey			int				IDENTITY(1,1)	PRIMARY KEY,
	employeeNumber		int				NOT NULL,
	lastName			varchar(50)		NOT NULL,
	firstName			varchar(50)		NOT NULL,
	extension			varchar(10)		NOT NULL,
	email				varchar(100)	NOT NULL,
	reportsTo			varchar(100)	NULL,
	jobTitle			varchar(50)		NOT NULL,
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

PRINT 'Creating dimProduct table'

CREATE TABLE dimProduct (
	productKey			int				IDENTITY(1,1)	PRIMARY KEY,
	productCode			varchar(15)		NOT NULL,
	productName			varchar(70)		NOT NULL,
	productScale		varchar(10)		NOT NULL,
	productVendor		varchar(50)		NOT NULL,
	productDescription	text			NOT NULL,
	quantityInStock		smallint		NOT NULL,
	buyPrice			decimal(10,2)	NOT NULL,
	MSRP				decimal(10,2)	NOT NULL,
	productLine			varchar(50)		NOT NULL,
	textDescription		varchar(4000)	NULL,
	HTMLDescription		text			NULL,
	productImage		image			NULL
);

PRINT 'Creating factSale table'

CREATE TABLE factSale (
	saleKey				int				IDENTITY(1,1)	PRIMARY KEY,
	orderNumber			int				NOT NULL,
	orderDateKey		int				NOT NULL,
	requiredDateKey		int				NULL,
	shippedDateKey		int				NULL,
	status				varchar(15)		NOT NULL,
	comments			text			NULL,
	customerKey			int				NOT NULL,
	productKey			int				NOT NULL,
	quantityOrdered		int				NULL,
	priceEach			decimal(10,2)	NOT NULL,
	totalPrice			decimal(10,2)	NULL,
	totalProfit			decimal(10,2)	NULL,
	totalPossibleProfit	decimal(10,2)	NULL,
	orderLineNumber		smallint		NOT NULL,
	salesRepKey			int				NULL,
	CONSTRAINT fk_productKey_dp			FOREIGN KEY(productKey)			REFERENCES dimProduct(productKey),
	CONSTRAINT fk_orderDateKey_dt		FOREIGN KEY(orderDateKey)		REFERENCES dimDate(DateKey),
	CONSTRAINT fk_requiredDateKey_dt	FOREIGN KEY(requiredDateKey)	REFERENCES dimDate(DateKey),
	CONSTRAINT fk_shippedDateKey_dt		FOREIGN KEY(shippedDateKey)		REFERENCES dimDate(DateKey),
	CONSTRAINT fk_customerKey_dc		FOREIGN KEY (customerKey)		REFERENCES dimCustomer(customerKey),
	CONSTRAINT fk_salesRepKey_de		FOREIGN KEY (salesRepKey)		REFERENCES dimEmployee(employeeKey),
	CONSTRAINT ch_orderStatus			CHECK (status IN ('Shipped', 'Cancelled', 'Disputed', 'In Process', 'On Hold', 'Resolved'))
);

PRINT 'Data Warehouse build complete'

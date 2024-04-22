use master 
go 
Create database Ass2_Prn221_Bl5
go
use [Ass2_Prn221_Bl5]
go 
create table Customers
(
	CustomerID int Identity(1,1) Primary key,
	[Password] varchar(50),
	ContactName nvarchar(50),
	Adress nvarchar(100),
	Phone varchar(10) unique,
);

create table Categories
(
	CategoryID int identity(1,1) Primary key,
	CategoryName nvarchar(50) Unique not null,
	[Description] nvarchar(256), 
);
Create table Suppliers
(
	SupplierID int Identity(1,1) primary key,
	CompanyName nvarchar(100),
	[Address] nvarchar(100),
	Phone varchar(20) unique,
);
Create table Account
(
	AccountID int identity(1,1) Primary Key,
	UserName varchar(50) not null unique,
	[Password] varchar(100) not null,
	FullName nvarchar(100) not null,
	[Type] bit not null,
);
Create table Products
(	
	ProductID int identity(1,1) primary key,
	ProductName nvarchar(100) not null,
	SupplierID int foreign key references Suppliers(SupplierID),
	CategoryID int foreign key references Categories(CategoryID),
	QuantityPerUnit int Default '0' check (QuantityPerUnit >= 0) not null,
	UnitPrice float not null check (UnitPrice >= 0),
	ProductImage varchar(256),
);
Create table Orders
(
	OrderID int Identity(1,1) Primary key,
	CustomerID int foreign key references Customers(CustomerID),
	OrderDate datetime not null,
	RequiredDate Datetime,
	ShippedDate datetime,
	Freight float,
	ShippedAddress nvarchar(100),
);
Create table OrderDetails
(
	OrderID int foreign key references Orders(OrderID),
	ProductID int foreign key references Products(ProductID),
	UnitPrice float not null check (UnitPrice >= 0),
	Quantity int not null check (Quantity >= 1),
	Primary key(OrderID, ProductID)
);

-- Customers table
INSERT INTO Customers ([Password], ContactName, Adress, Phone)
VALUES 
('pass123', 'John Doe', '123 Main St, Cityville', '1234567890'),
('abc456', 'Jane Smith', '456 Oak Ave, Townsville', '0987654321'),
('qwerty', 'Alice Johnson', '789 Elm Rd, Villagetown', '1357924680'),
('password123', 'Bob Brown', '321 Pine Ln, Hamletville', '2468013579'),
('letmein', 'Emily Davis', '654 Cedar Dr, Countryside', '9876543210');

-- Categories table
INSERT INTO Categories (CategoryName, [Description])
VALUES 
('Electronics', 'Electronic devices and accessories'),
('Clothing', 'Apparel and fashion accessories'),
('Books', 'Literature and educational material'),
('Home & Garden', 'Products for household and outdoor use'),
('Toys & Games', 'Entertainment and recreational items');

-- Suppliers table
INSERT INTO Suppliers (CompanyName, [Address], Phone)
VALUES 
('ElectroMart', '123 Tech Blvd, Tech City', '123-456-7890'),
('FashionHub', '456 Style St, Fashion Town', '456-789-0123'),
('BookBarn', '789 Read Ave, Booksville', '789-012-3456'),
('HomeDepot', '321 Garden Rd, Green City', '321-654-9870'),
('ToyLand', '654 Play Ln, Fun Town', '654-987-0123');

-- Account table
INSERT INTO Account (UserName, [Password], FullName, [Type])
VALUES 
('user1', 'pass123', 'John Doe', 1),
('user2', 'abc456', 'Jane Smith', 1),
('admin1', 'qwerty', 'Alice Johnson', 0),
('admin2', 'password123', 'Bob Brown', 0),
('user3', 'letmein', 'Emily Davis', 1);

-- Products table
INSERT INTO Products (ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, ProductImage)
VALUES 
('Smartphone', 1, 1, 1, 599.99, 'smartphone.jpg'),
('T-shirt', 2, 2, 1, 19.99, 'tshirt.jpg'),
('History Book', 3, 3, 1, 29.99, 'historybook.jpg'),
('Garden Hose', 4, 4, 1, 29.99, 'gardenhose.jpg'),
('Board Game', 5, 5, 1, 24.99, 'boardgame.jpg');

-- Orders table
INSERT INTO Orders (CustomerID, OrderDate, RequiredDate, ShippedDate, Freight, ShippedAddress)
VALUES 
(1, '2024-04-15', '2024-04-20', '2024-04-18', 10.50, '123 Main St, Cityville'),
(2, '2024-04-16', '2024-04-21', NULL, 8.75, '456 Oak Ave, Townsville'),
(3, '2024-04-14', '2024-04-19', '2024-04-17', 12.00, '789 Elm Rd, Villagetown'),
(4, '2024-04-17', '2024-04-22', NULL, 15.25, '321 Pine Ln, Hamletville'),
(5, '2024-04-13', '2024-04-18', '2024-04-16', 9.99, '654 Cedar Dr, Countryside');

-- OrderDetails table
INSERT INTO OrderDetails (OrderID, ProductID, UnitPrice, Quantity)
VALUES 
(1, 1, 599.99, 1),
(2, 2, 19.99, 2),
(3, 3, 29.99, 1),
(4, 4, 29.99, 3),
(5, 5, 24.99, 1);

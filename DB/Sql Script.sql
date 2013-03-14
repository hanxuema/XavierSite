CREATE TABLE Posts
(
	PostId INT NOT NULL PRIMARY KEY IDENTITY, 
    Title Nvarchar(50) not null,
	Content NVARCHAR(MAX) NOT NULL,
	CreatedDate datetime not null,
	ModifiedDate datetime not null,
	UserId int not null
)


CREATE TABLE Comments
(
	CommetId INT NOT NULL PRIMARY KEY IDENTITY , 
    Content NVARCHAR(400) NOT NULL, 
    CreatedDate DateTime NOT NULL,
	PostId int not null,
	UserId int not null
)


CREATE TABLE Users
(
	[UserId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserName] VARCHAR(50) NOT NULL, 
    [EmailAddress] VARCHAR(50) NOT NULL,
	[Password] varchar(20) not null
)

 
CREATE TABLE Products
(
	[ProductId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [Price] DECIMAL NOT NULL, 
    [Quantity] INT NOT NULL,
	[Category] INT NOT NULL
)

 CREATE TABLE Orders
(
	OrderId INT NOT NULL PRIMARY KEY identity,
	UserId int not null,
	DeliveryAddress nvarchar(max) not null,
	CreatedDate datetime not null,
	OrderStatus int not null,
)

CREATE TABLE [dbo].[OrderProducts](
	[OrderProductId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL
)

CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL
)
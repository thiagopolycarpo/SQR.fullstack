USE SQRPRODUCTION;

-- Create Orders table
CREATE TABLE Orders (
    OrderId VARCHAR(50) PRIMARY KEY,
    Quantity NUMERIC(18,2),
    ProductCode VARCHAR(50)
);

-- Create Products table
CREATE TABLE Products (
    ProductCode VARCHAR(50) PRIMARY KEY,
    ProductDescription VARCHAR(50),
    Image VARCHAR(500),
    CycleTime NUMERIC(18,2)
);

-- Create Materials table
CREATE TABLE Materials (
    MaterialCode VARCHAR(50) PRIMARY KEY,
    MaterialDescription VARCHAR(500)
);

-- Create ProductMaterials table
CREATE TABLE ProductMaterials (
    ProductCode VARCHAR(50),
    MaterialCode VARCHAR(50),
    PRIMARY KEY (ProductCode, MaterialCode),
    FOREIGN KEY (ProductCode) REFERENCES Products(ProductCode),
    FOREIGN KEY (MaterialCode) REFERENCES Materials(MaterialCode)
);

-- Create Users table
CREATE TABLE Users (
    Email VARCHAR(100) PRIMARY KEY,
    Name VARCHAR(50),
    InitialDate DATETIME,
    EndDate DATETIME
);

-- Create Productions table
CREATE TABLE Productions (
    Id BIGINT IDENTITY(1,1) PRIMARY KEY,
    Email VARCHAR(100),
    OrderId VARCHAR(50),
    Date DATETIME,
    Quantity NUMERIC(18,2),
    MaterialCode VARCHAR(50),
    CycleTime NUMERIC(18,2),
    FOREIGN KEY (Email) REFERENCES Users(Email),
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),
    FOREIGN KEY (MaterialCode) REFERENCES Materials(MaterialCode)
);
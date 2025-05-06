USE SQRPRODUCTION;

-- Insert Users
INSERT INTO Users (Email, Name, InitialDate, EndDate)
VALUES ('teste@sequor.com.br', 'Test User', '2020-01-01 00:00:00.000', '2025-12-31 00:00:00.000');

-- Insert Products
INSERT INTO Products (ProductCode, ProductDescription, Image, CycleTime)
VALUES 
    ('abc', 'xxx', '0x000001', 30.3),
    ('def', 'yyy', '0x00000', 45.5);

-- Insert Orders
INSERT INTO Orders (OrderId, Quantity, ProductCode)
VALUES 
    ('111', 100.00, 'abc'),
    ('222', 200.00, 'def');

-- Insert Materials
INSERT INTO Materials (MaterialCode, MaterialDescription)
VALUES 
    ('aaa', 'desc1'),
    ('bbb', 'desc2'),
    ('ccc', 'desc3');

-- Insert ProductMaterials
INSERT INTO ProductMaterials (ProductCode, MaterialCode)
VALUES 
    ('abc', 'aaa'),
    ('abc', 'bbb'),
    ('def', 'ccc'),
    ('def', 'bbb');

-- Insert Productions (sample data for GetProduction)
INSERT INTO Productions (Email, OrderId, Date, Quantity, MaterialCode, CycleTime)
VALUES 
    ('teste@sequor.com.br', '111', '2022-02-13 10:33:03.000', 1, 'aaa', 30.3),
    ('teste@sequor.com.br', '111', '2022-01-10 10:30:17.000', 50, 'aaa', 36.3),
    ('teste@sequor.com.br', '111', '2022-01-10 10:30:19.000', 50, 'aaa', 120),
    ('teste@sequor.com.br', '111', '2022-01-10 10:30:21.000', 50, 'aaa', 12);

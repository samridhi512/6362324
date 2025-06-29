USE TestDB;
GO

DROP TABLE Products;
GO

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10, 2)
);
INSERT INTO Products (ProductID, ProductName, Category, Price)
VALUES 
(1, 'iPhone 12', 'Mobiles', 799),
(2, 'Samsung S21', 'Mobiles', 749),
(3, 'OnePlus 9', 'Mobiles', 729),
(4, 'Nokia X', 'Mobiles', 699),
(5, 'LG Wing', 'Mobiles', 749),

(6, 'MacBook Pro', 'Laptops', 1299),
(7, 'Dell XPS', 'Laptops', 1199),
(8, 'HP Spectre', 'Laptops', 1199),
(9, 'Asus ZenBook', 'Laptops', 1099),
(10, 'Lenovo Yoga', 'Laptops', 1049);
SELECT *
FROM (
    SELECT 
        ProductID,
        ProductName,
        Category,
        Price,
        ROW_NUMBER() OVER(PARTITION BY Category ORDER BY Price DESC) AS RowNum
    FROM Products
) AS Ranked
WHERE RowNum <= 3;
SELECT *
FROM (
    SELECT 
        ProductID,
        ProductName,
        Category,
        Price,
        RANK() OVER(PARTITION BY Category ORDER BY Price DESC) AS RankNum
    FROM Products
) AS Ranked
WHERE RankNum <= 3;
SELECT *
FROM (
    SELECT 
        ProductID,
        ProductName,
        Category,
        Price,
        DENSE_RANK() OVER(PARTITION BY Category ORDER BY Price DESC) AS DenseRank
    FROM Products
) AS Ranked
WHERE DenseRank <= 3;

use Northwind
go

--1
select distinct City 
from dbo.Customers
where City in (select distinct City from dbo.Employees)


--2a

select distinct City  
from dbo.Customers   
where City not in (select distinct City from dbo.Employees)

--2b

SELECT DISTINCT c.City
FROM dbo.Customers c
LEFT JOIN dbo.Employees e ON c.City = e.City
WHERE e.EmployeeID IS NULL;


--3

select p.ProductID as Products, SUM(od.Quantity) as "Total Order Quantity"
from dbo.Products p join dbo.[Order Details] od on p.ProductID = od.ProductID
GROUP by p.ProductID

--4

select c.City as City, SUM(od.Quantity) as "Total Order Quantity"
from dbo.Customers c join dbo.Orders o on c.CustomerID = o.CustomerID join dbo.[Order Details] od on o.OrderID = od.OrderID
GROUP by c.City

--5a

SELECT City
FROM dbo.Customers
GROUP BY City
HAVING COUNT(CustomerID) >= 2;

--5b

SELECT DISTINCT c1.City
FROM dbo.Customers c1
INNER JOIN dbo.Customers c2 ON c1.City = c2.City AND c1.CustomerID <> c2.CustomerID;


--6

select c.City 
from dbo.Customers c join dbo.Orders o on c.CustomerID = o.CustomerID
join dbo.[Order Details] od on o.OrderID = od.OrderID
GROUP by c.City
having count(*) >1

--7

select distinct c.CustomerID as Customers 
from dbo.Customers c join dbo.Orders o on c.CustomerID=o.CustomerID
where c.City != o.ShipCity

--8
WITH ProductSales AS (
    SELECT 
        od.ProductID,
        p.ProductName,
        AVG(od.UnitPrice) AS AvgPrice,
        o.ShipCity AS CustomerCity,
        SUM(od.Quantity) AS TotalQuantity,
        ROW_NUMBER() OVER (ORDER BY SUM(od.Quantity) DESC) AS RowNum
    FROM 
        dbo.[Order Details] od
    JOIN 
        dbo.Orders o ON od.OrderID = o.OrderID
    JOIN 
        dbo.Products p ON od.ProductID = p.ProductID
    GROUP BY 
        od.ProductID, p.ProductName, o.ShipCity
)
SELECT 
    ProductName,
    AvgPrice,
    CustomerCity,
    TotalQuantity
FROM 
    ProductSales
WHERE 
    RowNum <= 5;



--9a

select e.City 
from dbo.Employees e 
where e.City not in (select o.ShipCity from dbo.Orders o)

--9b

select distinct e.City 
from dbo.Employees e left join dbo.Orders o on e.City = o.ShipCity
where o.OrderID is NULL

--10

WITH EmployeeSales AS (
    SELECT 
        e.EmployeeID,
        o.ShipCity AS MostOrdersCity,
        ROW_NUMBER() OVER (PARTITION BY e.EmployeeID ORDER BY COUNT(o.OrderID) DESC) AS OrdersRowNum,
        ROW_NUMBER() OVER (ORDER BY SUM(od.Quantity) DESC) AS QuantityRowNum
    FROM 
        dbo.Orders o
    JOIN 
        dbo.Employees e ON o.EmployeeID = e.EmployeeID
    JOIN 
        dbo.[Order Details] od ON o.OrderID = od.OrderID
    GROUP BY 
        e.EmployeeID, o.ShipCity
)
SELECT 
    MostCity
FROM 
    (
        SELECT 
            MostOrdersCity AS MostCity,
            ROW_NUMBER() OVER (ORDER BY COUNT(*) DESC) AS RowNum
        FROM 
            EmployeeSales
        WHERE 
            OrdersRowNum = 1
        GROUP BY 
            MostOrdersCity
    ) mo
UNION ALL
SELECT 
    MostCity
FROM 
    (
        SELECT 
            MostOrdersCity AS MostCity,
            ROW_NUMBER() OVER (ORDER BY SUM(od.Quantity) DESC) AS RowNum
        FROM 
            EmployeeSales
        WHERE 
            QuantityRowNum = 1
        GROUP BY 
            MostOrdersCity
    ) mq
WHERE 
    mo.RowNum = 1 OR mq.RowNum = 1;

--11

--To remove duplicate records from a table in SQL, you can use the DELETE statement with a common table expression (CTE) and the ROW_NUMBER() window function to identify and delete duplicates. 
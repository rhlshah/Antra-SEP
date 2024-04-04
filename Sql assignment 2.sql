use AdventureWorks2019
go

--1

select count(ProductID) as Total_Products
from Production.Product

--2

select count(*) as Total_Products
from Production.Product as p 
where p.ProductSubCategoryID is not NULL

--3

select p.ProductSubCategoryID, count(*) as Total_Products
from Production.Product as p 
GROUP by p.ProductSubCategoryID

--4

select count(*) as ProductsWithoutSubCategory
from Production.Product as p 
where p.ProductSubCategoryID is NULL

--5

select ProductID, SUM(Quantity) as TheSUM
from Production.ProductInventory
GROUP by ProductID

--6

select ProductID, SUM(Quantity) as TheSUM
from Production.ProductInventory
where LocationID = 40
group by ProductID
having SUM(Quantity) < 100

--7

select Shelf, ProductID, SUM(Quantity) as TheSUM
from Production.ProductInventory
where LocationID = 40
group by ProductID, Shelf
having SUM(Quantity) < 100


--8

select ProductID, AVG(Quantity) as TheAvg
from Production.ProductInventory
where LocationID = 10
GROUP by ProductID

--9

select ProductID, Shelf, AVG(Quantity) as TheAvg
from Production.ProductInventory
GROUP by ProductID, Shelf

--10
select ProductID, Shelf, AVG(Quantity) as TheAvg
from Production.ProductInventory
where Shelf != 'N/A'
GROUP by ProductID, Shelf

--11
select Color, Class, COUNT(ListPrice) as TheCount, AVG(ListPrice) as AvgPrice
from Production.Product
where Color is not null and Class is not NULL
group by Color, Class

--12

select c.Name as Country, s.Name as Province
from Person.StateProvince as s join Person.CountryRegion as c on s.CountryRegionCode = c.CountryRegionCode

--13

select c.Name as Country, s.Name as Province
from Person.StateProvince as s join Person.CountryRegion as c on s.CountryRegionCode = c.CountryRegionCode
where c.Name in ('Germany', 'Canada')

--14
use Northwind
go

SELECT DISTINCT p.ProductID
FROM dbo.Products p
JOIN dbo."Order Details" od ON p.ProductID = od.ProductID
JOIN dbo.Orders o ON od.OrderID = o.OrderID
WHERE o.OrderDate >= DATEADD(YEAR, -26, GETDATE());

--15

SELECT TOP 5 o.ShipPostalCode AS ZipCode, COUNT(*) AS TotalProductsSold
FROM dbo.Orders o
JOIN dbo."Order Details" od ON o.OrderID = od.OrderID
where o.ShipPostalCode is not null
GROUP BY o.ShipPostalCode
ORDER BY COUNT(*) DESC;

--16
SELECT TOP 5 o.ShipPostalCode AS ZipCode, COUNT(*) AS TotalProductsSold
FROM dbo.Orders o
JOIN dbo."Order Details" od ON o.OrderID = od.OrderID
where o.ShipPostalCode is not null and o.OrderDate >= DATEADD(YEAR, -26, GETDATE())
GROUP BY o.ShipPostalCode
ORDER BY COUNT(*) DESC;

--17
select City, Count(*) as NumberOfCustomers 
from dbo.Customers
group by City

--18
select City, Count(*) as NumberOfCustomers 
from dbo.Customers
group by City
having Count(*) > 2

--19

SELECT c.ContactName,o.OrderDate
FROM  dbo.Customers c
JOIN dbo.Orders o ON c.CustomerID = o.CustomerID
WHERE o.OrderDate > '1998-01-01';

--20

SELECT c.ContactName,o.MostRecentOrderDate
FROM dbo.Customers c
JOIN (SELECT CustomerID,MAX(OrderDate) AS MostRecentOrderDate FROM dbo.Orders GROUP BY CustomerID) o ON c.CustomerID = o.CustomerID;

--21

select c.ContactName, Count(od.ProductID) as TotalProducts
from dbo.Customers c join dbo.Orders o on c.CustomerID = o.CustomerID
join dbo."Order Details" od on o.OrderID = od.OrderID
group by c.ContactName 

--22
select c.CustomerID, Count(od.ProductID) as TotalProducts
from dbo.Customers c join dbo.Orders o on c.CustomerID = o.CustomerID
join dbo."Order Details" od on o.OrderID = od.OrderID
group by c.CustomerID
having Count(od.ProductID) > 100 

--23

select su.CompanyName as "Supplier Company Name", sh.CompanyName as "Shipping Company Name"
from dbo.Shippers sh join dbo.Suppliers su on su.SupplierID = sh.ShipperID

--24

SELECT o.OrderDate, p.ProductName
FROM dbo.Products p
JOIN dbo."Order Details" od ON p.ProductID = od.ProductID
JOIN dbo.Orders o ON od.OrderID = o.OrderID


--25

SELECT e1.EmployeeID AS EmployeeID1,e2.EmployeeID AS EmployeeID2,  e1.Title AS Title
FROM dbo.Employees e1
JOIN dbo.Employees e2 ON e1.Title = e2.Title
WHERE e1.EmployeeID < e2.EmployeeID;


--26

SELECT  M.EmployeeID AS ManagerID
FROM dbo.Employees AS M
JOIN dbo.Employees AS E ON M.EmployeeID = E.ReportsTo
GROUP BY M.EmployeeID
HAVING COUNT(E.EmployeeID) > 2;

--27

SELECT  City, CompanyName AS Name,ContactName AS ContactName,'Customer' AS Type
FROM dbo.Customers
UNION ALL
SELECT City,CompanyName AS Name,ContactName AS ContactName, 'Supplier' AS Type
FROM dbo.Suppliers
ORDER BY City, Name, Type;

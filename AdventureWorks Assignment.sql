use AdventureWorks2019
go

--1

SELECT ProductID, Name, Color, ListPrice
from Production.Product 

--2

SELECT ProductID, Name, Color, ListPrice
from Production.Product 
where ListPrice != 0

--3

SELECT ProductID, Name, Color, ListPrice
from Production.Product 
where Color is NULL

--4

SELECT ProductID, Name, Color, ListPrice
from Production.Product 
where Color is not NULL

--5

SELECT ProductID, Name, Color, ListPrice
from Production.Product 
where Color is not NULL and ListPrice > 0

--6

select Name + Color
from Production.Product
where Color is not NULL

--7

SELECT Name + ' --  COLOR: ' + Color AS ProductDetails
FROM Production.Product
WHERE Name IN ('LL Crankarm', 'ML Crankarm', 'HL Crankarm', 'Chainring Bolts', 'Chainring Nut', 'Chainring')
ORDER BY Name, Color


--8

select ProductID, Name 
from Production.Product
where ProductID BETWEEN 400 and 500

--9
select ProductID, Name, Color 
from Production.Product
where Color in ('Black', 'Blue')

--10

select * 
from Production.Product
where Name like 'S%'

--11

select Name, ListPrice
from Production.Product
order by Name

--12

select Name, ListPrice
from Production.Product
where Name like '[AS]%'
order by Name

--13

select * 
from Production.Product
where Name like '[SPO][^K]%'
order by Name

--14

select distinct Color 
from Production.Product
order by Color desc


--15

select distinct ProductSubcategoryID, Color 
from Production.Product
where ProductSubcategoryID is not null and Color is not NULL
order by ProductSubcategoryID, Color
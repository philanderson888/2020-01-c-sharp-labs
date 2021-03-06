﻿use northwind
go

select top 5 * from customers
select top 5 * from customers order by customerid desc

-- quiz : find count of employees in London
select count(*) from employees where city='London'
-- find all titles of courtesy given to employees
select * from employees
select Employees.TitleOfCourtesy from Employees
select count(TitleOfCourtesy) from Employees
select count(distinct TitleOfCourtesy) from Employees
-- how many 'dr.' employees exist?
select count(TitleOfCourtesy) AS NumberOfEmployees from employees 
	where TitleOfCourtesy = 'Dr.'
-- how many discontinued products exist
select * from Products
select count(*) from Products where Discontinued=1

-- offset = skip
-- first 5 customers
select top(5) * from customers
-- next 5 customers
select *  from customers order by customerid 
	offset 5 rows 
	fetch next 5 rows only
-- next 5 customers
select *  from customers order by customerid 
	offset 10 rows 
	fetch next 5 rows only

-- how many products with categoryid = 1 and discontinued?  
select count(*) from products where categoryid=1 and discontinued=1 -- 1
-- how many products with items in stock and unitprice > 29.99
select count(*) from products where unitsinstock>0 and unitprice>29.99 --22
-- order the above list to show products ordered by unit price descending
select products.unitprice, ProductName from products where unitsinstock>0 and unitprice>29.99 
	order by unitprice desc
-- how many distinct countries exist in customers table?
select count (distinct country) from customers --21
-- how many distinct cities exist in customers table?
select count (distinct city) from customers --69



-- LIKE
-- % is a wildcard for anything   %a%   contains a
--                                 a%   starts with
--                                 %a   ends with

-- _ is a wildcard for ONE CHARACTER

-- how many products contain 'ch'
select * from products where ProductName LIKE '%ch%'
select count(*) from products where ProductName LIKE '%ch%' -- 14

-- how many regions contain the letter 'a' in Customers
select count(*) from customers where region LIKE '%a%'  -- 8

-- how many regions start with a
select count(*) from customers where region LIKE 'a%'  -- 1
-- how many regions end with a
select count(*) from customers where region LIKE '%a'  -- 1

-- NOT LIKE reverses the query

-- how many products do not contain 'ch'
select count(*) from products where ProductName NOT LIKE '%ch%' -- 63

-- using _ UNDERSCORE to represent SINGLE CHARACTER WILDCARD

-- how many regions have 'A' as second letter (first letter wildcard)
select region, * from customers where region LIKE '_a%'

-- OR but for long lists, use IN for a shorter version
select region,* from customers where region IN ('wa','ca')

-- BETWEEN FOR NUMERIC RANGES

-- how many products which are not discontinued have unitprice between 10.00 and 40.00
select count(*) from products where Discontinued=0 and unitprice between 10.00 and 40.00 -- 50

-- how many products start with B, S or T
select count(*) from products where productname LIKE ('B%') OR PRODUCTNAME LIKE ('s%') OR PRODUCTNAME LIKE ('t%')
--select count(*) from products where contains (productname,'"b%" or "s%" or "t%"')

-- how many product categoryname start with C or S -- 37
select count(*) from products 
JOIN Categories 
ON products.CategoryID = categories.categoryid
where categoryname LIKE 'C%' OR CATEGORYNAME LIKE 'S%'

-- concatenation
-- select customers but join 'city and country' into one column eg 'lives in'

select  concat (city,', ',country) as livesin,* from Customers
select city + ', ' + country as livesin,* from Customers



-- customer => order => details of order (order_details)
-- select orders for ALFKI customer
select * from orders where customerid = 'alfki'

-- have a look at order details as well
select * from orders 
join [Order Details] on orders.OrderID = [Order Details].OrderID
where customerid = 'alfki'

-- create a query to have orderid, productname and quantity 
select orderid, productname, quantity,* from products
join [Order Details] on [Order Details].ProductID = products.ProductID

-- filter orders by customer 'alfki' to show product names
select * from orders
select * from [Order Details]
select * from products 

select customerid, orders.orderid, productname, Quantity, [order details].UnitPrice from orders
join [Order Details] on Orders.OrderID = [order details].OrderID
join Products on [order details].ProductID = products.ProductID
where customerid = 'alfki'



-- GOAL IS TO LIST, FOR ANY GIVEN CUSTOMER, THE ORDER DETAILS.  
-- REMEMBER TO GET TO THE ORDER DETAILS WE HAVE TO GO FIRST THROUGH ORDERS TABLE
--  CUSTOMER ==> ORDER ==> ORDER_DETAILS
                  --              PRODUCTID BOUGHT, QUANTITY, PRICE AND DISCOUNT
--   NOTE : CUSTOMERID IS ALREADY IN ORDERS TABLE 

-- get customer contactname and all orders for customerid='alfki'
select c.customerid, contactname, orderid from customers c
join orders o on c.CustomerID = o.CustomerID
where c.customerid = 'alfki'

-- develop this to show productid as well (ie include order_details table)
select c.customerid, contactname, o.OrderID, ProductID from customers c
join orders o on c.CustomerID = o.CustomerID
join [Order Details] od on o.OrderID = od.OrderID
where c.customerid = 'alfki'

-- productName
select c.customerid, contactname, o.OrderID, p.ProductID, ProductName from customers c
join orders o on c.CustomerID = o.CustomerID
join [Order Details] od on o.OrderID = od.OrderID
join products p on od.productid = p.productid
where c.customerid = 'alfki'

--add in quantity price and discount
select c.customerid, contactname, o.OrderID, p.ProductID, ProductName, od.Quantity , od.UnitPrice , od.Discount
from customers c
join orders o on c.CustomerID = o.CustomerID
join [Order Details] od on o.OrderID = od.OrderID
join products p on od.productid = p.productid
where c.customerid = 'alfki'

-- now can add some CALCULATED COLUMNS eg ORDER BEFORE DISCOUNT 
select c.customerid, contactname, o.OrderID, p.ProductID, ProductName, od.Quantity , od.UnitPrice , 
od.Discount * 100  as 'Percentage Discount' ,
od.UnitPrice * od.Quantity as 'Order Before Discount', 
od.UnitPrice * od.Quantity * od.Discount as 'Discount',
od.UnitPrice * od.Quantity - od.UnitPrice * od.Quantity * od.Discount as 'Order After Discount',
od.UnitPrice * od.Quantity * (1 - od.Discount) as 'order after discount'
from  customers c
join orders o on c.CustomerID = o.CustomerID
join [Order Details] od on o.OrderID = od.OrderID
join products p on od.productid = p.productid
where c.customerid = 'alfki'

-- can we get totals  (HAVE TO OMIT THE OTHER FIELDS FOR NOW)
select  
sum (od.Quantity) as 'quantity total', 
sum (od.UnitPrice * od.Quantity) as 'Order Before Discount', 
sum (od.UnitPrice * od.Quantity * od.Discount) as 'Discount',
sum (od.UnitPrice * od.Quantity * (1 - od.Discount)) as 'order after discount'
from  customers c
join orders o on c.CustomerID = o.CustomerID
join [Order Details] od on o.OrderID = od.OrderID
join products p on od.productid = p.productid
where c.customerid = 'alfki'

-- Now we have this working for ONE CUSTOMER ALKFI.
-- How can we get this working for ALL CUSTOMERS???
-- can use a GROUP BY condition which groups results by a column
-- SO WE CAN REPEAT THESE TOTALS AND GROUP BY CUSTOMERID
select  
c.customerid,
sum (od.Quantity) as 'quantity total', 
sum (od.UnitPrice * od.Quantity) as 'Order Before Discount', 
sum (od.UnitPrice * od.Quantity * od.Discount) as 'Discount',
sum (od.UnitPrice * od.Quantity * (1 - od.Discount)) as 'order after discount'
from  customers c
join orders o on c.CustomerID = o.CustomerID
join [Order Details] od on o.OrderID = od.OrderID
join products p on od.productid = p.productid
group by c.customerid

-- sort results by biggest spender!
select  
c.customerid,
sum (od.Quantity) as 'quantity total', 
sum (od.UnitPrice * od.Quantity) as 'Order Before Discount', 
sum (od.UnitPrice * od.Quantity * od.Discount) as 'Discount',
sum (od.UnitPrice * od.Quantity * (1 - od.Discount)) as 'order after discount'
from  customers c
join orders o on c.CustomerID = o.CustomerID
join [Order Details] od on o.OrderID = od.OrderID
join products p on od.productid = p.productid
group by c.customerid
order by [order after discount] desc

-- filter where discount is not zero  (WHERE)
-- also only show orders where total order after discount > 10000 (HAVING)
select  
c.customerid,
sum (od.Quantity) as 'quantity total', 
sum (od.UnitPrice * od.Quantity) as 'Order Before Discount', 
sum (od.UnitPrice * od.Quantity * od.Discount) as 'Discount Price',
sum (od.UnitPrice * od.Quantity * (1 - od.Discount)) as 'order after discount'
from  customers c
join orders o on c.CustomerID = o.CustomerID
join [Order Details] od on o.OrderID = od.OrderID
join products p on od.productid = p.productid
where od.Discount > 0

group by c.customerid
having sum (od.UnitPrice * od.Quantity * (1 - od.Discount)) > 10000

order by [order after discount] desc



-- ### STRING MANIUPLATION

-- SUBSTRING from first given index (1-based counting) and specify number of letters to return
SELECT SUBSTRING('verylongstring',3,6)  -- from index 3 (3rd character) for 6 letters -- rylong

-- CHARINDEX -- get the index of character where it is placed inside long string
--              NOTE AGAIN INDEX IS NOT ZERO BASED COUNTING SO RETURS 6 = 6TH CHARACTER
SELECT CHARINDEX ('a','verylangstrang')
SELECT CHARINDEX (' ','TM44 5AZ')  -- SPLIT UP A POSTCODE USING THIS

-- LEFT/RIGHT  RETURN FIRST / LAST n characters
SELECT LEFT('verylongstring',4)  -- very
SELECT LEFT('TM44 5AZ',CHARINDEX (' ','TM44 5AZ')-1) -- should select TM44
SELECT RIGHT('TM44 5AZ', 3) -- should select 5AZ
SELECT RIGHT('TM44 5AZ', LEN('TM44 5AZ')-CHARINDEX (' ','TM44 5AZ')) -- should select 5AZ

-- LTRIM/RTRIM removes spaces
SELECT LTRIM(RTRIM(('   some data with space around   ')))

-- REPLACE
SELECT REPLACE('very long string','very','very very very extremely')

-- UPPER/LOWER
SELECT UPPER ('a long string in lower case')



-- DATES

-- TODAY
SELECT GetDate()
SELECT CONCAT('Today is ', GETDATE())
SELECT CONCAT('Tomorrow is ',DATEADD(d,1,GETDATE()))
SELECT CONCAT('Yesterday was ',DATEADD(d,-1,GETDATE()))
-- DATE DIFF  eg difference in days between today and a week's time
SELECT DATEDIFF(d, DATEADD(d,7,GETDATE()) ,  GETDATE()  )

-- d   or   dd    or  mm   or  yy  or   yyyy 

SELECT * FROM ORDERS 

-- WHAT'S THE LONGEST SHIPPING TIME???  SUBTRACT SHIPDATE FROM ORDERDATE AND GET MAX!
SELECT ORDERID, DATEDIFF(D, ORDERDATE, SHIPPEDDATE) AS SHIPPINGTIME
FROM ORDERS O
ORDER BY SHIPPINGTIME DESC

-- FLOOR - CONVERT TO INTEGER
select floor(10.65)
SELECT CEILING(10.65)
SELECT ROUND(10.49,0)
SELECT ROUND(10.50,0)

-- CASE .. WHEN .. ELSE

SELECT CASE
WHEN (10<11)
THEN '10 is small'
ELSE 'some other number'
END
AS 'is 10 small?'

SELECT * FROM ORDERS 


-- GROUP BY EXERCISES

--- PRINT CUSTOMERS GROUPED BY COUNTRY?
SELECT Count(Country),Country 
FROM Customers 
GROUP BY COUNTRY 

-- SUM THE COUNT
SELECT COUNT(COUNTRY) FROM CUSTOMERS GROUP BY COUNTRY

SELECT Country, ContactName
FROM Customers 
ORDER BY COUNTRY 

--- PRINT CUSTOMERS GROUPED BY CITY?
SELECT CITY, CONTACTNAME FROM CUSTOMERS ORDER BY CITY 

-- PRINT PRODUCTS GROUPED BY CATEGORY?
SELECT  COUNT(p.ProductName), c.CATEGORYNAME
FROM PRODUCTS p
INNER JOIN CATEGORIES c ON p.CategoryId = c.CategoryId
GROUP BY c.CategoryName

select CategoryName , c.CategoryID , ProductName 
FROM PRODUCTS p
INNER JOIN CATEGORIES c on p.CategoryID = c.CategoryID
ORDER BY C.CategoryName

-- all products
select * from products order by categoryid



--- LEFT, RIGHT, INNER, OUTER JOINS 

--- LEFT (OUTER) JOIN : ALL RECORDS FROM LEFT TABLE AND MATCHING FROM RIGHT TABLE

		-- ALL CUSTOMERS (BY CUSTOMERID) AND ANY MATCHING ORDERS

--- RIGHT (OUTER) JOIN : ALL ORDERS (BY ORDERID) AND ANY MATCHING CUSTOMERS 

--- OUTER JOIN = EITHER LEFT (OUTER) JOIN OR RIGHT (OUTER) JOIN WHICH ARE DESCRIBED ABOVE

--- INNER JOIN = ONLY FROM FIRST TABLE WHEN MATCHING SECOND TABLE

		-- ONLY CUSTOMERS WHO HAVE ORDERS, AND THEIR MATCHING ORDER

-- can we do an INNER JOIN and compare with STANDARD LEFT JOIN?  DO ALL CUSTOMERS HAVE ORDERS?
SELECT CustomerId 
FROM Customers c


SELECT COUNT(*) FROM CUSTOMERS
SELECT COUNT(*) FROM ORDERS 
SELECT c.CustomerId, o.OrderID
FROM Customers c 
LEFT JOIN Orders o on c.CustomerID = o.CustomerID
WHERE o.OrderID IS NULL
ORDER BY OrderID

-- NOW WE CAN CHECK LEFT JOIN VS INNER JOIN SHOULD DIFFER BY 2 RECORDS
SELECT COUNT(*)
FROM CUSTOMERS c
LEFT JOIN Orders o on c.CustomerID = o.CustomerID
SELECT COUNT(*)
FROM CUSTOMERS c
INNER JOIN Orders o on c.CustomerID = o.CustomerID
SELECT COUNT(*)
FROM CUSTOMERS c
FULL JOIN Orders o on c.CustomerID = o.CustomerID



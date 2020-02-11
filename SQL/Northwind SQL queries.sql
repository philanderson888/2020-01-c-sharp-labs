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
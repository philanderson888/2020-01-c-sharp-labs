-- system database
use master
go

-- create database
drop database if exists Users
go
create database Users
go
use Users
go

-- create Users and Categories

create table Categories(
  CategoryId INT NOT NULL PRIMARY KEY IDENTITY,
  CategoryName VARCHAR(50) NULL
)

create table Users(
   UserId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
   UserName VARCHAR(50) NULL,
   DateOfBirth DATE NULL,
   isValid BIT NULL,
   CategoryId INT NULL FOREIGN KEY REFERENCES Categories(CategoryId)
)

INSERT INTO CATEGORIES VALUES ('admin')
INSERT INTO CATEGORIES VALUES ('work')
INSERT INTO CATEGORIES VALUES ('personal')

INSERT INTO USERS VALUES ('fred','2020-10-10','true',1)
INSERT INTO USERS VALUES ('bill','2020-10-10','true',2)
INSERT INTO USERS VALUES ('wilma','2020-10-10','true',3)

SELECT * FROM USERS 
SELECT * FROM Categories

-- SQL JOIN SIMILAR TO LINQ 
SELECT * FROM USERS 
JOIN Categories
ON Users.CategoryId = Categories.CategoryId

SELECT UserId,UserName,isValid, CategoryName from USERS 
INNER JOIN Categories
ON Users.CategoryId = Categories.CategoryId



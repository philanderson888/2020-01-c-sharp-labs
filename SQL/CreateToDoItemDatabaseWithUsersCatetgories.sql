use master 
go

drop database if exists ToDoDatabase 
go

create database ToDoDatabase
go
use ToDoDatabase

CREATE TABLE users(
	UserId INT NOT NULL PRIMARY KEY IDENTITY,
	UserName VARCHAR(50) NULL
	
)
CREATE TABLE categories(
	CategoryId INT NOT NULL PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(50) NULL
)
CREATE TABLE ToDoItems(
	ToDoItemId INT NOT NULL PRIMARY KEY IDENTITY,
	ToDoItemName VARCHAR(50) NULL,
	StartDate DATE NULL,
	isDone BIT NULL,
	UserId INT NULL FOREIGN KEY REFERENCES Users(UserId),
	CategoryId INT NULL FOREIGN KEY REFERENCES Categories(CategoryId)
)

INSERT INTO USERS VALUES ('bob')
INSERT INTO USERS VALUES ('tim')
INSERT INTO USERS VALUES ('paul')
INSERT INTO CATEGORIES VALUES ('admin')
INSERT INTO CATEGORIES VALUES ('users')
INSERT INTO CATEGORIES VALUES ('personal')
INSERT INTO ToDoItems VALUES ('first item','2020-02-02','false',1,1)
INSERT INTO ToDoItems VALUES ('second item','2020-02-02','false',2,2)
INSERT INTO ToDoItems VALUES ('third item','2020-02-02','false',3,3)


ALTER TABLE Users ADD UserAge varchar(50) null
ALTER TABLE Users ALTER COLUMN UserAge INT NULL
UPDATE Users Set UserAge = 22 where UserId = 1;

select todoitemid, todoitemname, CategoryName, 
   UserName person_name, isDone, StartDate, 
   ToDoItems.CategoryId as ID, UserAge  from todoitems
join categories on ToDoItems.CategoryId = categories.CategoryId
join users on ToDoItems.UserId = users.UserId

select * from INFORMATION_SCHEMA.COLUMNS




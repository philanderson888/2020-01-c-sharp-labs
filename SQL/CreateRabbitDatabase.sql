use master
go


drop database if exists RabbitDatabase 
go

create database RabbitDatabase
go

use RabbitDatabase
go

create table Rabbits(
	RabbitId int not null primary key identity,
	RabbitName varchar(50) null,
	Age int null,
)



alter table Rabbits add DOB datetime NULL
alter table Rabbits add isActive bit NULL
alter table Rabbits add Type varchar(30) NULL

insert into Rabbits values('Rabbit01',0,'2019-01-01',true,'lapland')

select * from Rabbits 
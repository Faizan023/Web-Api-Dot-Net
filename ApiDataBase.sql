create database ApiHandling;
use  ApiHandling;

create table Employee(
EmployeeId int Identity(1,1) not null,
EmployeeName varchar(25) not null,
Email varchar(50) not null,
Number int not null,

constraint Pk_EmpId primary key (EmployeeId)
);

create table Department(
DepartmentId int identity(1,1) not null,
DepartmentName varchar(30) not null

constraint Pk_DepId primary key (DepartmentId)
);

insert into Employee( EmployeeName, Email,Number)
values('Faizan', 'mansurifaizan315@gmail.com', 1234567890);


insert into Employee( EmployeeName, Email,Number)
values('Afzal', 'mansuriafzal315@gmail.com', 1234567890);


insert into Employee( EmployeeName, Email,Number)
values('Idrish', 'mansuriidrish315@gmail.com', 1234567890);

insert into Department(DepartmentName)
values ('IT');

insert into Department(DepartmentName)
values ('Banking');
insert into Department(DepartmentName)
values ('Manager');

insert into Department(DepartmentName)
values ('HR');

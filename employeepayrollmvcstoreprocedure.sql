create database EmployeePayrollMVC


create table EmployeeMVCTable(
Emplooyeeid int identity primary key,
Employeename varchar(100),
Employeeimage varchar(255),
Gender varchar(100),
Department varchar(100),
Salary bigint,
Startdate datetime,
Notes varchar(100))


create procedure SpAddEmpDetails
@Employeename varchar(100),
@Employeeimage varchar(255),
@Gender varchar(100),
@Department varchar(100),
@Salary bigint,
@Startdate datetime,
@Notes varchar(100)
as 
begin 
insert into EmployeeMVCTable (Employeename,Employeeimage,Gender,Department,Salary,Startdate,Notes) values (@Employeename,@Employeeimage,@Gender,@Department,@Salary,@Startdate,@Notes)
end

create procedure SpUpdate
@Empid int ,
@Employeename varchar(100),
@Employeeimage varchar(255),
@Gender varchar(100),
@Department varchar(100),
@Salary bigint,
@Startdate datetime,
@Notes varchar(100)
as 
begin 
update EmployeeMVCTable
set Employeename=@Employeename,
Employeeimage=@Employeeimage,
Gender=@Gender,
Department=@Department,
Salary=@Salary,
Startdate=@Startdate,
Notes=@Notes
where Emplooyeeid=@Empid

end

create procedure spDeleteEmp
@Empid int 
as 
begin 
delete from EmployeeMVCTable where Emplooyeeid=@Empid
end

create procedure SpGetallEmp
as
begin
select *
from EmployeeMVCTable
end

create procedure SpGetallempbyid
@empid int 
as 
begin
select *
from EmployeeMVCTable
where Emplooyeeid=@empid
end
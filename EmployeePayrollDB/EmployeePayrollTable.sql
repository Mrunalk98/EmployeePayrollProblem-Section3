-- UC 2
create table employee_payroll(
ID int NOT NULL identity(1, 1) PRIMARY KEY,
Name varchar(50) NOT NULL,
StartDate datetime NOT NULL,
Salary decimal (12, 2) NOT NULL
);

-- UC 3
insert into employee_payroll values('Mrunal', '2020-10-01', 20000);
insert into employee_payroll values('Abc', '2020-01-01', 30000);
insert into employee_payroll values('Sam', '2020-03-01', 15000);
insert into employee_payroll values('John', '2020-08-01', 20000);

-- UC 4
select * from employee_payroll;

-- UC 5
select Salary from employee_payroll where Name='Mrunal';

select Salary from employee_payroll where StartDate between CAST('2020-02-01' AS DATE) AND GETDATE();


-- UC 6
alter table employee_payroll  add Gender char(1);
update employee_payroll set Gender='F' where Name = 'Mrunal' or Name='Sam';
update employee_payroll set Gender='M' where Name = 'Abc' or Name='John';

-- UC 7
select SUM(Salary) as TotalSalary from employee_payroll where Gender='F' group by Gender;
select AVG(Salary) from employee_payroll where Gender='M' group by Gender;
select COUNT(ID) from employee_payroll where Gender='F' group by Gender;

-- UC 8
alter table employee_payroll add PhoneNumber varchar(10);
alter table employee_payroll add Address varchar(30) NOT NULL default 'Mumbai';
alter table employee_payroll add Department varchar(30) NOT NULL default '';

update employee_payroll set PhoneNumber='9854785965' where Name = 'Mrunal';
update employee_payroll set PhoneNumber='7854785965' where Name = 'John';
update employee_payroll set PhoneNumber='8596541526' where Name='Abc';
update employee_payroll set PhoneNumber='7896541526' where Name='Sam';

update employee_payroll set Department='HR' where Name = 'Mrunal' or Name='John';
update employee_payroll set Department='R&D' where Name = 'Sam';
update employee_payroll set Department='Marketing' where Name = 'Abc';

--UC 9
alter table employee_payroll add BasicPay decimal(10, 2) NOT NULL default 0;
alter table employee_payroll add Deductions decimal(10, 2) NOT NULL default 0;
alter table employee_payroll add TaxablePay decimal(10, 2) NOT NULL default 0;
alter table employee_payroll add IncomeTax decimal(10, 2) NOT NULL default 0;
alter table employee_payroll add NetPay decimal(10, 2) NOT NULL default 0;

-- UC 11

create table payroll(
Payroll_ID int NOT NULL identity(1, 1) PRIMARY KEY,
BasicPay decimal(10,2) NOT NULL,
Deductions decimal(10,2) NOT NULL,
TaxablePay as (BasicPay-Deductions),
IncomeTax decimal(10,2) NOT NULL,
NetPay as ((BasicPay-Deductions)-IncomeTax),
StartDate datetime NOT NULL,
Emp_ID  int FOREIGN KEY REFERENCES employee(Emp_ID) ON DELETE CASCADE
);

create table employee(
Emp_ID int NOT NULL identity(1000, 1) PRIMARY KEY,
Emp_Name varchar(50) NOT NULL,
Emp_Phone varchar(50) NOT NULL,
Emp_Address varchar(50) NOT NULL,
Emp_Gender varchar(50) NOT NULL,
);

create table department(
Dept_ID int NOT NULL identity(10, 1) PRIMARY KEY,
Dept_Name varchar(50) NOT NULL
);

create table emp_dept(
Emp_ID int FOREIGN KEY REFERENCES employee(Emp_ID) ON DELETE CASCADE,
Dept_ID int FOREIGN KEY REFERENCES department(Dept_ID) ON DELETE CASCADE,
PRIMARY KEY (Emp_ID,Dept_ID)
);

select * from employee;
select * from payroll;
select * from department;
select * from emp_dept;

insert into employee values('Mrunal', '8596515265', 'LA', 'F');
insert into employee values('John', '9999515265', 'SA', 'M');
insert into employee values('Sam', '8899515265', 'LA', 'F');

insert into payroll values(2000, 200, 50, '2020-03-01', 1002);
insert into payroll values(4000, 250, 100, '2020-02-01', 1001);
insert into payroll values(3000, 150, 70, '2020-05-01', 1000);

insert into department values('HR');
insert into department values('R&D');
insert into department values('Marketing');

insert into emp_dept values(1000,10);
insert into emp_dept values(1001,10);
insert into emp_dept values(1001,12);
insert into emp_dept values(1002,11);

-- UC 12
select Emp_Name, Emp_Phone, Emp_Address, Emp_Gender, Emp_Phone, BasicPay, Deductions, TaxablePay, IncomeTax, NetPay
from employee inner join payroll
on employee.Emp_ID = payroll.Emp_ID;

select * from payroll where Emp_ID = (select Emp_ID from employee where Emp_Name='Mrunal');

select Emp_Name, Emp_Phone, Emp_Address, Emp_Gender, Emp_Phone, BasicPay, Deductions, TaxablePay, IncomeTax, NetPay
from employee inner join payroll
on employee.Emp_ID = payroll.Emp_ID
where StartDate between CAST('2020-03-01' AS DATE) AND GETDATE();

select SUM(NetPay) as Total_Salary, COUNT(payroll.Payroll_ID) as Total_Count
from payroll inner join employee
on employee.Emp_ID = payroll.Emp_ID
group by employee.Emp_Gender;

select Emp_Name, Emp_Phone, Emp_Address, Emp_Gender, Emp_Phone, Dept_Name
from emp_dept 
inner join employee on  emp_dept.Emp_ID = employee.Emp_ID
inner join department on emp_dept.Dept_ID = department.Dept_ID;

--insert into employee values('Mark', '7796515265', 'PA', 'M');
--insert into payroll values(5000,500, 100, '2020-06-01', 1003)

delete from employee where Emp_Name='Terrence';

SELECT Emp_ID, Emp_Name, Emp_Phone, Emp_Address, Emp_Gender FROM employee where Emp_Name='Mrunal';
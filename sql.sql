USE payroll_service

-- To create table
CREATE TABLE [dbo].[EmployeeTable](
	EmpId INT IDENTITY(1,1) NOT NULL,
	EmpName VARCHAR(20) NULL,
	Gender CHAR(1) NULL,
	HireDay DATE NULL,
	DeptNo INT NULL,
	Email VARCHAR(20) NULL,
	BirthDay DATE NULL,
	JobDiscription VARCHAR(20) NULL,
	ProfileImage VARCHAR(20) NULL,
)

-- Retrieve records from table
SELECT * FROM [EmployeeTable]

-- Insert into table
INSERT INTO [EmployeeTable] VALUES
('Smith','M','2007-07-12',1,'s@gmail.com','1986-04-2','SDE','url'),
('Alex','M','2008-08-12',2,'a@gmail.com','1987-08-12','SDE','url');

SELECT * FROM [EmployeeTable] where EmpId=2

-- Create table
CREATE TABLE [dbo].[Salary](
	SalaryId INT IDENTITY(1,1) NOT NULL,
	SalaryMonth VARCHAR(20) NULL,
	EmpSalary MONEY NULL,
	EmpId INT NULL,
)

-- Insert into table
INSERT INTO Salary VALUES
('Jan',1400,1),
('Jan',1300,2);

-- Retrieve records from table
SELECT * FROM [Salary]
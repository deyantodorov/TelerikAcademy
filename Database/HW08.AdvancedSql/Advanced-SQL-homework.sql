USE TelerikAcademy
GO

--	1. Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company. 
--	Use a nested SELECT statement.

SELECT
	FirstName + ' '+ LastName AS [Employee Name],
	Salary
FROM Employees
	WHERE Salary = (SELECT MIN(Salary) FROM Employees)
GO

-- 2. Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.

SELECT
	FirstName + ' '+ LastName AS [Employee Name],
	Salary
FROM Employees
	WHERE Salary <= (SELECT MIN(Salary) FROM Employees) * (1.00 + (10.00/100.00))
ORDER BY Salary DESC
GO

--	3. Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department.
--	Use a nested SELECT statement.

SELECT
	e.FirstName + ' '+ e.LastName AS [Employee Name],
	e.Salary
FROM Employees e 
	JOIN Departments d on e.DepartmentID = d.DepartmentID
	WHERE Salary <= (SELECT MIN(Salary) FROM Employees WHERE e.DepartmentID = d.DepartmentID)
ORDER BY e.Salary DESC
GO

-- 4. Write a SQL query to find the average salary in the department #1.

SELECT
	AVG(Salary) AS [Average Salary]
FROM Employees 
	WHERE DepartmentID = 1
GO

-- 5. Write a SQL query to find the average salary in the "Sales" department.

SELECT
	AVG(e.Salary) AS [Sales Department Avg. Salary]
FROM Employees e
	JOIN Departments d on e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales'
GO

-- 6. Write a SQL query to find the number of employees in the "Sales" department.

SELECT
	COUNT(e.Salary) AS [Employees in the Sales]
FROM Employees e
	JOIN Departments d on e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales'
GO

-- 7. Write a SQL query to find the number of all employees that have manager.

SELECT
	COUNT(EmployeeID) AS [Employees that have manager]
FROM Employees 
	WHERE ManagerID IS NOT NULL
GO

-- OR

SELECT 
	COUNT(ManagerID) AS [Employees that have manager]
FROM 
	Employees
GO

-- 8. Write a SQL query to find the number of all employees that have no manager.

SELECT
	COUNT(EmployeeID) AS [Employees that have manager]
FROM Employees 
	WHERE ManagerID IS NULL
GO

-- 9. Write a SQL query to find all departments and the average salary for each of them.

SELECT
	AVG(e.Salary) AS [Salary],
	d.Name AS [Department Name]
FROM Employees e
	JOIN Departments d on e.DepartmentID = d.DepartmentID
GROUP BY d.Name
ORDER BY AVG(e.Salary) DESC
GO

-- 10. Write a SQL query to find the count of all employees in each department and for each town.

SELECT
	d.Name AS [Department],
	t.Name AS [Town],
	COUNT(e.EmployeeID) AS [Count]
FROM Employees e
	JOIN Departments d on e.DepartmentID = d.DepartmentID
	JOIN Addresses a on e.AddressID = a.AddressID
	JOIN Towns t on a.TownID = t.TownID
GROUP BY d.Name, t.Name
GO

-- 11. Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.

SELECT
	m.FirstName,
	m.LastName
FROM Employees e
	JOIN Employees m on e.ManagerID = m.EmployeeID
GROUP BY 
	m.FirstName, 
	m.LastName
HAVING COUNT(*) = 5
GO

-- 12. Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)".

SELECT 
	m.FirstName + ' ' + m.LastName AS [Employee Name],
	ISNULL(e.FirstName + ' ' + e.LastName, 'No manager') AS [Manager Name]
FROM 
	Employees e RIGHT OUTER JOIN Employees m 
	ON e.EmployeeID = m.ManagerID

-- 13. Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function.

SELECT 
	LastName
FROM Employees
	WHERE LEN(LastName) = 5
GO

-- 14. Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds".

SELECT 
	CONVERT(VARCHAR(24), GETDATE(), 113) AS [Current Date]
GO

-- OR

PRINT CONVERT(VARCHAR(24), GETDATE(), 113)

--	15. Write a SQL statement to create a table Users. Users should have username, password, full name and last login time.
--		Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint.
--		Define the primary key column as identity to facilitate inserting records.
--		Define unique constraint to avoid repeating usernames.
--		Define a check constraint to ensure the password is at least 5 characters long.

CREATE TABLE Users (
  UserID int IDENTITY(1,1),
  UserName nvarchar(100) NOT NULL UNIQUE,
  UserPassword nvarchar(50) NOT NULL CHECK(LEN(UserPassword) >= 5),
  UserFullName nvarchar(100) NOT NULL,
  UserLastLogin datetime NOT NULL default GETDATE()
  CONSTRAINT PK_Users PRIMARY KEY(UserID)
)
GO

--	16. Write a SQL statement to create a view that displays the users from the Users table that have been in the system today.
--		Test if the view works correctly.

CREATE VIEW [Today Users] AS
SELECT *
FROM Users
WHERE CONVERT(DATE, UserLastLogin, 112) = CONVERT(DATE, GETDATE(), 112)
GO

--	17. Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint).
--		Define primary key and identity column.

CREATE TABLE Groups (
  GroupID int IDENTITY(1,1),
  GroupName nvarchar(100) NOT NULL UNIQUE,
  CONSTRAINT PK_Groups PRIMARY KEY(GroupID)
)
GO

--	18. Write a SQL statement to add a column GroupID to the table Users.
--		Fill some data in this new column and as well in the `Groups table.
--		Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.

ALTER TABLE Users ADD GroupID INT
GO

ALTER TABLE Users ADD CONSTRAINT FK_Users_Groups FOREIGN KEY (GroupID) REFERENCES Groups (GroupID)
GO

--	19. Write SQL statements to insert several records in the Users and Groups tables.

INSERT INTO Groups (GroupName)
	VALUES ('Nobody') ,('Someone') ,('Trainer')
GO

INSERT INTO Users (UserName ,UserPassword ,UserFullName, GroupID)
VALUES 
	('kircho' ,'123123' ,'Kircho Kirchev', 1),
	('mircho' ,'123123' ,'Mircho Mirchev', 2),
	('svircho' ,'123123' ,'Svircho Svirchev', 3)
GO

--	20. Write SQL statements to update some of the records in the Users and Groups tables.

UPDATE Users
SET UserFullName = 'Mincho Praznikov'
WHERE UserFullName = 'Mircho Mirchev'
GO

UPDATE Groups
SET GroupName = 'Lazy Trainer'
WHERE GroupName = 'Trainer'
GO

--	21. Write SQL statements to delete some of the records from the Users and Groups tables.

DELETE
FROM Users
WHERE UserFullName = 'Mincho Praznikov'
GO

DELETE
FROM Groups
WHERE GroupName = 'Lazy Trainer'
GO

--	22. Write SQL statements to insert in the Users table the names of all employees from the Employees table.
--		Combine the first and last names as a full name.
--		For username use the first letter of the first name + the last name (in lowercase).
--		Use the same for the password, and NULL for last login time.

INSERT INTO Users (UserName, UserPassword, UserFullName)
SELECT LOWER(SUBSTRING(FirstName, 1, 1) + SUBSTRING(LastName, 1, 1) + SUBSTRING(CONVERT(NVARCHAR(100), NEWID()), 0, 9))
	,LOWER(SUBSTRING(FirstName, 1, 1) + SUBSTRING(LastName, 1, 1) + SUBSTRING(CONVERT(NVARCHAR(100), NEWID()), 0, 5))
	,FirstName + ' ' + LastName
FROM Employees
GO

--	23. Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.

UPDATE Users
SET UserPassword = NULL
WHERE DATEDIFF(day, UserLastLogin, CAST('10.03.2010' AS DATE)) > 0
GO

--	24. Write a SQL statement that deletes all users without passwords (NULL password).

DELETE 
FROM Users 
WHERE UserPassword IS NULL
GO

--	25. Write a SQL query to display the average employee salary by department and job title.

SELECT 
	AVG(Salary) AS [Average Salary],
	e.JobTitle,
	d.NAME AS [Department Name]
FROM Employees e
	JOIN Departments d ON e.DepartmentID = d.DepartmentID
GROUP BY e.JobTitle ,d.NAME
ORDER BY AVG(Salary) DESC

--	26. Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it.

SELECT 
	MIN(Salary) AS [Average Salary],
	e.JobTitle,
	e.FirstName + ' ' + e.LastName AS FullName,
	d.NAME AS [Department Name]
FROM Employees e
	JOIN Departments d ON e.DepartmentID = d.DepartmentID
GROUP BY e.JobTitle,
	d.NAME,
	e.FirstName,
	e.LastName
ORDER BY MIN(Salary) DESC
GO

--	27. Write a SQL query to display the town where maximal number of employees work.

SELECT TOP 1 
	COUNT(t.TownID) AS [Number of Employees],
	t.NAME
FROM Employees e
	JOIN Addresses a ON e.AddressID = a.AddressID
	JOIN Towns t ON a.TownID = t.TownID
GROUP BY t.TownID ,t.NAME
ORDER BY COUNT(t.TownID) DESC, t.NAME
GO

--	28. Write a SQL query to display the number of managers from each town.

SELECT 
	COUNT(e.ManagerID) AS [Number of Managers],
	t.NAME
FROM Employees e
	JOIN Addresses a ON e.AddressID = a.AddressID
	JOIN Towns t ON a.TownID = t.TownID
GROUP BY e.ManagerID ,t.NAME
ORDER BY COUNT(e.ManagerID) DESC, t.NAME
GO

--	29. Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments).
--		Don't forget to define identity, primary key and appropriate foreign key.
--		Issue few SQL statements to insert, update and delete of some data in the table.
--		Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
--		For each change keep the old record data, the new record data and the command (insert / update / delete).

CREATE TABLE WorkHours (
	WorkHourID INT identity(1, 1) NOT NULL,
	EmployeeID INT NOT NULL,
	WorkDate DATE NOT NULL,
	WorkTask NVARCHAR(100) NOT NULL,
	WorkHours INT NOT NULL,
	Comments NVARCHAR(300),
	CONSTRAINT PK_WorkHour PRIMARY KEY (WorkHourID),
	CONSTRAINT FK_WorkHours_Employees FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
) 
GO

-- INSERT

INSERT INTO WorkHours (
	EmployeeID, WorkDate, WorkTask, WorkHours, Comments)
VALUES 
	(1, GETDATE(), 'Something', 4, 'I sleep all day'),
	(2, GETDATE(), 'Something else', 3, 'I sleep all day')
GO

-- UPDATE

UPDATE WorkHours
SET Comments = 'I sleep, drink, eat and f..k all day long...'
WHERE WorkTask = 'Something'
GO

-- DELETE

DELETE
FROM WorkHours
WHERE WorkTask = 'Something'
GO

CREATE TABLE WorkHoursLogs (
	LogID INT IDENTITY(1, 1) NOT NULL,
	Action NVARCHAR(200) NOT NULL,
	CONSTRAINT PK_WorkHoursLogs PRIMARY KEY (LogID)
)
GO

-- TRIGGER FOR INSERT

CREATE TRIGGER TR_WorkHoursInsert ON WorkHours
FOR INSERT
AS
DECLARE 
	@EmployeeID INT,
	@Date DATE,
	@WorkTask NVARCHAR(50),
	@WorkHours INT,
	@Comments NVARCHAR(300);

SET @EmployeeID = (SELECT EmployeeID FROM inserted);
SET @Date = (SELECT WorkDate FROM inserted);
SET @WorkTask = (SELECT WorkTask FROM inserted);
SET @WorkHours = (SELECT WorkHours FROM inserted);
SET @Comments = (SELECT Comments FROM inserted);

INSERT INTO WorkHoursLogs (Action)
VALUES (CONCAT('INSERTED: ', @EmployeeID, ' | ', @Date, ' | ', @WorkTask, ' | ', @WorkHours, ' | ', @Comments))
GO

-- TRIGGER FOR DELETE

CREATE TRIGGER TR_WorkHoursDelete ON WorkHours
FOR INSERT
AS
DECLARE 
	@EmployeeID INT,
	@Date DATE,
	@WorkTask NVARCHAR(50),
	@WorkHours INT,
	@Comments NVARCHAR(300);

SET @EmployeeID = (SELECT EmployeeID FROM deleted);
SET @Date = (SELECT WorkDate FROM deleted);
SET @WorkTask = (SELECT WorkTask FROM deleted);
SET @WorkHours = (SELECT WorkHours FROM deleted);
SET @Comments = (SELECT Comments FROM deleted);

INSERT INTO WorkHoursLogs (Action)
VALUES (CONCAT('INSERTED: ', @EmployeeID, ' | ', @Date, ' | ', @WorkTask, ' | ', @WorkHours, ' | ', @Comments))
GO

-- TRIGGER FOR UPDATE

CREATE TRIGGER TR_WorkHoursUpdate ON WorkHours
FOR INSERT
AS
DECLARE 
	@EmployeeID INT,
	@Date DATE,
	@WorkTask NVARCHAR(50),
	@WorkHours INT,
	@Comments NVARCHAR(300);

SET @EmployeeID = (SELECT EmployeeID FROM deleted);
SET @Date = (SELECT WorkDate FROM deleted);
SET @WorkTask = (SELECT WorkTask FROM deleted);
SET @WorkHours = (SELECT WorkHours FROM deleted);
SET @Comments = (SELECT Comments FROM deleted);

INSERT INTO WorkHoursLogs (Action)
VALUES (CONCAT ('OLD UPDATED RECORD: ', @EmployeeID, ' | ', @Date, ' | ', @WorkTask, ' | ', @WorkHours, ' | ', @Comments))

SET @EmployeeID = (SELECT EmployeeID FROM inserted);
SET @Date = (SELECT WorkDate FROM inserted);
SET @WorkTask = (SELECT WorkTask FROM inserted);
SET @WorkHours = (SELECT WorkHours FROM inserted);
SET @Comments = (SELECT Comments FROM inserted);

INSERT INTO WorkHoursLogs (Action)
VALUES (CONCAT ('NEW UPDATED RECORD: ', @EmployeeID, ' | ', @Date, ' | ', @WorkTask, ' | ', @WorkHours, ' | ', @Comments))
GO

--	30. Start a database transaction, delete all employees from the 'Sales' department along with all dependent records from the pother tables.
--		At the end rollback the transaction.

BEGIN TRAN

DELETE
FROM Employees
WHERE EmployeeID IN 
		(
			SELECT e.EmployeeID
			FROM Employees e
			JOIN Departments d ON e.DepartmentID = d.DepartmentID
			WHERE d.Name = 'Sales'
		)

ROLLBACK TRAN

--	31. Start a database transaction and drop the table EmployeesProjects.
--		Now how you could restore back the lost table data?

CREATE DATABASE TelerikAcademyCopy ON 
(
	NAME = TelerikAcademy,
	FILENAME = 'D:\DB_backup.ss'
) 
AS SNAPSHOT OF TelerikAcademy
GO

-- DROP Table

DROP TABLE EmployeesProjects
GO

-- RESTORE FROM SNAPSHOT

SELECT *
INTO EmployeesProjects
FROM [TelerikAcademyCopy].[dbo].[EmployeesProjects]
GO

--	32. Find how to use temporary tables in SQL Server.
--		Using temporary tables backup all records from EmployeesProjects and restore them back after dropping and re-creating the table.

-- COPY IN TEMP DB

SELECT *
INTO #EmployeesProjects_TMP
FROM EmployeesProjects;
GO

-- DROP ORIGINAL TABLE

DROP TABLE EmployeesProjects;
GO

-- RESTORE ORIGINAL TABLE

SELECT *
INTO EmployeesProjects
FROM #EmployeesProjects_TMP;
GO

-- DROP TEMP TABLE

DROP TABLE #EmployeesProjects_TMP
GO
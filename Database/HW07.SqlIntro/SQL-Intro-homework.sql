-----------------------------------------------------------------------------------
--  1. What is SQL? What is DML? What is DDL? Recite the most important SQL commands. 
--  DML - Data Manipulation Language: Basic CRUD commands (create, read, update, delete) in SQL are SELECT, INSERT, UPDATE, DELETE
--  DDL - Data Definition Language: CREATE, DROP, ALTER, GRANT, REVOKE
-----------------------------------------------------------------------------------

-----------------------------------------------------------------------------------
--	2. What is Transact-SQL (T-SQL)?
--	T-SQL (Transact SQL) is an extension to the standard SQL language. 
--  T-SQL is the standard language used in MS SQL Server. Supports if statements, loops, exceptions. 
--	Constructions used in the high-level procedural programming languages. 
--	T-SQL is used for writing stored procedures, functions, triggers, etc.
-----------------------------------------------------------------------------------

-----------------------------------------------------------------------------------
--	3. Start SQL Management Studio and connect to the database TelerikAcademy. Examine the major tables in the "TelerikAcademy" database.
--	I've done this. Beleive me and see the result below!
-----------------------------------------------------------------------------------

-----------------------------------------------------------------------------------
--	4. Write a SQL query to find all information about all departments (use "TelerikAcademy" database).

USE TelerikAcademy
GO

SELECT *
FROM Departments
GO
-----------------------------------------------------------------------------------

-----------------------------------------------------------------------------------
--	5. Write a SQL query to find all department names.

USE TelerikAcademy
GO

SELECT Name AS [Department Names]
FROM Departments
GO
-----------------------------------------------------------------------------------

-----------------------------------------------------------------------------------
--	6. Write a SQL query to find the salary of each employee.

USE TelerikAcademy
GO

SELECT Salary AS [Employee Salary]
FROM Employees
GO

--	6. BGCoder - Write a SQL query to find the salary of each employee ordered in ascending order.

USE TelerikAcademy
GO

SELECT Salary
FROM Employees
ORDER BY Salary ASC
GO
-----------------------------------------------------------------------------------

-----------------------------------------------------------------------------------
--	7. Write a SQL to find the full name of each employee.

USE TelerikAcademy
GO

SELECT FirstName + ' ' + LastName AS [Employee Full Name]
FROM Employees
GO
-----------------------------------------------------------------------------------

-----------------------------------------------------------------------------------
--	8. Write a SQL query to find the email addresses of each employee (by his first and last name). 
--	Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com". 
--	The produced column should be named "Full Email Addresses".

USE TelerikAcademy
GO

SELECT FirstName + '.' + LastName + '@telerik.com' AS [Full Email Addresses]
FROM Employees
GO
-----------------------------------------------------------------------------------

-----------------------------------------------------------------------------------
--	9. Write a SQL query to find all different employee salaries.

USE TelerikAcademy
GO

SELECT DISTINCT Salary AS [Different Employee Salaries]
FROM Employees
GO
-----------------------------------------------------------------------------------

-----------------------------------------------------------------------------------
--	10. Write a SQL query to find all information about the employees whose job title is “Sales Representative“.

USE TelerikAcademy
GO

SELECT emp.EmployeeID,
	emp.FirstName,
	emp.MiddleName,
	emp.LastName, 
	emp.JobTitle,
	dep.Name AS [Department Name],
	emp.HireDate,
	emp.Salary,
	t.Name AS [Town],
	adr.AddressText AS [Address]
FROM Employees emp
	JOIN Departments dep on emp.DepartmentID = dep.DepartmentID
	JOIN Addresses adr on emp.AddressID = adr.AddressID
	JOIN Towns t on adr.TownID = t.TownID
WHERE JobTitle = 'Sales Representative'
GO
-----------------------------------------------------------------------------------

-----------------------------------------------------------------------------------
--	11. Write a SQL query to find the names of all employees whose first name starts with "SA".

USE TelerikAcademy
GO

SELECT FirstName
FROM Employees
	WHERE FirstName LIKE 'SA%'
GO
-----------------------------------------------------------------------------------

-----------------------------------------------------------------------------------
-- 12. Write a SQL query to find the names of all employees whose last name contains "ei".

USE TelerikAcademy
GO

SELECT LastName
FROM Employees
	WHERE LastName LIKE '%ei%'
GO
-----------------------------------------------------------------------------------

-----------------------------------------------------------------------------------
-- 13. Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].

USE TelerikAcademy
GO

SELECT 
	FirstName, 
	LastName, 
	Salary
FROM Employees
	WHERE Salary BETWEEN 20000 AND 30000
GO

-----------------------------------------------------------------------------------

-----------------------------------------------------------------------------------
-- 14. Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.

USE TelerikAcademy
GO

SELECT 
	FirstName, 
	LastName, 
	Salary
FROM Employees
	WHERE Salary IN(25000, 14000, 12500, 23600)
ORDER BY Salary
GO

-----------------------------------------------------------------------------------

-----------------------------------------------------------------------------------
-- 15. Write a SQL query to find all employees that do not have manager.

USE TelerikAcademy
GO

SELECT *
FROM Employees
	WHERE ManagerID IS NULL
ORDER BY Salary DESC
GO

-----------------------------------------------------------------------------------

-----------------------------------------------------------------------------------
-- 16. Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary.

USE TelerikAcademy
GO

SELECT *
FROM Employees
	WHERE Salary > 50000
ORDER BY Salary DESC
GO

-----------------------------------------------------------------------------------
-- 17. Write a SQL query to find the top 5 best paid employees.

USE TelerikAcademy
GO

SELECT TOP 5 *
	FROM Employees
ORDER BY Salary DESC
GO
-----------------------------------------------------------------------------------

-----------------------------------------------------------------------------------
-- 18. Write a SQL query to find all employees along with their address. Use inner join with ON clause.

USE TelerikAcademy
GO

SELECT 
	emp.EmployeeID AS [ID],
	emp.FirstName,
	emp.MiddleName,
	emp.LastName,
	emp.JobTitle,
	dep.Name AS [Department Name],
	man.FirstName + ' ' + man.LastName AS [Mangaer Name],
	emp.HireDate,
	emp.Salary,
	town.Name + ', ' + adr.AddressText AS [Adress]
	FROM Employees emp
	JOIN Addresses adr on emp.AddressID = adr.AddressID
	JOIN Towns town on adr.TownID = town.TownID
	JOIN Departments dep on emp.DepartmentID = dep.DepartmentID
	JOIN Employees man on emp.ManagerID = man.EmployeeID
GO

-----------------------------------------------------------------------------------

-----------------------------------------------------------------------------------
--	19. Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause).

USE TelerikAcademy
GO

SELECT *
FROM Employees e, Addresses a
	 WHERE e.AddressID = a.AddressID

-----------------------------------------------------------------------------------

-----------------------------------------------------------------------------------
-- 20. Write a SQL query to find all employees along with their manager

USE TelerikAcademy
GO

SELECT 
	e.FirstName + ' ' + e.LastName AS [Employee Name],
	e.JobTitle AS [Employee Position],
	m.FirstName + ' ' + m.LastName AS [Manager Name],
	m.JobTitle AS [Manager Position]
FROM Employees e, Employees m
	 WHERE e.ManagerID = m.EmployeeID

-----------------------------------------------------------------------------------

-----------------------------------------------------------------------------------
--	21. Write a SQL query to find all employees, along with their manager and their address. Join the 3 tables: Employees e, Employees m and Addresses a.

USE TelerikAcademy
GO

SELECT 
	e.EmployeeID AS [ID],
	e.FirstName + ' ' + e.LastName AS [Employee Name],
	e.JobTitle,
	m.FirstName + ' ' + m.LastName AS [Manager Name],
	e.HireDate,
	e.Salary,
	t.Name + ', ' + a.AddressText AS [Address]
FROM Employees e
	JOIN Employees m on e.ManagerID = m.EmployeeID
	JOIN Addresses a on e.AddressID = a.AddressID
	JOIN Towns t on a.TownID = t.TownID
GO

-----------------------------------------------------------------------------------
-- 22. Write a SQL query to find all departments and all town names as a single list. Use UNION.

USE TelerikAcademy
GO

SELECT 
	Name
FROM Departments
UNION
SELECT
	Name
FROM Towns
GO

-----------------------------------------------------------------------------------

-----------------------------------------------------------------------------------
--	23. Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager. 
--	Use right outer join. Rewrite the query to use left outer join.

USE TelerikAcademy
GO

-- RIGHT OUTER JOIN
SELECT 
	e.FirstName + ' ' + e.LastName AS [Employee Name], 
	m.FirstName + ' ' + e.LastName AS [Manager Name]
FROM Employees e RIGHT OUTER JOIN Employees m
	ON e.ManagerID = m.EmployeeID
GO

-- LEFT OUTER JOIN
SELECT 
	e.FirstName + ' ' + e.LastName AS [Employee Name], 
	m.FirstName + ' ' + e.LastName AS [Manager Name]
FROM Employees e LEFT OUTER JOIN Employees m
	ON e.ManagerID = m.EmployeeID
GO

-----------------------------------------------------------------------------------

-----------------------------------------------------------------------------------
--	24. Write a SQL query to find the first and last name of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005. 
--  Order the results by first name, then by last name, both in ascending order.

USE TelerikAcademy
GO

SELECT 
	e.FirstName,
	e.LastName
FROM Employees e
JOIN Departments d on e.DepartmentID = d.DepartmentID
WHERE (d.Name LIKE 'Sales' OR d.Name LIKE 'Finance') AND (HireDate BETWEEN '1-1-1995' AND '1-1-2015')
ORDER BY e.FirstName, e.LastName ASC

-----------------------------------------------------------------------------------
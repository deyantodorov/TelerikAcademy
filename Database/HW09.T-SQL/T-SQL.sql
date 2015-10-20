-- 1. Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance). 
--    Insert few records for testing. Write a stored procedure that selects the full names of all persons.
--
-- create Bank account db
--
USE master
GO

CREATE DATABASE Bank
GO

USE Bank
GO

-- create tables Persons & Accounts
--
CREATE TABLE Persons (
	PersonID INT IDENTITY(1, 1)
	,FirstName NVARCHAR(50) NOT NULL
	,LastName NVARCHAR(50) NOT NULL
	,SSN NVARCHAR(10) NOT NULL UNIQUE CHECK (LEN(SSN) = 10)
	,CONSTRAINT PK_Persons PRIMARY KEY (PersonID)
	)
GO

CREATE TABLE Accounts (
	AccountID INT IDENTITY(1, 1)
	,PersonID INT NOT NULL
	,Balance MONEY NOT NULL
	,CONSTRAINT PK_Accounts PRIMARY KEY (AccountID)
	,CONSTRAINT FK_Persons_Accounts FOREIGN KEY (PersonID) REFERENCES Persons(PersonID)
	)
GO

-- insert data
--
INSERT INTO Persons (FirstName, LastName, SSN)
VALUES ('Kircho','Kirchev','1234567890'),
	('Mircho', 'Mirchev', '9234567891'),
	('Svircho', 'Svirchev', '9234657891')
GO

INSERT INTO Accounts (PersonID, Balance)
VALUES (1, 1234.0123),
	   (2, 12345.21312),
	   (3, 12346.9123)
GO

-- stored procedure for full name
--
CREATE PROC usp_SelectPersonsFullName
AS
SELECT FirstName + ' ' + LastName AS FullName
FROM Persons
GO

-- 2. Create a stored procedure that accepts a number as a parameter and returns all persons who have more money in their accounts than the supplied number.
--
CREATE PROC usp_SelectEmployeesByMoney (@moneyLimit MONEY = 0)
AS
SELECT p.FirstName
	,p.LastName
	,p.SSN
	,a.Balance
FROM Persons p
JOIN Accounts a ON p.PersonID = a.PersonID
WHERE a.Balance > @moneyLimit
GO

-- 3. Create a function that accepts as parameters – sum, yearly interest rate and number of months. 
-- It should calculate and return the new sum. Write a SELECT to test whether the function works as expected.
--
CREATE FUNCTION ufn_CalculateInterestRate (@sum MONEY, @interestRate REAL, @months INT)
RETURNS MONEY
AS
BEGIN
	DECLARE @monthRate REAL, @moneyFromIR MONEY

	SET @monthRate = (@interestRate / 12) * @months
	SET @moneyFromIR = @sum + ((@sum * @monthRate) / 100)

	RETURN @moneyFromIR
END
GO

SELECT dbo.ufn_CalculateInterestRate(Balance, 7, 3) AS [Sum + Interest Rate]
FROM Accounts
GO

-- 4. Create a stored procedure that uses the function from the previous example to give an interest to a person's account for one month. It should take the AccountId and the interest rate as parameters.
-- 
CREATE PROC usp_MonthInterestRate @AccountID INT, @interestRate REAL
AS
SELECT dbo.ufn_CalculateInterestRate(Balance, @interestRate, 1)
FROM Accounts
WHERE AccountID = @AccountID
GO

EXEC usp_MonthInterestRate 2, 7
GO

-- 5. Add two more stored procedures WithdrawMoney( AccountId, money) and DepositMoney (AccountId, money) that operate in transactions.
-- 
-- withdraw
--
CREATE PROC usp_WithdrawMoney @AccountId INT, @Money MONEY
AS
BEGIN TRAN

DECLARE @ClientMoney MONEY = (
		SELECT Balance
		FROM Accounts
		WHERE AccountID = @AccountId)

IF (@ClientMoney >= @Money)
BEGIN
	UPDATE Accounts
	SET Balance = Balance - @Money
	WHERE AccountID = @AccountId
END
ELSE
BEGIN
	RAISERROR ('Not enought money to withdraw', 16, 1)
	ROLLBACK TRAN
END
GO

EXEC usp_WithdrawMoney 1, 20
GO

-- deposit
--
CREATE PROC usp_DepositMoney @AccountId INT, @Money MONEY
AS
BEGIN TRAN

BEGIN TRY
	UPDATE Accounts
	SET Balance = Balance + @Money
	WHERE AccountID = @AccountId

	COMMIT TRAN
END TRY

BEGIN CATCH
	ROLLBACK TRAN
END CATCH
GO

EXEC usp_DepositMoney 1, 20
GO

-- 6. Create another table – Logs(LogID, AccountID, OldSum, NewSum). Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes.
-- 
CREATE TABLE Logs (
	LogID INT NOT NULL Identity(1, 1)
	,AccountID INT NOT NULL
	,OldSum MONEY NOT NULL
	,NewSum MONEY NOT NULL
	,CONSTRAINT PK_LogID PRIMARY KEY (LogID)
	,CONSTRAINT FK_Logs_Accounts FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID)
	)
GO

CREATE TRIGGER tr_SumUpdate ON Accounts
FOR UPDATE
AS
INSERT INTO Logs (AccountID, OldSum, NewSum)
SELECT d.AccountID, d.Balance, i.Balance
FROM deleted d
INNER JOIN inserted i ON d.AccountID = i.AccountID
GO

-- test
EXEC usp_DepositMoney 1, 20
GO

-- 7. Define a function in the database TelerikAcademy that returns all Employee's names (first or middle or last name) and all town's names that are comprised of given set of letters. 
-- Example 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.
--
-- search function
USE TelerikAcademy
GO

CREATE FUNCTION ufn_IsComprised (
	@name NVARCHAR(50)
	,@characters NVARCHAR(50)
	)
RETURNS BIT
AS
BEGIN
	DECLARE @index INT = 1
		,@foundIndex INT
		,@currentCharacter NVARCHAR(1)
		,@counter INT
		,@result BIT
	DECLARE @usedLetters TABLE (
		LetterIndex INT
		,Letter NVARCHAR(1)
		)

	SET @characters = LOWER(@characters);

	WHILE (@index <= LEN(@name))
	BEGIN
		SET @currentCharacter = LOWER(SUBSTRING(@name, @index, 1));
		SET @foundIndex = CHARINDEX(@currentCharacter, @characters);

		IF (@foundIndex = 0)
		BEGIN
			SET @result = 0;

			BREAK
		END
		ELSE
		BEGIN
			IF (
					EXISTS (
						SELECT *
						FROM @usedLetters
						WHERE LetterIndex = @foundIndex
						)
					)
			BEGIN
				SELECT TOP 1 @foundIndex = LetterIndex
				FROM @usedLetters
				WHERE Letter = @currentCharacter
				ORDER BY Letter DESC

				SET @foundIndex = CHARINDEX(@currentCharacter, @characters, @foundIndex + 1)

				IF (@foundIndex = 0)
				BEGIN
					SET @result = 0

					BREAK
				END
			END

			INSERT INTO @usedLetters
			VALUES (
				@foundIndex
				,@currentCharacter
				)
		END

		SET @index += 1;
	END

	SELECT @counter = COUNT(*)
	FROM @usedLetters

	IF (@counter = len(@name))
	BEGIN
		SET @result = 1
	END
	ELSE
	BEGIN
		SET @result = 0
	END

	RETURN @result
END
GO

USE TelerikAcademy
GO

-- union function from search results
CREATE FUNCTION ufn_GetComprisedNames (@characters NVARCHAR(50))
RETURNS TABLE
AS
RETURN (
		SELECT 'First Name: ' + e.FirstName AS FirstName
		FROM Employees AS e
		WHERE 1 = (
				SELECT dbo.ufn_IsComprised(e.FirstName, @characters)
				)
		
		UNION
		
		SELECT 'Middle Name: ' + e.MiddleName AS MiddleName
		FROM Employees AS e
		WHERE 1 = (
				SELECT dbo.ufn_IsComprised(e.MiddleName, @characters)
				)
		
		UNION
		
		SELECT 'Last Name: ' + e.LastName AS LastName
		FROM Employees AS e
		WHERE 1 = (
				SELECT dbo.ufn_IsComprised(e.LastName, @characters)
				)
		
		UNION
		
		SELECT 'Town name: ' + t.NAME AS TownName
		FROM Towns AS t
		WHERE 1 = (
				SELECT dbo.ufn_IsComprised(t.NAME, @characters)
				)
		)
GO

SELECT *
FROM dbo.ufn_GetComprisedNames('oistmiahf')

-- 8. Using database cursor write a T-SQL script that scans all employees and their addresses and prints all pairs of employees that live in the same town.
--
USE TelerikAcademy;
GO

DECLARE LineCursor CURSOR READ_ONLY
FOR
SELECT e1.FirstName
	,e1.LastName
	,t1.NAME
	,e2.FirstName
	,e2.LastName
FROM Employees e1
INNER JOIN Addresses a1 ON a1.AddressID = e1.AddressID
INNER JOIN Towns t1 ON t1.TownID = a1.TownID
	,Employees e2
INNER JOIN Addresses a2 ON a2.AddressID = e2.AddressID
INNER JOIN Towns t2 ON t2.TownID = a2.TownID
WHERE t1.TownID = t2.TownID
	AND e1.EmployeeID <> e2.EmployeeID
ORDER BY t1.NAME
	,e1.FirstName
	,e2.FirstName

OPEN LineCursor

DECLARE @FirstName1 NVARCHAR(50)
	,@LastName1 NVARCHAR(50)
	,@Town NVARCHAR(50)
	,@FirstName2 NVARCHAR(50)
	,@LastName2 NVARCHAR(50)
DECLARE @ResultTable TABLE (
	FirstEmployee NVARCHAR(100)
	,Town NVARCHAR(500)
	,SecondEmployee NVARCHAR(100)
	)

FETCH NEXT
FROM LineCursor
INTO @FirstName1
	,@LastName1
	,@Town
	,@FirstName2
	,@LastName2

WHILE @@FETCH_STATUS = 0
BEGIN
	INSERT INTO @ResultTable
	VALUES (
		@FirstName1 + ' ' + @LastName1
		,@Town
		,@FirstName2 + ' ' + @LastName2
		);

	FETCH NEXT
	FROM LineCursor
	INTO @FirstName1
		,@LastName1
		,@Town
		,@FirstName2
		,@LastName2
END

CLOSE LineCursor

DEALLOCATE LineCursor

SELECT *
FROM @ResultTable;
GO

-- 9. * Write a T-SQL script that shows for each town a list of all employees that live in it. Sample output:
-- Sofia -> Svetlin Nakov, Martin Kulov, George Denchev
-- Ottawa -> Jose Saraiva
--
USE TelerikAcademy
GO

DECLARE LineCursor CURSOR READ_ONLY
FOR
SELECT t.NAME AS [Town Name]
	,e.FirstName + ' ' + e.LastName AS [Employees Name]
FROM Employees AS e
INNER JOIN Addresses a ON a.AddressID = e.AddressID
INNER JOIN Towns t ON t.TownID = a.TownID

OPEN LineCursor

DECLARE @EmployeesName NVARCHAR(100)
	,@TownName NVARCHAR(50)
DECLARE @ResultTable TABLE (
	TownName NVARCHAR(50)
	,EmployeesName NVARCHAR(MAX)
	)

FETCH NEXT
FROM LineCursor
INTO @TownName
	,@EmployeesName

WHILE @@FETCH_STATUS = 0
BEGIN
	IF (
			EXISTS (
				SELECT *
				FROM @ResultTable
				WHERE TownName = @TownName
				)
			)
	BEGIN
		UPDATE @ResultTable
		SET EmployeesName = EmployeesName + ', ' + @EmployeesName
		WHERE TownName = @TownName
	END
	ELSE
	BEGIN
		INSERT INTO @ResultTable
		VALUES (
			@TownName
			,@EmployeesName
			)
	END

	FETCH NEXT
	FROM LineCursor
	INTO @TownName
		,@EmployeesName
END

CLOSE LineCursor

DEALLOCATE LineCursor

SELECT *
FROM @ResultTable
ORDER BY TownName DESC
GO

-- 10. Define a .NET aggregate function StrConcat that takes as input a sequence of strings and return a single string that consists of the input strings separated by ','. 
-- For example the following SQL statement should return a single string:
-- 
DECLARE @name NVARCHAR(MAX);

SET @name = N'';

SELECT @name += e.FirstName + N','
FROM Employees e

SELECT LEFT(@name, LEN(@name) - 1);
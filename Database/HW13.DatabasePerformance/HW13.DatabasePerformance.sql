---------------------------------------------------------------------------------------------------------------------------------------------------
-- 1. Create a table in SQL Server with 10 000 000 log entries (date + text). Search in the table by date range. Check the speed (without caching).
---------------------------------------------------------------------------------------------------------------------------------------------------
CREATE DATABASE PerformanceDB
GO

USE PerformanceDB
GO

CREATE TABLE Logs (
	LogId INT NOT NULL PRIMARY KEY IDENTITY
	,LogDate DATETIME NOT NULL
	,LogText NVARCHAR(1000)
	,
	)
GO

INSERT INTO Logs (
	LogDate
	,LogText
	)
VALUES (
	'1992-02-01'
	,'Loged in'
	);
GO

-- 3.33 secs DON'T Try this at home it takes too long :)
DECLARE @Counter INT = 0

WHILE (
		SELECT COUNT(*)
		FROM Logs
		) < 10000000 -- If you want to hurt your HDD
BEGIN
	INSERT INTO Logs (
		LogDate
		,LogText
		)
	SELECT LogDate = DATEADD(day, (ABS(CHECKSUM(NEWID())) % 65530), 0)
		,LogText + CONVERT(VARCHAR, @Counter)
	FROM Logs

	SET @Counter = @Counter + 1
END
GO

CHECKPOINT;

DBCC DROPCLEANBUFFERS;-- Empty the SQL Server cache

-- 0.20 secs
SELECT *
FROM Logs
WHERE LogDate > '1-1-1990'
	AND LogDate < '1-1-2002'
ORDER BY LogDate ASC
GO

-- 0.00 secs with cache
-- With the SQL Server cache
SELECT *
FROM Logs
WHERE LogDate > '1-1-1990'
	AND LogDate < '1-1-2002'
ORDER BY LogDate ASC
GO

---------------------------------------------------------------------------------------------------------------------------------------------------
-- 2. Add an index to speed-up the search by date. Test the search speed (after cleaning the cache).
---------------------------------------------------------------------------------------------------------------------------------------------------
CREATE INDEX IDX_Logs_LogDate ON Logs (LogDate)
GO

CHECKPOINT;

DBCC DROPCLEANBUFFERS;-- Empty the SQL Server cache

SELECT *
FROM Logs
WHERE LogDate > '1-1-1990'
	AND LogDate < '1-1-2002'
ORDER BY LogDate ASC
GO

---------------------------------------------------------------------------------------------------------------------------------------------------
-- 3. Add a full text index for the text column. Try to search with and without the full-text index and compare the speed.
---------------------------------------------------------------------------------------------------------------------------------------------------
CREATE FULLTEXT CATALOG LogsFullTextForLogText
	WITH ACCENT_SENSITIVITY = OFF

CREATE FULLTEXT INDEX ON Logs (LogText) KEY INDEX PK_Logs ON LogsFullTextForLogText
	WITH CHANGE_TRACKING AUTO

--Empty the SQL Server cache
CHECKPOINT;

DBCC DROPCLEANBUFFERS;

--Search from full text
SELECT *
FROM Logs
WHERE LogText LIKE '%1256789'

--Empty the SQL Server cache
CHECKPOINT;

DBCC DROPCLEANBUFFERS;

--Search from full text
SELECT *
FROM Logs
WHERE CONTAINS (
		LogText
		,'1256789'
		)
GO

--------------------------------------------------------------------------------------------------------------------
-- 4. Create the same table in MySQL and partition it by date (1990, 2000, 2010). Fill 1 000 000 log entries. 
--    Compare the searching speed in all partitions (random dates) to certain partition (e.g. year 1995).
--------------------------------------------------------------------------------------------------------------------

-- MySQL
create database performance_db;

use performance_db;

create table logs(
	log_id int not null auto_increment,
	log_date datetime,
	log_text nvarchar(1000),
	constraint pk_logs_log_id primary key(log_id, log_date)
) partition by range(year(log_date))(
	partition p0 values less than (1990),
	partition p1 values less than (2000),
	partition p2 values less than (2010),
	partition p3 values less than maxvalue
);

// test performance
use performance_db;

delimiter $$
drop procedure if exists insert_million_rows $$

create procedure insertmilionrowsindb () 
begin
declare counter int default 0;
	start transaction;
	while counter < 1000000 do
		insert into logs(log_date, log_text)
		values(timestampadd(day, floor(1 + rand() * 10000), '1990-01-01'),
		concat('sample text ', counter));
set counter = counter + 1;
end while;
end $$

call insertmilionrowsindb ();

select * from logs partition(p2);

select * from logs where year(log_date) = 1995;
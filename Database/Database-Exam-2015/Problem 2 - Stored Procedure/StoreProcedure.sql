USE PetStore
GO

CREATE PROC dbo.usp_AddColors
AS
  IF((SELECT COUNT(*) FROM dbo.Colors) = 0)
  BEGIN
	INSERT INTO dbo.Colors(Name)
	VALUES ('black');
	INSERT INTO dbo.Colors(Name)
	VALUES ('white');
	INSERT INTO dbo.Colors(Name)
	VALUES ('red');
	INSERT INTO dbo.Colors(Name)
	VALUES ('mixed');
  END
GO
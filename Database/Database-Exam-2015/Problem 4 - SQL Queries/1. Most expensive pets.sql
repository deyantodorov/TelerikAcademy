USE PetStore
GO

SELECT TOP 5
	Price,
	Breed,
	Birth
FROM Pets
WHERE Birth >= Convert(datetime, '2012-01-01' )
ORDER BY Price DESC
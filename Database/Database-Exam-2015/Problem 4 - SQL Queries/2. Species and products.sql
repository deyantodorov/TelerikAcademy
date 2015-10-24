USE PetStore
GO

SELECT 
	s.Name AS [Species Name],
	COUNT(p.Id) AS [Number of Products]
FROM Species s
	INNER JOIN ProductsInSpecies ps
	on s.Id = ps.SpecieId
	INNER JOIN Products p
	on p.Id = ps.ProductId
GROUP BY s.Name
ORDER BY COUNT(p.Id) DESC
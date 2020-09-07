
INSERT INTO dbo.AspNetRoles (Id, Name, NormalizedName) VALUES (NewID(), 'Admin', 'ADMIN')
INSERT INTO dbo.AspNetRoles (Id, Name, NormalizedName) VALUES (NewID(), 'Empresa', 'EMPRESA')


SELECT 
	l.LeyID, l.Descripcion as DescripcionLey, 
	t.TituloID, t.Descripcion as DescripcionTitulo, 
	c.CapituloID, c.Descripcion as DescripcionCapitulo, c.Detalle as DetalleCapitulo
FROM Leyes l
INNER JOIN 
	Titulos t on l.LeyID = t.LeyID
INNER JOIN 
	Capitulos c on t.TituloID = c.TituloID


SELECT 
	t.TituloID, t.Descripcion, t.Detalle,
	c.CapituloID, c.Descripcion, c.Detalle,
	a.ArticuloID, a.Descripcion, a.Detalle
FROM Titulos t 
INNER JOIN Capitulos c ON t.TituloID = c.TituloID
INNER JOIN Articulos a ON c.CapituloID = a.CapituloID

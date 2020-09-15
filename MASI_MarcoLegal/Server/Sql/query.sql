USE MASI_MarcoLegalDB;

/* Insertar los roles en la BD */
INSERT INTO dbo.AspNetRoles (Id, Name, NormalizedName) VALUES (NewID(), 'Administrador', 'ADMINISTRADOR')
INSERT INTO dbo.AspNetRoles (Id, Name, NormalizedName) VALUES (NewID(), 'Supervisor', 'SUPERVISOR')
INSERT INTO dbo.AspNetRoles (Id, Name, NormalizedName) VALUES (NewID(), 'Empresa', 'EMPRESA')

SELECT * FROM dbo.AspNetRoles

/* Insertar Marcos Legales a Empresas */
select * from dbo.LeyesOrganizaciones
INSERT INTO dbo.LeyesOrganizaciones (OrganizacionID, LeyID) 
	VALUES (1,1), (2,1), (3,1);

SELECT * FROM Leyes
SELECT * FROM Articulos where Verificable = 1

SELECT * FROM dbo.AspNetUsers

select * from dbo.AspNetRoles

SELECT 
	--l.LeyID, l.Descripcion as DescripcionLey, 
	--t.TituloID, t.Descripcion as DescripcionTitulo, 
	--c.CapituloID, c.Descripcion as DescripcionCapitulo, c.Detalle as DetalleCapitulo,
	a.ArticuloID, a.Descripcion as DescripcionArticulo, a.Detalle as DetalleArticulo,
	 i.IncisoID, i.Descripcion as DescripcionInciso, i.Detalle as DetalleInciso, i.Verificable
FROM Leyes l
INNER JOIN 
	Titulos t ON l.LeyID = t.LeyID
INNER JOIN 
	Capitulos c ON t.TituloID = c.TituloID
INNER JOIN 
	Articulos a ON c.CapituloID = a.CapituloID
INNER JOIN
	Incisos i ON a.ArticuloID = i.ArticuloID
	WHERE 1 = 1
	AND l.LeyID = 1 	
	AND i.Verificable = 1



SELECT 
	t.TituloID, t.Descripcion, t.Detalle,
	c.CapituloID, c.Descripcion, c.Detalle,
	a.ArticuloID, a.Descripcion, a.Detalle
FROM Titulos t 
INNER JOIN Capitulos c ON t.TituloID = c.TituloID
INNER JOIN Articulos a ON c.CapituloID = a.CapituloID



select * from Incisos

update Incisos set Verificable = 1 where ArticuloID = 9



SELECT * FROM Titulos

select * from Verificacion
select * from CumplimientoArticulo


SELECT * FROM Capitulos
UPDATE Capitulos SET Descripcion = 'CAPITULO I' WHERE CapituloID = 15


SELECT * FROM Leyes

select * from Organizaciones

Insert Into Organizaciones (Nombre) values ('Banco GyT Continental')
Insert Into Organizaciones (Nombre) values ('Banco Rural de Guatemala')
Insert Into Organizaciones (Nombre) values ('Banco Agrícola Mercantil BAM')
Insert Into Organizaciones (Nombre) values ('Banco Industria BI')



Insert Into Organizaciones (Nombre) values ('Bancafé')

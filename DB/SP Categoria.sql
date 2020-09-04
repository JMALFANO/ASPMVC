use ASPNETMVC;

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'categoria_upd')
DROP PROCEDURE categoria_upd
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'categoria_sel_max_id_categoria')
DROP PROCEDURE categoria_sel_max_id_categoria
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'categoria_sel_by_id')
DROP PROCEDURE categoria_sel_by_id
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'categoria_sel_all')
DROP PROCEDURE categoria_sel_all
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'categoria_ins')
DROP PROCEDURE categoria_ins
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'categoria_del')
DROP PROCEDURE categoria_del
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'categoria_id')
DROP PROCEDURE categoria_id
GO

/***
* Descripción: Selecciona el máximo valor del campo clave primaria (primary key).
***/
CREATE PROCEDURE categoria_sel_max_id_categoria
AS
BEGIN
	SELECT MAX(id_categoria) FROM Categoria
END

GO

/***
* Descripción: Adiciona un registro en la tabla socio.
***/
CREATE PROCEDURE categoria_ins
	@nombre varchar(50)
	AS
BEGIN
	INSERT INTO categoria 
            (nombre) 
    VALUES 
           (@nombre) 
END

GO

/***
* Descripción: Modifica un registro de la tabla Socios.
***/
CREATE PROCEDURE categoria_upd
	@id_categoria int,
	@Nombre varchar(50)

AS
BEGIN
	UPDATE Categoria
	SET  
		Nombre = @Nombre
		                           
	 WHERE id_categoria = @id_categoria
END

GO

/***
* Descripción: Selecciona un registro de la tabla Categoria por su clave primaria (primary key).
***/
CREATE PROCEDURE [categoria_sel_by_id]
	@id_categoria int
AS
BEGIN
	SELECT * FROM Categoria WHERE id_categoria = @id_categoria
END

GO

/***
* Descripción: Selecciona todos los registros de la tabla Categoria.
***/
CREATE PROCEDURE categoria_sel_all
AS
BEGIN
	SELECT * FROM Categoria ORDER BY id_categoria ASC
END

GO

/***
* Descripción: Elimina un registro por su clave primaria (primary key)
***/
CREATE PROCEDURE categoria_del
	@id_categoria int
AS
BEGIN
	DELETE FROM Categoria WHERE id_categoria = @id_categoria
END
GO
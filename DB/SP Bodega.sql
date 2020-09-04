use ASPNETMVC;

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'bodega_upd')
DROP PROCEDURE bodega_upd
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'bodega_sel_max_id_bodega')
DROP PROCEDURE bodega_sel_max_id_bodega
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'bodega_sel_by_id')
DROP PROCEDURE bodega_sel_by_id
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'bodega_sel_all')
DROP PROCEDURE bodega_sel_all
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'bodega_ins')
DROP PROCEDURE bodega_ins
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'bodega_del')
DROP PROCEDURE bodega_del
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'bodega_id')
DROP PROCEDURE bodega_id
GO

/***
* Descripción: Selecciona el máximo valor del campo clave primaria (primary key).
***/
CREATE PROCEDURE bodega_sel_max_id_bodega
AS
BEGIN
	SELECT MAX(id_bodega) FROM Bodega
END

GO

/***
* Descripción: Adiciona un registro en la tabla socio.
***/
CREATE PROCEDURE bodega_ins
	@nombre varchar(50)
	AS
BEGIN
	INSERT INTO bodega 
            (nombre) 
    VALUES 
           (@nombre) 
END

GO

/***
* Descripción: Modifica un registro de la tabla Socios.
***/
CREATE PROCEDURE bodega_upd
	@id_bodega int,
	@Nombre varchar(50)

AS
BEGIN
	UPDATE Bodega
	SET  
		Nombre = @Nombre
		                           
	 WHERE id_bodega = @id_bodega
END

GO

/***
* Descripción: Selecciona un registro de la tabla Bodega por su clave primaria (primary key).
***/
CREATE PROCEDURE [bodega_sel_by_id]
	@id_bodega int
AS
BEGIN
	SELECT * FROM Bodega WHERE id_bodega = @id_bodega
END

GO

/***
* Descripción: Selecciona todos los registros de la tabla Bodega.
***/
CREATE PROCEDURE bodega_sel_all
AS
BEGIN
	SELECT * FROM Bodega ORDER BY id_bodega ASC
END

GO

/***
* Descripción: Elimina un registro por su clave primaria (primary key)
***/
CREATE PROCEDURE bodega_del
	@id_bodega int
AS
BEGIN
	DELETE FROM Bodega WHERE id_bodega = @id_bodega
END
GO
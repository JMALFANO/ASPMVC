use ASPNETMVC;

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'producto_upd')
DROP PROCEDURE producto_upd
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'producto_sel_max_id_producto')
DROP PROCEDURE producto_sel_max_id_producto
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'producto_sel_by_id')
DROP PROCEDURE producto_sel_by_id
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'producto_sel_all')
DROP PROCEDURE producto_sel_all
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'producto_ins')
DROP PROCEDURE producto_ins
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'producto_del')
DROP PROCEDURE producto_del
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'producto_id')
DROP PROCEDURE producto_id
GO

/***
* Descripción: Selecciona el máximo valor del campo clave primaria (primary key).
***/
CREATE PROCEDURE producto_sel_max_id_producto
AS
BEGIN
	SELECT MAX(id_producto) FROM Producto
END

GO

/***
* Descripción: Adiciona un registro en la tabla socio.
***/
CREATE PROCEDURE producto_ins
	@Nombre varchar(50),
	@descripcion varchar(50),
	@Precio float,
	@id_categoria int,
	@id_bodega int,
	@unidades_producto int

	AS
BEGIN
	INSERT INTO producto 
            (nombre, descripcion,precio, id_categoria, id_bodega, unidades_producto) 
    VALUES 
           (@nombre, @descripcion, @precio, @id_categoria, @id_bodega, @unidades_producto) 
END

GO

/***
* Descripción: Modifica un registro de la tabla Socios.
***/
CREATE PROCEDURE producto_upd
	@id_producto int,
	@Nombre varchar(50),
	@descripcion varchar(50),
	@Precio float,
	@id_categoria int,
	@id_bodega int,
	@unidades_producto int

AS
BEGIN
	UPDATE Producto
	SET  
		Nombre = @Nombre,
		descripcion = @descripcion,
		precio = @precio,
		id_categoria = @id_categoria,
		id_bodega = @id_bodega,
		unidades_producto= @unidades_producto
		                           
	 WHERE id_producto = @id_producto
END

GO

/***
* Descripción: Selecciona un registro de la tabla Producto por su clave primaria (primary key).
***/
CREATE PROCEDURE [producto_sel_by_id]
	@id_producto int
AS
BEGIN
	SELECT * FROM Producto WHERE id_producto = @id_producto
END

GO

/***
* Descripción: Selecciona todos los registros de la tabla Producto.
***/
CREATE PROCEDURE producto_sel_all
AS
BEGIN
	SELECT * FROM Producto ORDER BY id_producto ASC
END

GO

/***
* Descripción: Elimina un registro por su clave primaria (primary key)
***/
CREATE PROCEDURE producto_del
	@id_producto int
AS
BEGIN
	DELETE FROM Producto WHERE id_producto = @id_producto
END
GO
use ASPNETMVC;

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'U' AND name = 'Producto')
DROP TABLE Producto
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'U' AND name = 'Bodega')
DROP TABLE Bodega
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'U' AND name = 'Categoria')
DROP TABLE Categoria
GO


CREATE TABLE [dbo].[Producto] (
    [id_producto] INT  IDENTITY(1,1) NOT NULL,
    [nombre] VARCHAR (50) NULL,
	[descripcion]  VARCHAR (50) NULL,
	[precio]  FLOAT NULL,
	[id_categoria]  int  NULL,
	[id_bodega]  int  NULL,
	[unidades_producto] INT NULL

  PRIMARY KEY CLUSTERED ([id_producto] ASC)
);

CREATE TABLE [dbo].[Categoria] (
    [id_categoria] INT  IDENTITY(1,1) NOT NULL,
    [nombre] VARCHAR (50) NULL
  PRIMARY KEY CLUSTERED ([id_categoria] ASC)
);

CREATE TABLE [dbo].[Bodega] (
    [id_bodega] INT  IDENTITY(1,1) NOT NULL,
    [nombre] VARCHAR (50) NULL,
  PRIMARY KEY CLUSTERED ([id_bodega] ASC)
);

	INSERT INTO Producto VALUES ('Vino', 'Vino tinto Malbec','50','1','1','10')
	INSERT INTO Producto VALUES ('Vino', 'Vino Blanco Dulce','100','1','1','10')

	INSERT INTO Producto VALUES ('Leche', 'Leche Descremada', '150','2','2','20')
	INSERT INTO Producto VALUES ('Queso', 'Queso Fresco', '200','2','2','20')

	INSERT INTO Producto VALUES ('Lavandina', 'Lavandina máxima pureza', '250','3','3','30')
	INSERT INTO Producto VALUES ('Alcohol en gel', 'Alcohol 96°', '300','3','3','30')

	INSERT INTO Categoria VALUES ('Vinos')
	INSERT INTO Categoria VALUES ('Lacteos')
	INSERT INTO Categoria VALUES ('Limpieza')

	INSERT INTO Bodega VALUES ('Bodega Flores')
    INSERT INTO Bodega VALUES ('Bodega Caballito')
	INSERT INTO Bodega VALUES ('Bodega Saavedra')

	select * from Bodega;
	select * from Categoria;
	select * from Producto;
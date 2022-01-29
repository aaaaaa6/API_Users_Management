
-- Base de datos

CREATE DATABASE PruebaSD

GO

-- Usar Base de datos

USE PruebaSD
GO
---------------------------------------------
------------- Tablas-------------------------
---------------------------------------------
---- Usuarios
---------------------------------------------
IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'Usuario'))
BEGIN

	CREATE TABLE [dbo].[Usuario](
		[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
		[Nombre] [varchar](100) NULL,
		[Apellido] [varchar](100) NULL,
	)
		
END
GO
INSERT INTO  [dbo].[Usuario] VALUES('Usuario Uno','Apellido Uno')
INSERT INTO  [dbo].[Usuario] VALUES('Usuario Dos','Apellido Dos')
INSERT INTO  [dbo].[Usuario] VALUES('Usuario Tres','Apellido Tres')
INSERT INTO  [dbo].[Usuario] VALUES('Usuario Cuatro','Apellido Cuatro')
INSERT INTO  [dbo].[Usuario] VALUES('Usuario Cinco','Apellido Cinco')
INSERT INTO  [dbo].[Usuario] VALUES('Usuario Seis','Apellido Seis')
GO

SELECT * FROM [dbo].[Usuario]

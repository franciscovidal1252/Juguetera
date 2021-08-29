1) Paso
Para poder utilizar el programa se debe de crear una base de datos en Sql Server y ejecutar el siguiente script.
---------
USE [master]

CREATE DATABASE [JugueteriaDB]
GO

USE [JugueteriaDB]
GO

CREATE TABLE [dbo].[Inventario](
	  Id INT
	, Nombre VARCHAR(50)
	, Descripcion VARCHAR(100)
	, RestriccionEdad INT
	, Compania VARCHAR(50)
	, Precio MONEY
CONSTRAINT [PK_Id] PRIMARY KEY CLUSTERED
(
	Id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


----------

2) Paso
Abrir la solución y editar el appsettings.json del proyecto Jugueteria.API, modificar el ConnectionStrings a la conexion de base de datos creada.
ejecutar el proyecto de Jugueteria.API, una vez abierto tomar nota de la url que se nos genera  junto con el puerto. 
detener la depuración.
Editar el appsettings.json del proyecto Jugueteria.MVC, modificar el urlWebApi colocando la url del proyecto Jugueteria.API

3) Ejecutar el proyecto Jugueteria.API, una vez cargada la pagina, ejecutar el proyecto Jugueteria.MVC como nueva instancia(clicl derecho sobre el proyecto - Depurar - Iniciar nueva instancia.

El programa Jugueteria.API inserta 5 ejemplos para poder visualizar.

----------------
En el programa podemos ver un boton de nuevo y una tabla donde se muestra el inventario, se puede dar de alta un nuevo articulo dando clic en Add New y modificar en los botones de la tabla.
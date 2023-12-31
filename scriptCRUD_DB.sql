USE [master]
GO
/****** Object:  Database [CRUD_DB]    Script Date: 22/9/2023 08:02:49 ******/
CREATE DATABASE [CRUD_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CRUD_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\CRUD_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CRUD_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\CRUD_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [CRUD_DB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CRUD_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CRUD_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CRUD_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CRUD_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CRUD_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CRUD_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CRUD_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CRUD_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CRUD_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CRUD_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CRUD_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CRUD_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CRUD_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CRUD_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CRUD_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CRUD_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CRUD_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CRUD_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CRUD_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CRUD_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CRUD_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CRUD_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CRUD_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CRUD_DB] SET RECOVERY FULL 
GO
ALTER DATABASE [CRUD_DB] SET  MULTI_USER 
GO
ALTER DATABASE [CRUD_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CRUD_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CRUD_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CRUD_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CRUD_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CRUD_DB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CRUD_DB', N'ON'
GO
ALTER DATABASE [CRUD_DB] SET QUERY_STORE = ON
GO
ALTER DATABASE [CRUD_DB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [CRUD_DB]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 22/9/2023 08:02:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[Codigo_Categoria] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion_Categoria] [varchar](50) NULL,
	[Activo] [bit] NULL,
 CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED 
(
	[Codigo_Categoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medidas]    Script Date: 22/9/2023 08:02:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medidas](
	[Codigo_Medida] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion_Medida] [varchar](20) NULL,
	[Activo] [bit] NULL,
 CONSTRAINT [PK_Medidas] PRIMARY KEY CLUSTERED 
(
	[Codigo_Medida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 22/9/2023 08:02:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[Codigo_Producto] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion_Producto] [varchar](80) NULL,
	[Marca_Producto] [varchar](30) NULL,
	[Codigo_Medida] [int] NULL,
	[Codigo_Categoria] [int] NULL,
	[Stock_Actual] [decimal](18, 2) NULL,
	[Fecha_Creacion] [datetime] NULL,
	[Activo] [bit] NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[Codigo_Producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categorias] ON 

INSERT [dbo].[Categorias] ([Codigo_Categoria], [Descripcion_Categoria], [Activo]) VALUES (1, N'Abarrotes', 1)
INSERT [dbo].[Categorias] ([Codigo_Categoria], [Descripcion_Categoria], [Activo]) VALUES (2, N'Bebidas', 1)
INSERT [dbo].[Categorias] ([Codigo_Categoria], [Descripcion_Categoria], [Activo]) VALUES (3, N'Verduras', 1)
SET IDENTITY_INSERT [dbo].[Categorias] OFF
GO
SET IDENTITY_INSERT [dbo].[Medidas] ON 

INSERT [dbo].[Medidas] ([Codigo_Medida], [Descripcion_Medida], [Activo]) VALUES (1, N'Unidad', 1)
INSERT [dbo].[Medidas] ([Codigo_Medida], [Descripcion_Medida], [Activo]) VALUES (2, N'Kilogramo', 1)
INSERT [dbo].[Medidas] ([Codigo_Medida], [Descripcion_Medida], [Activo]) VALUES (3, N'Metro', 1)
INSERT [dbo].[Medidas] ([Codigo_Medida], [Descripcion_Medida], [Activo]) VALUES (4, N'Litro', 1)
INSERT [dbo].[Medidas] ([Codigo_Medida], [Descripcion_Medida], [Activo]) VALUES (5, N'Caja', 1)
INSERT [dbo].[Medidas] ([Codigo_Medida], [Descripcion_Medida], [Activo]) VALUES (6, N'Pieza', 1)
SET IDENTITY_INSERT [dbo].[Medidas] OFF
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Categorias] FOREIGN KEY([Codigo_Categoria])
REFERENCES [dbo].[Categorias] ([Codigo_Categoria])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Categorias]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Medidas] FOREIGN KEY([Codigo_Medida])
REFERENCES [dbo].[Medidas] ([Codigo_Medida])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Medidas]
GO
/****** Object:  StoredProcedure [dbo].[Activo_Producto]    Script Date: 22/9/2023 08:02:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Activo_Producto]
@nCodigo_Producto int,
@bEstado_Activo bit
AS
	UPDATE Productos SET Activo = @bEstado_Activo
					 WHERE Codigo_Producto = @nCodigo_Producto
GO
/****** Object:  StoredProcedure [dbo].[USP_Guardar_Producto]    Script Date: 22/9/2023 08:02:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_Guardar_Producto]  
@Opcion int = 1, -- 1 = Nuevo Registro / 2 = Actualizar Registro  
@nCodigo_Producto int,  
@cDescripcion_Producto varchar(80),  
@cMarca_Producto varchar(30),  
@nCodigo_Medida int,  
@nCodigo_Categoria int,  
@nStock_Actual decimal(18,2)  
AS  
IF @Opcion = 1 --Nuevo Ingreso  
 BEGIN  
  INSERT INTO Productos(Descripcion_Producto, Marca_Producto,   
         Codigo_Medida, Codigo_Categoria, Stock_Actual,   
         Fecha_Creacion, Activo)  
     VALUES (@cDescripcion_Producto, @cMarca_Producto,  
       @nCodigo_Medida, @nCodigo_Categoria, @nStock_Actual,  
       GETDATE(), 1);  
 END;  
ELSE -- Actualizar Registro  
 BEGIN  
  UPDATE Productos SET Descripcion_Producto = @cDescripcion_Producto,  
        Marca_Producto = @cMarca_Producto,  
        Codigo_Medida = @nCodigo_Medida,  
        Codigo_Categoria = @nCodigo_Categoria,  
        Stock_Actual = @nStock_Actual  
      WHERE Codigo_Producto = @nCodigo_Producto;  
 END;  
GO
/****** Object:  StoredProcedure [dbo].[USP_Listado_Categoria]    Script Date: 22/9/2023 08:02:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_Listado_Categoria]
AS
	SELECT Descripcion_Categoria, Codigo_Categoria
	FROM Categorias
	WHERE Activo = 1;
GO
/****** Object:  StoredProcedure [dbo].[USP_Listado_Medida]    Script Date: 22/9/2023 08:02:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_Listado_Medida]
AS
	SELECT Descripcion_Medida, Codigo_Medida
	FROM Medidas
	WHERE Activo = 1;
GO
/****** Object:  StoredProcedure [dbo].[USP_Listado_Producto]    Script Date: 22/9/2023 08:02:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_Listado_Producto]
@cTexto varchar(80)=''
AS
	SELECT P.Codigo_Producto, P.Descripcion_Producto, P.Marca_Producto,
			M.Descripcion_Medida, C.Descripcion_Categoria, P.Stock_Actual,
			P.Codigo_Medida, P.Codigo_Categoria
	FROM Productos P
	INNER JOIN Medidas M ON P.Codigo_Medida = M.Codigo_Medida
	INNER JOIN Categorias C ON P.Codigo_Categoria = C.Codigo_Categoria
	WHERE P.Activo = 1 AND UPPER(TRIM(P.Descripcion_Producto)) + UPPER(TRIM(P.Marca_Producto))
	LIKE '%'+UPPER(TRIM(@cTexto))+'%'
	ORDER BY P.Codigo_Producto; 
GO
USE [master]
GO
ALTER DATABASE [CRUD_DB] SET  READ_WRITE 
GO

USE [master]
GO
/****** Object:  Database [PUPUSERIA]    Script Date: 8/6/2026 17:27:39 ******/
CREATE DATABASE [PUPUSERIA]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PUPUSERIA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL17.SQLEXPRESS\MSSQL\DATA\PUPUSERIA.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PUPUSERIA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL17.SQLEXPRESS\MSSQL\DATA\PUPUSERIA_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [PUPUSERIA] SET COMPATIBILITY_LEVEL = 170
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PUPUSERIA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PUPUSERIA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PUPUSERIA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PUPUSERIA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PUPUSERIA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PUPUSERIA] SET ARITHABORT OFF 
GO
ALTER DATABASE [PUPUSERIA] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PUPUSERIA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PUPUSERIA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PUPUSERIA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PUPUSERIA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PUPUSERIA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PUPUSERIA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PUPUSERIA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PUPUSERIA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PUPUSERIA] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PUPUSERIA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PUPUSERIA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PUPUSERIA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PUPUSERIA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PUPUSERIA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PUPUSERIA] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PUPUSERIA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PUPUSERIA] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PUPUSERIA] SET  MULTI_USER 
GO
ALTER DATABASE [PUPUSERIA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PUPUSERIA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PUPUSERIA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PUPUSERIA] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PUPUSERIA] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PUPUSERIA] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PUPUSERIA] SET OPTIMIZED_LOCKING = OFF 
GO
ALTER DATABASE [PUPUSERIA] SET QUERY_STORE = ON
GO
ALTER DATABASE [PUPUSERIA] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [PUPUSERIA]
GO
/****** Object:  Schema [AUDITORIA]    Script Date: 8/6/2026 17:27:39 ******/
CREATE SCHEMA [AUDITORIA]
GO
/****** Object:  Schema [AUTENTICACION]    Script Date: 8/6/2026 17:27:39 ******/
CREATE SCHEMA [AUTENTICACION]
GO
/****** Object:  Schema [BODEGA]    Script Date: 8/6/2026 17:27:39 ******/
CREATE SCHEMA [BODEGA]
GO
/****** Object:  Schema [COMPRA]    Script Date: 8/6/2026 17:27:39 ******/
CREATE SCHEMA [COMPRA]
GO
/****** Object:  Schema [DELIVERY]    Script Date: 8/6/2026 17:27:39 ******/
CREATE SCHEMA [DELIVERY]
GO
/****** Object:  Schema [GLOBAL]    Script Date: 8/6/2026 17:27:39 ******/
CREATE SCHEMA [GLOBAL]
GO
/****** Object:  Schema [RRHH]    Script Date: 8/6/2026 17:27:39 ******/
CREATE SCHEMA [RRHH]
GO
/****** Object:  Schema [VENTA]    Script Date: 8/6/2026 17:27:39 ******/
CREATE SCHEMA [VENTA]
GO
/****** Object:  UserDefinedTableType [BODEGA].[DetalleProduccionType]    Script Date: 8/6/2026 17:27:39 ******/
CREATE TYPE [BODEGA].[DetalleProduccionType] AS TABLE(
	[InventarioId] [int] NULL,
	[Cantidad] [float] NULL
)
GO
/****** Object:  UserDefinedTableType [COMPRA].[DetalleCompraType]    Script Date: 8/6/2026 17:27:40 ******/
CREATE TYPE [COMPRA].[DetalleCompraType] AS TABLE(
	[InventarioId] [int] NULL,
	[Cantidad] [float] NULL,
	[PrecioCompra] [decimal](10, 2) NULL
)
GO
/****** Object:  UserDefinedTableType [VENTA].[DetalleOrdenType]    Script Date: 8/6/2026 17:27:40 ******/
CREATE TYPE [VENTA].[DetalleOrdenType] AS TABLE(
	[MenuId] [int] NULL,
	[ComboId] [int] NULL,
	[PrecioUnitario] [decimal](10, 2) NULL,
	[Cantidad] [int] NULL
)
GO
/****** Object:  Table [AUDITORIA].[ACCION_EVENTO]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AUDITORIA].[ACCION_EVENTO](
	[AccionEventoId] [int] IDENTITY(1,1) NOT NULL,
	[AccionEvento] [varchar](75) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AccionEventoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [AUDITORIA].[HISTORIAL]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AUDITORIA].[HISTORIAL](
	[HistorialId] [int] IDENTITY(1,1) NOT NULL,
	[FechaHora] [datetime] NULL,
	[AccionEventoId] [int] NOT NULL,
	[Detalle] [varchar](200) NULL,
	[UsuarioRegistroId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[HistorialId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [AUTENTICACION].[ROL]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AUTENTICACION].[ROL](
	[RolId] [int] IDENTITY(1,1) NOT NULL,
	[Rol] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [AUTENTICACION].[USUARIO]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AUTENTICACION].[USUARIO](
	[UsuarioId] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](20) NOT NULL,
	[Clave] [varchar](25) NOT NULL,
	[EmpleadoId] [int] NULL,
	[EstadoId] [int] NOT NULL,
	[RolId] [int] NOT NULL,
	[UsuarioRegistroId] [int] NULL,
	[UsuarioModificiacionId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [BODEGA].[DET_ORDEN_PRODUCCION]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [BODEGA].[DET_ORDEN_PRODUCCION](
	[DetOrdenProduccionId] [int] IDENTITY(1,1) NOT NULL,
	[OrdenProduccionId] [int] NOT NULL,
	[InventarioId] [int] NOT NULL,
	[Cantidad] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DetOrdenProduccionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [BODEGA].[ORDEN_PRODUCCION]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [BODEGA].[ORDEN_PRODUCCION](
	[OrdenProduccionId] [int] IDENTITY(1,1) NOT NULL,
	[NoOrdenProduccion] [varchar](10) NOT NULL,
	[Fecha] [date] NOT NULL,
	[EmpleadoId] [int] NOT NULL,
	[UsuarioRegistroId] [int] NOT NULL,
	[UsuarioModificacionId] [int] NULL,
	[ProductoFinal] [varchar](100) NULL,
	[CantidadProducto] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrdenProduccionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [COMPRA].[COMPRA]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [COMPRA].[COMPRA](
	[CompraId] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [date] NOT NULL,
	[NoDocumento] [varchar](10) NOT NULL,
	[ProveedorId] [int] NOT NULL,
	[Total] [decimal](10, 2) NOT NULL,
	[EstadoId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CompraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [COMPRA].[DET_COMPRA]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [COMPRA].[DET_COMPRA](
	[DetalleCompraId] [int] IDENTITY(1,1) NOT NULL,
	[CompraId] [int] NOT NULL,
	[InventarioId] [int] NOT NULL,
	[Cantidad] [float] NOT NULL,
	[PrecioCompra] [decimal](10, 2) NOT NULL,
	[TotalDetalleCompra] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DetalleCompraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [COMPRA].[INVENTARIO]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [COMPRA].[INVENTARIO](
	[InventarioId] [int] IDENTITY(1,1) NOT NULL,
	[NombreProducto] [varchar](100) NOT NULL,
	[UnidadDeMedida] [varchar](20) NULL,
	[Cantidad] [float] NOT NULL,
	[PrecioCosto] [decimal](10, 2) NOT NULL,
	[TipoInventarioId] [int] NOT NULL,
	[UsuarioRegistroId] [int] NOT NULL,
	[UsuarioModificacionId] [int] NULL,
	[EstadoId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[InventarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [COMPRA].[PROVEEDOR]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [COMPRA].[PROVEEDOR](
	[ProveedorId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Direccion] [varchar](100) NULL,
	[Telefono] [varchar](9) NOT NULL,
	[NoRegistro] [varchar](8) NOT NULL,
	[NIT] [varchar](16) NOT NULL,
	[EstadoId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProveedorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [COMPRA].[TIPO_INVENTARIO]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [COMPRA].[TIPO_INVENTARIO](
	[TipoInventarioId] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [varchar](30) NOT NULL,
	[Descripcion] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[TipoInventarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [DELIVERY].[CONFIGURACION_LOCAL]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [DELIVERY].[CONFIGURACION_LOCAL](
	[ConfigId] [int] IDENTITY(1,1) NOT NULL,
	[MunicipioId] [int] NOT NULL,
	[ColoniaBarrio] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ConfigId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [DELIVERY].[COORDENADAS_MUNICIPIO]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [DELIVERY].[COORDENADAS_MUNICIPIO](
	[MunicipioId] [int] NOT NULL,
	[Latitud] [float] NOT NULL,
	[Longitud] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MunicipioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [DELIVERY].[DIRECCION]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [DELIVERY].[DIRECCION](
	[DireccionId] [int] IDENTITY(1,1) NOT NULL,
	[MunicipioId] [int] NOT NULL,
	[ColoniBarrio] [varchar](100) NOT NULL,
	[NoCasa] [varchar](4) NULL,
	[PuntoReferencia] [varchar](50) NULL,
	[CoordenadasMaps] [varchar](50) NULL,
	[EstadoId] [int] NOT NULL,
	[FechaModificacion] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DireccionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [DELIVERY].[ENVIO]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [DELIVERY].[ENVIO](
	[EnvioId] [int] IDENTITY(1,1) NOT NULL,
	[OrdenId] [int] NOT NULL,
	[RepartidorId] [int] NOT NULL,
	[DireccionId] [int] NOT NULL,
	[Tarifa] [decimal](10, 2) NOT NULL,
	[EstadoId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EnvioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [DELIVERY].[MUNICIPIO]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [DELIVERY].[MUNICIPIO](
	[MunicipioId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MunicipioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [DELIVERY].[REPARTIDOR]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [DELIVERY].[REPARTIDOR](
	[RepartidorId] [int] IDENTITY(1,1) NOT NULL,
	[EmpleadoId] [int] NOT NULL,
	[NoPlacaMoto] [varchar](7) NOT NULL,
	[EstadoId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RepartidorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [DELIVERY].[TARIFA_DELIVERY]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [DELIVERY].[TARIFA_DELIVERY](
	[TarifaId] [int] IDENTITY(1,1) NOT NULL,
	[MunicipioId] [int] NOT NULL,
	[Costo] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TarifaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [GLOBAL].[ENTIDAD]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GLOBAL].[ENTIDAD](
	[EntidadId] [int] IDENTITY(1,1) NOT NULL,
	[Entidad] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EntidadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [GLOBAL].[ESTADO]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GLOBAL].[ESTADO](
	[EstadoId] [int] IDENTITY(1,1) NOT NULL,
	[Estado] [varchar](30) NOT NULL,
	[Descripcion] [varchar](100) NULL,
	[EntidadId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EstadoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [RRHH].[CARGO]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RRHH].[CARGO](
	[CargoId] [int] IDENTITY(1,1) NOT NULL,
	[Cargo] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CargoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [RRHH].[EMPLEADO]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RRHH].[EMPLEADO](
	[EmpleadoId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](25) NOT NULL,
	[Apellido] [varchar](25) NOT NULL,
	[Telefono] [varchar](15) NOT NULL,
	[Email] [varchar](60) NULL,
	[Direccion] [varchar](100) NOT NULL,
	[FechaNac] [date] NOT NULL,
	[FechaContratacion] [date] NOT NULL,
	[CargoId] [int] NOT NULL,
	[EstadoId] [int] NOT NULL,
	[UsuarioRegistroId] [int] NOT NULL,
	[UsuarioModificacionId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmpleadoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [VENTA].[CATEGORIA]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [VENTA].[CATEGORIA](
	[CategoriaId] [int] IDENTITY(1,1) NOT NULL,
	[Categoria] [varchar](20) NOT NULL,
	[EstadoId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoriaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [VENTA].[CLIENTE]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [VENTA].[CLIENTE](
	[ClienteId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](25) NOT NULL,
	[Apellido] [varchar](25) NOT NULL,
	[Telefono] [varchar](10) NOT NULL,
	[CorreoElectronico] [varchar](100) NULL,
	[DireccionId] [int] NOT NULL,
	[EstadoId] [int] NOT NULL,
	[NombreCompleto] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [VENTA].[COMBO]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [VENTA].[COMBO](
	[ComboId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](40) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[Precio] [decimal](10, 2) NOT NULL,
	[EstadoId] [int] NOT NULL,
	[CategoriaId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ComboId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [VENTA].[DESCUENTO]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [VENTA].[DESCUENTO](
	[DescuentoId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Porcentaje] [decimal](5, 2) NOT NULL,
	[CategoriaId] [int] NULL,
	[MenuId] [int] NULL,
	[ComboId] [int] NULL,
	[FechaDesde] [date] NOT NULL,
	[FechaHasta] [date] NOT NULL,
	[EstadoId] [int] NOT NULL,
	[TipoDescuentoId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[DescuentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [VENTA].[DET_COMBO]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [VENTA].[DET_COMBO](
	[DetalleComboId] [int] IDENTITY(1,1) NOT NULL,
	[ComboId] [int] NULL,
	[idMenu] [int] NULL,
	[Cantidad] [int] NULL,
	[CategoriaId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[DetalleComboId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [VENTA].[DET_ORDEN]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [VENTA].[DET_ORDEN](
	[DetOrdenId] [int] IDENTITY(1,1) NOT NULL,
	[OrdenId] [int] NOT NULL,
	[MenuId] [int] NULL,
	[ComboId] [int] NULL,
	[PrecioUnitario] [decimal](10, 2) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Total]  AS ([PrecioUnitario]*[Cantidad]),
PRIMARY KEY CLUSTERED 
(
	[DetOrdenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [VENTA].[MENU]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [VENTA].[MENU](
	[MenuId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Precio] [decimal](10, 2) NOT NULL,
	[InventarioId] [int] NULL,
	[CategoriaId] [int] NOT NULL,
	[EstadoId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [VENTA].[METODO_PAGO]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [VENTA].[METODO_PAGO](
	[MetodoPagoId] [int] IDENTITY(1,1) NOT NULL,
	[Metodo] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MetodoPagoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [VENTA].[ORDEN]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [VENTA].[ORDEN](
	[OrdenId] [int] IDENTITY(1,1) NOT NULL,
	[FechaHora] [datetime] NOT NULL,
	[Total] [decimal](10, 2) NOT NULL,
	[DescuentoId] [int] NULL,
	[ClienteId] [int] NOT NULL,
	[EstadoId] [int] NOT NULL,
	[TipoOrdenId] [int] NOT NULL,
	[UsuarioRegistroId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrdenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [VENTA].[TIPO_DESCUENTO]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [VENTA].[TIPO_DESCUENTO](
	[TipoDescuentoId] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TipoDescuentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [VENTA].[TIPO_ORDEN]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [VENTA].[TIPO_ORDEN](
	[TipoOrdenId] [int] IDENTITY(1,1) NOT NULL,
	[TipoOrden] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TipoOrdenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [VENTA].[VENTA]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [VENTA].[VENTA](
	[VentaId] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [date] NOT NULL,
	[OrdenId] [int] NOT NULL,
	[NoDocumento] [varchar](10) NOT NULL,
	[EstadoId] [int] NOT NULL,
	[MetodoPago] [varchar](30) NULL,
	[MontoRecibido] [decimal](10, 2) NULL,
	[Cambio] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[VentaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [AUDITORIA].[ACCION_EVENTO] ON 

INSERT [AUDITORIA].[ACCION_EVENTO] ([AccionEventoId], [AccionEvento]) VALUES (1, N'INSERCION')
INSERT [AUDITORIA].[ACCION_EVENTO] ([AccionEventoId], [AccionEvento]) VALUES (2, N'ACTUALIZACION')
INSERT [AUDITORIA].[ACCION_EVENTO] ([AccionEventoId], [AccionEvento]) VALUES (3, N'ELIMINACION')
INSERT [AUDITORIA].[ACCION_EVENTO] ([AccionEventoId], [AccionEvento]) VALUES (4, N'ELIMINACION LOGICA')
INSERT [AUDITORIA].[ACCION_EVENTO] ([AccionEventoId], [AccionEvento]) VALUES (5, N'LOGIN')
SET IDENTITY_INSERT [AUDITORIA].[ACCION_EVENTO] OFF
GO
SET IDENTITY_INSERT [AUDITORIA].[HISTORIAL] ON 

INSERT [AUDITORIA].[HISTORIAL] ([HistorialId], [FechaHora], [AccionEventoId], [Detalle], [UsuarioRegistroId]) VALUES (6, CAST(N'2026-06-08T01:16:51.117' AS DateTime), 2, N'Empleado actualizado: Carlos Mendoza', 9)
INSERT [AUDITORIA].[HISTORIAL] ([HistorialId], [FechaHora], [AccionEventoId], [Detalle], [UsuarioRegistroId]) VALUES (8, CAST(N'2026-06-08T08:01:29.090' AS DateTime), 2, N'Empleado actualizado: Carlos Manuel Mendoza', 9)
INSERT [AUDITORIA].[HISTORIAL] ([HistorialId], [FechaHora], [AccionEventoId], [Detalle], [UsuarioRegistroId]) VALUES (9, CAST(N'2026-06-08T08:08:47.230' AS DateTime), 2, N'Usuario cocinero modificado por ID 9: EstadoId: 2 ? 1', 9)
INSERT [AUDITORIA].[HISTORIAL] ([HistorialId], [FechaHora], [AccionEventoId], [Detalle], [UsuarioRegistroId]) VALUES (10, CAST(N'2026-06-08T08:08:52.633' AS DateTime), 4, N'Usuario desactivado: cocinero (ID: 6) por usuario ID 9', 9)
INSERT [AUDITORIA].[HISTORIAL] ([HistorialId], [FechaHora], [AccionEventoId], [Detalle], [UsuarioRegistroId]) VALUES (11, CAST(N'2026-06-08T08:13:26.390' AS DateTime), 1, N'Nuevo usuario: smolina (Registrado por ID: 9)', 9)
INSERT [AUDITORIA].[HISTORIAL] ([HistorialId], [FechaHora], [AccionEventoId], [Detalle], [UsuarioRegistroId]) VALUES (12, CAST(N'2026-06-08T08:20:25.830' AS DateTime), 2, N'Proveedor NIÑA LUCY - MAIZ AL MAYOR modificado por ID 9: Teléfono: 76768989 a 76768983; Estado: Inactivo a Inactivo', 9)
INSERT [AUDITORIA].[HISTORIAL] ([HistorialId], [FechaHora], [AccionEventoId], [Detalle], [UsuarioRegistroId]) VALUES (13, CAST(N'2026-06-08T08:30:39.103' AS DateTime), 1, N'Nuevo cliente: Felipe Tobar (Prueba) (Registrado por ID: 9)', 9)
INSERT [AUDITORIA].[HISTORIAL] ([HistorialId], [FechaHora], [AccionEventoId], [Detalle], [UsuarioRegistroId]) VALUES (14, CAST(N'2026-06-08T08:31:47.170' AS DateTime), 2, N'Cliente Felipe Tobar (Prueba) modificado por ID 9: Teléfono: +503323232 a +503323200', 9)
INSERT [AUDITORIA].[HISTORIAL] ([HistorialId], [FechaHora], [AccionEventoId], [Detalle], [UsuarioRegistroId]) VALUES (15, CAST(N'2026-06-08T09:29:53.220' AS DateTime), 1, N'Nuevo cliente: Gerson Perez (Registrado por ID: 9)', 9)
INSERT [AUDITORIA].[HISTORIAL] ([HistorialId], [FechaHora], [AccionEventoId], [Detalle], [UsuarioRegistroId]) VALUES (16, CAST(N'2026-06-08T09:31:35.173' AS DateTime), 1, N'Nuevo cliente: Gerson Perez (Registrado por ID: 9)', 9)
INSERT [AUDITORIA].[HISTORIAL] ([HistorialId], [FechaHora], [AccionEventoId], [Detalle], [UsuarioRegistroId]) VALUES (17, CAST(N'2026-06-08T09:33:00.663' AS DateTime), 2, N'Empleado Pedro Martinez modificado por ID 9: Teléfono: 78909012 a +50361050871', 9)
INSERT [AUDITORIA].[HISTORIAL] ([HistorialId], [FechaHora], [AccionEventoId], [Detalle], [UsuarioRegistroId]) VALUES (18, CAST(N'2026-06-08T09:33:48.863' AS DateTime), 2, N'Empleado Pedro Martinez modificado por ID 9: Teléfono: 78909012 a +50361050871', 9)
INSERT [AUDITORIA].[HISTORIAL] ([HistorialId], [FechaHora], [AccionEventoId], [Detalle], [UsuarioRegistroId]) VALUES (19, CAST(N'2026-06-08T09:34:06.280' AS DateTime), 2, N'Empleado Pedro Martinez modificado por ID 9: Estado: Inactivo a Inactivo', 9)
INSERT [AUDITORIA].[HISTORIAL] ([HistorialId], [FechaHora], [AccionEventoId], [Detalle], [UsuarioRegistroId]) VALUES (20, CAST(N'2026-06-08T09:35:29.993' AS DateTime), 2, N'Empleado Fernando López modificado por ID 9: Nombre: Carlos a Fernando; Apellido: Mendoza a López; Teléfono: 78901234 a +50361050871; Email: cajero@gusto.com a fernando.lopez@gusto.com; Dirección: Col', 9)
INSERT [AUDITORIA].[HISTORIAL] ([HistorialId], [FechaHora], [AccionEventoId], [Detalle], [UsuarioRegistroId]) VALUES (21, CAST(N'2026-06-08T09:36:27.890' AS DateTime), 1, N'Nuevo empleado: Fernando Lopez (2) (Registrado por ID: 9)', 9)
INSERT [AUDITORIA].[HISTORIAL] ([HistorialId], [FechaHora], [AccionEventoId], [Detalle], [UsuarioRegistroId]) VALUES (22, CAST(N'2026-06-08T09:46:39.120' AS DateTime), 1, N'Nuevo empleado: Oracio Lopez (Registrado por ID: 9)', 9)
INSERT [AUDITORIA].[HISTORIAL] ([HistorialId], [FechaHora], [AccionEventoId], [Detalle], [UsuarioRegistroId]) VALUES (23, CAST(N'2026-06-08T09:47:10.877' AS DateTime), 1, N'Nuevo repartidor:  (Placa: P455-2) (Registrado por ID: 9)', 9)
INSERT [AUDITORIA].[HISTORIAL] ([HistorialId], [FechaHora], [AccionEventoId], [Detalle], [UsuarioRegistroId]) VALUES (24, CAST(N'2026-06-08T09:48:50.597' AS DateTime), 2, N'Empleado Pedro Martinez modificado por ID 9: Teléfono: 78909012 a +50361050871; Estado: Inactivo a Inactivo', 9)
INSERT [AUDITORIA].[HISTORIAL] ([HistorialId], [FechaHora], [AccionEventoId], [Detalle], [UsuarioRegistroId]) VALUES (25, CAST(N'2026-06-08T09:49:05.060' AS DateTime), 2, N'Repartidor  modificado por ID 9: Estado: No Disponible a No Disponible', 9)
INSERT [AUDITORIA].[HISTORIAL] ([HistorialId], [FechaHora], [AccionEventoId], [Detalle], [UsuarioRegistroId]) VALUES (26, CAST(N'2026-06-08T09:51:04.630' AS DateTime), 1, N'Nuevo empleado: Josue Medina (Registrado por ID: 9)', 9)
INSERT [AUDITORIA].[HISTORIAL] ([HistorialId], [FechaHora], [AccionEventoId], [Detalle], [UsuarioRegistroId]) VALUES (27, CAST(N'2026-06-08T09:51:29.640' AS DateTime), 1, N'Nuevo usuario: jmedina (Registrado por ID: 9)', 9)
INSERT [AUDITORIA].[HISTORIAL] ([HistorialId], [FechaHora], [AccionEventoId], [Detalle], [UsuarioRegistroId]) VALUES (28, CAST(N'2026-06-08T09:51:46.850' AS DateTime), 4, N'Usuario desactivado: jmedina (ID: 13) por usuario ID 9', 9)
INSERT [AUDITORIA].[HISTORIAL] ([HistorialId], [FechaHora], [AccionEventoId], [Detalle], [UsuarioRegistroId]) VALUES (29, CAST(N'2026-06-08T09:52:05.390' AS DateTime), 2, N'Usuario jmedina modificado por ID 9: EstadoId: 2 ? 1', 9)
SET IDENTITY_INSERT [AUDITORIA].[HISTORIAL] OFF
GO
SET IDENTITY_INSERT [AUTENTICACION].[ROL] ON 

INSERT [AUTENTICACION].[ROL] ([RolId], [Rol]) VALUES (1, N'ADMINISTRADOR')
INSERT [AUTENTICACION].[ROL] ([RolId], [Rol]) VALUES (2, N'CAJERO')
INSERT [AUTENTICACION].[ROL] ([RolId], [Rol]) VALUES (3, N'COCINERO')
INSERT [AUTENTICACION].[ROL] ([RolId], [Rol]) VALUES (4, N'REPARTIDOR')
INSERT [AUTENTICACION].[ROL] ([RolId], [Rol]) VALUES (5, N'BODEGUERO')
SET IDENTITY_INSERT [AUTENTICACION].[ROL] OFF
GO
SET IDENTITY_INSERT [AUTENTICACION].[USUARIO] ON 

INSERT [AUTENTICACION].[USUARIO] ([UsuarioId], [Usuario], [Clave], [EmpleadoId], [EstadoId], [RolId], [UsuarioRegistroId], [UsuarioModificiacionId]) VALUES (5, N'cajero', N'1234', 13, 1, 2, NULL, NULL)
INSERT [AUTENTICACION].[USUARIO] ([UsuarioId], [Usuario], [Clave], [EmpleadoId], [EstadoId], [RolId], [UsuarioRegistroId], [UsuarioModificiacionId]) VALUES (6, N'cocinero', N'1234', 14, 2, 3, NULL, 9)
INSERT [AUTENTICACION].[USUARIO] ([UsuarioId], [Usuario], [Clave], [EmpleadoId], [EstadoId], [RolId], [UsuarioRegistroId], [UsuarioModificiacionId]) VALUES (7, N'repartidor', N'111', 15, 1, 4, NULL, 9)
INSERT [AUTENTICACION].[USUARIO] ([UsuarioId], [Usuario], [Clave], [EmpleadoId], [EstadoId], [RolId], [UsuarioRegistroId], [UsuarioModificiacionId]) VALUES (8, N'bodeguero-1', N'111', 16, 2, 5, NULL, 11)
INSERT [AUTENTICACION].[USUARIO] ([UsuarioId], [Usuario], [Clave], [EmpleadoId], [EstadoId], [RolId], [UsuarioRegistroId], [UsuarioModificiacionId]) VALUES (9, N'admin', N'1234', 12, 1, 1, 9, 8)
INSERT [AUTENTICACION].[USUARIO] ([UsuarioId], [Usuario], [Clave], [EmpleadoId], [EstadoId], [RolId], [UsuarioRegistroId], [UsuarioModificiacionId]) VALUES (11, N'bsanchez', N'1234', 17, 1, 1, 9, NULL)
INSERT [AUTENTICACION].[USUARIO] ([UsuarioId], [Usuario], [Clave], [EmpleadoId], [EstadoId], [RolId], [UsuarioRegistroId], [UsuarioModificiacionId]) VALUES (12, N'smolina', N'1234', 19, 1, 3, 9, NULL)
INSERT [AUTENTICACION].[USUARIO] ([UsuarioId], [Usuario], [Clave], [EmpleadoId], [EstadoId], [RolId], [UsuarioRegistroId], [UsuarioModificiacionId]) VALUES (13, N'jmedina', N'1234', 29, 1, 2, 9, 9)
SET IDENTITY_INSERT [AUTENTICACION].[USUARIO] OFF
GO
SET IDENTITY_INSERT [BODEGA].[DET_ORDEN_PRODUCCION] ON 

INSERT [BODEGA].[DET_ORDEN_PRODUCCION] ([DetOrdenProduccionId], [OrdenProduccionId], [InventarioId], [Cantidad]) VALUES (13, 8, 4, 1)
INSERT [BODEGA].[DET_ORDEN_PRODUCCION] ([DetOrdenProduccionId], [OrdenProduccionId], [InventarioId], [Cantidad]) VALUES (14, 8, 5, 0.4)
INSERT [BODEGA].[DET_ORDEN_PRODUCCION] ([DetOrdenProduccionId], [OrdenProduccionId], [InventarioId], [Cantidad]) VALUES (15, 9, 4, 1)
INSERT [BODEGA].[DET_ORDEN_PRODUCCION] ([DetOrdenProduccionId], [OrdenProduccionId], [InventarioId], [Cantidad]) VALUES (16, 9, 5, 0.4)
INSERT [BODEGA].[DET_ORDEN_PRODUCCION] ([DetOrdenProduccionId], [OrdenProduccionId], [InventarioId], [Cantidad]) VALUES (17, 10, 4, 2.25)
INSERT [BODEGA].[DET_ORDEN_PRODUCCION] ([DetOrdenProduccionId], [OrdenProduccionId], [InventarioId], [Cantidad]) VALUES (18, 10, 5, 1)
INSERT [BODEGA].[DET_ORDEN_PRODUCCION] ([DetOrdenProduccionId], [OrdenProduccionId], [InventarioId], [Cantidad]) VALUES (19, 11, 9, 1)
SET IDENTITY_INSERT [BODEGA].[DET_ORDEN_PRODUCCION] OFF
GO
SET IDENTITY_INSERT [BODEGA].[ORDEN_PRODUCCION] ON 

INSERT [BODEGA].[ORDEN_PRODUCCION] ([OrdenProduccionId], [NoOrdenProduccion], [Fecha], [EmpleadoId], [UsuarioRegistroId], [UsuarioModificacionId], [ProductoFinal], [CantidadProducto]) VALUES (8, N'OP-001', CAST(N'2026-06-07' AS Date), 21, 9, NULL, N'Pupusa de queso', 20)
INSERT [BODEGA].[ORDEN_PRODUCCION] ([OrdenProduccionId], [NoOrdenProduccion], [Fecha], [EmpleadoId], [UsuarioRegistroId], [UsuarioModificacionId], [ProductoFinal], [CantidadProducto]) VALUES (9, N'OP-002', CAST(N'2026-06-07' AS Date), 21, 9, NULL, N'Pupusa de queso', 20)
INSERT [BODEGA].[ORDEN_PRODUCCION] ([OrdenProduccionId], [NoOrdenProduccion], [Fecha], [EmpleadoId], [UsuarioRegistroId], [UsuarioModificacionId], [ProductoFinal], [CantidadProducto]) VALUES (10, N'OP-003', CAST(N'2026-06-07' AS Date), 21, 9, NULL, N'1', 35)
INSERT [BODEGA].[ORDEN_PRODUCCION] ([OrdenProduccionId], [NoOrdenProduccion], [Fecha], [EmpleadoId], [UsuarioRegistroId], [UsuarioModificacionId], [ProductoFinal], [CantidadProducto]) VALUES (11, N'OP-004', CAST(N'2026-06-08' AS Date), 14, 9, NULL, N'6', 10)
SET IDENTITY_INSERT [BODEGA].[ORDEN_PRODUCCION] OFF
GO
SET IDENTITY_INSERT [COMPRA].[COMPRA] ON 

INSERT [COMPRA].[COMPRA] ([CompraId], [Fecha], [NoDocumento], [ProveedorId], [Total], [EstadoId]) VALUES (2, CAST(N'2026-06-07' AS Date), N'FAC-001', 2, CAST(81.25 AS Decimal(10, 2)), 13)
INSERT [COMPRA].[COMPRA] ([CompraId], [Fecha], [NoDocumento], [ProveedorId], [Total], [EstadoId]) VALUES (3, CAST(N'2026-06-07' AS Date), N'FAC-002', 2, CAST(20.40 AS Decimal(10, 2)), 13)
INSERT [COMPRA].[COMPRA] ([CompraId], [Fecha], [NoDocumento], [ProveedorId], [Total], [EstadoId]) VALUES (4, CAST(N'2026-06-07' AS Date), N'FAC-003', 1, CAST(11.25 AS Decimal(10, 2)), 13)
INSERT [COMPRA].[COMPRA] ([CompraId], [Fecha], [NoDocumento], [ProveedorId], [Total], [EstadoId]) VALUES (5, CAST(N'2026-06-06' AS Date), N'FAC-004', 1, CAST(6.75 AS Decimal(10, 2)), 13)
INSERT [COMPRA].[COMPRA] ([CompraId], [Fecha], [NoDocumento], [ProveedorId], [Total], [EstadoId]) VALUES (6, CAST(N'2026-06-07' AS Date), N'FAC-005', 1, CAST(45.00 AS Decimal(10, 2)), 13)
SET IDENTITY_INSERT [COMPRA].[COMPRA] OFF
GO
SET IDENTITY_INSERT [COMPRA].[DET_COMPRA] ON 

INSERT [COMPRA].[DET_COMPRA] ([DetalleCompraId], [CompraId], [InventarioId], [Cantidad], [PrecioCompra], [TotalDetalleCompra]) VALUES (1, 2, 7, 50, CAST(0.75 AS Decimal(10, 2)), CAST(37.50 AS Decimal(10, 2)))
INSERT [COMPRA].[DET_COMPRA] ([DetalleCompraId], [CompraId], [InventarioId], [Cantidad], [PrecioCompra], [TotalDetalleCompra]) VALUES (2, 2, 6, 35, CAST(1.25 AS Decimal(10, 2)), CAST(43.75 AS Decimal(10, 2)))
INSERT [COMPRA].[DET_COMPRA] ([DetalleCompraId], [CompraId], [InventarioId], [Cantidad], [PrecioCompra], [TotalDetalleCompra]) VALUES (3, 3, 8, 24, CAST(0.85 AS Decimal(10, 2)), CAST(20.40 AS Decimal(10, 2)))
INSERT [COMPRA].[DET_COMPRA] ([DetalleCompraId], [CompraId], [InventarioId], [Cantidad], [PrecioCompra], [TotalDetalleCompra]) VALUES (4, 4, 5, 5, CAST(2.25 AS Decimal(10, 2)), CAST(11.25 AS Decimal(10, 2)))
INSERT [COMPRA].[DET_COMPRA] ([DetalleCompraId], [CompraId], [InventarioId], [Cantidad], [PrecioCompra], [TotalDetalleCompra]) VALUES (5, 5, 5, 3, CAST(2.25 AS Decimal(10, 2)), CAST(6.75 AS Decimal(10, 2)))
INSERT [COMPRA].[DET_COMPRA] ([DetalleCompraId], [CompraId], [InventarioId], [Cantidad], [PrecioCompra], [TotalDetalleCompra]) VALUES (6, 6, 4, 10, CAST(3.25 AS Decimal(10, 2)), CAST(32.50 AS Decimal(10, 2)))
INSERT [COMPRA].[DET_COMPRA] ([DetalleCompraId], [CompraId], [InventarioId], [Cantidad], [PrecioCompra], [TotalDetalleCompra]) VALUES (7, 6, 5, 10, CAST(1.25 AS Decimal(10, 2)), CAST(12.50 AS Decimal(10, 2)))
SET IDENTITY_INSERT [COMPRA].[DET_COMPRA] OFF
GO
SET IDENTITY_INSERT [COMPRA].[INVENTARIO] ON 

INSERT [COMPRA].[INVENTARIO] ([InventarioId], [NombreProducto], [UnidadDeMedida], [Cantidad], [PrecioCosto], [TipoInventarioId], [UsuarioRegistroId], [UsuarioModificacionId], [EstadoId]) VALUES (4, N'Quesillo', N'Libras', 15.75, CAST(3.25 AS Decimal(10, 2)), 2, 9, 9, 7)
INSERT [COMPRA].[INVENTARIO] ([InventarioId], [NombreProducto], [UnidadDeMedida], [Cantidad], [PrecioCosto], [TipoInventarioId], [UsuarioRegistroId], [UsuarioModificacionId], [EstadoId]) VALUES (5, N'Loroco', N'Libras / pupusa', 21.2, CAST(1.25 AS Decimal(10, 2)), 2, 9, 9, 7)
INSERT [COMPRA].[INVENTARIO] ([InventarioId], [NombreProducto], [UnidadDeMedida], [Cantidad], [PrecioCosto], [TipoInventarioId], [UsuarioRegistroId], [UsuarioModificacionId], [EstadoId]) VALUES (6, N'Coca-Cola', N'Unidades', 36.25, CAST(1.25 AS Decimal(10, 2)), 3, 9, 9, 7)
INSERT [COMPRA].[INVENTARIO] ([InventarioId], [NombreProducto], [UnidadDeMedida], [Cantidad], [PrecioCosto], [TipoInventarioId], [UsuarioRegistroId], [UsuarioModificacionId], [EstadoId]) VALUES (7, N'Coca-Cola de lata', N'Unidades', 405, CAST(0.75 AS Decimal(10, 2)), 3, 9, 9, 7)
INSERT [COMPRA].[INVENTARIO] ([InventarioId], [NombreProducto], [UnidadDeMedida], [Cantidad], [PrecioCosto], [TipoInventarioId], [UsuarioRegistroId], [UsuarioModificacionId], [EstadoId]) VALUES (8, N'Jugo Petit - Manzana', N'Unidades', 25, CAST(0.85 AS Decimal(10, 2)), 3, 9, NULL, 7)
INSERT [COMPRA].[INVENTARIO] ([InventarioId], [NombreProducto], [UnidadDeMedida], [Cantidad], [PrecioCosto], [TipoInventarioId], [UsuarioRegistroId], [UsuarioModificacionId], [EstadoId]) VALUES (9, N'Tortilla para tacos', N'Paquete', 4, CAST(3.00 AS Decimal(10, 2)), 1, 9, NULL, 7)
SET IDENTITY_INSERT [COMPRA].[INVENTARIO] OFF
GO
SET IDENTITY_INSERT [COMPRA].[PROVEEDOR] ON 

INSERT [COMPRA].[PROVEEDOR] ([ProveedorId], [Nombre], [Direccion], [Telefono], [NoRegistro], [NIT], [EstadoId]) VALUES (1, N'NIÑA LUCY - MAIZ AL MAYOR', N'Col. San Antonio', N'76768983', N'R0012341', N'0214-020202-201', 6)
INSERT [COMPRA].[PROVEEDOR] ([ProveedorId], [Nombre], [Direccion], [Telefono], [NoRegistro], [NIT], [EstadoId]) VALUES (2, N'Distribuidora San Jose', N'Col. Centro, San Salvador', N'12232323', N'R0023456', N'0214-020202-202', 5)
SET IDENTITY_INSERT [COMPRA].[PROVEEDOR] OFF
GO
SET IDENTITY_INSERT [COMPRA].[TIPO_INVENTARIO] ON 

INSERT [COMPRA].[TIPO_INVENTARIO] ([TipoInventarioId], [Tipo], [Descripcion]) VALUES (1, N'Masa', N'Ingredientes para masa de pupusas')
INSERT [COMPRA].[TIPO_INVENTARIO] ([TipoInventarioId], [Tipo], [Descripcion]) VALUES (2, N'Relleno', N'Ingredientes para rellenos')
INSERT [COMPRA].[TIPO_INVENTARIO] ([TipoInventarioId], [Tipo], [Descripcion]) VALUES (3, N'Bebida', N'Bebidas y refrescos')
INSERT [COMPRA].[TIPO_INVENTARIO] ([TipoInventarioId], [Tipo], [Descripcion]) VALUES (4, N'Lácteo', N'Productos lácteos')
INSERT [COMPRA].[TIPO_INVENTARIO] ([TipoInventarioId], [Tipo], [Descripcion]) VALUES (5, N'Salsa', N'Salsas y curtidos')
INSERT [COMPRA].[TIPO_INVENTARIO] ([TipoInventarioId], [Tipo], [Descripcion]) VALUES (6, N'Especia', N'Especias y condimentos')
INSERT [COMPRA].[TIPO_INVENTARIO] ([TipoInventarioId], [Tipo], [Descripcion]) VALUES (7, N'Empaque', N'Material de empaque y servilletas')
SET IDENTITY_INSERT [COMPRA].[TIPO_INVENTARIO] OFF
GO
SET IDENTITY_INSERT [DELIVERY].[CONFIGURACION_LOCAL] ON 

INSERT [DELIVERY].[CONFIGURACION_LOCAL] ([ConfigId], [MunicipioId], [ColoniaBarrio]) VALUES (1, 9, N'San julian')
SET IDENTITY_INSERT [DELIVERY].[CONFIGURACION_LOCAL] OFF
GO
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (1, 13.92, -89.83)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (2, 13.92, -89.85)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (3, 13.92, -89.84)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (4, 13.98, -89.54)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (5, 13.98, -89.55)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (6, 13.98, -89.53)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (7, 13.98, -89.56)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (8, 13.72, -89.73)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (9, 13.72, -89.72)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (10, 13.72, -89.71)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (11, 13.72, -89.74)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (12, 13.49, -89.32)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (13, 13.49, -89.33)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (14, 13.49, -89.31)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (15, 13.49, -89.34)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (16, 13.49, -89.35)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (17, 13.49, -89.36)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (18, 13.69, -89.19)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (19, 13.69, -89.21)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (20, 13.69, -89.18)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (21, 13.69, -89.2)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (22, 13.69, -89.22)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (23, 14.03, -88.93)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (24, 14.03, -88.94)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (25, 14.03, -88.95)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (26, 13.84, -88.98)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (27, 13.84, -88.99)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (28, 13.51, -88.88)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (29, 13.51, -88.89)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (30, 13.51, -88.87)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (31, 13.94, -88.74)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (32, 13.94, -88.75)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (33, 13.65, -88.8)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (34, 13.65, -88.81)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (35, 13.35, -88.45)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (36, 13.35, -88.43)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (37, 13.35, -88.46)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (38, 13.48, -88.18)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (39, 13.48, -88.19)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (40, 13.48, -88.2)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (41, 13.9, -88.1)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (42, 13.9, -88.11)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (43, 13.34, -87.85)
INSERT [DELIVERY].[COORDENADAS_MUNICIPIO] ([MunicipioId], [Latitud], [Longitud]) VALUES (44, 13.34, -87.86)
GO
SET IDENTITY_INSERT [DELIVERY].[DIRECCION] ON 

INSERT [DELIVERY].[DIRECCION] ([DireccionId], [MunicipioId], [ColoniBarrio], [NoCasa], [PuntoReferencia], [CoordenadasMaps], [EstadoId], [FechaModificacion]) VALUES (1, 9, N'Lot. El Carmen', N'19', N'A dos cuadras de la casa Comunal', N'13.716439, -89.715961', 29, CAST(N'2026-06-06T16:31:35.057' AS DateTime))
INSERT [DELIVERY].[DIRECCION] ([DireccionId], [MunicipioId], [ColoniBarrio], [NoCasa], [PuntoReferencia], [CoordenadasMaps], [EstadoId], [FechaModificacion]) VALUES (2, 8, N'Juayúa', N'32', N'Cerca de la catedral', N'13°42''46.1"N 89°43''41.1"W', 29, CAST(N'2026-06-07T22:22:01.380' AS DateTime))
INSERT [DELIVERY].[DIRECCION] ([DireccionId], [MunicipioId], [ColoniBarrio], [NoCasa], [PuntoReferencia], [CoordenadasMaps], [EstadoId], [FechaModificacion]) VALUES (3, 9, N'Col. Belen', N'23', N'Cerca de la terminal nueva (Despensa Familiar)', N'13°43''05.4"N 89°42''53.2', 29, CAST(N'2026-06-06T16:31:35.057' AS DateTime))
INSERT [DELIVERY].[DIRECCION] ([DireccionId], [MunicipioId], [ColoniBarrio], [NoCasa], [PuntoReferencia], [CoordenadasMaps], [EstadoId], [FechaModificacion]) VALUES (4, 9, N'Sensunapan', N'34', N'A la par de la escuela, pasaje 3', N'13°42''46.1"N 89°43''41.1"W', 29, CAST(N'2026-06-07T16:58:00.993' AS DateTime))
INSERT [DELIVERY].[DIRECCION] ([DireccionId], [MunicipioId], [ColoniBarrio], [NoCasa], [PuntoReferencia], [CoordenadasMaps], [EstadoId], [FechaModificacion]) VALUES (5, 10, N'San Julian', N'11', N'Por la entrada', N'13°42''46.1"N 89°43''41.1"W', 29, CAST(N'2026-06-07T22:21:54.940' AS DateTime))
INSERT [DELIVERY].[DIRECCION] ([DireccionId], [MunicipioId], [ColoniBarrio], [NoCasa], [PuntoReferencia], [CoordenadasMaps], [EstadoId], [FechaModificacion]) VALUES (6, 2, N'Apaneca', N'39', N'Catedral', N'13.716439, -89.715961', 29, CAST(N'2026-06-08T09:31:08.317' AS DateTime))
SET IDENTITY_INSERT [DELIVERY].[DIRECCION] OFF
GO
SET IDENTITY_INSERT [DELIVERY].[ENVIO] ON 

INSERT [DELIVERY].[ENVIO] ([EnvioId], [OrdenId], [RepartidorId], [DireccionId], [Tarifa], [EstadoId]) VALUES (1, 9, 1, 4, CAST(2.00 AS Decimal(10, 2)), 21)
INSERT [DELIVERY].[ENVIO] ([EnvioId], [OrdenId], [RepartidorId], [DireccionId], [Tarifa], [EstadoId]) VALUES (2, 10, 3, 2, CAST(3.50 AS Decimal(10, 2)), 21)
INSERT [DELIVERY].[ENVIO] ([EnvioId], [OrdenId], [RepartidorId], [DireccionId], [Tarifa], [EstadoId]) VALUES (3, 11, 3, 2, CAST(3.50 AS Decimal(10, 2)), 21)
INSERT [DELIVERY].[ENVIO] ([EnvioId], [OrdenId], [RepartidorId], [DireccionId], [Tarifa], [EstadoId]) VALUES (4, 12, 2, 4, CAST(2.00 AS Decimal(10, 2)), 21)
INSERT [DELIVERY].[ENVIO] ([EnvioId], [OrdenId], [RepartidorId], [DireccionId], [Tarifa], [EstadoId]) VALUES (5, 14, 1, 4, CAST(2.00 AS Decimal(10, 2)), 21)
INSERT [DELIVERY].[ENVIO] ([EnvioId], [OrdenId], [RepartidorId], [DireccionId], [Tarifa], [EstadoId]) VALUES (6, 13, 2, 2, CAST(3.50 AS Decimal(10, 2)), 23)
INSERT [DELIVERY].[ENVIO] ([EnvioId], [OrdenId], [RepartidorId], [DireccionId], [Tarifa], [EstadoId]) VALUES (7, 15, 4, 5, CAST(2.00 AS Decimal(10, 2)), 23)
INSERT [DELIVERY].[ENVIO] ([EnvioId], [OrdenId], [RepartidorId], [DireccionId], [Tarifa], [EstadoId]) VALUES (8, 20, 4, 5, CAST(2.00 AS Decimal(10, 2)), 23)
SET IDENTITY_INSERT [DELIVERY].[ENVIO] OFF
GO
SET IDENTITY_INSERT [DELIVERY].[MUNICIPIO] ON 

INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (1, N'Ahuachapán Norte')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (2, N'Ahuachapán Centro')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (3, N'Ahuachapán Sur')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (4, N'Santa Ana Norte')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (5, N'Santa Ana Centro')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (6, N'Santa Ana Este')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (7, N'Santa Ana Oeste')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (8, N'Sonsonate Norte')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (9, N'Sonsonate Centro')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (10, N'Sonsonate Este')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (11, N'Sonsonate Oeste')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (12, N'La Libertad Norte')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (13, N'La Libertad Centro')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (14, N'La Libertad Este')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (15, N'La Libertad Oeste')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (16, N'La Libertad Costa')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (17, N'La Libertad Sur')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (18, N'San Salvador Norte')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (19, N'San Salvador Oeste')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (20, N'San Salvador Este')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (21, N'San Salvador Centro')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (22, N'San Salvador Sur')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (23, N'Chalatenango Norte')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (24, N'Chalatenango Centro')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (25, N'Chalatenango Sur')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (26, N'Cuscatlán Norte')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (27, N'Cuscatlán Sur')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (28, N'La Paz Norte')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (29, N'La Paz Centro')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (30, N'La Paz Este')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (31, N'Cabañas Este')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (32, N'Cabañas Oeste')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (33, N'San Vicente Norte')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (34, N'San Vicente Sur')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (35, N'Usulután Norte')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (36, N'Usulután Este')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (37, N'Usulután Oeste')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (38, N'San Miguel Norte')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (39, N'San Miguel Centro')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (40, N'San Miguel Oeste')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (41, N'Morazán Norte')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (42, N'Morazán Sur')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (43, N'La Unión Norte')
INSERT [DELIVERY].[MUNICIPIO] ([MunicipioId], [Nombre]) VALUES (44, N'La Unión Sur')
SET IDENTITY_INSERT [DELIVERY].[MUNICIPIO] OFF
GO
SET IDENTITY_INSERT [DELIVERY].[REPARTIDOR] ON 

INSERT [DELIVERY].[REPARTIDOR] ([RepartidorId], [EmpleadoId], [NoPlacaMoto], [EstadoId]) VALUES (1, 15, N'P 893-9', 25)
INSERT [DELIVERY].[REPARTIDOR] ([RepartidorId], [EmpleadoId], [NoPlacaMoto], [EstadoId]) VALUES (2, 24, N'P 987-4', 25)
INSERT [DELIVERY].[REPARTIDOR] ([RepartidorId], [EmpleadoId], [NoPlacaMoto], [EstadoId]) VALUES (3, 27, N'P 783-2', 25)
INSERT [DELIVERY].[REPARTIDOR] ([RepartidorId], [EmpleadoId], [NoPlacaMoto], [EstadoId]) VALUES (4, 28, N'P455-2', 25)
SET IDENTITY_INSERT [DELIVERY].[REPARTIDOR] OFF
GO
SET IDENTITY_INSERT [DELIVERY].[TARIFA_DELIVERY] ON 

INSERT [DELIVERY].[TARIFA_DELIVERY] ([TarifaId], [MunicipioId], [Costo]) VALUES (1, 9, CAST(2.00 AS Decimal(10, 2)))
INSERT [DELIVERY].[TARIFA_DELIVERY] ([TarifaId], [MunicipioId], [Costo]) VALUES (2, 8, CAST(3.50 AS Decimal(10, 2)))
INSERT [DELIVERY].[TARIFA_DELIVERY] ([TarifaId], [MunicipioId], [Costo]) VALUES (3, 11, CAST(4.00 AS Decimal(10, 2)))
INSERT [DELIVERY].[TARIFA_DELIVERY] ([TarifaId], [MunicipioId], [Costo]) VALUES (4, 10, CAST(5.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [DELIVERY].[TARIFA_DELIVERY] OFF
GO
SET IDENTITY_INSERT [GLOBAL].[ENTIDAD] ON 

INSERT [GLOBAL].[ENTIDAD] ([EntidadId], [Entidad]) VALUES (12, N'CATEGORIA')
INSERT [GLOBAL].[ENTIDAD] ([EntidadId], [Entidad]) VALUES (14, N'CLIENTE')
INSERT [GLOBAL].[ENTIDAD] ([EntidadId], [Entidad]) VALUES (6, N'COMBO')
INSERT [GLOBAL].[ENTIDAD] ([EntidadId], [Entidad]) VALUES (7, N'COMPRA')
INSERT [GLOBAL].[ENTIDAD] ([EntidadId], [Entidad]) VALUES (15, N'DESCUENTO')
INSERT [GLOBAL].[ENTIDAD] ([EntidadId], [Entidad]) VALUES (13, N'DIRECCION')
INSERT [GLOBAL].[ENTIDAD] ([EntidadId], [Entidad]) VALUES (2, N'EMPLEADO')
INSERT [GLOBAL].[ENTIDAD] ([EntidadId], [Entidad]) VALUES (10, N'ENVIO')
INSERT [GLOBAL].[ENTIDAD] ([EntidadId], [Entidad]) VALUES (4, N'INVENTARIO')
INSERT [GLOBAL].[ENTIDAD] ([EntidadId], [Entidad]) VALUES (5, N'MENU')
INSERT [GLOBAL].[ENTIDAD] ([EntidadId], [Entidad]) VALUES (8, N'ORDEN')
INSERT [GLOBAL].[ENTIDAD] ([EntidadId], [Entidad]) VALUES (3, N'PROVEEDOR')
INSERT [GLOBAL].[ENTIDAD] ([EntidadId], [Entidad]) VALUES (11, N'REPARTIDOR')
INSERT [GLOBAL].[ENTIDAD] ([EntidadId], [Entidad]) VALUES (1, N'USUARIO')
INSERT [GLOBAL].[ENTIDAD] ([EntidadId], [Entidad]) VALUES (9, N'VENTA')
SET IDENTITY_INSERT [GLOBAL].[ENTIDAD] OFF
GO
SET IDENTITY_INSERT [GLOBAL].[ESTADO] ON 

INSERT [GLOBAL].[ESTADO] ([EstadoId], [Estado], [Descripcion], [EntidadId]) VALUES (1, N'ACTIVO', N'Usuario activo en el sistema', 1)
INSERT [GLOBAL].[ESTADO] ([EstadoId], [Estado], [Descripcion], [EntidadId]) VALUES (2, N'INACTIVO', N'Usuario inactivo o eliminado logicamente', 1)
INSERT [GLOBAL].[ESTADO] ([EstadoId], [Estado], [Descripcion], [EntidadId]) VALUES (3, N'ACTIVO', N'Empleado activo', 2)
INSERT [GLOBAL].[ESTADO] ([EstadoId], [Estado], [Descripcion], [EntidadId]) VALUES (4, N'INACTIVO', N'Empleado inactivo o retirado', 2)
INSERT [GLOBAL].[ESTADO] ([EstadoId], [Estado], [Descripcion], [EntidadId]) VALUES (5, N'ACTIVO', N'Proveedor activo', 3)
INSERT [GLOBAL].[ESTADO] ([EstadoId], [Estado], [Descripcion], [EntidadId]) VALUES (6, N'INACTIVO', N'Proveedor inactivo', 3)
INSERT [GLOBAL].[ESTADO] ([EstadoId], [Estado], [Descripcion], [EntidadId]) VALUES (7, N'DISPONIBLE', N'Producto disponible en inventario', 4)
INSERT [GLOBAL].[ESTADO] ([EstadoId], [Estado], [Descripcion], [EntidadId]) VALUES (8, N'AGOTADO', N'Producto agotado en inventario', 4)
INSERT [GLOBAL].[ESTADO] ([EstadoId], [Estado], [Descripcion], [EntidadId]) VALUES (9, N'DISPONIBLE', N'Item del menu disponible', 5)
INSERT [GLOBAL].[ESTADO] ([EstadoId], [Estado], [Descripcion], [EntidadId]) VALUES (10, N'NO DISPONIBLE', N'Item del menu no disponible', 5)
INSERT [GLOBAL].[ESTADO] ([EstadoId], [Estado], [Descripcion], [EntidadId]) VALUES (11, N'DISPONIBLE', N'Combo disponible', 6)
INSERT [GLOBAL].[ESTADO] ([EstadoId], [Estado], [Descripcion], [EntidadId]) VALUES (12, N'NO DISPONIBLE', N'Combo no disponible', 6)
INSERT [GLOBAL].[ESTADO] ([EstadoId], [Estado], [Descripcion], [EntidadId]) VALUES (13, N'REGISTRADA', N'Compra registrada correctamente', 7)
INSERT [GLOBAL].[ESTADO] ([EstadoId], [Estado], [Descripcion], [EntidadId]) VALUES (14, N'ANULADA', N'Compra anulada', 7)
INSERT [GLOBAL].[ESTADO] ([EstadoId], [Estado], [Descripcion], [EntidadId]) VALUES (15, N'PENDIENTE', N'Orden pendiente de atencion', 8)
INSERT [GLOBAL].[ESTADO] ([EstadoId], [Estado], [Descripcion], [EntidadId]) VALUES (16, N'EN PROCESO', N'Orden en preparacion', 8)
INSERT [GLOBAL].[ESTADO] ([EstadoId], [Estado], [Descripcion], [EntidadId]) VALUES (17, N'COMPLETADA', N'Orden completada', 8)
INSERT [GLOBAL].[ESTADO] ([EstadoId], [Estado], [Descripcion], [EntidadId]) VALUES (18, N'CANCELADA', N'Orden cancelada', 8)
INSERT [GLOBAL].[ESTADO] ([EstadoId], [Estado], [Descripcion], [EntidadId]) VALUES (19, N'VIGENTE', N'Venta vigente', 9)
INSERT [GLOBAL].[ESTADO] ([EstadoId], [Estado], [Descripcion], [EntidadId]) VALUES (20, N'ANULADA', N'Venta anulada', 9)
INSERT [GLOBAL].[ESTADO] ([EstadoId], [Estado], [Descripcion], [EntidadId]) VALUES (21, N'ASIGNADO', N'Envio asignado a repartidor', 10)
INSERT [GLOBAL].[ESTADO] ([EstadoId], [Estado], [Descripcion], [EntidadId]) VALUES (22, N'EN CAMINO', N'Envio en camino al cliente', 10)
INSERT [GLOBAL].[ESTADO] ([EstadoId], [Estado], [Descripcion], [EntidadId]) VALUES (23, N'ENTREGADO', N'Envio entregado al cliente', 10)
INSERT [GLOBAL].[ESTADO] ([EstadoId], [Estado], [Descripcion], [EntidadId]) VALUES (24, N'CANCELADO', N'Envio cancelado', 10)
INSERT [GLOBAL].[ESTADO] ([EstadoId], [Estado], [Descripcion], [EntidadId]) VALUES (25, N'DISPONIBLE', N'Repartidor disponible para envios', 11)
INSERT [GLOBAL].[ESTADO] ([EstadoId], [Estado], [Descripcion], [EntidadId]) VALUES (26, N'NO DISPONIBLE', N'Repartidor no disponible', 11)
INSERT [GLOBAL].[ESTADO] ([EstadoId], [Estado], [Descripcion], [EntidadId]) VALUES (27, N'ACTIVO', N'Categoría activa', 12)
INSERT [GLOBAL].[ESTADO] ([EstadoId], [Estado], [Descripcion], [EntidadId]) VALUES (28, N'INACTIVO', N'Categoría inactiva', 12)
INSERT [GLOBAL].[ESTADO] ([EstadoId], [Estado], [Descripcion], [EntidadId]) VALUES (29, N'ACTIVO', N'Dirección activa', 13)
INSERT [GLOBAL].[ESTADO] ([EstadoId], [Estado], [Descripcion], [EntidadId]) VALUES (30, N'INACTIVO', N'Dirección inactiva', 13)
INSERT [GLOBAL].[ESTADO] ([EstadoId], [Estado], [Descripcion], [EntidadId]) VALUES (31, N'ACTIVO', N'Cliente activo', 14)
INSERT [GLOBAL].[ESTADO] ([EstadoId], [Estado], [Descripcion], [EntidadId]) VALUES (32, N'INACTIVO', N'Cliente inactivo', 14)
INSERT [GLOBAL].[ESTADO] ([EstadoId], [Estado], [Descripcion], [EntidadId]) VALUES (33, N'ACTIVO', N'Descuento activo', 15)
INSERT [GLOBAL].[ESTADO] ([EstadoId], [Estado], [Descripcion], [EntidadId]) VALUES (34, N'INACTIVO', N'Descuento inactivo', 15)
SET IDENTITY_INSERT [GLOBAL].[ESTADO] OFF
GO
SET IDENTITY_INSERT [RRHH].[CARGO] ON 

INSERT [RRHH].[CARGO] ([CargoId], [Cargo]) VALUES (1, N'ADMINISTRADOR')
INSERT [RRHH].[CARGO] ([CargoId], [Cargo]) VALUES (2, N'CAJERO')
INSERT [RRHH].[CARGO] ([CargoId], [Cargo]) VALUES (3, N'COCINERO')
INSERT [RRHH].[CARGO] ([CargoId], [Cargo]) VALUES (4, N'REPARTIDOR')
INSERT [RRHH].[CARGO] ([CargoId], [Cargo]) VALUES (5, N'BODEGUERO')
SET IDENTITY_INSERT [RRHH].[CARGO] OFF
GO
SET IDENTITY_INSERT [RRHH].[EMPLEADO] ON 

INSERT [RRHH].[EMPLEADO] ([EmpleadoId], [Nombre], [Apellido], [Telefono], [Email], [Direccion], [FechaNac], [FechaContratacion], [CargoId], [EstadoId], [UsuarioRegistroId], [UsuarioModificacionId]) VALUES (12, N'Admin', N'Sistema', N'00000001', N'admin@gusto.com', N'Sistema', CAST(N'1990-01-01' AS Date), CAST(N'2024-01-01' AS Date), 1, 3, 9, NULL)
INSERT [RRHH].[EMPLEADO] ([EmpleadoId], [Nombre], [Apellido], [Telefono], [Email], [Direccion], [FechaNac], [FechaContratacion], [CargoId], [EstadoId], [UsuarioRegistroId], [UsuarioModificacionId]) VALUES (13, N'Carlos', N'Mendoza', N'78901234', N'cajero@gusto.com', N'Col. Centro #10', CAST(N'1995-03-15' AS Date), CAST(N'2024-01-01' AS Date), 2, 2, 9, 9)
INSERT [RRHH].[EMPLEADO] ([EmpleadoId], [Nombre], [Apellido], [Telefono], [Email], [Direccion], [FechaNac], [FechaContratacion], [CargoId], [EstadoId], [UsuarioRegistroId], [UsuarioModificacionId]) VALUES (14, N'Maria', N'Gomez', N'78905678', N'cocinero@gusto.com', N'Col. San Jose #22', CAST(N'1993-07-20' AS Date), CAST(N'2024-01-01' AS Date), 3, 3, 9, NULL)
INSERT [RRHH].[EMPLEADO] ([EmpleadoId], [Nombre], [Apellido], [Telefono], [Email], [Direccion], [FechaNac], [FechaContratacion], [CargoId], [EstadoId], [UsuarioRegistroId], [UsuarioModificacionId]) VALUES (15, N'Pedro', N'Martinez', N'+50361050871', N'reparto@gusto.com', N'Col. Las Flores #5', CAST(N'1997-11-05' AS Date), CAST(N'2024-01-01' AS Date), 4, 3, 9, 9)
INSERT [RRHH].[EMPLEADO] ([EmpleadoId], [Nombre], [Apellido], [Telefono], [Email], [Direccion], [FechaNac], [FechaContratacion], [CargoId], [EstadoId], [UsuarioRegistroId], [UsuarioModificacionId]) VALUES (16, N'Luis', N'Hernandez', N'78903456', N'bodega@gusto.com', N'Col. El Roble #8', CAST(N'1992-05-10' AS Date), CAST(N'2024-01-01' AS Date), 5, 3, 9, NULL)
INSERT [RRHH].[EMPLEADO] ([EmpleadoId], [Nombre], [Apellido], [Telefono], [Email], [Direccion], [FechaNac], [FechaContratacion], [CargoId], [EstadoId], [UsuarioRegistroId], [UsuarioModificacionId]) VALUES (17, N'Bryan Manuel', N'Sanchez Mendoza', N'87878780', N'msanchez@gusto.com', N'Lot. El Carmen, Sonsonate.', CAST(N'2005-12-04' AS Date), CAST(N'2026-06-04' AS Date), 1, 3, 9, 9)
INSERT [RRHH].[EMPLEADO] ([EmpleadoId], [Nombre], [Apellido], [Telefono], [Email], [Direccion], [FechaNac], [FechaContratacion], [CargoId], [EstadoId], [UsuarioRegistroId], [UsuarioModificacionId]) VALUES (18, N'Oscar', N'Tobar', N'77777777', N'otobar11@gusto.com', N'sonsonate', CAST(N'2004-04-22' AS Date), CAST(N'2026-06-04' AS Date), 2, 3, 9, NULL)
INSERT [RRHH].[EMPLEADO] ([EmpleadoId], [Nombre], [Apellido], [Telefono], [Email], [Direccion], [FechaNac], [FechaContratacion], [CargoId], [EstadoId], [UsuarioRegistroId], [UsuarioModificacionId]) VALUES (19, N'Sofía', N'Molina', N'78901237', N'sofia.molina@gusto.com', N'Col. San Benito #7', CAST(N'1994-08-15' AS Date), CAST(N'2024-03-01' AS Date), 2, 3, 9, NULL)
INSERT [RRHH].[EMPLEADO] ([EmpleadoId], [Nombre], [Apellido], [Telefono], [Email], [Direccion], [FechaNac], [FechaContratacion], [CargoId], [EstadoId], [UsuarioRegistroId], [UsuarioModificacionId]) VALUES (20, N'Javier', N'Palacios', N'78901238', N'javier.palacios@gusto.com', N'Col. Escalón #101', CAST(N'1996-02-20' AS Date), CAST(N'2024-03-15' AS Date), 2, 3, 9, NULL)
INSERT [RRHH].[EMPLEADO] ([EmpleadoId], [Nombre], [Apellido], [Telefono], [Email], [Direccion], [FechaNac], [FechaContratacion], [CargoId], [EstadoId], [UsuarioRegistroId], [UsuarioModificacionId]) VALUES (21, N'Elena', N'Sorto', N'78901239', N'elena.sorto@gusto.com', N'Col. La Rábida #23', CAST(N'1992-05-10' AS Date), CAST(N'2024-01-20' AS Date), 3, 3, 9, NULL)
INSERT [RRHH].[EMPLEADO] ([EmpleadoId], [Nombre], [Apellido], [Telefono], [Email], [Direccion], [FechaNac], [FechaContratacion], [CargoId], [EstadoId], [UsuarioRegistroId], [UsuarioModificacionId]) VALUES (22, N'Oscar', N'Herrera', N'78901240', N'oscar.herrera@gusto.com', N'Col. Centro #33', CAST(N'1990-12-05' AS Date), CAST(N'2024-02-10' AS Date), 3, 3, 9, NULL)
INSERT [RRHH].[EMPLEADO] ([EmpleadoId], [Nombre], [Apellido], [Telefono], [Email], [Direccion], [FechaNac], [FechaContratacion], [CargoId], [EstadoId], [UsuarioRegistroId], [UsuarioModificacionId]) VALUES (23, N'Fernando', N'López', N'78901241', N'fernando.lopez@gusto.com', N'Col. San Mateo #56', CAST(N'1993-09-18' AS Date), CAST(N'2024-04-01' AS Date), 4, 3, 9, NULL)
INSERT [RRHH].[EMPLEADO] ([EmpleadoId], [Nombre], [Apellido], [Telefono], [Email], [Direccion], [FechaNac], [FechaContratacion], [CargoId], [EstadoId], [UsuarioRegistroId], [UsuarioModificacionId]) VALUES (24, N'Carmen', N'Vásquez', N'78901242', N'carmen.vasquez@gusto.com', N'Col. Las Palmas #78', CAST(N'1995-07-22' AS Date), CAST(N'2024-04-15' AS Date), 4, 3, 9, NULL)
INSERT [RRHH].[EMPLEADO] ([EmpleadoId], [Nombre], [Apellido], [Telefono], [Email], [Direccion], [FechaNac], [FechaContratacion], [CargoId], [EstadoId], [UsuarioRegistroId], [UsuarioModificacionId]) VALUES (25, N'Mario', N'Córdova', N'78901243', N'mario.cordova@gusto.com', N'Col. El Roble #12', CAST(N'1989-03-14' AS Date), CAST(N'2024-02-20' AS Date), 5, 3, 9, NULL)
INSERT [RRHH].[EMPLEADO] ([EmpleadoId], [Nombre], [Apellido], [Telefono], [Email], [Direccion], [FechaNac], [FechaContratacion], [CargoId], [EstadoId], [UsuarioRegistroId], [UsuarioModificacionId]) VALUES (26, N'Diana', N'Peña', N'78901244', N'diana.pena@gusto.com', N'Col. San Francisco #90', CAST(N'1991-11-08' AS Date), CAST(N'2024-05-01' AS Date), 5, 3, 9, NULL)
INSERT [RRHH].[EMPLEADO] ([EmpleadoId], [Nombre], [Apellido], [Telefono], [Email], [Direccion], [FechaNac], [FechaContratacion], [CargoId], [EstadoId], [UsuarioRegistroId], [UsuarioModificacionId]) VALUES (27, N'Juan Jose', N'Ramirez Mendoza', N'+50361050871', N'jramirez@gusto.com', N'Sonsonate Centro, Sonsonate', CAST(N'2005-12-04' AS Date), CAST(N'2026-06-07' AS Date), 4, 3, 9, NULL)
INSERT [RRHH].[EMPLEADO] ([EmpleadoId], [Nombre], [Apellido], [Telefono], [Email], [Direccion], [FechaNac], [FechaContratacion], [CargoId], [EstadoId], [UsuarioRegistroId], [UsuarioModificacionId]) VALUES (28, N'Oracio', N'Lopez', N'+50361050871', N'flopez54@gusto.com', N'El Sauce, Sonsonate Centro', CAST(N'2000-07-06' AS Date), CAST(N'2026-06-08' AS Date), 4, 3, 9, NULL)
INSERT [RRHH].[EMPLEADO] ([EmpleadoId], [Nombre], [Apellido], [Telefono], [Email], [Direccion], [FechaNac], [FechaContratacion], [CargoId], [EstadoId], [UsuarioRegistroId], [UsuarioModificacionId]) VALUES (29, N'Josue', N'Medina', N'+50361050871', N'jmedina@gusto.com', N'Sonsonate Centro, Sonsonate', CAST(N'2026-06-08' AS Date), CAST(N'2026-06-08' AS Date), 2, 3, 9, NULL)
SET IDENTITY_INSERT [RRHH].[EMPLEADO] OFF
GO
SET IDENTITY_INSERT [VENTA].[CATEGORIA] ON 

INSERT [VENTA].[CATEGORIA] ([CategoriaId], [Categoria], [EstadoId]) VALUES (1, N'BEBIDAS CALIENTES', 27)
INSERT [VENTA].[CATEGORIA] ([CategoriaId], [Categoria], [EstadoId]) VALUES (2, N'BEBIDAS FRIAS', 27)
INSERT [VENTA].[CATEGORIA] ([CategoriaId], [Categoria], [EstadoId]) VALUES (3, N'PUPUSAS DE MAIZ', 28)
INSERT [VENTA].[CATEGORIA] ([CategoriaId], [Categoria], [EstadoId]) VALUES (4, N'PUPUSAS DE ARROZ', 28)
INSERT [VENTA].[CATEGORIA] ([CategoriaId], [Categoria], [EstadoId]) VALUES (5, N'Combo Familiar', 1)
INSERT [VENTA].[CATEGORIA] ([CategoriaId], [Categoria], [EstadoId]) VALUES (6, N'Combo Individual', 1)
INSERT [VENTA].[CATEGORIA] ([CategoriaId], [Categoria], [EstadoId]) VALUES (7, N'Oferta del día', 1)
INSERT [VENTA].[CATEGORIA] ([CategoriaId], [Categoria], [EstadoId]) VALUES (8, N'Promoción', 1)
INSERT [VENTA].[CATEGORIA] ([CategoriaId], [Categoria], [EstadoId]) VALUES (9, N'Combo Infantil', 1)
INSERT [VENTA].[CATEGORIA] ([CategoriaId], [Categoria], [EstadoId]) VALUES (10, N'COMIDA MEXICANA', 27)
SET IDENTITY_INSERT [VENTA].[CATEGORIA] OFF
GO
SET IDENTITY_INSERT [VENTA].[CLIENTE] ON 

INSERT [VENTA].[CLIENTE] ([ClienteId], [Nombre], [Apellido], [Telefono], [DireccionId], [EstadoId], [NombreCompleto]) VALUES (1, N'Mario', N'Gutierrez', N'34654343', 2, 31, N'Mario Gutierrez')
INSERT [VENTA].[CLIENTE] ([ClienteId], [Nombre], [Apellido], [Telefono], [DireccionId], [EstadoId], [NombreCompleto]) VALUES (3, N'Mario', N'Gutierrez', N'34654343', 4, 32, N'Mario Gutierrez')
INSERT [VENTA].[CLIENTE] ([ClienteId], [Nombre], [Apellido], [Telefono], [DireccionId], [EstadoId], [NombreCompleto]) VALUES (4, N'Carlo Gerardo', N'Perez Navarrete', N'2222-2222', 5, 32, N'Carlo Gerardo Perez Navarrete')
INSERT [VENTA].[CLIENTE] ([ClienteId], [Nombre], [Apellido], [Telefono], [DireccionId], [EstadoId], [NombreCompleto]) VALUES (5, N'Carlo Gerardo', N'Perez Navarrete', N'2222-2222', 4, 31, N'Carlo Gerardo Perez Navarrete (2)')
INSERT [VENTA].[CLIENTE] ([ClienteId], [Nombre], [Apellido], [Telefono], [DireccionId], [EstadoId], [NombreCompleto]) VALUES (6, N'Joel Antonio', N'Guiron Ramos', N'+503704047', 4, 31, N'Joel Antonio Guiron Ramos')
INSERT [VENTA].[CLIENTE] ([ClienteId], [Nombre], [Apellido], [Telefono], [DireccionId], [EstadoId], [NombreCompleto]) VALUES (7, N'Felipe', N'Tobar (Prueba)', N'+503323200', 5, 31, N'Felipe Tobar (Prueba)')
INSERT [VENTA].[CLIENTE] ([ClienteId], [Nombre], [Apellido], [Telefono], [DireccionId], [EstadoId], [NombreCompleto]) VALUES (8, N'Gerson', N'Perez', N'+503610508', 4, 31, N'Gerson Perez')
INSERT [VENTA].[CLIENTE] ([ClienteId], [Nombre], [Apellido], [Telefono], [DireccionId], [EstadoId], [NombreCompleto]) VALUES (9, N'Gerson', N'Perez', N'+503610508', 6, 31, N'Gerson Perez (2)')
SET IDENTITY_INSERT [VENTA].[CLIENTE] OFF
GO
SET IDENTITY_INSERT [VENTA].[COMBO] ON 

INSERT [VENTA].[COMBO] ([ComboId], [Nombre], [Descripcion], [Precio], [EstadoId], [CategoriaId]) VALUES (1, N'Desayuno Personal', N'Incluye 3 pupusas revueltas de maiz y una coca-cola de lata', CAST(1.75 AS Decimal(10, 2)), 9, 6)
SET IDENTITY_INSERT [VENTA].[COMBO] OFF
GO
SET IDENTITY_INSERT [VENTA].[DESCUENTO] ON 

INSERT [VENTA].[DESCUENTO] ([DescuentoId], [Nombre], [Porcentaje], [CategoriaId], [MenuId], [ComboId], [FechaDesde], [FechaHasta], [EstadoId], [TipoDescuentoId]) VALUES (1, N'Dia del padre', CAST(25.00 AS Decimal(5, 2)), NULL, NULL, 1, CAST(N'2026-06-07' AS Date), CAST(N'2026-06-18' AS Date), 33, 1)
INSERT [VENTA].[DESCUENTO] ([DescuentoId], [Nombre], [Porcentaje], [CategoriaId], [MenuId], [ComboId], [FechaDesde], [FechaHasta], [EstadoId], [TipoDescuentoId]) VALUES (2, N'Pupusas de queso en descuento (15%)', CAST(15.00 AS Decimal(5, 2)), NULL, 1, NULL, CAST(N'2026-06-07' AS Date), CAST(N'2026-07-07' AS Date), 33, 2)
SET IDENTITY_INSERT [VENTA].[DESCUENTO] OFF
GO
SET IDENTITY_INSERT [VENTA].[DET_COMBO] ON 

INSERT [VENTA].[DET_COMBO] ([DetalleComboId], [ComboId], [idMenu], [Cantidad], [CategoriaId]) VALUES (5, 1, 4, 1, 6)
INSERT [VENTA].[DET_COMBO] ([DetalleComboId], [ComboId], [idMenu], [Cantidad], [CategoriaId]) VALUES (7, 1, 3, 3, 6)
SET IDENTITY_INSERT [VENTA].[DET_COMBO] OFF
GO
SET IDENTITY_INSERT [VENTA].[DET_ORDEN] ON 

INSERT [VENTA].[DET_ORDEN] ([DetOrdenId], [OrdenId], [MenuId], [ComboId], [PrecioUnitario], [Cantidad]) VALUES (7, 9, NULL, 1, CAST(1.00 AS Decimal(10, 2)), 1)
INSERT [VENTA].[DET_ORDEN] ([DetOrdenId], [OrdenId], [MenuId], [ComboId], [PrecioUnitario], [Cantidad]) VALUES (8, 9, NULL, 1, CAST(1.00 AS Decimal(10, 2)), 1)
INSERT [VENTA].[DET_ORDEN] ([DetOrdenId], [OrdenId], [MenuId], [ComboId], [PrecioUnitario], [Cantidad]) VALUES (9, 10, 5, NULL, CAST(5.00 AS Decimal(10, 2)), 0)
INSERT [VENTA].[DET_ORDEN] ([DetOrdenId], [OrdenId], [MenuId], [ComboId], [PrecioUnitario], [Cantidad]) VALUES (10, 10, 3, NULL, CAST(6.00 AS Decimal(10, 2)), 0)
INSERT [VENTA].[DET_ORDEN] ([DetOrdenId], [OrdenId], [MenuId], [ComboId], [PrecioUnitario], [Cantidad]) VALUES (11, 11, NULL, 1, CAST(1.00 AS Decimal(10, 2)), 1)
INSERT [VENTA].[DET_ORDEN] ([DetOrdenId], [OrdenId], [MenuId], [ComboId], [PrecioUnitario], [Cantidad]) VALUES (12, 11, 1, 1, CAST(1.00 AS Decimal(10, 2)), 0)
INSERT [VENTA].[DET_ORDEN] ([DetOrdenId], [OrdenId], [MenuId], [ComboId], [PrecioUnitario], [Cantidad]) VALUES (13, 11, 1, 1, CAST(1.00 AS Decimal(10, 2)), 1)
INSERT [VENTA].[DET_ORDEN] ([DetOrdenId], [OrdenId], [MenuId], [ComboId], [PrecioUnitario], [Cantidad]) VALUES (14, 12, NULL, 1, CAST(1.00 AS Decimal(10, 2)), 1)
INSERT [VENTA].[DET_ORDEN] ([DetOrdenId], [OrdenId], [MenuId], [ComboId], [PrecioUnitario], [Cantidad]) VALUES (15, 13, 3, NULL, CAST(5.00 AS Decimal(10, 2)), 0)
INSERT [VENTA].[DET_ORDEN] ([DetOrdenId], [OrdenId], [MenuId], [ComboId], [PrecioUnitario], [Cantidad]) VALUES (16, 14, NULL, 1, CAST(1.00 AS Decimal(10, 2)), 1)
INSERT [VENTA].[DET_ORDEN] ([DetOrdenId], [OrdenId], [MenuId], [ComboId], [PrecioUnitario], [Cantidad]) VALUES (17, 15, 6, NULL, CAST(4.00 AS Decimal(10, 2)), 0)
INSERT [VENTA].[DET_ORDEN] ([DetOrdenId], [OrdenId], [MenuId], [ComboId], [PrecioUnitario], [Cantidad]) VALUES (18, 16, 4, NULL, CAST(1.00 AS Decimal(10, 2)), 1)
INSERT [VENTA].[DET_ORDEN] ([DetOrdenId], [OrdenId], [MenuId], [ComboId], [PrecioUnitario], [Cantidad]) VALUES (19, 17, 6, NULL, CAST(2.00 AS Decimal(10, 2)), 0)
INSERT [VENTA].[DET_ORDEN] ([DetOrdenId], [OrdenId], [MenuId], [ComboId], [PrecioUnitario], [Cantidad]) VALUES (20, 18, 6, NULL, CAST(2.00 AS Decimal(10, 2)), 0)
INSERT [VENTA].[DET_ORDEN] ([DetOrdenId], [OrdenId], [MenuId], [ComboId], [PrecioUnitario], [Cantidad]) VALUES (21, 19, 6, NULL, CAST(0.75 AS Decimal(10, 2)), 2)
INSERT [VENTA].[DET_ORDEN] ([DetOrdenId], [OrdenId], [MenuId], [ComboId], [PrecioUnitario], [Cantidad]) VALUES (22, 20, NULL, 1, CAST(1.31 AS Decimal(10, 2)), 6)
INSERT [VENTA].[DET_ORDEN] ([DetOrdenId], [OrdenId], [MenuId], [ComboId], [PrecioUnitario], [Cantidad]) VALUES (23, 20, 3, 1, CAST(0.26 AS Decimal(10, 2)), 10)
INSERT [VENTA].[DET_ORDEN] ([DetOrdenId], [OrdenId], [MenuId], [ComboId], [PrecioUnitario], [Cantidad]) VALUES (24, 21, 2, NULL, CAST(1.25 AS Decimal(10, 2)), 1)
INSERT [VENTA].[DET_ORDEN] ([DetOrdenId], [OrdenId], [MenuId], [ComboId], [PrecioUnitario], [Cantidad]) VALUES (25, 21, 6, NULL, CAST(0.75 AS Decimal(10, 2)), 4)
SET IDENTITY_INSERT [VENTA].[DET_ORDEN] OFF
GO
SET IDENTITY_INSERT [VENTA].[MENU] ON 

INSERT [VENTA].[MENU] ([MenuId], [Nombre], [Precio], [InventarioId], [CategoriaId], [EstadoId]) VALUES (1, N'Pupusa de queso', CAST(0.35 AS Decimal(10, 2)), NULL, 3, 9)
INSERT [VENTA].[MENU] ([MenuId], [Nombre], [Precio], [InventarioId], [CategoriaId], [EstadoId]) VALUES (2, N'Coca-Cola de vidrio', CAST(1.25 AS Decimal(10, 2)), 6, 2, 9)
INSERT [VENTA].[MENU] ([MenuId], [Nombre], [Precio], [InventarioId], [CategoriaId], [EstadoId]) VALUES (3, N'Pupusa revuelta', CAST(0.35 AS Decimal(10, 2)), NULL, 3, 9)
INSERT [VENTA].[MENU] ([MenuId], [Nombre], [Precio], [InventarioId], [CategoriaId], [EstadoId]) VALUES (4, N'Coca-Cola de lata', CAST(1.00 AS Decimal(10, 2)), 7, 2, 9)
INSERT [VENTA].[MENU] ([MenuId], [Nombre], [Precio], [InventarioId], [CategoriaId], [EstadoId]) VALUES (5, N'Pupusa de frijol con queso', CAST(0.35 AS Decimal(10, 2)), NULL, 3, 9)
INSERT [VENTA].[MENU] ([MenuId], [Nombre], [Precio], [InventarioId], [CategoriaId], [EstadoId]) VALUES (6, N'Tcaos Mixtos', CAST(0.75 AS Decimal(10, 2)), NULL, 10, 9)
SET IDENTITY_INSERT [VENTA].[MENU] OFF
GO
SET IDENTITY_INSERT [VENTA].[METODO_PAGO] ON 

INSERT [VENTA].[METODO_PAGO] ([MetodoPagoId], [Metodo]) VALUES (1, N'Efectivo')
INSERT [VENTA].[METODO_PAGO] ([MetodoPagoId], [Metodo]) VALUES (2, N'Tarjeta de crédito')
INSERT [VENTA].[METODO_PAGO] ([MetodoPagoId], [Metodo]) VALUES (3, N'Tarjeta de débito')
INSERT [VENTA].[METODO_PAGO] ([MetodoPagoId], [Metodo]) VALUES (4, N'Transferencia')
SET IDENTITY_INSERT [VENTA].[METODO_PAGO] OFF
GO
SET IDENTITY_INSERT [VENTA].[ORDEN] ON 

INSERT [VENTA].[ORDEN] ([OrdenId], [FechaHora], [Total], [DescuentoId], [ClienteId], [EstadoId], [TipoOrdenId], [UsuarioRegistroId]) VALUES (4, CAST(N'2026-06-07T15:01:15.687' AS DateTime), CAST(0.00 AS Decimal(10, 2)), NULL, 1, 1, 4, 9)
INSERT [VENTA].[ORDEN] ([OrdenId], [FechaHora], [Total], [DescuentoId], [ClienteId], [EstadoId], [TipoOrdenId], [UsuarioRegistroId]) VALUES (5, CAST(N'2026-06-07T16:52:45.157' AS DateTime), CAST(15.00 AS Decimal(10, 2)), NULL, 1, 17, 3, 9)
INSERT [VENTA].[ORDEN] ([OrdenId], [FechaHora], [Total], [DescuentoId], [ClienteId], [EstadoId], [TipoOrdenId], [UsuarioRegistroId]) VALUES (6, CAST(N'2026-06-07T16:55:28.123' AS DateTime), CAST(15.00 AS Decimal(10, 2)), NULL, 1, 17, 3, 9)
INSERT [VENTA].[ORDEN] ([OrdenId], [FechaHora], [Total], [DescuentoId], [ClienteId], [EstadoId], [TipoOrdenId], [UsuarioRegistroId]) VALUES (7, CAST(N'2026-06-07T16:59:54.577' AS DateTime), CAST(1.00 AS Decimal(10, 2)), NULL, 6, 1, 3, 9)
INSERT [VENTA].[ORDEN] ([OrdenId], [FechaHora], [Total], [DescuentoId], [ClienteId], [EstadoId], [TipoOrdenId], [UsuarioRegistroId]) VALUES (8, CAST(N'2026-06-07T17:08:16.133' AS DateTime), CAST(1.00 AS Decimal(10, 2)), NULL, 6, 1, 3, 9)
INSERT [VENTA].[ORDEN] ([OrdenId], [FechaHora], [Total], [DescuentoId], [ClienteId], [EstadoId], [TipoOrdenId], [UsuarioRegistroId]) VALUES (9, CAST(N'2026-06-07T17:22:52.723' AS DateTime), CAST(2.00 AS Decimal(10, 2)), NULL, 6, 17, 3, 9)
INSERT [VENTA].[ORDEN] ([OrdenId], [FechaHora], [Total], [DescuentoId], [ClienteId], [EstadoId], [TipoOrdenId], [UsuarioRegistroId]) VALUES (10, CAST(N'2026-06-07T17:27:06.117' AS DateTime), CAST(0.00 AS Decimal(10, 2)), NULL, 1, 17, 3, 9)
INSERT [VENTA].[ORDEN] ([OrdenId], [FechaHora], [Total], [DescuentoId], [ClienteId], [EstadoId], [TipoOrdenId], [UsuarioRegistroId]) VALUES (11, CAST(N'2026-06-07T18:40:17.520' AS DateTime), CAST(2.00 AS Decimal(10, 2)), NULL, 1, 17, 3, 9)
INSERT [VENTA].[ORDEN] ([OrdenId], [FechaHora], [Total], [DescuentoId], [ClienteId], [EstadoId], [TipoOrdenId], [UsuarioRegistroId]) VALUES (12, CAST(N'2026-06-07T22:22:55.613' AS DateTime), CAST(1.00 AS Decimal(10, 2)), NULL, 6, 17, 3, 9)
INSERT [VENTA].[ORDEN] ([OrdenId], [FechaHora], [Total], [DescuentoId], [ClienteId], [EstadoId], [TipoOrdenId], [UsuarioRegistroId]) VALUES (13, CAST(N'2026-06-07T22:47:09.587' AS DateTime), CAST(0.00 AS Decimal(10, 2)), NULL, 1, 17, 3, 9)
INSERT [VENTA].[ORDEN] ([OrdenId], [FechaHora], [Total], [DescuentoId], [ClienteId], [EstadoId], [TipoOrdenId], [UsuarioRegistroId]) VALUES (14, CAST(N'2026-06-07T22:47:57.290' AS DateTime), CAST(1.00 AS Decimal(10, 2)), NULL, 6, 17, 3, 9)
INSERT [VENTA].[ORDEN] ([OrdenId], [FechaHora], [Total], [DescuentoId], [ClienteId], [EstadoId], [TipoOrdenId], [UsuarioRegistroId]) VALUES (15, CAST(N'2026-06-08T09:57:38.817' AS DateTime), CAST(0.00 AS Decimal(10, 2)), NULL, 7, 17, 3, 9)
INSERT [VENTA].[ORDEN] ([OrdenId], [FechaHora], [Total], [DescuentoId], [ClienteId], [EstadoId], [TipoOrdenId], [UsuarioRegistroId]) VALUES (16, CAST(N'2026-06-08T10:20:09.280' AS DateTime), CAST(1.00 AS Decimal(10, 2)), NULL, 7, 17, 3, 9)
INSERT [VENTA].[ORDEN] ([OrdenId], [FechaHora], [Total], [DescuentoId], [ClienteId], [EstadoId], [TipoOrdenId], [UsuarioRegistroId]) VALUES (17, CAST(N'2026-06-08T10:20:44.343' AS DateTime), CAST(0.00 AS Decimal(10, 2)), NULL, 7, 17, 4, 9)
INSERT [VENTA].[ORDEN] ([OrdenId], [FechaHora], [Total], [DescuentoId], [ClienteId], [EstadoId], [TipoOrdenId], [UsuarioRegistroId]) VALUES (18, CAST(N'2026-06-08T10:21:18.777' AS DateTime), CAST(0.00 AS Decimal(10, 2)), NULL, 7, 17, 4, 9)
INSERT [VENTA].[ORDEN] ([OrdenId], [FechaHora], [Total], [DescuentoId], [ClienteId], [EstadoId], [TipoOrdenId], [UsuarioRegistroId]) VALUES (19, CAST(N'2026-06-08T10:38:42.617' AS DateTime), CAST(1.50 AS Decimal(10, 2)), NULL, 6, 17, 4, 9)
INSERT [VENTA].[ORDEN] ([OrdenId], [FechaHora], [Total], [DescuentoId], [ClienteId], [EstadoId], [TipoOrdenId], [UsuarioRegistroId]) VALUES (20, CAST(N'2026-06-08T10:39:32.957' AS DateTime), CAST(10.46 AS Decimal(10, 2)), NULL, 7, 17, 3, 9)
INSERT [VENTA].[ORDEN] ([OrdenId], [FechaHora], [Total], [DescuentoId], [ClienteId], [EstadoId], [TipoOrdenId], [UsuarioRegistroId]) VALUES (21, CAST(N'2026-06-08T10:49:20.930' AS DateTime), CAST(4.25 AS Decimal(10, 2)), NULL, 7, 17, 4, 9)
SET IDENTITY_INSERT [VENTA].[ORDEN] OFF
GO
SET IDENTITY_INSERT [VENTA].[TIPO_DESCUENTO] ON 

INSERT [VENTA].[TIPO_DESCUENTO] ([TipoDescuentoId], [Tipo]) VALUES (1, N'Por temporada')
INSERT [VENTA].[TIPO_DESCUENTO] ([TipoDescuentoId], [Tipo]) VALUES (2, N'Cliente frecuente')
INSERT [VENTA].[TIPO_DESCUENTO] ([TipoDescuentoId], [Tipo]) VALUES (3, N'Promoción')
INSERT [VENTA].[TIPO_DESCUENTO] ([TipoDescuentoId], [Tipo]) VALUES (4, N'Compra mayorista')
SET IDENTITY_INSERT [VENTA].[TIPO_DESCUENTO] OFF
GO
SET IDENTITY_INSERT [VENTA].[TIPO_ORDEN] ON 

INSERT [VENTA].[TIPO_ORDEN] ([TipoOrdenId], [TipoOrden]) VALUES (1, N'En restaurante')
INSERT [VENTA].[TIPO_ORDEN] ([TipoOrdenId], [TipoOrden]) VALUES (2, N'Para llevar')
INSERT [VENTA].[TIPO_ORDEN] ([TipoOrdenId], [TipoOrden]) VALUES (3, N'Delivery')
INSERT [VENTA].[TIPO_ORDEN] ([TipoOrdenId], [TipoOrden]) VALUES (4, N'Comer en restaurante')
SET IDENTITY_INSERT [VENTA].[TIPO_ORDEN] OFF
GO
SET IDENTITY_INSERT [VENTA].[VENTA] ON 

INSERT [VENTA].[VENTA] ([VentaId], [Fecha], [OrdenId], [NoDocumento], [EstadoId], [MetodoPago], [MontoRecibido], [Cambio]) VALUES (1, CAST(N'2026-06-07' AS Date), 11, N'FAC-001', 19, N'Efectivo', CAST(5.00 AS Decimal(10, 2)), CAST(3.00 AS Decimal(10, 2)))
INSERT [VENTA].[VENTA] ([VentaId], [Fecha], [OrdenId], [NoDocumento], [EstadoId], [MetodoPago], [MontoRecibido], [Cambio]) VALUES (2, CAST(N'2026-06-07' AS Date), 5, N'FAC-002', 19, N'Transferencia', CAST(20.00 AS Decimal(10, 2)), CAST(5.00 AS Decimal(10, 2)))
INSERT [VENTA].[VENTA] ([VentaId], [Fecha], [OrdenId], [NoDocumento], [EstadoId], [MetodoPago], [MontoRecibido], [Cambio]) VALUES (3, CAST(N'2026-06-07' AS Date), 6, N'FAC-003', 19, N'Efectivo', CAST(15.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)))
INSERT [VENTA].[VENTA] ([VentaId], [Fecha], [OrdenId], [NoDocumento], [EstadoId], [MetodoPago], [MontoRecibido], [Cambio]) VALUES (4, CAST(N'2026-06-07' AS Date), 9, N'FAC-004', 19, N'Efectivo', CAST(5.00 AS Decimal(10, 2)), CAST(3.00 AS Decimal(10, 2)))
INSERT [VENTA].[VENTA] ([VentaId], [Fecha], [OrdenId], [NoDocumento], [EstadoId], [MetodoPago], [MontoRecibido], [Cambio]) VALUES (5, CAST(N'2026-06-07' AS Date), 10, N'FAC-005', 19, N'Efectivo', CAST(2.00 AS Decimal(10, 2)), CAST(2.00 AS Decimal(10, 2)))
INSERT [VENTA].[VENTA] ([VentaId], [Fecha], [OrdenId], [NoDocumento], [EstadoId], [MetodoPago], [MontoRecibido], [Cambio]) VALUES (6, CAST(N'2026-06-07' AS Date), 12, N'FAC-006', 19, N'Efectivo', CAST(5.00 AS Decimal(10, 2)), CAST(4.00 AS Decimal(10, 2)))
INSERT [VENTA].[VENTA] ([VentaId], [Fecha], [OrdenId], [NoDocumento], [EstadoId], [MetodoPago], [MontoRecibido], [Cambio]) VALUES (7, CAST(N'2026-06-07' AS Date), 14, N'FAC-007', 19, N'Efectivo', CAST(5.00 AS Decimal(10, 2)), CAST(4.00 AS Decimal(10, 2)))
INSERT [VENTA].[VENTA] ([VentaId], [Fecha], [OrdenId], [NoDocumento], [EstadoId], [MetodoPago], [MontoRecibido], [Cambio]) VALUES (8, CAST(N'2026-06-08' AS Date), 13, N'FAC-008', 19, N'Efectivo', CAST(1.00 AS Decimal(10, 2)), CAST(1.00 AS Decimal(10, 2)))
INSERT [VENTA].[VENTA] ([VentaId], [Fecha], [OrdenId], [NoDocumento], [EstadoId], [MetodoPago], [MontoRecibido], [Cambio]) VALUES (9, CAST(N'2026-06-08' AS Date), 15, N'FAC-009', 19, N'Efectivo', CAST(4.00 AS Decimal(10, 2)), CAST(4.00 AS Decimal(10, 2)))
INSERT [VENTA].[VENTA] ([VentaId], [Fecha], [OrdenId], [NoDocumento], [EstadoId], [MetodoPago], [MontoRecibido], [Cambio]) VALUES (10, CAST(N'2026-06-08' AS Date), 16, N'FAC-010', 19, N'Efectivo', CAST(4.00 AS Decimal(10, 2)), CAST(3.00 AS Decimal(10, 2)))
INSERT [VENTA].[VENTA] ([VentaId], [Fecha], [OrdenId], [NoDocumento], [EstadoId], [MetodoPago], [MontoRecibido], [Cambio]) VALUES (11, CAST(N'2026-06-08' AS Date), 17, N'FAC-011', 19, N'Efectivo', CAST(4.00 AS Decimal(10, 2)), CAST(4.00 AS Decimal(10, 2)))
INSERT [VENTA].[VENTA] ([VentaId], [Fecha], [OrdenId], [NoDocumento], [EstadoId], [MetodoPago], [MontoRecibido], [Cambio]) VALUES (12, CAST(N'2026-06-08' AS Date), 18, N'FAC-012', 19, N'Efectivo', CAST(4.00 AS Decimal(10, 2)), CAST(4.00 AS Decimal(10, 2)))
INSERT [VENTA].[VENTA] ([VentaId], [Fecha], [OrdenId], [NoDocumento], [EstadoId], [MetodoPago], [MontoRecibido], [Cambio]) VALUES (13, CAST(N'2026-06-08' AS Date), 19, N'FAC-013', 19, N'Efectivo', CAST(5.00 AS Decimal(10, 2)), CAST(3.50 AS Decimal(10, 2)))
INSERT [VENTA].[VENTA] ([VentaId], [Fecha], [OrdenId], [NoDocumento], [EstadoId], [MetodoPago], [MontoRecibido], [Cambio]) VALUES (14, CAST(N'2026-06-08' AS Date), 20, N'FAC-014', 19, N'Efectivo', CAST(15.00 AS Decimal(10, 2)), CAST(4.54 AS Decimal(10, 2)))
INSERT [VENTA].[VENTA] ([VentaId], [Fecha], [OrdenId], [NoDocumento], [EstadoId], [MetodoPago], [MontoRecibido], [Cambio]) VALUES (15, CAST(N'2026-06-08' AS Date), 21, N'FAC-015', 19, N'Efectivo', CAST(5.00 AS Decimal(10, 2)), CAST(0.75 AS Decimal(10, 2)))
SET IDENTITY_INSERT [VENTA].[VENTA] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__USUARIO__E3237CF7F41FFA5B]    Script Date: 8/6/2026 17:27:40 ******/
ALTER TABLE [AUTENTICACION].[USUARIO] ADD UNIQUE NONCLUSTERED 
(
	[Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__ORDEN_PR__0536FAC512EC774F]    Script Date: 8/6/2026 17:27:40 ******/
ALTER TABLE [BODEGA].[ORDEN_PRODUCCION] ADD UNIQUE NONCLUSTERED 
(
	[NoOrdenProduccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__COMPRA__BFBAD14A0A892BD5]    Script Date: 8/6/2026 17:27:40 ******/
ALTER TABLE [COMPRA].[COMPRA] ADD UNIQUE NONCLUSTERED 
(
	[NoDocumento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__PROVEEDO__4EC5048036B89167]    Script Date: 8/6/2026 17:27:40 ******/
ALTER TABLE [COMPRA].[PROVEEDOR] ADD UNIQUE NONCLUSTERED 
(
	[Telefono] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__PROVEEDO__512B7933F4004C3F]    Script Date: 8/6/2026 17:27:40 ******/
ALTER TABLE [COMPRA].[PROVEEDOR] ADD UNIQUE NONCLUSTERED 
(
	[NoRegistro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__PROVEEDO__C7DEC3C248A8CF52]    Script Date: 8/6/2026 17:27:40 ******/
ALTER TABLE [COMPRA].[PROVEEDOR] ADD UNIQUE NONCLUSTERED 
(
	[NIT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__ENTIDAD__EB0C54CCE58186B3]    Script Date: 8/6/2026 17:27:40 ******/
ALTER TABLE [GLOBAL].[ENTIDAD] ADD UNIQUE NONCLUSTERED 
(
	[Entidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__VENTA__BFBAD14ACF3F613E]    Script Date: 8/6/2026 17:27:40 ******/
ALTER TABLE [VENTA].[VENTA] ADD UNIQUE NONCLUSTERED 
(
	[NoDocumento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [AUDITORIA].[HISTORIAL] ADD  DEFAULT (getdate()) FOR [FechaHora]
GO
ALTER TABLE [COMPRA].[INVENTARIO] ADD  DEFAULT ((7)) FOR [EstadoId]
GO
ALTER TABLE [DELIVERY].[DIRECCION] ADD  DEFAULT ((29)) FOR [EstadoId]
GO
ALTER TABLE [DELIVERY].[DIRECCION] ADD  DEFAULT (getdate()) FOR [FechaModificacion]
GO
ALTER TABLE [VENTA].[CATEGORIA] ADD  DEFAULT ((27)) FOR [EstadoId]
GO
ALTER TABLE [VENTA].[CLIENTE] ADD  DEFAULT ((31)) FOR [EstadoId]
GO
ALTER TABLE [VENTA].[DESCUENTO] ADD  DEFAULT ((33)) FOR [EstadoId]
GO
ALTER TABLE [AUDITORIA].[HISTORIAL]  WITH CHECK ADD FOREIGN KEY([AccionEventoId])
REFERENCES [AUDITORIA].[ACCION_EVENTO] ([AccionEventoId])
GO
ALTER TABLE [AUDITORIA].[HISTORIAL]  WITH CHECK ADD FOREIGN KEY([UsuarioRegistroId])
REFERENCES [AUTENTICACION].[USUARIO] ([UsuarioId])
GO
ALTER TABLE [AUTENTICACION].[USUARIO]  WITH CHECK ADD FOREIGN KEY([EstadoId])
REFERENCES [GLOBAL].[ESTADO] ([EstadoId])
GO
ALTER TABLE [AUTENTICACION].[USUARIO]  WITH CHECK ADD FOREIGN KEY([RolId])
REFERENCES [AUTENTICACION].[ROL] ([RolId])
GO
ALTER TABLE [AUTENTICACION].[USUARIO]  WITH CHECK ADD FOREIGN KEY([UsuarioRegistroId])
REFERENCES [AUTENTICACION].[USUARIO] ([UsuarioId])
GO
ALTER TABLE [AUTENTICACION].[USUARIO]  WITH CHECK ADD FOREIGN KEY([UsuarioModificiacionId])
REFERENCES [AUTENTICACION].[USUARIO] ([UsuarioId])
GO
ALTER TABLE [AUTENTICACION].[USUARIO]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadoId] FOREIGN KEY([EmpleadoId])
REFERENCES [RRHH].[EMPLEADO] ([EmpleadoId])
GO
ALTER TABLE [AUTENTICACION].[USUARIO] CHECK CONSTRAINT [FK_EmpleadoId]
GO
ALTER TABLE [BODEGA].[DET_ORDEN_PRODUCCION]  WITH CHECK ADD FOREIGN KEY([InventarioId])
REFERENCES [COMPRA].[INVENTARIO] ([InventarioId])
GO
ALTER TABLE [BODEGA].[DET_ORDEN_PRODUCCION]  WITH CHECK ADD FOREIGN KEY([OrdenProduccionId])
REFERENCES [BODEGA].[ORDEN_PRODUCCION] ([OrdenProduccionId])
GO
ALTER TABLE [BODEGA].[ORDEN_PRODUCCION]  WITH CHECK ADD FOREIGN KEY([EmpleadoId])
REFERENCES [RRHH].[EMPLEADO] ([EmpleadoId])
GO
ALTER TABLE [BODEGA].[ORDEN_PRODUCCION]  WITH CHECK ADD FOREIGN KEY([UsuarioRegistroId])
REFERENCES [AUTENTICACION].[USUARIO] ([UsuarioId])
GO
ALTER TABLE [BODEGA].[ORDEN_PRODUCCION]  WITH CHECK ADD FOREIGN KEY([UsuarioModificacionId])
REFERENCES [AUTENTICACION].[USUARIO] ([UsuarioId])
GO
ALTER TABLE [COMPRA].[COMPRA]  WITH CHECK ADD FOREIGN KEY([EstadoId])
REFERENCES [GLOBAL].[ESTADO] ([EstadoId])
GO
ALTER TABLE [COMPRA].[COMPRA]  WITH CHECK ADD FOREIGN KEY([ProveedorId])
REFERENCES [COMPRA].[PROVEEDOR] ([ProveedorId])
GO
ALTER TABLE [COMPRA].[DET_COMPRA]  WITH CHECK ADD FOREIGN KEY([CompraId])
REFERENCES [COMPRA].[COMPRA] ([CompraId])
GO
ALTER TABLE [COMPRA].[DET_COMPRA]  WITH CHECK ADD FOREIGN KEY([InventarioId])
REFERENCES [COMPRA].[INVENTARIO] ([InventarioId])
GO
ALTER TABLE [COMPRA].[INVENTARIO]  WITH CHECK ADD FOREIGN KEY([EstadoId])
REFERENCES [GLOBAL].[ESTADO] ([EstadoId])
GO
ALTER TABLE [COMPRA].[INVENTARIO]  WITH CHECK ADD FOREIGN KEY([TipoInventarioId])
REFERENCES [COMPRA].[TIPO_INVENTARIO] ([TipoInventarioId])
GO
ALTER TABLE [COMPRA].[INVENTARIO]  WITH CHECK ADD FOREIGN KEY([UsuarioRegistroId])
REFERENCES [AUTENTICACION].[USUARIO] ([UsuarioId])
GO
ALTER TABLE [COMPRA].[INVENTARIO]  WITH CHECK ADD FOREIGN KEY([UsuarioModificacionId])
REFERENCES [AUTENTICACION].[USUARIO] ([UsuarioId])
GO
ALTER TABLE [COMPRA].[PROVEEDOR]  WITH CHECK ADD FOREIGN KEY([EstadoId])
REFERENCES [GLOBAL].[ESTADO] ([EstadoId])
GO
ALTER TABLE [DELIVERY].[CONFIGURACION_LOCAL]  WITH CHECK ADD FOREIGN KEY([MunicipioId])
REFERENCES [DELIVERY].[MUNICIPIO] ([MunicipioId])
GO
ALTER TABLE [DELIVERY].[COORDENADAS_MUNICIPIO]  WITH CHECK ADD FOREIGN KEY([MunicipioId])
REFERENCES [DELIVERY].[MUNICIPIO] ([MunicipioId])
GO
ALTER TABLE [DELIVERY].[DIRECCION]  WITH CHECK ADD FOREIGN KEY([EstadoId])
REFERENCES [GLOBAL].[ESTADO] ([EstadoId])
GO
ALTER TABLE [DELIVERY].[DIRECCION]  WITH CHECK ADD FOREIGN KEY([MunicipioId])
REFERENCES [DELIVERY].[MUNICIPIO] ([MunicipioId])
GO
ALTER TABLE [DELIVERY].[ENVIO]  WITH CHECK ADD FOREIGN KEY([DireccionId])
REFERENCES [DELIVERY].[DIRECCION] ([DireccionId])
GO
ALTER TABLE [DELIVERY].[ENVIO]  WITH CHECK ADD FOREIGN KEY([EstadoId])
REFERENCES [GLOBAL].[ESTADO] ([EstadoId])
GO
ALTER TABLE [DELIVERY].[ENVIO]  WITH CHECK ADD FOREIGN KEY([OrdenId])
REFERENCES [VENTA].[ORDEN] ([OrdenId])
GO
ALTER TABLE [DELIVERY].[ENVIO]  WITH CHECK ADD FOREIGN KEY([RepartidorId])
REFERENCES [DELIVERY].[REPARTIDOR] ([RepartidorId])
GO
ALTER TABLE [DELIVERY].[REPARTIDOR]  WITH CHECK ADD FOREIGN KEY([EmpleadoId])
REFERENCES [RRHH].[EMPLEADO] ([EmpleadoId])
GO
ALTER TABLE [DELIVERY].[REPARTIDOR]  WITH CHECK ADD FOREIGN KEY([EstadoId])
REFERENCES [GLOBAL].[ESTADO] ([EstadoId])
GO
ALTER TABLE [DELIVERY].[TARIFA_DELIVERY]  WITH CHECK ADD FOREIGN KEY([MunicipioId])
REFERENCES [DELIVERY].[MUNICIPIO] ([MunicipioId])
GO
ALTER TABLE [GLOBAL].[ESTADO]  WITH CHECK ADD FOREIGN KEY([EntidadId])
REFERENCES [GLOBAL].[ENTIDAD] ([EntidadId])
GO
ALTER TABLE [RRHH].[EMPLEADO]  WITH CHECK ADD FOREIGN KEY([CargoId])
REFERENCES [RRHH].[CARGO] ([CargoId])
GO
ALTER TABLE [RRHH].[EMPLEADO]  WITH CHECK ADD FOREIGN KEY([EstadoId])
REFERENCES [GLOBAL].[ESTADO] ([EstadoId])
GO
ALTER TABLE [RRHH].[EMPLEADO]  WITH CHECK ADD FOREIGN KEY([UsuarioRegistroId])
REFERENCES [AUTENTICACION].[USUARIO] ([UsuarioId])
GO
ALTER TABLE [RRHH].[EMPLEADO]  WITH CHECK ADD FOREIGN KEY([UsuarioModificacionId])
REFERENCES [AUTENTICACION].[USUARIO] ([UsuarioId])
GO
ALTER TABLE [VENTA].[CATEGORIA]  WITH CHECK ADD FOREIGN KEY([EstadoId])
REFERENCES [GLOBAL].[ESTADO] ([EstadoId])
GO
ALTER TABLE [VENTA].[CLIENTE]  WITH CHECK ADD FOREIGN KEY([DireccionId])
REFERENCES [DELIVERY].[DIRECCION] ([DireccionId])
GO
ALTER TABLE [VENTA].[CLIENTE]  WITH CHECK ADD FOREIGN KEY([EstadoId])
REFERENCES [GLOBAL].[ESTADO] ([EstadoId])
GO
ALTER TABLE [VENTA].[COMBO]  WITH CHECK ADD FOREIGN KEY([CategoriaId])
REFERENCES [VENTA].[CATEGORIA] ([CategoriaId])
GO
ALTER TABLE [VENTA].[COMBO]  WITH CHECK ADD FOREIGN KEY([EstadoId])
REFERENCES [GLOBAL].[ESTADO] ([EstadoId])
GO
ALTER TABLE [VENTA].[DESCUENTO]  WITH CHECK ADD FOREIGN KEY([CategoriaId])
REFERENCES [VENTA].[CATEGORIA] ([CategoriaId])
GO
ALTER TABLE [VENTA].[DESCUENTO]  WITH CHECK ADD FOREIGN KEY([ComboId])
REFERENCES [VENTA].[COMBO] ([ComboId])
GO
ALTER TABLE [VENTA].[DESCUENTO]  WITH CHECK ADD FOREIGN KEY([EstadoId])
REFERENCES [GLOBAL].[ESTADO] ([EstadoId])
GO
ALTER TABLE [VENTA].[DESCUENTO]  WITH CHECK ADD FOREIGN KEY([MenuId])
REFERENCES [VENTA].[MENU] ([MenuId])
GO
ALTER TABLE [VENTA].[DESCUENTO]  WITH CHECK ADD FOREIGN KEY([TipoDescuentoId])
REFERENCES [VENTA].[TIPO_DESCUENTO] ([TipoDescuentoId])
GO
ALTER TABLE [VENTA].[DET_COMBO]  WITH CHECK ADD  CONSTRAINT [FK_DET_COMBO_Categoria] FOREIGN KEY([CategoriaId])
REFERENCES [VENTA].[CATEGORIA] ([CategoriaId])
GO
ALTER TABLE [VENTA].[DET_COMBO] CHECK CONSTRAINT [FK_DET_COMBO_Categoria]
GO
ALTER TABLE [VENTA].[DET_COMBO]  WITH CHECK ADD  CONSTRAINT [FK_DET_COMBO_Combo] FOREIGN KEY([ComboId])
REFERENCES [VENTA].[COMBO] ([ComboId])
GO
ALTER TABLE [VENTA].[DET_COMBO] CHECK CONSTRAINT [FK_DET_COMBO_Combo]
GO
ALTER TABLE [VENTA].[DET_COMBO]  WITH CHECK ADD  CONSTRAINT [FK_DET_COMBO_Menu] FOREIGN KEY([idMenu])
REFERENCES [VENTA].[MENU] ([MenuId])
GO
ALTER TABLE [VENTA].[DET_COMBO] CHECK CONSTRAINT [FK_DET_COMBO_Menu]
GO
ALTER TABLE [VENTA].[DET_ORDEN]  WITH CHECK ADD FOREIGN KEY([ComboId])
REFERENCES [VENTA].[COMBO] ([ComboId])
GO
ALTER TABLE [VENTA].[DET_ORDEN]  WITH CHECK ADD FOREIGN KEY([MenuId])
REFERENCES [VENTA].[MENU] ([MenuId])
GO
ALTER TABLE [VENTA].[DET_ORDEN]  WITH CHECK ADD FOREIGN KEY([OrdenId])
REFERENCES [VENTA].[ORDEN] ([OrdenId])
GO
ALTER TABLE [VENTA].[MENU]  WITH CHECK ADD FOREIGN KEY([CategoriaId])
REFERENCES [VENTA].[CATEGORIA] ([CategoriaId])
GO
ALTER TABLE [VENTA].[MENU]  WITH CHECK ADD FOREIGN KEY([EstadoId])
REFERENCES [GLOBAL].[ESTADO] ([EstadoId])
GO
ALTER TABLE [VENTA].[MENU]  WITH CHECK ADD FOREIGN KEY([InventarioId])
REFERENCES [COMPRA].[INVENTARIO] ([InventarioId])
GO
ALTER TABLE [VENTA].[ORDEN]  WITH CHECK ADD FOREIGN KEY([ClienteId])
REFERENCES [VENTA].[CLIENTE] ([ClienteId])
GO
ALTER TABLE [VENTA].[ORDEN]  WITH CHECK ADD FOREIGN KEY([DescuentoId])
REFERENCES [VENTA].[DESCUENTO] ([DescuentoId])
GO
ALTER TABLE [VENTA].[ORDEN]  WITH CHECK ADD FOREIGN KEY([EstadoId])
REFERENCES [GLOBAL].[ESTADO] ([EstadoId])
GO
ALTER TABLE [VENTA].[ORDEN]  WITH CHECK ADD FOREIGN KEY([TipoOrdenId])
REFERENCES [VENTA].[TIPO_ORDEN] ([TipoOrdenId])
GO
ALTER TABLE [VENTA].[ORDEN]  WITH CHECK ADD FOREIGN KEY([UsuarioRegistroId])
REFERENCES [AUTENTICACION].[USUARIO] ([UsuarioId])
GO
ALTER TABLE [VENTA].[VENTA]  WITH CHECK ADD FOREIGN KEY([EstadoId])
REFERENCES [GLOBAL].[ESTADO] ([EstadoId])
GO
ALTER TABLE [VENTA].[VENTA]  WITH CHECK ADD FOREIGN KEY([OrdenId])
REFERENCES [VENTA].[ORDEN] ([OrdenId])
GO
ALTER TABLE [BODEGA].[DET_ORDEN_PRODUCCION]  WITH CHECK ADD  CONSTRAINT [CK_DET_ORDEN_Cantidad_Pos] CHECK  (([Cantidad]>(0)))
GO
ALTER TABLE [BODEGA].[DET_ORDEN_PRODUCCION] CHECK CONSTRAINT [CK_DET_ORDEN_Cantidad_Pos]
GO
ALTER TABLE [COMPRA].[COMPRA]  WITH CHECK ADD CHECK  (([Total]>(0.0)))
GO
ALTER TABLE [COMPRA].[DET_COMPRA]  WITH CHECK ADD CHECK  (([Cantidad]>(0)))
GO
ALTER TABLE [COMPRA].[DET_COMPRA]  WITH CHECK ADD CHECK  (([PrecioCompra]>(0.00)))
GO
ALTER TABLE [COMPRA].[DET_COMPRA]  WITH CHECK ADD CHECK  (([TotalDetalleCompra]>(0.00)))
GO
ALTER TABLE [COMPRA].[INVENTARIO]  WITH CHECK ADD CHECK  (([Cantidad]>(0)))
GO
ALTER TABLE [COMPRA].[INVENTARIO]  WITH CHECK ADD CHECK  (([PrecioCosto]>(0.00)))
GO
ALTER TABLE [VENTA].[COMBO]  WITH CHECK ADD CHECK  (([Precio]>(0.00)))
GO
ALTER TABLE [VENTA].[DESCUENTO]  WITH CHECK ADD CHECK  (([Porcentaje]>(0) AND [Porcentaje]<=(100)))
GO
ALTER TABLE [VENTA].[MENU]  WITH CHECK ADD CHECK  (([Precio]>(0.00)))
GO
ALTER TABLE [VENTA].[ORDEN]  WITH CHECK ADD CHECK  (([Total]>=(0.00)))
GO
/****** Object:  StoredProcedure [AUDITORIA].[SpInsertAccionEvento]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--###################################################################################################################

-- Sp para AUDITORIA.ACCION_EVENTO
-- 1. Insercion de Accion Evento
CREATE PROC [AUDITORIA].[SpInsertAccionEvento]
    @AccionEvento VARCHAR(75)
AS
BEGIN
    IF NOT EXISTS (SELECT * FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = @AccionEvento)
        INSERT INTO AUDITORIA.ACCION_EVENTO (AccionEvento)
        VALUES (@AccionEvento);
    ELSE
        PRINT('Mensaje: La accion de evento ingresada ya existe en la BD.');
END
GO
/****** Object:  StoredProcedure [AUDITORIA].[SpInsertHistorial]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--###################################################################################################################

-- Sp para AUDITORIA.HISTORIAL
-- 1. Insercion de registro en Historial
CREATE PROC [AUDITORIA].[SpInsertHistorial]
    @AccionEventoId INT,
    @Detalle VARCHAR(100),
    @UsuarioRegistroId INT
AS
begin
    IF NOT EXISTS (SELECT * FROM AUTENTICACION.USUARIO WHERE UsuarioId = @UsuarioRegistroId)
        PRINT('Mensaje: El usuario ingresado no existe en la BD.');
    ELSE IF @Detalle IS NULL OR LTRIM(RTRIM(@Detalle)) = ''
        PRINT('Mensaje: El detalle del historial no puede estar vacio.');
    ELSE
        INSERT INTO AUDITORIA.HISTORIAL (FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
        VALUES (GETDATE(), @AccionEventoId, @Detalle, @UsuarioRegistroId);
end
GO
/****** Object:  StoredProcedure [AUDITORIA].[SpRegistrarAuditoria]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [AUDITORIA].[SpRegistrarAuditoria]
    @AccionEvento VARCHAR(75),
    @Detalle VARCHAR(200),
    @UsuarioRegistroId INT
AS
BEGIN
    DECLARE @AccionEventoId INT;
    SELECT @AccionEventoId = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = @AccionEvento;
    
    IF @AccionEventoId IS NOT NULL
        INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
        VALUES (GETDATE(), @AccionEventoId, @Detalle, @UsuarioRegistroId);
END
GO
/****** Object:  StoredProcedure [AUDITORIA].[SpSelectAllAccionEvento]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 2. Select All de Acciones de Evento
CREATE PROC [AUDITORIA].[SpSelectAllAccionEvento]
AS
BEGIN
    SELECT AccionEventoId AS 'Codigo', AccionEvento AS 'Accion de Evento'
    FROM AUDITORIA.ACCION_EVENTO
    ORDER BY AccionEvento ASC;
END
GO
/****** Object:  StoredProcedure [AUDITORIA].[SpSelectAllHistorial]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 2. Select All del Historial
CREATE PROC [AUDITORIA].[SpSelectAllHistorial]
AS
begin
    SELECT a.HistorialId AS 'Codigo',
    a.FechaHora AS 'Fecha y Hora',
    b.AccionEvento AS 'Accion',
    a.Detalle,
    a.UsuarioRegistroId AS 'UsuarioId',
    CONCAT('Id: ', a.UsuarioRegistroId, ' - ', COALESCE(c.Usuario, 'N/D')) AS 'Usuario'
    FROM AUDITORIA.HISTORIAL a
    INNER JOIN AUDITORIA.ACCION_EVENTO b ON a.AccionEventoId = b.AccionEventoId
    LEFT JOIN AUTENTICACION.USUARIO c ON a.UsuarioRegistroId = c.UsuarioId
    ORDER BY a.FechaHora DESC;
end
GO
/****** Object:  StoredProcedure [AUDITORIA].[SpSelectHistorial]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ============================================================
-- 3. Procedimiento de consulta (no se toca si ya existe)
-- ============================================================
CREATE   PROCEDURE [AUDITORIA].[SpSelectHistorial]
    @UsuarioBuscar VARCHAR(50) = NULL,
    @AccionEventoId INT = NULL,
    @FechaDesde DATE = NULL,
    @FechaHasta DATE = NULL
AS
BEGIN
    SELECT h.HistorialId,
           h.FechaHora,
           a.AccionEvento AS Accion,
           h.Detalle,
           h.UsuarioRegistroId AS UsuarioId,
           CONCAT('Id: ', h.UsuarioRegistroId, ' - ', COALESCE(u.Usuario, 'N/D')) AS Usuario
    FROM AUDITORIA.HISTORIAL h
    INNER JOIN AUDITORIA.ACCION_EVENTO a ON h.AccionEventoId = a.AccionEventoId
    LEFT JOIN AUTENTICACION.USUARIO u ON h.UsuarioRegistroId = u.UsuarioId
    WHERE (@UsuarioBuscar IS NULL OR COALESCE(u.Usuario, '') LIKE '%' + @UsuarioBuscar + '%')
      AND (@AccionEventoId IS NULL OR h.AccionEventoId = @AccionEventoId)
      AND (@FechaDesde IS NULL OR CAST(h.FechaHora AS DATE) >= @FechaDesde)
      AND (@FechaHasta IS NULL OR CAST(h.FechaHora AS DATE) <= @FechaHasta)
    ORDER BY h.FechaHora DESC;
END
GO
/****** Object:  StoredProcedure [AUDITORIA].[SpSelectHistorialPorAccion]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 5. SP de busqueda de Historial por tipo de Accion Evento
CREATE PROC [AUDITORIA].[SpSelectHistorialPorAccion]
    @AccionEventoId INT
AS
begin
    IF NOT EXISTS (SELECT * FROM AUDITORIA.ACCION_EVENTO WHERE AccionEventoId = @AccionEventoId)
        PRINT('Mensaje: La accion de evento ingresada no existe en la BD.');
    ELSE IF NOT EXISTS (SELECT * FROM AUDITORIA.HISTORIAL WHERE AccionEventoId = @AccionEventoId)
        PRINT('Mensaje: No se encontraron registros para la accion indicada.');
    ELSE
        SELECT a.HistorialId AS 'Codigo',
        a.FechaHora AS 'Fecha y Hora',
        b.AccionEvento AS 'Accion',
        a.Detalle,
        a.UsuarioRegistroId AS 'UsuarioId',
        CONCAT('Id: ', a.UsuarioRegistroId, ' - ', COALESCE(c.Usuario, 'N/D')) AS 'Usuario'
        FROM AUDITORIA.HISTORIAL a
        INNER JOIN AUDITORIA.ACCION_EVENTO b ON a.AccionEventoId = b.AccionEventoId
        LEFT JOIN AUTENTICACION.USUARIO c ON a.UsuarioRegistroId = c.UsuarioId
        WHERE a.AccionEventoId = @AccionEventoId
        ORDER BY a.FechaHora DESC;
end
GO
/****** Object:  StoredProcedure [AUDITORIA].[SpSelectHistorialPorFecha]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 3. SP de busqueda de Historial por rango de fechas
CREATE PROC [AUDITORIA].[SpSelectHistorialPorFecha]
    @FechaInicio DATE, @FechaFin DATE
AS
begin
    IF @FechaInicio > @FechaFin
        PRINT('Mensaje: La fecha de inicio no puede ser mayor a la fecha fin.');
    ELSE IF NOT EXISTS (SELECT * FROM AUDITORIA.HISTORIAL
                        WHERE CAST(FechaHora AS DATE) BETWEEN @FechaInicio AND @FechaFin)
        PRINT('Mensaje: No se encontraron registros en el rango de fechas indicado.');
    ELSE
        SELECT a.HistorialId AS 'Codigo',
        a.FechaHora AS 'Fecha y Hora',
        b.AccionEvento AS 'Accion',
        a.Detalle,
        a.UsuarioRegistroId AS 'UsuarioId',
        CONCAT('Id: ', a.UsuarioRegistroId, ' - ', COALESCE(c.Usuario, 'N/D')) AS 'Usuario'
        FROM AUDITORIA.HISTORIAL a
        INNER JOIN AUDITORIA.ACCION_EVENTO b ON a.AccionEventoId = b.AccionEventoId
        LEFT JOIN AUTENTICACION.USUARIO c ON a.UsuarioRegistroId = c.UsuarioId
        WHERE CAST(a.FechaHora AS DATE) BETWEEN @FechaInicio AND @FechaFin
        ORDER BY a.FechaHora DESC;
end
GO
/****** Object:  StoredProcedure [AUDITORIA].[SpSelectHistorialPorUsuario]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 4. SP de busqueda de Historial por usuario
CREATE PROC [AUDITORIA].[SpSelectHistorialPorUsuario]
    @UsuarioId INT
AS
begin
    IF NOT EXISTS (SELECT * FROM AUTENTICACION.USUARIO WHERE UsuarioId = @UsuarioId)
        PRINT('Mensaje: El usuario ingresado no existe en la BD.');
    ELSE IF NOT EXISTS (SELECT * FROM AUDITORIA.HISTORIAL WHERE UsuarioRegistroId = @UsuarioId)
        PRINT('Mensaje: El usuario no tiene registros en el historial.');
    ELSE
        SELECT a.HistorialId AS 'Codigo',
        a.FechaHora AS 'Fecha y Hora',
        b.AccionEvento AS 'Accion',
        a.Detalle,
        a.UsuarioRegistroId AS 'UsuarioId',
        CONCAT('Id: ', a.UsuarioRegistroId, ' - ', COALESCE(c.Usuario, 'N/D')) AS 'Usuario'
        FROM AUDITORIA.HISTORIAL a
        INNER JOIN AUDITORIA.ACCION_EVENTO b ON a.AccionEventoId = b.AccionEventoId
        LEFT JOIN AUTENTICACION.USUARIO c ON a.UsuarioRegistroId = c.UsuarioId
        WHERE a.UsuarioRegistroId = @UsuarioId
        ORDER BY a.FechaHora DESC;
end
GO
/****** Object:  StoredProcedure [AUDITORIA].[SpUpdateAccionEvento]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 3. SP de actualizacion de Accion Evento
CREATE PROC [AUDITORIA].[SpUpdateAccionEvento]
    @AccionEventoId INT, 
    @AccionEvento VARCHAR(75)
AS
BEGIN
    IF NOT EXISTS (SELECT * FROM AUDITORIA.ACCION_EVENTO WHERE AccionEventoId = @AccionEventoId)
        PRINT('Mensaje: La accion de evento no ha sido encontrada en la BD.');
    ELSE IF EXISTS (SELECT * FROM AUDITORIA.ACCION_EVENTO 
                    WHERE AccionEvento = @AccionEvento AND AccionEventoId <> @AccionEventoId)
        PRINT('Mensaje: La accion de evento ingresada ya existe en otro registro de la BD.');
    ELSE
        UPDATE AUDITORIA.ACCION_EVENTO
        SET AccionEvento = @AccionEvento
        WHERE AccionEventoId = @AccionEventoId;
END
GO
/****** Object:  StoredProcedure [AUTENTICACION].[SpDeleteLogicoUsuario]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Sp para borrar
CREATE PROCEDURE [AUTENTICACION].[SpDeleteLogicoUsuario]
    @UsuarioId INT,
    @EstadoId INT
AS
BEGIN
    IF EXISTS(SELECT * FROM AUTENTICACION.USUARIO WHERE UsuarioId = @UsuarioId)
        UPDATE AUTENTICACION.USUARIO
        SET EstadoId = @EstadoId
        WHERE UsuarioId = @UsuarioId 
    ELSE
        PRINT('El usuario no existe...')
END
GO
/****** Object:  StoredProcedure [AUTENTICACION].[SpInsertRol]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--###################################################################################################################

-- Sp para AUTENTICACION.ROL
-- Insertar un rol
CREATE PROCEDURE [AUTENTICACION].[SpInsertRol]
    @Rol VARCHAR(30)
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM AUTENTICACION.ROL WHERE Rol = @Rol)
        INSERT INTO AUTENTICACION.ROL(Rol)
        VALUES (@Rol);
END
GO
/****** Object:  StoredProcedure [AUTENTICACION].[SpInsertUsuario]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--###################################################################################################################

--Sp para AUTENTICACION.USUARIO
--Insertar un usuario
CREATE PROCEDURE [AUTENTICACION].[SpInsertUsuario]
    @Usuario VARCHAR(20),
    @Clave VARCHAR(25),
    @EmpleadoId INT = NULL,
    @EstadoId INT,
    @RolId INT,
    @UsuarioRegistroId INT
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM AUTENTICACION.USUARIO WHERE Usuario = @Usuario OR (EmpleadoId = @EmpleadoId AND EmpleadoId IS NOT NULL))
        INSERT INTO AUTENTICACION.USUARIO(Usuario,Clave,EmpleadoId,EstadoId,RolId,UsuarioRegistroId)
        VALUES (@Usuario,@Clave,@EmpleadoId,@EstadoId,@RolId,@UsuarioRegistroId)
    ELSE
        PRINT('Mensaje : ')
END
GO
/****** Object:  StoredProcedure [AUTENTICACION].[SpSelectAllRol]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Seleccionar todos los roles
CREATE PROCEDURE [AUTENTICACION].[SpSelectAllRol]
AS
BEGIN
    SELECT RolId AS 'Id', Rol  FROM AUTENTICACION.ROL
END
GO
/****** Object:  StoredProcedure [AUTENTICACION].[SpSelectAllusuario]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Quitar filtro de activos en SpSelectAllUsuario
CREATE PROCEDURE [AUTENTICACION].[SpSelectAllusuario]
AS
BEGIN
    SELECT  a.UsuarioId,
            a.Usuario,
            a.Clave,
            a.EmpleadoId,
            b.Nombre + ', ' + b.Apellido AS EmpleadoNombre,
            a.RolId,
            c.Rol,
            a.EstadoId,
            d.Estado AS EstadoNombre,
            a.UsuarioRegistroId,
            a.UsuarioModificiacionId
    FROM AUTENTICACION.USUARIO a
    INNER JOIN RRHH.EMPLEADO b ON a.EmpleadoId = b.EmpleadoId
    INNER JOIN AUTENTICACION.ROL c ON a.RolId = c.RolId
    INNER JOIN GLOBAL.ESTADO d ON a.EstadoId = d.EstadoId
    INNER JOIN GLOBAL.ENTIDAD e ON d.EntidadId = e.EntidadId
    WHERE UPPER(e.Entidad) = 'USUARIO'
    ORDER BY a.Usuario;
END
GO
/****** Object:  StoredProcedure [AUTENTICACION].[SpSelectUsuario]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Quitar filtro de activos en SpSelectUsuario
CREATE PROCEDURE [AUTENTICACION].[SpSelectUsuario]
    @buscar VARCHAR(50)
AS
BEGIN
    SELECT  a.UsuarioId,
            a.Usuario,
            a.Clave,
            a.EmpleadoId,
            b.Nombre + ', ' + b.Apellido AS EmpleadoNombre,
            a.RolId,
            c.Rol,
            a.EstadoId,
            d.Estado AS EstadoNombre,
            a.UsuarioRegistroId,
            a.UsuarioModificiacionId
    FROM AUTENTICACION.USUARIO a
    INNER JOIN RRHH.EMPLEADO b ON a.EmpleadoId = b.EmpleadoId
    INNER JOIN AUTENTICACION.ROL c ON a.RolId = c.RolId
    INNER JOIN GLOBAL.ESTADO d ON a.EstadoId = d.EstadoId
    INNER JOIN GLOBAL.ENTIDAD e ON d.EntidadId = e.EntidadId
    WHERE (a.UsuarioId = TRY_CAST(@buscar AS INT)
           OR a.Usuario LIKE '%' + @buscar + '%'
           OR b.Nombre + ', ' + b.Apellido LIKE '%' + @buscar + '%')
      AND UPPER(e.Entidad) = 'USUARIO'
    ORDER BY a.Usuario;
END
GO
/****** Object:  StoredProcedure [AUTENTICACION].[SpUpdaterol]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Actualizar un un rol
CREATE PROCEDURE [AUTENTICACION].[SpUpdaterol]
    @RolId INT,
    @Rol VARCHAR(30)
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM AUTENTICACION.ROL WHERE Rol = @Rol)
        UPDATE AUTENTICACION.ROL
        SET Rol = @Rol
        WHERE RolId = @RolId
END
GO
/****** Object:  StoredProcedure [AUTENTICACION].[SpUpdateUsuario]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [AUTENTICACION].[SpUpdateUsuario]
    @UsuarioId INT,
    @Usuario VARCHAR(20),
    @Clave VARCHAR(25),
    @EmpleadoId INT = NULL,
    @EstadoId INT,
    @RolId INT,
    @UsuarioModificacionId INT
AS
BEGIN
    IF EXISTS (SELECT * FROM AUTENTICACION.USUARIO 
               WHERE (Usuario = @Usuario OR (EmpleadoId = @EmpleadoId AND EmpleadoId IS NOT NULL))
                 AND UsuarioId <> @UsuarioId)
    BEGIN
        PRINT('Mensaje: Registro denegado por usuario existente.');
        RETURN;
    END

    UPDATE AUTENTICACION.USUARIO
    SET Usuario = @Usuario,
        Clave = @Clave,
        EmpleadoId = @EmpleadoId,
        EstadoId = @EstadoId,
        RolId = @RolId,
        UsuarioModificiacionId = @UsuarioModificacionId
    WHERE UsuarioId = @UsuarioId;
END
GO
/****** Object:  StoredProcedure [BODEGA].[SpRegistrarProduccion]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [BODEGA].[SpRegistrarProduccion]
    @NoOrdenProduccion VARCHAR(20),
    @Fecha DATE,
    @EmpleadoId INT,
    @UsuarioRegistroId INT,
    @ProductoFinal VARCHAR(100) = NULL,
    @CantidadProducto INT = NULL,
    @Detalle BODEGA.DetalleProduccionType READONLY
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Validar stock suficiente antes de descontar
        IF EXISTS (
            SELECT 1 FROM @Detalle d
            INNER JOIN COMPRA.INVENTARIO i ON d.InventarioId = i.InventarioId
            WHERE i.Cantidad < d.Cantidad
        )
        BEGIN
            RAISERROR('No hay suficiente stock para uno o más insumos.', 16, 1);
            RETURN;
        END

        DECLARE @OrdenId INT;
        INSERT INTO BODEGA.ORDEN_PRODUCCION(NoOrdenProduccion, Fecha, EmpleadoId, UsuarioRegistroId, ProductoFinal, CantidadProducto)
        VALUES (@NoOrdenProduccion, @Fecha, @EmpleadoId, @UsuarioRegistroId, @ProductoFinal, @CantidadProducto);
        SET @OrdenId = SCOPE_IDENTITY();

        -- Insertar detalle
        INSERT INTO BODEGA.DET_ORDEN_PRODUCCION(OrdenProduccionId, InventarioId, Cantidad)
        SELECT @OrdenId, InventarioId, Cantidad FROM @Detalle;

        -- Descontar inventario de ingredientes
        UPDATE i
        SET i.Cantidad = i.Cantidad - d.Cantidad
        FROM COMPRA.INVENTARIO i
        INNER JOIN @Detalle d ON i.InventarioId = d.InventarioId;

        -- ============================================================
        -- NUEVO: Aumentar el stock del producto final (si aplica)
        -- ============================================================
        IF @ProductoFinal IS NOT NULL AND @CantidadProducto IS NOT NULL AND @CantidadProducto > 0
        BEGIN
            -- Buscar el InventarioId asociado al menú seleccionado
            DECLARE @InventarioFinalId INT;
            SELECT @InventarioFinalId = InventarioId FROM VENTA.MENU WHERE MenuId = CAST(@ProductoFinal AS INT);

            -- Si el menú tiene un inventario asociado, aumentar su stock
            IF @InventarioFinalId IS NOT NULL
            BEGIN
                UPDATE COMPRA.INVENTARIO
                SET Cantidad = Cantidad + @CantidadProducto
                WHERE InventarioId = @InventarioFinalId;
            END
        END

        COMMIT TRANSACTION;
        SELECT @OrdenId AS OrdenProduccionId;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO
/****** Object:  StoredProcedure [COMPRA].[SpDeleteLogicoInventario]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ============================================================
-- 6. Crear SpDeleteLogicoInventario (pasa a AGOTADO)
-- ============================================================
CREATE PROCEDURE [COMPRA].[SpDeleteLogicoInventario]
    @InventarioId INT
AS
BEGIN
    DECLARE @EstadoAgotado INT = (
        SELECT EstadoId FROM GLOBAL.ESTADO 
        WHERE Estado = 'AGOTADO' 
          AND EntidadId = (SELECT EntidadId FROM GLOBAL.ENTIDAD WHERE Entidad = 'INVENTARIO')
    );

    IF EXISTS(SELECT * FROM COMPRA.INVENTARIO WHERE InventarioId = @InventarioId)
        UPDATE COMPRA.INVENTARIO SET EstadoId = @EstadoAgotado WHERE InventarioId = @InventarioId;
    ELSE
        RAISERROR('El producto no existe en el inventario.', 16, 1);
END
GO
/****** Object:  StoredProcedure [COMPRA].[SpInsertCompra]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--###################################################################################################################

-- SP's para COMPRA.COMPRA
-- 1. Insersion de registro de compra
CREATE PROCEDURE [COMPRA].[SpInsertCompra]
    @Fecha DATE,
    @NoDocumento VARCHAR(10), 
    @ProveedorId INT,
    @Total DECIMAL(10,2),
    @EstadoId INT
AS
BEGIN
    IF EXISTS(SELECT * FROM COMPRA.COMPRA WHERE NoDocumento = @NoDocumento)
        PRINT('Mensaje: El número de documento ya existe en la BD.');
    ELSE IF @Fecha < CAST(GETDATE() AS DATE)
        PRINT('Mensaje: La fecha no puede ser anterior a la fecha actual.');
    ELSE IF @Total <= 0.00
        PRINT('Mensaje: El total debe ser mayor a $0.00.');
    ELSE
        INSERT INTO COMPRA.COMPRA(Fecha, NoDocumento, ProveedorId, Total, EstadoId)
        VALUES (@Fecha, @NoDocumento, @ProveedorId, @Total, @EstadoId);
END
GO
/****** Object:  StoredProcedure [COMPRA].[SpInsertDetCompra]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--EXEC COMPRA.SpUpdateInventario 1,'Masa de maíz','Libras',30.00,4.00,1,1; -- Ejecucion del sp para comprobar funcionalidad
--GO

----------------------------------------------------------------------------------------

-- SP's para COMPRA.DET_COMPRA
-- 1. Insersion de detalles compra

CREATE PROC [COMPRA].[SpInsertDetCompra]
    @CompraId INT, @InventarioId INT,
    @Cantidad FLOAT, @PrecioCompra DECIMAL(10,2)
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM COMPRA.COMPRA WHERE CompraId = @CompraId)
        PRINT('Mensaje: La compra no ha sido encontrada en la BD.');
    ELSE IF NOT EXISTS(SELECT * FROM COMPRA.INVENTARIO WHERE InventarioId = @InventarioId)
        PRINT('Mensaje: El producto no ha sido encontrado en el inventario.');
    ELSE IF @Cantidad <= 0.00
        PRINT('Mensaje: La cantidad debe ser mayor a 0.');
    ELSE IF @PrecioCompra <= 0.00
        PRINT('Mensaje: El precio de compra debe ser mayor a $0.00.');
    ELSE
        INSERT INTO COMPRA.DET_COMPRA(CompraId, InventarioId, Cantidad, PrecioCompra, TotalDetalleCompra)
        VALUES (@CompraId, @InventarioId, @Cantidad, @PrecioCompra, @Cantidad * @PrecioCompra);
END
GO
/****** Object:  StoredProcedure [COMPRA].[SpInsertInventario]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [COMPRA].[SpInsertInventario]
    @NombreProducto VARCHAR(100),
    @UnidadDeMedida VARCHAR(20),
    @Cantidad FLOAT,
    @PrecioCosto DECIMAL(10,2),
    @TipoInventarioId INT,
    @UsuarioRegistroId INT,
    @EstadoId INT
AS
BEGIN
    IF EXISTS(SELECT * FROM COMPRA.INVENTARIO WHERE NombreProducto = @NombreProducto)
        RAISERROR('El producto ya existe en el inventario.', 16, 1);
    ELSE IF @Cantidad <= 0
        RAISERROR('La cantidad debe ser mayor a 0.', 16, 1);
    ELSE IF @PrecioCosto <= 0.00
        RAISERROR('El precio costo debe ser mayor a $0.00.', 16, 1);
    ELSE
        INSERT INTO COMPRA.INVENTARIO(NombreProducto, UnidadDeMedida, Cantidad, PrecioCosto, TipoInventarioId, UsuarioRegistroId, EstadoId)
        VALUES (@NombreProducto, @UnidadDeMedida, @Cantidad, @PrecioCosto, @TipoInventarioId, @UsuarioRegistroId, @EstadoId);
END
GO
/****** Object:  StoredProcedure [COMPRA].[SpInsertProveedor]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--###################################################################################################################
-- SP's para COMPRA.PROVEEDOR
-- 1. Insersion de Proveedor
CREATE PROC [COMPRA].[SpInsertProveedor]
	@nombre varchar(50),
    @direccion varchar(100),
    @telefono varchar(9),
	@noRegistro varchar(8),
    @NIT varchar(16),
    @estado int
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM COMPRA.PROVEEDOR WHERE Telefono = @telefono OR NoRegistro = @noRegistro OR NIT = @NIT)
		INSERT INTO COMPRA.PROVEEDOR (Nombre,Direccion,Telefono,NoRegistro,NIT,EstadoId)
		VALUES (@nombre,@direccion,@telefono,@noRegistro,@NIT,@estado);
	ELSE
		PRINT('Mensaje: Los datos ingresados del proveedor ya existen en la BD. (Verifique el Telefono, No. Registro o NIT)');
END
GO
/****** Object:  StoredProcedure [COMPRA].[SpInsertTipoInventario]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- EXEC COMPRA.SpUpdateEstadoCompra 1,5; 

----------------------------------------------------------------------------------------

-- SP's para COMPRA.TIPO_INVENTARIO
-- 1. Insersion de Tipo de Inventario
CREATE PROC [COMPRA].[SpInsertTipoInventario]
    @Tipo varchar(30),
    @Descripcion varchar(100)
AS
BEGIN
    IF NOT EXISTS (SELECT * FROM COMPRA.TIPO_INVENTARIO WHERE Tipo = @Tipo) 
        INSERT INTO COMPRA.TIPO_INVENTARIO (Tipo,Descripcion) VALUES
        (@Tipo,@Descripcion)
    ELSE 
        PRINT ('Mensaje: El Tipo de Inventario ya existe en la BD.');
END
GO
/****** Object:  StoredProcedure [COMPRA].[SpRegistrarCompraCompleta]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [COMPRA].[SpRegistrarCompraCompleta]
    @Fecha DATE,
    @NoDocumento VARCHAR(10),
    @ProveedorId INT,
    @UsuarioRegistroId INT,
    @Detalle COMPRA.DetalleCompraType READONLY
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Calcular total del detalle
        DECLARE @Total DECIMAL(10,2);
        SELECT @Total = SUM(Cantidad * PrecioCompra) FROM @Detalle;

        -- Insertar encabezado con el total ya calculado
        DECLARE @CompraId INT;
        INSERT INTO COMPRA.COMPRA(Fecha, NoDocumento, ProveedorId, Total, EstadoId)
        VALUES (@Fecha, @NoDocumento, @ProveedorId, @Total, 
                (SELECT EstadoId FROM GLOBAL.ESTADO WHERE Estado = 'REGISTRADA' 
                 AND EntidadId = (SELECT EntidadId FROM GLOBAL.ENTIDAD WHERE Entidad = 'COMPRA')));
        SET @CompraId = SCOPE_IDENTITY();

        -- Insertar detalles
        INSERT INTO COMPRA.DET_COMPRA(CompraId, InventarioId, Cantidad, PrecioCompra, TotalDetalleCompra)
        SELECT @CompraId, InventarioId, Cantidad, PrecioCompra, Cantidad * PrecioCompra
        FROM @Detalle;

        -- Actualizar stock del inventario
        UPDATE i
        SET i.Cantidad = i.Cantidad + d.Cantidad
        FROM COMPRA.INVENTARIO i
        INNER JOIN @Detalle d ON i.InventarioId = d.InventarioId;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO
/****** Object:  StoredProcedure [COMPRA].[SpSelectAllCompras]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DECLARE @Fecha DATE = GETDATE();
--EXEC COMPRA.SpInsertCompra @Fecha,'FAC-001',1,250.00,1; -- ejecucion del sp para comprobar funcionalidad (manejamos siempre la fecha actual para evitar colocar fechas anteriores)

-- 2. SP de Select All en Compras
CREATE PROC [COMPRA].[SpSelectAllCompras]
AS
BEGIN
	SELECT a.CompraId as 'Codigo', a.Fecha,a.NoDocumento,('Cod:' + cast(a.ProveedorId as varchar) +' - ' + b.Nombre) as 'Proveedor',
    a.Total,c.Estado
	FROM COMPRA.COMPRA a, COMPRA.PROVEEDOR b, GLOBAL.ESTADO c
	WHERE a.ProveedorId = b.ProveedorId AND a.EstadoId = c.EstadoId ORDER BY a.Fecha DESC;
END
GO
/****** Object:  StoredProcedure [COMPRA].[SpSelectAllDetCompra]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--EXEC COMPRA.SpInsertDetCompra 1,1,10.00,3.75; 

-- 2. Select All de detalles de compra

CREATE PROC [COMPRA].[SpSelectAllDetCompra]
AS
BEGIN
    SELECT a.DetalleCompraId AS 'Codigo', 
    ('Cod:' + CAST(a.CompraId AS VARCHAR) + ' - ' + b.NoDocumento) AS 'Compra',
    ('Cod:' + CAST(a.InventarioId AS VARCHAR) + ' - ' + c.NombreProducto) AS 'Producto',
    a.Cantidad, a.PrecioCompra AS 'Precio Compra',
    a.TotalDetalleCompra AS 'Total Detalle'
    FROM COMPRA.DET_COMPRA a, COMPRA.COMPRA b, COMPRA.INVENTARIO c
    WHERE a.CompraId = b.CompraId AND a.InventarioId = c.InventarioId
    ORDER BY a.DetalleCompraId ASC;
END
GO
/****** Object:  StoredProcedure [COMPRA].[SpSelectAllInventario]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [COMPRA].[SpSelectAllInventario]
AS
BEGIN
    SELECT a.InventarioId AS 'Codigo',
           a.NombreProducto AS 'Producto',
           a.UnidadDeMedida AS 'Unidad de Medida',
           a.Cantidad,
           a.PrecioCosto AS 'Precio Costo',
           b.Tipo AS 'Tipo Inventario',
           a.EstadoId,
           c.Estado AS EstadoNombre
    FROM COMPRA.INVENTARIO a
    INNER JOIN COMPRA.TIPO_INVENTARIO b ON a.TipoInventarioId = b.TipoInventarioId
    INNER JOIN GLOBAL.ESTADO c ON a.EstadoId = c.EstadoId
    ORDER BY a.Cantidad ASC; -- Menor stock primero
END
GO
/****** Object:  StoredProcedure [COMPRA].[SpSelectAllProveedores]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--EXEC COMPRA.SpInsertProveedor 'Distribuidora La Cosecha','Colonia Las Flores, Sonsonate','7894-6123','R0012345','1234-567890-101-2',1;

-- 2. Select all de proveedores
CREATE PROC [COMPRA].[SpSelectAllProveedores]
AS
BEGIN
	SELECT a.ProveedorId as 'Codigo', a.Nombre,a.Direccion,a.Telefono,a.NoRegistro as 'No. Registro',
	a.NIT,b.Estado
	FROM COMPRA.PROVEEDOR a, GLOBAL.ESTADO b
	WHERE a.EstadoId = b.EstadoId ORDER BY Nombre ASC;
END
GO
/****** Object:  StoredProcedure [COMPRA].[SpSelectAllTipoInventario]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--EXEC COMPRA.SpInsertTipoInventario 'PRUEBA2','Tests sp - 2';

-- 2. Select All para visualizar lo tipos de inventarios
CREATE PROC [COMPRA].[SpSelectAllTipoInventario]
AS
BEGIN
    SELECT TipoInventarioId as 'Codigo', Tipo, Descripcion
    FROM COMPRA.TIPO_INVENTARIO;
END
GO
/****** Object:  StoredProcedure [COMPRA].[SpSelectCompraNDoc]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- EXEC COMPRA.SpSelectAllCompras; 

-- 3. SP para busqueda por No. Documento
CREATE PROC [COMPRA].[SpSelectCompraNDoc]
    @Buscar VARCHAR(10)
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM COMPRA.COMPRA WHERE NoDocumento LIKE '%' + @Buscar + '%')
        PRINT('Mensaje: El numero de documento no ha sido encontrado en la BD.');
    ELSE
        SELECT a.CompraId as 'Codigo', a.Fecha, a.NoDocumento,
        ('Cod:' + CAST(a.ProveedorId AS VARCHAR) + ' - ' + b.Nombre) as 'Proveedor',
        a.Total, c.Estado
        FROM COMPRA.COMPRA a, COMPRA.PROVEEDOR b, GLOBAL.ESTADO c
        WHERE a.ProveedorId = b.ProveedorId AND a.EstadoId = c.EstadoId
        AND a.NoDocumento LIKE '%' + @Buscar + '%';
END
GO
/****** Object:  StoredProcedure [COMPRA].[SpSelectDetCompraNDoc]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--EXEC COMPRA.SpSelectAllDetCompra; 

-- 3. Select de busqueda de detalles de compra de una compra en especifico por No. Documento
CREATE PROC [COMPRA].[SpSelectDetCompraNDoc]
    @Buscar VARCHAR(10)
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM COMPRA.COMPRA WHERE NoDocumento LIKE '%' + @Buscar + '%')
        PRINT('Mensaje: El número de documento no ha sido encontrado en la BD.');
    ELSE
        SELECT a.DetalleCompraId AS 'Codigo',
        ('Cod:' + CAST(a.CompraId AS VARCHAR) + ' - ' + b.NoDocumento) AS 'Compra',
        ('Cod:' + CAST(a.InventarioId AS VARCHAR) + ' - ' + c.NombreProducto) AS 'Producto',
        a.Cantidad, a.PrecioCompra AS 'Precio Compra',
        a.TotalDetalleCompra AS 'Total Detalle'
        FROM COMPRA.DET_COMPRA a, COMPRA.COMPRA b, COMPRA.INVENTARIO c
        WHERE a.CompraId = b.CompraId AND a.InventarioId = c.InventarioId
        AND b.NoDocumento LIKE '%' + @Buscar + '%';
END
GO
/****** Object:  StoredProcedure [COMPRA].[SpSelectInventarioNombre]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [COMPRA].[SpSelectInventarioNombre]
    @Buscar VARCHAR(100)
AS
BEGIN
    SELECT a.InventarioId AS 'Codigo',
           a.NombreProducto AS 'Producto',
           a.UnidadDeMedida AS 'Unidad de Medida',
           a.Cantidad,
           a.PrecioCosto AS 'Precio Costo',
           b.Tipo AS 'Tipo Inventario',
           a.EstadoId,
           c.Estado AS EstadoNombre
    FROM COMPRA.INVENTARIO a
    INNER JOIN COMPRA.TIPO_INVENTARIO b ON a.TipoInventarioId = b.TipoInventarioId
    INNER JOIN GLOBAL.ESTADO c ON a.EstadoId = c.EstadoId
    WHERE a.NombreProducto LIKE '%' + @Buscar + '%'
    ORDER BY a.Cantidad ASC; -- Menor stock primero
END
GO
/****** Object:  StoredProcedure [COMPRA].[SpUpdateEstadoCompra]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- EXEC COMPRA.SpSelectCompraNDoc '01';

-- 4. Sp para actualizar una Compra (para cuando se cambie el estado de la compra)
CREATE PROC [COMPRA].[SpUpdateEstadoCompra]
    @CompraId INT,
    @EstadoId INT
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM COMPRA.COMPRA WHERE CompraId = @CompraId)
        PRINT('Mensaje: La compra no ha sido encontrada en la BD.');
    ELSE IF NOT EXISTS(SELECT * FROM GLOBAL.ESTADO WHERE EstadoId = @EstadoId)
        PRINT('Mensaje: El estado ingresado no existe en la BD.');
    ELSE
        UPDATE COMPRA.COMPRA
        SET EstadoId = @EstadoId
        WHERE CompraId = @CompraId
END
GO
/****** Object:  StoredProcedure [COMPRA].[SpUpdateInventario]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [COMPRA].[SpUpdateInventario]
    @InventarioId INT,
    @NombreProducto VARCHAR(100),
    @UnidadDeMedida VARCHAR(20),
    @Cantidad FLOAT,
    @PrecioCosto DECIMAL(10,2),
    @TipoInventarioId INT,
    @UsuarioModificacionId INT,
    @EstadoId INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS(SELECT 1 FROM COMPRA.INVENTARIO WHERE InventarioId = @InventarioId)
    BEGIN
        RAISERROR('El producto no ha sido encontrado en el inventario.', 16, 1);
        RETURN;
    END

    IF EXISTS(SELECT 1 FROM COMPRA.INVENTARIO WHERE NombreProducto = @NombreProducto AND InventarioId <> @InventarioId)
    BEGIN
        RAISERROR('El nombre del producto ya existe en otro registro.', 16, 1);
        RETURN;
    END

    IF @PrecioCosto <= 0.00
    BEGIN
        RAISERROR('El precio costo debe ser mayor a $0.00.', 16, 1);
        RETURN;
    END

    -- Validación de stock automático
    DECLARE @CantidadActual FLOAT;
    SELECT @CantidadActual = Cantidad FROM COMPRA.INVENTARIO WHERE InventarioId = @InventarioId;

    IF @Cantidad <> @CantidadActual
    BEGIN
        RAISERROR('El stock se maneja automáticamente. No puede modificarse manualmente.', 16, 1);
        RETURN;
    END

    -- Actualización incluyendo UsuarioModificacionId
    UPDATE COMPRA.INVENTARIO
    SET NombreProducto = @NombreProducto,
        UnidadDeMedida = @UnidadDeMedida,
        Cantidad = @Cantidad,
        PrecioCosto = @PrecioCosto,
        TipoInventarioId = @TipoInventarioId,
        UsuarioModificacionId = @UsuarioModificacionId,  -- ¡ESTA LÍNEA ES CLAVE!
        EstadoId = @EstadoId
    WHERE InventarioId = @InventarioId;
END
GO
/****** Object:  StoredProcedure [COMPRA].[SpUpdateProveedor]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- 3. SP de acutalizacion de proveedor (no permite ingresar datos que ya existen en otros proveedores)
CREATE PROC [COMPRA].[SpUpdateProveedor]
    @ProveedorId INT,
    @Nombre VARCHAR(50),
    @Direccion VARCHAR(100),
    @Telefono VARCHAR(9),
    @NoRegistro VARCHAR(8),
    @NIT VARCHAR(16),
    @EstadoId INT
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM COMPRA.PROVEEDOR 
                  WHERE (Telefono = @Telefono OR NoRegistro = @NoRegistro OR NIT = @NIT)
                  AND ProveedorId <> @ProveedorId)
        UPDATE COMPRA.PROVEEDOR
        SET Nombre = @Nombre,
            Direccion = @Direccion,
            Telefono = @Telefono,
            NoRegistro = @NoRegistro,
            NIT = @NIT,
            EstadoId = @EstadoId
        WHERE ProveedorId = @ProveedorId
    ELSE
        PRINT('Mensaje: No es posible modificar, ya existe un proveedor con ese Teléfono, No. Registro o NIT.');
END
GO
/****** Object:  StoredProcedure [COMPRA].[SpUpdateTipoInventario]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--EXEC COMPRA.SpSelectAllTipoInventario;
    
-- 3. SP para actualizar tipo de inventario
CREATE PROC [COMPRA].[SpUpdateTipoInventario]
    @TipoInventarioId int, @Tipo varchar(30), @Descripcion varchar(100)
AS
BEGIN
    IF EXISTS (SELECT * FROM COMPRA.TIPO_INVENTARIO WHERE Tipo = @Tipo AND TipoInventarioId <> @TipoInventarioId)
        PRINT ('Mensaje: El Tipo de Inventario ingresado ya existe en la BD.');
    ELSE IF EXISTS (SELECT * FROM COMPRA.TIPO_INVENTARIO WHERE Descripcion = @Descripcion AND TipoInventarioId <> @TipoInventarioId)
        PRINT ('Mensaje: La descripcion agregada ya existe en otro Tipo de Inventario dentro de la BD. Confirme los datos ingredsados.');
    ELSE 
        UPDATE COMPRA.TIPO_INVENTARIO
        SET Tipo = @Tipo,
            Descripcion = @Descripcion
        WHERE TipoInventarioId = @TipoInventarioId
END
GO
/****** Object:  StoredProcedure [dbo].[SpSelectEmpleado]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Consultar uno o varios empleados a travez de un parametro
CREATE PROCEDURE [dbo].[SpSelectEmpleado] 
    @Buscar VARCHAR(50)
AS
BEGIN
    SELECT a.EmpleadoId AS 'Codigo', a.Nombre + ', ' + a.Apellido AS 'Nombre completo', a.Telefono, a.Email,
    a.Direccion, a.FechaContratacion, b.Cargo, c.Estado
    FROM RRHH.EMPLEADO a, RRHH.CARGO b, GLOBAL.ESTADO c
    WHERE (a.CargoId = b.Cargo AND a.EstadoId = c.EstadoId) AND (a.EmpleadoId = CAST(@Buscar AS INT) OR 
    a.Nombre LIKE CONCAT('%',@Buscar,'%') OR a.Apellido LIKE CONCAT('%',@Buscar,'%') OR
    a.Telefono LIKE CONCAT('%',@Buscar,'%') OR a.Email LIKE CONCAT('%',@Buscar,'%'))
END
GO
/****** Object:  StoredProcedure [DELIVERY].[SpDeleteLogicoDireccion]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Crear SpDeleteLogicoDireccion
CREATE PROCEDURE [DELIVERY].[SpDeleteLogicoDireccion]
    @DireccionId INT
AS
BEGIN
    DECLARE @EstadoInactivo INT = (
        SELECT EstadoId FROM GLOBAL.ESTADO 
        WHERE Estado = 'INACTIVO' 
          AND EntidadId = (SELECT EntidadId FROM GLOBAL.ENTIDAD WHERE Entidad = 'DIRECCION')
    );

    IF EXISTS(SELECT * FROM DELIVERY.DIRECCION WHERE DireccionId = @DireccionId)
        UPDATE DELIVERY.DIRECCION
        SET EstadoId = @EstadoInactivo
        WHERE DireccionId = @DireccionId;
    ELSE
        PRINT('Mensaje: La dirección no existe.');
END
GO
/****** Object:  StoredProcedure [DELIVERY].[SpDeleteLogicoEnvio]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 5. Cambiar estado de un envio (delete logico / cambio de estado)
CREATE PROCEDURE [DELIVERY].[SpDeleteLogicoEnvio]
    @EnvioId INT,
    @EstadoId INT
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM DELIVERY.ENVIO WHERE EnvioId = @EnvioId)
        PRINT('Mensaje: El envio indicado no existe en la BD.');
    ELSE
        UPDATE DELIVERY.ENVIO
        SET EstadoId = @EstadoId
        WHERE EnvioId = @EnvioId;
END
GO
/****** Object:  StoredProcedure [DELIVERY].[SpDeleteLogicoRepartidor]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 5. Desactivar / Activar un repartidor (delete logico)
CREATE PROCEDURE [DELIVERY].[SpDeleteLogicoRepartidor]
    @RepartidorId INT,
    @EstadoId INT
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM DELIVERY.REPARTIDOR WHERE RepartidorId = @RepartidorId)
        PRINT('Mensaje: El repartidor indicado no existe en la BD.');
    ELSE
        UPDATE DELIVERY.REPARTIDOR
        SET EstadoId = @EstadoId
        WHERE RepartidorId = @RepartidorId;
END
GO
/****** Object:  StoredProcedure [DELIVERY].[SpInsertDireccion]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Modificar SpInsertDireccion para incluir EstadoId
CREATE PROCEDURE [DELIVERY].[SpInsertDireccion]
    @MunicipioId INT,
    @ColoniBarrio VARCHAR(100),
    @NoCasa VARCHAR(4) = NULL,
    @PuntoReferencia VARCHAR(50) = NULL,
    @CoordenadasMaps VARCHAR(50) = NULL,
    @EstadoId INT
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM DELIVERY.MUNICIPIO WHERE MunicipioId = @MunicipioId)
        PRINT('Mensaje: El municipio indicado no existe en la BD.');
    ELSE
        INSERT INTO DELIVERY.DIRECCION(MunicipioId, ColoniBarrio, NoCasa, PuntoReferencia, CoordenadasMaps, EstadoId)
        VALUES (@MunicipioId, @ColoniBarrio, @NoCasa, @PuntoReferencia, @CoordenadasMaps, @EstadoId);
END
GO
/****** Object:  StoredProcedure [DELIVERY].[SpInsertEnvio]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--###################################################################################################################
-- Sp para DELIVERY.ENVIO

-- 1. Insertar un envio
CREATE PROCEDURE [DELIVERY].[SpInsertEnvio]
    @OrdenId INT,
    @RepartidorId INT,
    @DireccionId INT,
    @Tarifa DECIMAL(10,2),
    @EstadoId INT
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM VENTA.ORDEN WHERE OrdenId = @OrdenId)
        PRINT('Mensaje: La orden indicada no existe en la BD.');
    ELSE IF EXISTS(SELECT * FROM DELIVERY.ENVIO WHERE OrdenId = @OrdenId)
        PRINT('Mensaje: La orden ya tiene un envio registrado.');
    ELSE IF NOT EXISTS(SELECT * FROM DELIVERY.REPARTIDOR WHERE RepartidorId = @RepartidorId)
        PRINT('Mensaje: El repartidor indicado no existe en la BD.');
    ELSE IF NOT EXISTS(SELECT * FROM DELIVERY.DIRECCION WHERE DireccionId = @DireccionId)
        PRINT('Mensaje: La direccion indicada no existe en la BD.');
    ELSE IF @Tarifa <= 0
        PRINT('Mensaje: La tarifa debe ser mayor a cero.');
    ELSE
        INSERT INTO DELIVERY.ENVIO(OrdenId, RepartidorId, DireccionId, Tarifa, EstadoId)
        VALUES (@OrdenId, @RepartidorId, @DireccionId, @Tarifa, @EstadoId);
END    
GO
/****** Object:  StoredProcedure [DELIVERY].[SpInsertMunicipio]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--##############################################################
-- SP's de DELIVERY
---SPs Antonio----------------------------------------------
-- Sp para DELIVERY.MUNICIPIO

-- 1. Insertar un municipio
CREATE PROCEDURE [DELIVERY].[SpInsertMunicipio]
    @Nombre VARCHAR(50)
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM DELIVERY.MUNICIPIO WHERE UPPER(Nombre) = UPPER(@Nombre))
        INSERT INTO DELIVERY.MUNICIPIO(Nombre)
        VALUES (@Nombre);
    ELSE
        PRINT('Mensaje: El municipio ingresado ya existe en la BD.');
END
GO
/****** Object:  StoredProcedure [DELIVERY].[SpInsertRepartidor]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DELIVERY].[SpInsertRepartidor]
    @EmpleadoId INT,
    @NoPlacaMoto VARCHAR(7),
    @EstadoId INT
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM RRHH.EMPLEADO WHERE EmpleadoId = @EmpleadoId)
    BEGIN
        RAISERROR('El empleado indicado no existe en la BD.', 16, 1);
        RETURN;
    END

    IF EXISTS(SELECT * FROM DELIVERY.REPARTIDOR WHERE EmpleadoId = @EmpleadoId)
    BEGIN
        RAISERROR('El empleado ya está registrado como repartidor.', 16, 1);
        RETURN;
    END

    IF EXISTS(SELECT * FROM DELIVERY.REPARTIDOR WHERE UPPER(NoPlacaMoto) = UPPER(@NoPlacaMoto))
    BEGIN
        RAISERROR('La placa de moto ingresada ya está registrada.', 16, 1);
        RETURN;
    END

    INSERT INTO DELIVERY.REPARTIDOR(EmpleadoId, NoPlacaMoto, EstadoId)
    VALUES (@EmpleadoId, @NoPlacaMoto, @EstadoId);
END
GO
/****** Object:  StoredProcedure [DELIVERY].[SpSelectAllDireccion]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Modificar SpSelectAllDireccion para incluir EstadoId y EstadoNombre
CREATE PROCEDURE [DELIVERY].[SpSelectAllDireccion]
AS
BEGIN
    SELECT a.DireccionId,
           a.MunicipioId,
           b.Nombre AS Municipio,
           a.ColoniBarrio AS 'Colonia/Barrio',
           a.NoCasa AS 'No. Casa',
           a.PuntoReferencia AS 'Punto de Referencia',
           a.CoordenadasMaps AS 'Coordenadas',
           a.EstadoId,
           c.Estado AS EstadoNombre
    FROM DELIVERY.DIRECCION a
    INNER JOIN DELIVERY.MUNICIPIO b ON a.MunicipioId = b.MunicipioId
    INNER JOIN GLOBAL.ESTADO c ON a.EstadoId = c.EstadoId
    ORDER BY b.Nombre ASC;
END
GO
/****** Object:  StoredProcedure [DELIVERY].[SpSelectAllEnvio]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 2. Consultar todos los envios
CREATE PROCEDURE [DELIVERY].[SpSelectAllEnvio]
AS
BEGIN
    SELECT a.EnvioId AS 'Codigo',
           ('Cod:' + CAST(a.OrdenId AS VARCHAR)) AS 'Orden',
           b.Nombre + ', ' + b.Apellido AS 'Repartidor',
           c.NoPlacaMoto AS 'Placa',
           d.Nombre AS 'Municipio',
           e.ColoniBarrio AS 'Colonia/Barrio',
           a.Tarifa,
           f.Estado
    FROM DELIVERY.ENVIO a, RRHH.EMPLEADO b, DELIVERY.REPARTIDOR c,
         DELIVERY.MUNICIPIO d, DELIVERY.DIRECCION e, GLOBAL.ESTADO f
    WHERE a.RepartidorId = c.RepartidorId
      AND c.EmpleadoId   = b.EmpleadoId
      AND a.DireccionId  = e.DireccionId
      AND e.MunicipioId  = d.MunicipioId
      AND a.EstadoId     = f.EstadoId
    ORDER BY a.EnvioId DESC;
END
GO
/****** Object:  StoredProcedure [DELIVERY].[SpSelectAllMunicipio]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Verificamos el SP

--EXEC DELIVERY.SpInsertMunicipio @Nombre = 'Izalco';

--Visualizacion
--SELECT * FROM DELIVERY.MUNICIPIO;

--Reisamos posibles duplicaciones
--EXEC DELIVERY.SpInsertMunicipio @Nombre = 'IZALCO';

-- 2. Consultar todos los municipios
CREATE PROCEDURE [DELIVERY].[SpSelectAllMunicipio]
AS
BEGIN
    SELECT MunicipioId AS 'Codigo', Nombre AS 'Municipio'
    FROM DELIVERY.MUNICIPIO
    ORDER BY Nombre ASC;
END
GO
/****** Object:  StoredProcedure [DELIVERY].[SpSelectAllRepartidor]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SpSelectAllRepartidor modificado
CREATE PROCEDURE [DELIVERY].[SpSelectAllRepartidor]
AS
BEGIN
    SELECT a.RepartidorId,
           a.EmpleadoId,
           b.Nombre + ', ' + b.Apellido AS EmpleadoNombre,
           b.Telefono,
           a.NoPlacaMoto,
           a.EstadoId,
           c.Estado AS EstadoNombre
    FROM DELIVERY.REPARTIDOR a
    INNER JOIN RRHH.EMPLEADO b ON a.EmpleadoId = b.EmpleadoId
    INNER JOIN GLOBAL.ESTADO c ON a.EstadoId = c.EstadoId
    ORDER BY b.Apellido ASC;
END
GO
/****** Object:  StoredProcedure [DELIVERY].[SpSelectDireccion]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DELIVERY].[SpSelectDireccion]
    @Buscar VARCHAR(100)
AS
BEGIN
    SELECT a.DireccionId,
           a.MunicipioId,
           b.Nombre AS Municipio,
           a.ColoniBarrio AS 'Colonia/Barrio',
           a.NoCasa AS 'No. Casa',
           a.PuntoReferencia AS 'Punto de Referencia',
           a.CoordenadasMaps AS 'Coordenadas',
           a.EstadoId,
           c.Estado AS EstadoNombre
    FROM DELIVERY.DIRECCION a
    INNER JOIN DELIVERY.MUNICIPIO b ON a.MunicipioId = b.MunicipioId
    INNER JOIN GLOBAL.ESTADO c ON a.EstadoId = c.EstadoId
    WHERE b.Nombre LIKE '%' + @Buscar + '%'
       OR a.ColoniBarrio LIKE '%' + @Buscar + '%'
       OR a.PuntoReferencia LIKE '%' + @Buscar + '%'
       OR a.DireccionId = TRY_CAST(@Buscar AS INT)
    ORDER BY b.Nombre ASC;
END
GO
/****** Object:  StoredProcedure [DELIVERY].[SpSelectDireccionesActivas]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 3. Reemplazar SpSelectDireccionesActivas (nuevo SP)
CREATE PROCEDURE [DELIVERY].[SpSelectDireccionesActivas]
AS
BEGIN
    SELECT a.DireccionId,
           b.Nombre + ', ' + a.ColoniBarrio + 
           ISNULL(', ' + a.PuntoReferencia, '') AS DireccionCompleta,
           a.FechaModificacion
    FROM DELIVERY.DIRECCION a
    INNER JOIN DELIVERY.MUNICIPIO b ON a.MunicipioId = b.MunicipioId
    INNER JOIN GLOBAL.ESTADO c ON a.EstadoId = c.EstadoId
    WHERE c.Estado = 'ACTIVO'
      AND c.EntidadId = (SELECT EntidadId FROM GLOBAL.ENTIDAD WHERE Entidad = 'DIRECCION')
    ORDER BY a.FechaModificacion DESC;
END
GO
/****** Object:  StoredProcedure [DELIVERY].[SpSelectEnvio]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 3. Buscar envios por repartidor o municipio
CREATE PROCEDURE [DELIVERY].[SpSelectEnvio]
    @Buscar VARCHAR(50)
AS
BEGIN
    IF NOT EXISTS(
        SELECT * FROM DELIVERY.ENVIO a, RRHH.EMPLEADO b, DELIVERY.REPARTIDOR c,
                      DELIVERY.MUNICIPIO d, DELIVERY.DIRECCION e, GLOBAL.ESTADO f
        WHERE a.RepartidorId = c.RepartidorId AND c.EmpleadoId = b.EmpleadoId
          AND a.DireccionId = e.DireccionId AND e.MunicipioId = d.MunicipioId
          AND a.EstadoId = f.EstadoId AND
        (b.Nombre LIKE '%' + @Buscar + '%' OR b.Apellido LIKE '%' + @Buscar + '%' OR
         d.Nombre LIKE '%' + @Buscar + '%' OR c.NoPlacaMoto LIKE '%' + @Buscar + '%')
    )
        PRINT('Mensaje: No se encontraron envios con el criterio ingresado.');
    ELSE
        SELECT a.EnvioId AS 'Codigo',
               ('Cod:' + CAST(a.OrdenId AS VARCHAR)) AS 'Orden',
               b.Nombre + ', ' + b.Apellido AS 'Repartidor',
               c.NoPlacaMoto AS 'Placa',
               d.Nombre AS 'Municipio',
               e.ColoniBarrio AS 'Colonia/Barrio',
               a.Tarifa,
               f.Estado
        FROM DELIVERY.ENVIO a, RRHH.EMPLEADO b, DELIVERY.REPARTIDOR c,
             DELIVERY.MUNICIPIO d, DELIVERY.DIRECCION e, GLOBAL.ESTADO f
        WHERE a.RepartidorId = c.RepartidorId AND c.EmpleadoId = b.EmpleadoId
          AND a.DireccionId = e.DireccionId AND e.MunicipioId = d.MunicipioId
          AND a.EstadoId = f.EstadoId AND
        (b.Nombre LIKE '%' + @Buscar + '%' OR b.Apellido LIKE '%' + @Buscar + '%' OR
         d.Nombre LIKE '%' + @Buscar + '%' OR c.NoPlacaMoto LIKE '%' + @Buscar + '%')
        ORDER BY a.EnvioId DESC;
END
GO
/****** Object:  StoredProcedure [DELIVERY].[SpSelectRepartidor]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SpSelectRepartidor modificado
CREATE PROCEDURE [DELIVERY].[SpSelectRepartidor]
    @Buscar VARCHAR(50)
AS
BEGIN
    SELECT a.RepartidorId,
           a.EmpleadoId,
           b.Nombre + ', ' + b.Apellido AS EmpleadoNombre,
           b.Telefono,
           a.NoPlacaMoto,
           a.EstadoId,
           c.Estado AS EstadoNombre
    FROM DELIVERY.REPARTIDOR a
    INNER JOIN RRHH.EMPLEADO b ON a.EmpleadoId = b.EmpleadoId
    INNER JOIN GLOBAL.ESTADO c ON a.EstadoId = c.EstadoId
    WHERE (b.Nombre LIKE '%' + @Buscar + '%'
           OR b.Apellido LIKE '%' + @Buscar + '%'
           OR a.NoPlacaMoto LIKE '%' + @Buscar + '%'
           OR b.Telefono LIKE '%' + @Buscar + '%')
    ORDER BY b.Apellido ASC;
END
GO
/****** Object:  StoredProcedure [DELIVERY].[SpSelectRepartidoresDisponibles]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ============================================================
-- SP para obtener repartidores disponibles
-- ============================================================
CREATE PROCEDURE [DELIVERY].[SpSelectRepartidoresDisponibles]
AS
BEGIN
    SELECT r.RepartidorId,
           e.Nombre + ' ' + e.Apellido AS NombreCompleto,
           e.Telefono,
           r.NoPlacaMoto
    FROM DELIVERY.REPARTIDOR r
    INNER JOIN RRHH.EMPLEADO e ON r.EmpleadoId = e.EmpleadoId
    INNER JOIN GLOBAL.ESTADO es ON r.EstadoId = es.EstadoId
    WHERE UPPER(es.Estado) = 'DISPONIBLE';
END
GO
/****** Object:  StoredProcedure [DELIVERY].[SpUpdateDireccion]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 2. Modificar SpUpdateDireccion para que actualice la fecha
CREATE PROCEDURE [DELIVERY].[SpUpdateDireccion]
    @DireccionId INT,
    @MunicipioId INT,
    @ColoniBarrio VARCHAR(100),
    @NoCasa VARCHAR(4) = NULL,
    @PuntoReferencia VARCHAR(50) = NULL,
    @CoordenadasMaps VARCHAR(50) = NULL,
    @EstadoId INT
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM DELIVERY.DIRECCION WHERE DireccionId = @DireccionId)
        PRINT('Mensaje: La direccion indicada no existe en la BD.');
    ELSE IF NOT EXISTS(SELECT * FROM DELIVERY.MUNICIPIO WHERE MunicipioId = @MunicipioId)
        PRINT('Mensaje: El municipio indicado no existe en la BD.');
    ELSE
        UPDATE DELIVERY.DIRECCION
        SET MunicipioId      = @MunicipioId,
            ColoniBarrio     = @ColoniBarrio,
            NoCasa           = @NoCasa,
            PuntoReferencia  = @PuntoReferencia,
            CoordenadasMaps  = @CoordenadasMaps,
            EstadoId         = @EstadoId,
            FechaModificacion = GETDATE()
        WHERE DireccionId = @DireccionId;
END
GO
/****** Object:  StoredProcedure [DELIVERY].[SpUpdateEnvio]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 4. Actualizar un envio (reasignar repartidor, direccion o tarifa)
CREATE PROCEDURE [DELIVERY].[SpUpdateEnvio]
    @EnvioId INT,
    @RepartidorId INT,
    @DireccionId INT,
    @Tarifa DECIMAL(10,2),
    @EstadoId INT
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM DELIVERY.ENVIO WHERE EnvioId = @EnvioId)
        PRINT('Mensaje: El envio indicado no existe en la BD.');
    ELSE IF NOT EXISTS(SELECT * FROM DELIVERY.REPARTIDOR WHERE RepartidorId = @RepartidorId)
        PRINT('Mensaje: El repartidor indicado no existe en la BD.');
    ELSE IF NOT EXISTS(SELECT * FROM DELIVERY.DIRECCION WHERE DireccionId = @DireccionId)
        PRINT('Mensaje: La direccion indicada no existe en la BD.');
    ELSE IF @Tarifa <= 0
        PRINT('Mensaje: La tarifa debe ser mayor a cero.');
    ELSE
        UPDATE DELIVERY.ENVIO
        SET RepartidorId = @RepartidorId,
            DireccionId  = @DireccionId,
            Tarifa       = @Tarifa,
            EstadoId     = @EstadoId
        WHERE EnvioId = @EnvioId;
END
GO
/****** Object:  StoredProcedure [DELIVERY].[SpUpdateMunicipio]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Verificamos SP
--EXEC DELIVERY.SpSelectAllMunicipio;

-- 3. Actualizar un municipio
CREATE PROCEDURE [DELIVERY].[SpUpdateMunicipio]
    @MunicipioId INT,
    @Nombre VARCHAR(50)
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM DELIVERY.MUNICIPIO WHERE MunicipioId = @MunicipioId)
        PRINT('Mensaje: El municipio indicado no existe en la BD.');
    ELSE IF EXISTS(SELECT * FROM DELIVERY.MUNICIPIO WHERE UPPER(Nombre) = UPPER(@Nombre) AND MunicipioId <> @MunicipioId)
        PRINT('Mensaje: Ya existe otro municipio con ese nombre, no es posible modificar.');
    ELSE
        UPDATE DELIVERY.MUNICIPIO
        SET Nombre = @Nombre
        WHERE MunicipioId = @MunicipioId;
END
GO
/****** Object:  StoredProcedure [DELIVERY].[SpUpdateRepartidor]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 4. Actualizar un repartidor
CREATE PROCEDURE [DELIVERY].[SpUpdateRepartidor]
    @RepartidorId INT,
    @EmpleadoId INT,
    @NoPlacaMoto VARCHAR(7),
    @EstadoId INT
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM DELIVERY.REPARTIDOR WHERE RepartidorId = @RepartidorId)
        PRINT('Mensaje: El repartidor indicado no existe en la BD.');
    ELSE IF NOT EXISTS(SELECT * FROM RRHH.EMPLEADO WHERE EmpleadoId = @EmpleadoId)
        PRINT('Mensaje: El empleado indicado no existe en la BD.');
    ELSE IF EXISTS(SELECT * FROM DELIVERY.REPARTIDOR WHERE UPPER(NoPlacaMoto) = UPPER(@NoPlacaMoto) AND RepartidorId <> @RepartidorId)
        PRINT('Mensaje: La placa de moto ingresada ya esta registrada en otro repartidor.');
    ELSE
        UPDATE DELIVERY.REPARTIDOR
        SET EmpleadoId  = @EmpleadoId,
            NoPlacaMoto = @NoPlacaMoto,
            EstadoId    = @EstadoId
        WHERE RepartidorId = @RepartidorId;
END
GO
/****** Object:  StoredProcedure [GLOBAL].[SpConsultasDeEstadoPorEntidad]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [GLOBAL].[SpConsultasDeEstadoPorEntidad]
    @Entidad VARCHAR(25)
AS
    SELECT EstadoId FROM GLOBAL.ESTADO
    WHERE EntidadId = (
        SELECT EntidadId FROM GLOBAL.ENTIDAD 
        WHERE UPPER(Entidad) = UPPER(@Entidad))
GO
/****** Object:  StoredProcedure [GLOBAL].[SpInsertEntidad]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--###################################################################################################################
-- Sp para GLOBAL.ENTIDAD
-- Ingresar una entidad (Ninguna entidad debe de repetir su nombre)
CREATE PROCEDURE [GLOBAL].[SpInsertEntidad]
    @Entidad VARCHAR(30)
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM GLOBAL.ENTIDAD WHERE Entidad = @Entidad)
        INSERT INTO GLOBAL.ENTIDAD(Entidad)
        VALUES (@Entidad);
    ELSE
        PRINT('La entidad ya existe dentro de la BD...');
END
GO
/****** Object:  StoredProcedure [GLOBAL].[SpInsertEstado]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--###################################################################################################################

--Sp para GLOBAL.ESTADO
-- -- Ingresar una estado(Ninguna entidad debe de repetir su nombre)
CREATE PROCEDURE [GLOBAL].[SpInsertEstado]
    @Estado VARCHAR(30),
    @Descripcion VARCHAR(100),
    @EntidadId INT
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM GLOBAL.ESTADO WHERE Estado = @Estado AND EntidadId = @EntidadId)
        INSERT INTO GLOBAL.ESTADO(Estado, Descripcion, EntidadId)
        VALUES (@Estado, @Descripcion, @EntidadId);
    ELSE
        PRINT('El estado para esa entidad ya existe...');
END
GO
/****** Object:  StoredProcedure [GLOBAL].[SpSelectAllEntidad]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Seleccion de todas las entidades
CREATE PROCEDURE [GLOBAL].[SpSelectAllEntidad]
AS
BEGIN
    SELECT EntidadId AS 'Id', Entidad FROM GLOBAL.ENTIDAD;
END
GO
/****** Object:  StoredProcedure [GLOBAL].[SpSelectAllEstado]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Seleccion de todas los estados
CREATE PROCEDURE [GLOBAL].[SpSelectAllEstado]
AS
BEGIN
    SELECT EstadoId AS 'Id', Estado, Descripcion, b.Entidad
    FROM GLOBAL.ESTADO a, GLOBAL.ENTIDAD b
    WHERE a.EntidadId = b.EntidadId;
END
GO
/****** Object:  StoredProcedure [GLOBAL].[SpUpdateEntidad]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Actualizacion de una entidad
CREATE PROCEDURE [GLOBAL].[SpUpdateEntidad]
    @EntidadId INT,
    @Entidad VARCHAR(30)
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM GLOBAL.ENTIDAD WHERE Entidad = @Entidad)
            UPDATE GLOBAL.ENTIDAD
            SET Entidad = @Entidad
            WHERE EntidadId = @EntidadId
        ELSE
            PRINT('La entidad ya existe dentro de la BD, no es posible modificar...');
END
GO
/****** Object:  StoredProcedure [GLOBAL].[SpUpdateEstado]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Actualizacion de un estado
CREATE PROCEDURE [GLOBAL].[SpUpdateEstado]
    @EstadoId INT,
    @Estado VARCHAR(30),
    @Descripcion VARCHAR(100) = NULL,
    @EntidadId INT
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM GLOBAL.ESTADO WHERE Estado = @Estado AND EntidadId = @EntidadId)
            UPDATE GLOBAL.ESTADO
            SET Estado = @Estado,
                Descripcion = @Descripcion,
                EntidadId = @EntidadId
            WHERE EstadoId = @EstadoId
        ELSE
            PRINT('El estado para esa entidad ya existe dentro de la BD, no es posible modificar...');
END
GO
/****** Object:  StoredProcedure [RRHH].[SpInsertCargo]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--###################################################################################################################

--Sp para RRHH.CARGO
--Insertar un cargo
CREATE PROCEDURE [RRHH].[SpInsertCargo]
    @Cargo VARCHAR(30)
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM RRHH.CARGO WHERE Cargo = @Cargo)
        INSERT INTO RRHH.CARGO(Cargo)
        VALUES (@Cargo);
    ELSE
        PRINT('El cargo ya existe dentro de la BD...')
END
GO
/****** Object:  StoredProcedure [RRHH].[SpIsertEmpleado]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- SpIsertEmpleado sin validación de teléfono duplicado
CREATE PROCEDURE [RRHH].[SpIsertEmpleado]
    @Nombre VARCHAR(25),
    @Apellido VARCHAR(25),
    @Telefono VARCHAR(15),
    @Email VARCHAR(60),
    @Direccion VARCHAR(100),
    @FechaNac DATE,
    @FechaContratacion DATE,
    @CargoId INT,
    @EstadoId INT,
    @UsuarioRegistroId INT
AS
BEGIN
    -- Solo validamos que el email no se repita (si se proporciona)
    IF EXISTS(SELECT * FROM RRHH.EMPLEADO WHERE Email = @Email AND Email IS NOT NULL)
    BEGIN
        RAISERROR('El empleado no puede ser registrado: Email ya existe.', 16, 1);
        RETURN;
    END

    INSERT INTO RRHH.EMPLEADO(Nombre,Apellido,Telefono,Email,Direccion,FechaNac,FechaContratacion,CargoId,EstadoId,UsuarioRegistroId)
    VALUES (@Nombre,@Apellido,@Telefono,@Email,@Direccion,@FechaNac,@FechaContratacion,@CargoId,@EstadoId,@UsuarioRegistroId);
END
GO
/****** Object:  StoredProcedure [RRHH].[SpSelectAllCargo]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Consultar todos los cargos
CREATE PROCEDURE [RRHH].[SpSelectAllCargo]
AS
BEGIN
    SELECT CargoId AS 'Id', Cargo
    FROM RRHH.CARGO
END
GO
/****** Object:  StoredProcedure [RRHH].[SpSelectAllEmpleado]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [RRHH].[SpSelectAllEmpleado]
AS
BEGIN
    SELECT  a.EmpleadoId,
            a.Nombre,
            a.Apellido,
            a.Telefono,
            a.Email,
            a.Direccion,
            a.FechaNac,
            a.FechaContratacion,
            a.CargoId,
            b.Cargo AS CargoNombre,
            a.EstadoId,
            c.Estado AS EstadoNombre,
            a.UsuarioRegistroId,
            a.UsuarioModificacionId
    FROM RRHH.EMPLEADO a
    INNER JOIN RRHH.CARGO b ON a.CargoId = b.CargoId
    INNER JOIN GLOBAL.ESTADO c ON a.EstadoId = c.EstadoId
    ORDER BY a.Nombre, a.Apellido;
END
GO
/****** Object:  StoredProcedure [RRHH].[SpSelectEmpleado]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [RRHH].[SpSelectEmpleado]
    @Buscar VARCHAR(50)
AS
BEGIN
    SELECT  a.EmpleadoId,
            a.Nombre,
            a.Apellido,
            a.Telefono,
            a.Email,
            a.Direccion,
            a.FechaNac,
            a.FechaContratacion,
            a.CargoId,
            b.Cargo AS CargoNombre,
            a.EstadoId,
            c.Estado AS EstadoNombre,
            a.UsuarioRegistroId,
            a.UsuarioModificacionId
    FROM RRHH.EMPLEADO a
    INNER JOIN RRHH.CARGO b ON a.CargoId = b.CargoId
    INNER JOIN GLOBAL.ESTADO c ON a.EstadoId = c.EstadoId
    WHERE a.EmpleadoId = TRY_CAST(@Buscar AS INT)
       OR a.Nombre LIKE '%' + @Buscar + '%'
       OR a.Apellido LIKE '%' + @Buscar + '%'
       OR a.Telefono LIKE '%' + @Buscar + '%'
       OR a.Email LIKE '%' + @Buscar + '%'
       OR b.Cargo LIKE '%' + @Buscar + '%'          -- ← búsqueda por cargo
    ORDER BY a.Nombre, a.Apellido;
END
GO
/****** Object:  StoredProcedure [RRHH].[SpUpdateCargo]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Actualizar un cargo
CREATE PROCEDURE [RRHH].[SpUpdateCargo]
    @CargoId INT,
    @Cargo VARCHAR(30)
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM RRHH.CARGO WHERE Cargo = @Cargo)
        UPDATE RRHH.CARGO
        SET Cargo = @Cargo
        WHERE CargoId = @CargoId
    ELSE
        PRINT('El cargo ya existe dentro de la BD...')
END
GO
/****** Object:  StoredProcedure [RRHH].[SpUpdateEmpleado]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SpUpdateEmpleado sin validación de teléfono duplicado
CREATE PROCEDURE [RRHH].[SpUpdateEmpleado]
    @EmpleadoId INT,
    @Nombre VARCHAR(25),
    @Apellido VARCHAR(25),
    @Telefono VARCHAR(15),
    @Email VARCHAR(60),
    @Direccion VARCHAR(100),
    @FechaNac DATE,
    @FechaContratacion DATE,
    @CargoId INT,
    @EstadoId INT,
    @UsuarioModificacionId INT
AS
BEGIN
    -- Solo validamos que el email no se repita en otro empleado
    IF EXISTS (SELECT * FROM RRHH.EMPLEADO 
               WHERE Email = @Email AND Email IS NOT NULL
                 AND EmpleadoId <> @EmpleadoId)
    BEGIN
        RAISERROR('El empleado no puede ser modificado: Email ya existe en otro empleado.', 16, 1);
        RETURN;
    END

    UPDATE RRHH.EMPLEADO
    SET Nombre = @Nombre,
        Apellido = @Apellido,
        Telefono = @Telefono,
        Email = @Email,
        Direccion = @Direccion,
        FechaNac = @FechaNac,
        FechaContratacion = @FechaContratacion,
        CargoId = @CargoId,
        EstadoId = @EstadoId,
        UsuarioModificacionId = @UsuarioModificacionId
    WHERE EmpleadoId = @EmpleadoId;
END
GO
/****** Object:  StoredProcedure [VENTA].[SpDeleteDescuento]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Eliminar un descuento
CREATE PROCEDURE [VENTA].[SpDeleteDescuento]
    @DescuentoId INT
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM VENTA.DESCUENTO WHERE DescuentoId = @DescuentoId)
        PRINT('El descuento no ha sido encontrado en la BD');
    ELSE
        DELETE FROM VENTA.DESCUENTO
        WHERE DescuentoId = @DescuentoId;
        PRINT 'El descuento ha sido eliminado.';
END
GO
/****** Object:  StoredProcedure [VENTA].[SpDeleteDetCombo]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Eliminar un detalle de combo
CREATE PROCEDURE [VENTA].[SpDeleteDetCombo]
    @DetalleComboId INT
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM VENTA.DET_COMBO WHERE DetalleComboId = @DetalleComboId)
        PRINT('El detalle no ha sido encontrado en la BD');
    ELSE
        DELETE FROM VENTA.DET_COMBO
        WHERE DetalleComboId = @DetalleComboId;
        PRINT 'El detalle ha sido eliminado.';
END
GO
/****** Object:  StoredProcedure [VENTA].[SpDeleteDetOrden]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Eliminar un detalle de orden
CREATE PROCEDURE [VENTA].[SpDeleteDetOrden]
    @DetOrdenId INT
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM VENTA.DET_ORDEN WHERE DetOrdenId = @DetOrdenId)
        PRINT('El detalle no ha sido encontrado en la BD');
    ELSE
        DELETE FROM VENTA.DET_ORDEN
        WHERE DetOrdenId = @DetOrdenId;
        PRINT 'El detalle ha sido eliminado.';
END
GO
/****** Object:  StoredProcedure [VENTA].[SpDeleteLogicoCategoria]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 4. SpDeleteLogicoCategoria
CREATE PROCEDURE [VENTA].[SpDeleteLogicoCategoria]
    @CategoriaId INT
AS
BEGIN
    DECLARE @EstadoInactivo INT = (
        SELECT EstadoId FROM GLOBAL.ESTADO 
        WHERE Estado = 'INACTIVO' 
          AND EntidadId = (SELECT EntidadId FROM GLOBAL.ENTIDAD WHERE Entidad = 'CATEGORIA')
    );

    IF EXISTS(SELECT * FROM VENTA.CATEGORIA WHERE CategoriaId = @CategoriaId)
        UPDATE VENTA.CATEGORIA
        SET EstadoId = @EstadoInactivo
        WHERE CategoriaId = @CategoriaId;
    ELSE
        PRINT('La categoria no existe en la BD');
END
GO
/****** Object:  StoredProcedure [VENTA].[SpDeleteLogicoCliente]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 7. SpDeleteLogicoCliente
CREATE PROCEDURE [VENTA].[SpDeleteLogicoCliente]
    @ClienteId INT
AS
BEGIN
    DECLARE @EstadoInactivo INT = (SELECT EstadoId FROM GLOBAL.ESTADO WHERE Estado = 'INACTIVO' AND EntidadId = (SELECT EntidadId FROM GLOBAL.ENTIDAD WHERE Entidad = 'CLIENTE'));
    IF EXISTS(SELECT * FROM VENTA.CLIENTE WHERE ClienteId = @ClienteId)
        UPDATE VENTA.CLIENTE SET EstadoId = @EstadoInactivo WHERE ClienteId = @ClienteId;
    ELSE
        RAISERROR('El cliente no existe en la BD', 16, 1);
END
GO
/****** Object:  StoredProcedure [VENTA].[SpDeleteLogicoDescuento]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ============================================================
-- 5. Crear SpDeleteLogicoDescuento
-- ============================================================
CREATE PROCEDURE [VENTA].[SpDeleteLogicoDescuento]
    @DescuentoId INT
AS
BEGIN
    DECLARE @EstadoInactivo INT = (
        SELECT EstadoId FROM GLOBAL.ESTADO 
        WHERE Estado = 'INACTIVO' 
          AND EntidadId = (SELECT EntidadId FROM GLOBAL.ENTIDAD WHERE Entidad = 'DESCUENTO')
    );

    IF EXISTS(SELECT * FROM VENTA.DESCUENTO WHERE DescuentoId = @DescuentoId)
        UPDATE VENTA.DESCUENTO SET EstadoId = @EstadoInactivo WHERE DescuentoId = @DescuentoId;
    ELSE
        RAISERROR('El descuento no existe en la BD', 16, 1);
END
GO
/****** Object:  StoredProcedure [VENTA].[SpDesactivarCombo]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Desactivar un combo
CREATE PROCEDURE [VENTA].[SpDesactivarCombo]
    @ComboId INT,
    @EstadoId INT
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM VENTA.COMBO WHERE ComboId = @ComboId)
        PRINT('El combo no ha sido encontrado en la BD');
    ELSE IF NOT EXISTS(SELECT * FROM GLOBAL.ESTADO WHERE EstadoId = @EstadoId)
        PRINT('El estado no existe en la BD');
    ELSE
        UPDATE VENTA.COMBO
        SET EstadoId = @EstadoId
        WHERE ComboId = @ComboId;
        PRINT 'El combo ahora esta inactivo.';
END
GO
/****** Object:  StoredProcedure [VENTA].[SpDesactivarMenu]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Desactivar un menu
CREATE PROCEDURE [VENTA].[SpDesactivarMenu]
    @MenuId INT,
    @EstadoId INT
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM VENTA.MENU WHERE MenuId = @MenuId)
        PRINT('El menu no ha sido encontrado en la BD');
    ELSE IF NOT EXISTS(SELECT * FROM GLOBAL.ESTADO WHERE EstadoId = @EstadoId)
        PRINT('El estado no existe en la BD');
    ELSE
        UPDATE VENTA.MENU
        SET EstadoId = @EstadoId
        WHERE MenuId = @MenuId;
        PRINT 'El menu ahora esta inactivo.';
END
GO
/****** Object:  StoredProcedure [VENTA].[SpInsertCategoria]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 1. SpInsertCategoria
CREATE PROCEDURE [VENTA].[SpInsertCategoria]
    @Categoria VARCHAR(30),
    @EstadoId INT
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM VENTA.CATEGORIA WHERE Categoria = @Categoria)
        INSERT INTO VENTA.CATEGORIA(Categoria, EstadoId)
        VALUES (@Categoria, @EstadoId);
    ELSE
        PRINT('La categoria ya existe dentro de la BD');
END
GO
/****** Object:  StoredProcedure [VENTA].[SpInsertCliente]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [VENTA].[SpInsertCliente]
    @Nombre VARCHAR(25),
    @Apellido VARCHAR(25),
    @Telefono VARCHAR(10),
    @CorreoElectronico VARCHAR(100) = NULL,
    @DireccionId INT,
    @EstadoId INT
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM DELIVERY.DIRECCION WHERE DireccionId = @DireccionId)
    BEGIN
        RAISERROR('La dirección no existe en la BD', 16, 1);
        RETURN;
    END

    -- Validar que no exista el mismo cliente con la misma dirección
    IF EXISTS(SELECT * FROM VENTA.CLIENTE WHERE Telefono = @Telefono AND DireccionId = @DireccionId)
    BEGIN
        RAISERROR('El cliente ya existe en la BD con esa dirección.', 16, 1);
        RETURN;
    END

    DECLARE @NombreBase VARCHAR(50) = @Nombre + ' ' + @Apellido;
    DECLARE @Count INT;
    SELECT @Count = COUNT(*) FROM VENTA.CLIENTE WHERE Telefono = @Telefono;

    DECLARE @NombreCompleto VARCHAR(100);
    IF @Count > 0
        SET @NombreCompleto = @NombreBase + ' (' + CAST(@Count + 1 AS VARCHAR) + ')';
    ELSE
        SET @NombreCompleto = @NombreBase;

    INSERT INTO VENTA.CLIENTE(Nombre, Apellido, NombreCompleto, Telefono, CorreoElectronico, DireccionId, EstadoId)
    VALUES (@Nombre, @Apellido, @NombreCompleto, @Telefono, @CorreoElectronico, @DireccionId, @EstadoId);
END
GO
/****** Object:  StoredProcedure [VENTA].[SpInsertCombo]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ============================================================
-- 2. Modificar SpInsertCombo para incluir CategoriaId
-- ============================================================
CREATE PROCEDURE [VENTA].[SpInsertCombo]
    @Nombre VARCHAR(40),
    @Descripcion VARCHAR(100),
    @Precio DECIMAL(10,2),
    @EstadoId INT,
    @CategoriaId INT
AS
BEGIN
    IF EXISTS(SELECT * FROM VENTA.COMBO WHERE Nombre = @Nombre)
        RAISERROR('El combo ya existe en la BD', 16, 1);
    ELSE IF @Precio <= 0.00
        RAISERROR('El precio debe ser mayor a $0.00', 16, 1);
    ELSE
        INSERT INTO VENTA.COMBO(Nombre, Descripcion, Precio, EstadoId, CategoriaId)
        VALUES (@Nombre, @Descripcion, @Precio, @EstadoId, @CategoriaId);
END
GO
/****** Object:  StoredProcedure [VENTA].[SpInsertDescuento]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ============================================================
-- 3. Actualizar SpInsertDescuento
-- ============================================================
CREATE PROCEDURE [VENTA].[SpInsertDescuento]
    @Nombre VARCHAR(50),
    @Porcentaje DECIMAL(5,2),
    @TipoDescuentoId INT = NULL,
    @MenuId INT = NULL,
    @ComboId INT = NULL,
    @FechaDesde DATE,
    @FechaHasta DATE,
    @EstadoId INT
AS
BEGIN
    IF EXISTS(SELECT * FROM VENTA.DESCUENTO WHERE Nombre = @Nombre)
        RAISERROR('El descuento ya existe en la BD', 16, 1);
    ELSE IF @Porcentaje <= 0 OR @Porcentaje > 100
        RAISERROR('El porcentaje debe ser mayor a 0 y menor o igual a 100', 16, 1);
    ELSE IF @FechaDesde > @FechaHasta
        RAISERROR('La fecha desde no puede ser mayor a la fecha hasta', 16, 1);
    ELSE
        INSERT INTO VENTA.DESCUENTO(Nombre, Porcentaje, TipoDescuentoId, MenuId, ComboId, FechaDesde, FechaHasta, EstadoId)
        VALUES (@Nombre, @Porcentaje, @TipoDescuentoId, @MenuId, @ComboId, @FechaDesde, @FechaHasta, @EstadoId);
END
GO
/****** Object:  StoredProcedure [VENTA].[SpInsertDetCombo]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 3. Asegurar que el SP SpInsertDetCombo sea correcto
CREATE PROCEDURE [VENTA].[SpInsertDetCombo]
    @ComboId INT,
    @IdMenu INT,
    @Cantidad INT,
    @CategoriaId INT
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM VENTA.COMBO WHERE ComboId = @ComboId)
        RAISERROR('El combo no ha sido encontrado en la BD', 16, 1);
    ELSE IF NOT EXISTS(SELECT * FROM VENTA.MENU WHERE MenuId = @IdMenu)
        RAISERROR('El menu no ha sido encontrado en la BD', 16, 1);
    ELSE IF NOT EXISTS(SELECT * FROM VENTA.CATEGORIA WHERE CategoriaId = @CategoriaId)
        RAISERROR('La categoria no ha sido encontrada en la BD', 16, 1);
    ELSE IF @Cantidad <= 0
        RAISERROR('La cantidad debe ser mayor a 0', 16, 1);
    ELSE
        INSERT INTO VENTA.DET_COMBO(ComboId, IdMenu, Cantidad, CategoriaId)
        VALUES (@ComboId, @IdMenu, @Cantidad, @CategoriaId);
END
GO
/****** Object:  StoredProcedure [VENTA].[SpInsertDetOrden]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- Sp para VENTA.DET_ORDEN

-- Insertar un detalle de orden
CREATE PROCEDURE [VENTA].[SpInsertDetOrden]
    @OrdenId INT,
    @MenuId INT = NULL,
    @ComboId INT = NULL,
    @PrecioUnitario DECIMAL(10,2),
    @Cantidad INT
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM VENTA.ORDEN WHERE OrdenId = @OrdenId)
        PRINT('La orden no ha sido encontrada en la BD');
    ELSE IF @MenuId IS NULL AND @ComboId IS NULL
        PRINT('Debe ingresar al menos un menu o un combo');
    ELSE IF @MenuId IS NOT NULL AND NOT EXISTS(SELECT * FROM VENTA.MENU WHERE MenuId = @MenuId)
        PRINT('El menu no ha sido encontrado en la BD');
    ELSE IF @ComboId IS NOT NULL AND NOT EXISTS(SELECT * FROM VENTA.COMBO WHERE ComboId = @ComboId)
        PRINT('El combo no ha sido encontrado en la BD');
    ELSE IF @Cantidad <= 0
        PRINT('La cantidad debe ser mayor a 0');
    ELSE IF @PrecioUnitario <= 0.00
        PRINT('El precio unitario debe ser mayor a $0.00');
    ELSE
        INSERT INTO VENTA.DET_ORDEN(OrdenId, MenuId, ComboId, PrecioUnitario, Cantidad)
        VALUES (@OrdenId, @MenuId, @ComboId, @PrecioUnitario, @Cantidad);
END
GO
/****** Object:  StoredProcedure [VENTA].[SpInsertMenu]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- Sp para VENTA.MENU

-- Insertar un menu
CREATE PROCEDURE [VENTA].[SpInsertMenu]
    @Nombre VARCHAR(100),
    @Precio DECIMAL(10,2),
    @InventarioId INT = NULL,
    @CategoriaId INT,
    @EstadoId INT
AS
BEGIN
    IF EXISTS(SELECT * FROM VENTA.MENU WHERE Nombre = @Nombre)
        PRINT('El menu ya existe en la BD');
    ELSE IF @Precio <= 0.00
        PRINT('El precio debe ser mayor a $0.00');
    ELSE IF NOT EXISTS(SELECT * FROM VENTA.CATEGORIA WHERE CategoriaId = @CategoriaId)
        PRINT('La categoria no existe en la BD');
    ELSE IF NOT EXISTS(SELECT * FROM GLOBAL.ESTADO WHERE EstadoId = @EstadoId)
        PRINT('El estado no existe en la BD');
    ELSE
        INSERT INTO VENTA.MENU(Nombre, Precio, InventarioId, CategoriaId, EstadoId)
        VALUES (@Nombre, @Precio, @InventarioId, @CategoriaId, @EstadoId);
END
GO
/****** Object:  StoredProcedure [VENTA].[SpInsertOrden]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Sp para VENTA.ORDEN

-- Insertar una orden
CREATE PROCEDURE [VENTA].[SpInsertOrden]
    @ClienteId INT,
    @EstadoId INT,
    @TipoOrdenId INT,
    @DescuentoId INT
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM VENTA.CLIENTE WHERE ClienteId = @ClienteId)
        PRINT('El cliente no ha sido encontrado en la BD');
    ELSE IF NOT EXISTS(SELECT * FROM GLOBAL.ESTADO WHERE EstadoId = @EstadoId)
        PRINT('El estado no existe en la BD');
    ELSE IF NOT EXISTS(SELECT * FROM VENTA.TIPO_ORDEN WHERE TipoOrdenId = @TipoOrdenId)
        PRINT('El tipo de orden no existe en la BD');
    ELSE
        INSERT INTO VENTA.ORDEN(FechaHora, Total, DescuentoId, TipoOrdenId, ClienteId, EstadoId)
        VALUES (GETDATE(), 0, @DescuentoId, @TipoOrdenId, @ClienteId, @EstadoId);
END
GO
/****** Object:  StoredProcedure [VENTA].[SpInsertTipoOrden]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- Sp para VENTA.TIPO_ORDEN

-- Insertar un tipo de orden
CREATE PROCEDURE [VENTA].[SpInsertTipoOrden]
    @TipoOrden VARCHAR(30)
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM VENTA.TIPO_ORDEN WHERE TipoOrden = @TipoOrden)
        INSERT INTO VENTA.TIPO_ORDEN(TipoOrden)
        VALUES (@TipoOrden);
    ELSE
        PRINT('El tipo orden ya existe dentro de la BD');
END
GO
/****** Object:  StoredProcedure [VENTA].[SpInsertVenta]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Sp para VENTA.VENTA

-- Insertar una venta
CREATE PROCEDURE [VENTA].[SpInsertVenta]
    @OrdenId INT,
    @NoDocumento VARCHAR(10),
    @EstadoId INT
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM VENTA.ORDEN WHERE OrdenId = @OrdenId)
        PRINT('La orden no ha sido encontrada en la BD');
    ELSE IF EXISTS(SELECT * FROM VENTA.VENTA WHERE NoDocumento = @NoDocumento)
        PRINT('El numero de documento ya existe en la BD');
    ELSE IF NOT EXISTS(SELECT * FROM GLOBAL.ESTADO WHERE EstadoId = @EstadoId)
        PRINT('El estado no existe en la BD');
    ELSE
        INSERT INTO VENTA.VENTA(Fecha, OrdenId, NoDocumento, EstadoId)
        VALUES (GETDATE(), @OrdenId, @NoDocumento, @EstadoId);
END
GO
/****** Object:  StoredProcedure [VENTA].[SpRegistrarOrdenCompleta]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 4. Recrear el procedimiento almacenado limpio
CREATE PROCEDURE [VENTA].[SpRegistrarOrdenCompleta]
    @ClienteId INT,
    @TipoOrdenId INT,
    @DescuentoId INT = NULL,
    @EstadoId INT,
    @UsuarioRegistroId INT,
    @Detalle VENTA.DetalleOrdenType READONLY
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @Total DECIMAL(10,2);
        SELECT @Total = SUM(PrecioUnitario * Cantidad) FROM @Detalle;

        IF @DescuentoId IS NOT NULL
        BEGIN
            DECLARE @Porcentaje DECIMAL(5,2);
            SELECT @Porcentaje = Porcentaje FROM VENTA.DESCUENTO WHERE DescuentoId = @DescuentoId;
            SET @Total = @Total - (@Total * @Porcentaje / 100);
        END

        DECLARE @OrdenId INT;
        INSERT INTO VENTA.ORDEN(FechaHora, Total, DescuentoId, TipoOrdenId, ClienteId, EstadoId, UsuarioRegistroId)
        VALUES (GETDATE(), @Total, @DescuentoId, @TipoOrdenId, @ClienteId, @EstadoId, @UsuarioRegistroId);
        SET @OrdenId = SCOPE_IDENTITY();

        INSERT INTO VENTA.DET_ORDEN(OrdenId, MenuId, ComboId, PrecioUnitario, Cantidad)
        SELECT @OrdenId, MenuId, ComboId, PrecioUnitario, Cantidad
        FROM @Detalle;

        COMMIT TRANSACTION;
        SELECT @OrdenId AS OrdenId;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO
/****** Object:  StoredProcedure [VENTA].[SpRegistrarVenta]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--cambios para las consultas2.0


CREATE PROCEDURE [VENTA].[SpRegistrarVenta]
    @OrdenId INT,
    @Fecha DATE,
    @NoDocumento VARCHAR(10),
    @MetodoPago VARCHAR(30),
    @MontoRecibido DECIMAL(10,2),
    @Total DECIMAL(10,2)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @Cambio DECIMAL(10,2) = @MontoRecibido - @Total;
        IF @Cambio < 0
        BEGIN
            RAISERROR('El monto recibido es menor al total a pagar.', 16, 1);
            RETURN;
        END

        -- Insertar la venta
        INSERT INTO VENTA.VENTA(Fecha, OrdenId, NoDocumento, EstadoId, MetodoPago, MontoRecibido, Cambio)
        VALUES (@Fecha, @OrdenId, @NoDocumento, 
                (SELECT EstadoId FROM GLOBAL.ESTADO WHERE Estado = 'VIGENTE' 
                 AND EntidadId = (SELECT EntidadId FROM GLOBAL.ENTIDAD WHERE Entidad = 'VENTA')),
                @MetodoPago, @MontoRecibido, @Cambio);

        -- Cambiar el estado de la orden a COMPLETADA
        UPDATE VENTA.ORDEN
        SET EstadoId = (SELECT EstadoId FROM GLOBAL.ESTADO WHERE Estado = 'COMPLETADA' 
                        AND EntidadId = (SELECT EntidadId FROM GLOBAL.ENTIDAD WHERE Entidad = 'ORDEN'))
        WHERE OrdenId = @OrdenId;

        -- ============================================================
        -- NUEVO: Si la orden tiene un envío asociado, marcarlo como ENTREGADO
        -- ============================================================
        IF EXISTS (SELECT 1 FROM DELIVERY.ENVIO WHERE OrdenId = @OrdenId)
        BEGIN
            UPDATE DELIVERY.ENVIO
            SET EstadoId = (SELECT EstadoId FROM GLOBAL.ESTADO WHERE Estado = 'ENTREGADO' 
                            AND EntidadId = (SELECT EntidadId FROM GLOBAL.ENTIDAD WHERE Entidad = 'ENVIO'))
            WHERE OrdenId = @OrdenId;
        END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO
/****** Object:  StoredProcedure [VENTA].[SpSelectAllCategoria]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 3. SpSelectAllCategoria
CREATE PROCEDURE [VENTA].[SpSelectAllCategoria]
AS
BEGIN
    SELECT a.CategoriaId, 
           a.Categoria,
           a.EstadoId,
           b.Estado AS EstadoNombre
    FROM VENTA.CATEGORIA a
    INNER JOIN GLOBAL.ESTADO b ON a.EstadoId = b.EstadoId
    ORDER BY a.Categoria ASC;
END
GO
/****** Object:  StoredProcedure [VENTA].[SpSelectAllCliente]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 4. Modificar SpSelectAllCliente (incluir Municipio en DireccionNombre y PuntoReferencia)
CREATE PROCEDURE [VENTA].[SpSelectAllCliente]
AS
BEGIN
    SELECT a.ClienteId,
           a.Nombre,
           a.Apellido,
           a.NombreCompleto,
           a.Telefono,
           a.CorreoElectronico,
           a.DireccionId,
           (SELECT d.Nombre + ', ' + b.ColoniBarrio
            FROM DELIVERY.DIRECCION b
            INNER JOIN DELIVERY.MUNICIPIO d ON b.MunicipioId = d.MunicipioId
            WHERE b.DireccionId = a.DireccionId) AS DireccionNombre,
           (SELECT b.PuntoReferencia
            FROM DELIVERY.DIRECCION b
            WHERE b.DireccionId = a.DireccionId) AS PuntoReferencia,
           a.EstadoId,
           c.Estado AS EstadoNombre
    FROM VENTA.CLIENTE a
    INNER JOIN GLOBAL.ESTADO c ON a.EstadoId = c.EstadoId
    ORDER BY a.NombreCompleto;
END
GO
/****** Object:  StoredProcedure [VENTA].[SpSelectAllCombo]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ============================================================
-- 6. Crear SpSelectAllCombo (nuevo, devuelve todos los combos)
-- ============================================================
CREATE PROCEDURE [VENTA].[SpSelectAllCombo]
AS
BEGIN
    SELECT a.ComboId,
           a.Nombre,
           a.Descripcion,
           a.Precio,
           a.CategoriaId,
           c.Categoria,
           a.EstadoId,
           d.Estado AS EstadoNombre
    FROM VENTA.COMBO a
    LEFT JOIN VENTA.CATEGORIA c ON a.CategoriaId = c.CategoriaId
    INNER JOIN GLOBAL.ESTADO d ON a.EstadoId = d.EstadoId
    ORDER BY a.Nombre;
END
GO
/****** Object:  StoredProcedure [VENTA].[SpSelectAllMenu]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Actualizar SpSelectAllMenu para incluir el stock
CREATE PROCEDURE [VENTA].[SpSelectAllMenu]
AS
BEGIN
    SELECT a.MenuId,
           a.Nombre,
           a.Precio,
           a.InventarioId,
           ISNULL(b.NombreProducto, 'Sin inventario') AS InventarioNombre,
           ISNULL(b.Cantidad, 0) AS Stock,   -- ← nueva columna
           a.CategoriaId,
           c.Categoria,
           a.EstadoId,
           d.Estado AS EstadoNombre
    FROM VENTA.MENU a
    LEFT JOIN COMPRA.INVENTARIO b ON a.InventarioId = b.InventarioId
    INNER JOIN VENTA.CATEGORIA c ON a.CategoriaId = c.CategoriaId
    INNER JOIN GLOBAL.ESTADO d ON a.EstadoId = d.EstadoId
    ORDER BY a.Nombre;
END
GO
/****** Object:  StoredProcedure [VENTA].[SpSelectAllTipoDescuento]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------
CREATE PROCEDURE [VENTA].[SpSelectAllTipoDescuento]
AS
BEGIN
    SELECT TipoDescuentoId, Tipo FROM VENTA.TIPO_DESCUENTO ORDER BY Tipo;
END
GO
/****** Object:  StoredProcedure [VENTA].[SpSelectAllTipoOrden]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Seleccionar todos los tipos de orden
CREATE PROCEDURE [VENTA].[SpSelectAllTipoOrden]
AS
BEGIN
    SELECT TipoOrdenId AS 'Id', TipoOrden
    FROM VENTA.TIPO_ORDEN
    ORDER BY TipoOrden ASC;
END
GO
/****** Object:  StoredProcedure [VENTA].[SpSelectCliente]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 5. Modificar SpSelectCliente
CREATE PROCEDURE [VENTA].[SpSelectCliente]
    @Buscar VARCHAR(50)
AS
BEGIN
    SELECT a.ClienteId,
           a.Nombre,
           a.Apellido,
           a.NombreCompleto,
           a.Telefono,
           a.DireccionId,
           (SELECT d.Nombre + ', ' + b.ColoniBarrio
            FROM DELIVERY.DIRECCION b
            INNER JOIN DELIVERY.MUNICIPIO d ON b.MunicipioId = d.MunicipioId
            WHERE b.DireccionId = a.DireccionId) AS DireccionNombre,
           (SELECT b.PuntoReferencia
            FROM DELIVERY.DIRECCION b
            WHERE b.DireccionId = a.DireccionId) AS PuntoReferencia,
           a.EstadoId,
           c.Estado AS EstadoNombre
    FROM VENTA.CLIENTE a
    INNER JOIN GLOBAL.ESTADO c ON a.EstadoId = c.EstadoId
    WHERE a.NombreCompleto LIKE '%' + @Buscar + '%'
       OR a.Telefono LIKE '%' + @Buscar + '%'
       OR a.CorreoElectronico LIKE '%' + @Buscar + '%'
    ORDER BY a.NombreCompleto;
END
GO
/****** Object:  StoredProcedure [VENTA].[SpSelectCombo]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ============================================================
-- 7. Modificar SpSelectCombo (búsqueda) para devolver mismos campos
-- ============================================================
CREATE PROCEDURE [VENTA].[SpSelectCombo]
    @Buscar VARCHAR(40)
AS
BEGIN
    SELECT a.ComboId,
           a.Nombre,
           a.Descripcion,
           a.Precio,
           a.CategoriaId,
           c.Categoria,
           a.EstadoId,
           d.Estado AS EstadoNombre
    FROM VENTA.COMBO a
    LEFT JOIN VENTA.CATEGORIA c ON a.CategoriaId = c.CategoriaId
    INNER JOIN GLOBAL.ESTADO d ON a.EstadoId = d.EstadoId
    WHERE a.Nombre LIKE '%' + @Buscar + '%'
    ORDER BY a.Nombre;
END
GO
/****** Object:  StoredProcedure [VENTA].[SpSelectDescuento]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ============================================================
-- 5. Actualizar SpSelectDescuento
-- ============================================================
CREATE PROCEDURE [VENTA].[SpSelectDescuento]
    @Buscar VARCHAR(50)
AS
BEGIN
    SELECT a.DescuentoId AS 'Id',
           a.Nombre,
           a.Porcentaje,
           a.TipoDescuentoId,
           t.Tipo AS TipoDescuento,
           a.MenuId,
           c.Nombre AS MenuNombre,
           a.ComboId,
           d.Nombre AS ComboNombre,
           a.FechaDesde,
           a.FechaHasta,
           a.EstadoId,
           e.Estado AS EstadoNombre
    FROM VENTA.DESCUENTO a
    LEFT JOIN VENTA.TIPO_DESCUENTO t ON a.TipoDescuentoId = t.TipoDescuentoId
    LEFT JOIN VENTA.MENU c ON a.MenuId = c.MenuId
    LEFT JOIN VENTA.COMBO d ON a.ComboId = d.ComboId
    INNER JOIN GLOBAL.ESTADO e ON a.EstadoId = e.EstadoId
    WHERE a.Nombre LIKE '%' + @Buscar + '%'
       OR a.DescuentoId = TRY_CAST(@Buscar AS INT)
    ORDER BY a.FechaDesde DESC;
END
GO
/****** Object:  StoredProcedure [VENTA].[SpSelectDescuentosActivos]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ============================================================
-- 5. Crear SpSelectDescuentosActivos (para cargar en la orden)
-- ============================================================
CREATE PROCEDURE [VENTA].[SpSelectDescuentosActivos]
AS
BEGIN
    SELECT DescuentoId,
           Nombre,
           Porcentaje,
           CategoriaId,
           MenuId,
           ComboId,
           FechaDesde,
           FechaHasta
    FROM VENTA.DESCUENTO
    WHERE FechaDesde <= GETDATE() AND FechaHasta >= GETDATE()
    ORDER BY FechaDesde DESC;
END
GO
/****** Object:  StoredProcedure [VENTA].[SpSelectDetCombo]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Seleccion del detalle de un combo
CREATE PROCEDURE [VENTA].[SpSelectDetCombo]
    @ComboId INT
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM VENTA.DET_COMBO WHERE ComboId = @ComboId)
        PRINT('El combo no tiene detalles registrados en la BD');
    ELSE
        SELECT a.DetalleComboId AS 'Id', b.Nombre AS 'Combo', 
               c.Nombre AS 'Menu', a.Cantidad, d.Categoria
        FROM VENTA.DET_COMBO a, VENTA.COMBO b, VENTA.MENU c, VENTA.CATEGORIA d
        WHERE a.ComboId = b.ComboId AND a.IdMenu = c.MenuId 
        AND a.CategoriaId = d.CategoriaId
        AND a.ComboId = @ComboId
        ORDER BY c.Nombre ASC;
END
GO
/****** Object:  StoredProcedure [VENTA].[SpSelectDetOrden]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Seleccion del detalle de una orden
CREATE PROCEDURE [VENTA].[SpSelectDetOrden]
    @OrdenId INT
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM VENTA.DET_ORDEN WHERE OrdenId = @OrdenId)
        PRINT('La orden no tiene detalles registrados en la BD');
    ELSE
        SELECT a.DetOrdenId AS 'Id',
               ISNULL(b.Nombre, c.Nombre) AS 'Producto',
               a.PrecioUnitario AS 'Precio Unitario',
               a.Cantidad,
               a.Total
        FROM VENTA.DET_ORDEN a
        LEFT JOIN VENTA.MENU b ON a.MenuId = b.MenuId
        LEFT JOIN VENTA.COMBO c ON a.ComboId = c.ComboId
        WHERE a.OrdenId = @OrdenId;
END
GO
/****** Object:  StoredProcedure [VENTA].[SpSelectMenu]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- (Opcional) Actualizar también la búsqueda
CREATE PROCEDURE [VENTA].[SpSelectMenu]
    @Buscar VARCHAR(100)
AS
BEGIN
    SELECT a.MenuId,
           a.Nombre,
           a.Precio,
           a.InventarioId,
           ISNULL(b.NombreProducto, 'Sin inventario') AS InventarioNombre,
           ISNULL(b.Cantidad, 0) AS Stock,
           a.CategoriaId,
           c.Categoria,
           a.EstadoId,
           d.Estado AS EstadoNombre
    FROM VENTA.MENU a
    LEFT JOIN COMPRA.INVENTARIO b ON a.InventarioId = b.InventarioId
    INNER JOIN VENTA.CATEGORIA c ON a.CategoriaId = c.CategoriaId
    INNER JOIN GLOBAL.ESTADO d ON a.EstadoId = d.EstadoId
    WHERE a.Nombre LIKE '%' + @Buscar + '%'
    ORDER BY a.Nombre;
END
GO
/****** Object:  StoredProcedure [VENTA].[SpSelectOrden]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Busqueda de una orden
CREATE PROCEDURE [VENTA].[SpSelectOrden]
    @OrdenId INT
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM VENTA.ORDEN WHERE OrdenId = @OrdenId)
        PRINT('La orden no ha sido encontrada en la BD');
    ELSE
        SELECT a.OrdenId AS 'Id', a.FechaHora, a.Total, a.DescuentoId,
               a.TipoOrdenId, b.Nombre + ', ' + b.Apellido AS 'Cliente',
               c.Estado, d.TipoOrden AS 'Tipo de Orden'
        FROM VENTA.ORDEN a, VENTA.CLIENTE b, GLOBAL.ESTADO c, VENTA.TIPO_ORDEN d
        WHERE a.ClienteId = b.ClienteId AND a.EstadoId = c.EstadoId
        AND a.TipoOrdenId = d.TipoOrdenId
        AND a.OrdenId = @OrdenId;
END
GO
/****** Object:  StoredProcedure [VENTA].[SpSelectOrdenesPendientesDelivery]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [VENTA].[SpSelectOrdenesPendientesDelivery]
AS
BEGIN
    SELECT o.OrdenId,
           'ID:' + CAST(o.OrdenId AS VARCHAR) + ' - ' + c.Nombre + ' ' + c.Apellido AS DescripcionOrden,
           o.FechaHora,
           o.Total,
           c.Nombre + ' ' + c.Apellido AS ClienteNombre,
           c.Telefono AS ClienteTelefono,
           c.DireccionId,
           (SELECT m.Nombre + ', ' + dir.ColoniBarrio + ISNULL(', ' + dir.PuntoReferencia, '')
            FROM DELIVERY.DIRECCION dir
            INNER JOIN DELIVERY.MUNICIPIO m ON dir.MunicipioId = m.MunicipioId
            WHERE dir.DireccionId = c.DireccionId) AS DireccionCompleta,
           (SELECT dir.CoordenadasMaps FROM DELIVERY.DIRECCION dir WHERE dir.DireccionId = c.DireccionId) AS Coordenadas,
           (SELECT dir.MunicipioId FROM DELIVERY.DIRECCION dir WHERE dir.DireccionId = c.DireccionId) AS MunicipioId
    FROM VENTA.ORDEN o
    INNER JOIN VENTA.CLIENTE c ON o.ClienteId = c.ClienteId
    INNER JOIN GLOBAL.ESTADO e ON o.EstadoId = e.EstadoId
    INNER JOIN VENTA.TIPO_ORDEN t ON o.TipoOrdenId = t.TipoOrdenId
    WHERE UPPER(t.TipoOrden) = 'DELIVERY'
      AND UPPER(e.Estado) = 'PENDIENTE'
    ORDER BY o.FechaHora ASC;
END
GO
/****** Object:  StoredProcedure [VENTA].[SpSelectVenta]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Busqueda de una venta por No. Documento
CREATE PROCEDURE [VENTA].[SpSelectVenta]
    @Buscar VARCHAR(10)
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM VENTA.VENTA WHERE NoDocumento LIKE '%' + @Buscar + '%')
        PRINT('El numero de documento no ha sido encontrado en la BD');
    ELSE
        SELECT a.VentaId AS 'Codigo', a.Fecha, a.NoDocumento,
        ('Cod:' + CAST(a.OrdenId AS VARCHAR) ) AS 'Orden',
        b.Estado
        FROM VENTA.VENTA a, GLOBAL.ESTADO b
        WHERE a.EstadoId = b.EstadoId
        AND a.NoDocumento LIKE '%' + @Buscar + '%';
END
GO
/****** Object:  StoredProcedure [VENTA].[SpUpdateCategoria]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 2. SpUpdateCategoria
CREATE PROCEDURE [VENTA].[SpUpdateCategoria]
    @CategoriaId INT,
    @Categoria VARCHAR(30),
    @EstadoId INT
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM VENTA.CATEGORIA 
                  WHERE Categoria = @Categoria
                  AND CategoriaId <> @CategoriaId)
        UPDATE VENTA.CATEGORIA
        SET Categoria = @Categoria,
            EstadoId = @EstadoId
        WHERE CategoriaId = @CategoriaId
    ELSE
        PRINT('La categoria ya existe dentro de la BD, no es posible modificar');
END
GO
/****** Object:  StoredProcedure [VENTA].[SpUpdateCliente]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [VENTA].[SpUpdateCliente]
    @ClienteId INT,
    @Nombre VARCHAR(25),
    @Apellido VARCHAR(25),
    @NombreCompleto VARCHAR(100),
    @Telefono VARCHAR(10),
    @CorreoElectronico VARCHAR(100) = NULL,
    @DireccionId INT,
    @EstadoId INT
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM VENTA.CLIENTE WHERE ClienteId = @ClienteId)
    BEGIN
        RAISERROR('El cliente no ha sido encontrado en la BD', 16, 1);
        RETURN;
    END

    IF NOT EXISTS(SELECT * FROM DELIVERY.DIRECCION WHERE DireccionId = @DireccionId)
    BEGIN
        RAISERROR('La dirección no existe en la BD', 16, 1);
        RETURN;
    END

    -- Evitar que otro cliente tenga el mismo teléfono y dirección
    IF EXISTS(SELECT * FROM VENTA.CLIENTE WHERE Telefono = @Telefono AND DireccionId = @DireccionId AND ClienteId <> @ClienteId)
    BEGIN
        RAISERROR('Ya existe otro cliente con ese teléfono en la misma dirección.', 16, 1);
        RETURN;
    END

    UPDATE VENTA.CLIENTE
    SET Nombre = @Nombre,
        Apellido = @Apellido,
        NombreCompleto = @NombreCompleto,
        Telefono = @Telefono,
        CorreoElectronico = @CorreoElectronico,
        DireccionId = @DireccionId,
        EstadoId = @EstadoId
    WHERE ClienteId = @ClienteId;
END
GO
/****** Object:  StoredProcedure [VENTA].[SpUpdateCombo]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ============================================================
-- 3. Modificar SpUpdateCombo para incluir CategoriaId
-- ============================================================
CREATE PROCEDURE [VENTA].[SpUpdateCombo]
    @ComboId INT,
    @Nombre VARCHAR(40),
    @Descripcion VARCHAR(100),
    @Precio DECIMAL(10,2),
    @EstadoId INT,
    @CategoriaId INT
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM VENTA.COMBO WHERE ComboId = @ComboId)
        RAISERROR('El combo no ha sido encontrado en la BD', 16, 1);
    ELSE IF EXISTS(SELECT * FROM VENTA.COMBO WHERE Nombre = @Nombre AND ComboId <> @ComboId)
        RAISERROR('El nombre del combo ya existe', 16, 1);
    ELSE IF @Precio <= 0.00
        RAISERROR('El precio debe ser mayor a $0.00', 16, 1);
    ELSE
        UPDATE VENTA.COMBO
        SET Nombre = @Nombre,
            Descripcion = @Descripcion,
            Precio = @Precio,
            EstadoId = @EstadoId,
            CategoriaId = @CategoriaId
        WHERE ComboId = @ComboId;
END
GO
/****** Object:  StoredProcedure [VENTA].[SpUpdateDescuento]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ============================================================
-- 4. Actualizar SpUpdateDescuento
-- ============================================================
CREATE PROCEDURE [VENTA].[SpUpdateDescuento]
    @DescuentoId INT,
    @Nombre VARCHAR(50),
    @Porcentaje DECIMAL(5,2),
    @TipoDescuentoId INT = NULL,
    @MenuId INT = NULL,
    @ComboId INT = NULL,
    @FechaDesde DATE,
    @FechaHasta DATE,
    @EstadoId INT
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM VENTA.DESCUENTO WHERE DescuentoId = @DescuentoId)
        RAISERROR('El descuento no ha sido encontrado en la BD', 16, 1);
    ELSE IF EXISTS(SELECT * FROM VENTA.DESCUENTO WHERE Nombre = @Nombre AND DescuentoId <> @DescuentoId)
        RAISERROR('El descuento ya existe en la BD', 16, 1);
    ELSE IF @Porcentaje <= 0 OR @Porcentaje > 100
        RAISERROR('El porcentaje debe ser mayor a 0 y menor o igual a 100', 16, 1);
    ELSE IF @FechaDesde > @FechaHasta
        RAISERROR('La fecha desde no puede ser mayor a la fecha hasta', 16, 1);
    ELSE
        UPDATE VENTA.DESCUENTO
        SET Nombre = @Nombre,
            Porcentaje = @Porcentaje,
            TipoDescuentoId = @TipoDescuentoId,
            MenuId = @MenuId,
            ComboId = @ComboId,
            FechaDesde = @FechaDesde,
            FechaHasta = @FechaHasta,
            EstadoId = @EstadoId
        WHERE DescuentoId = @DescuentoId;
END
GO
/****** Object:  StoredProcedure [VENTA].[SpUpdateEstadoOrden]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Actualizar estado de una orden
CREATE PROCEDURE [VENTA].[SpUpdateEstadoOrden]
    @OrdenId INT,
    @EstadoId INT
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM VENTA.ORDEN WHERE OrdenId = @OrdenId)
        PRINT('La orden no ha sido encontrada en la BD');
    ELSE IF NOT EXISTS(SELECT * FROM GLOBAL.ESTADO WHERE EstadoId = @EstadoId)
        PRINT('El estado no existe en la BD');
    ELSE
        UPDATE VENTA.ORDEN
        SET EstadoId = @EstadoId
        WHERE OrdenId = @OrdenId;
END
GO
/****** Object:  StoredProcedure [VENTA].[SpUpdateEstadoVenta]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Actualizar estado de una venta
CREATE PROCEDURE [VENTA].[SpUpdateEstadoVenta]
    @VentaId INT,
    @EstadoId INT
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM VENTA.VENTA WHERE VentaId = @VentaId)
        PRINT('La venta no ha sido encontrada en la BD');
    ELSE IF NOT EXISTS(SELECT * FROM GLOBAL.ESTADO WHERE EstadoId = @EstadoId)
        PRINT('El estado no existe en la BD');
    ELSE
        UPDATE VENTA.VENTA
        SET EstadoId = @EstadoId
        WHERE VentaId = @VentaId;
END
GO
/****** Object:  StoredProcedure [VENTA].[SpUpdateMenu]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Actualizacion de un menu
CREATE PROCEDURE [VENTA].[SpUpdateMenu]
    @MenuId INT,
    @Nombre VARCHAR(100),
    @Precio DECIMAL(10,2),
    @InventarioId INT = NULL,
    @CategoriaId INT,
    @EstadoId INT

AS
BEGIN
    IF NOT EXISTS(SELECT * FROM VENTA.MENU WHERE MenuId = @MenuId)
        PRINT('El menu no ha sido encontrado en la BD');
    ELSE IF EXISTS(SELECT * FROM VENTA.MENU WHERE Nombre = @Nombre AND MenuId <> @MenuId)
        PRINT('El menu ya existe en la BD, no es posible modificar');
    ELSE IF @Precio <= 0.00
        PRINT('El precio debe ser mayor a $0.00');
    ELSE IF NOT EXISTS(SELECT * FROM VENTA.CATEGORIA WHERE CategoriaId = @CategoriaId)
        PRINT('La categoria no existe en la BD');
    ELSE
        UPDATE VENTA.MENU
        SET Nombre = @Nombre,
            Precio = @Precio,
            InventarioId = @InventarioId,
            CategoriaId = @CategoriaId,
            EstadoId = @EstadoId
        WHERE MenuId = @MenuId;
END
GO
/****** Object:  StoredProcedure [VENTA].[SpUpdateTotalOrden]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Actualizar total de una orden
CREATE PROCEDURE [VENTA].[SpUpdateTotalOrden]
    @OrdenId INT
AS
BEGIN
    IF NOT EXISTS(SELECT * FROM VENTA.ORDEN WHERE OrdenId = @OrdenId)
        PRINT('La orden no ha sido encontrada en la BD');
    ELSE IF NOT EXISTS(SELECT * FROM VENTA.DET_ORDEN WHERE OrdenId = @OrdenId)
        PRINT('La orden no tiene detalles registrados en la BD');
    ELSE
        UPDATE VENTA.ORDEN
        SET Total = (SELECT SUM(Total) FROM VENTA.DET_ORDEN WHERE OrdenId = @OrdenId)
        WHERE OrdenId = @OrdenId;
END
GO
/****** Object:  Trigger [AUTENTICACION].[TgAuditoriaInsertUsuario]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- AFTER INSERT
CREATE   TRIGGER [AUTENTICACION].[TgAuditoriaInsertUsuario] ON [AUTENTICACION].[USUARIO] AFTER INSERT
AS
BEGIN
    INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
    SELECT GETDATE(), (SELECT AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'INSERCION'),
           'Nuevo usuario: ' + i.Usuario, i.UsuarioRegistroId
    FROM inserted i;
END
GO
ALTER TABLE [AUTENTICACION].[USUARIO] DISABLE TRIGGER [TgAuditoriaInsertUsuario]
GO
/****** Object:  Trigger [AUTENTICACION].[TgAuditoriaUpdateUsuario]    Script Date: 8/6/2026 17:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- AFTER UPDATE (incluye eliminación lógica)
CREATE   TRIGGER [AUTENTICACION].[TgAuditoriaUpdateUsuario] ON [AUTENTICACION].[USUARIO] AFTER UPDATE
AS
BEGIN
    INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
    SELECT GETDATE(), 
           CASE WHEN i.EstadoId <> d.EstadoId AND i.EstadoId = (SELECT EstadoId FROM GLOBAL.ESTADO WHERE Estado = 'INACTIVO' AND EntidadId = (SELECT EntidadId FROM GLOBAL.ENTIDAD WHERE Entidad = 'USUARIO'))
                THEN (SELECT AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'ELIMINACION LOGICA')
                ELSE (SELECT AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'ACTUALIZACION')
           END,
           'Usuario actualizado: ' + i.Usuario, i.UsuarioModificiacionId
    FROM inserted i
    INNER JOIN deleted d ON i.UsuarioId = d.UsuarioId;
END
GO
ALTER TABLE [AUTENTICACION].[USUARIO] DISABLE TRIGGER [TgAuditoriaUpdateUsuario]
GO
/****** Object:  Trigger [AUTENTICACION].[TgDeleteLogicoUsuario]    Script Date: 8/6/2026 17:27:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Tg para cuando se intenta eliminar un usuario, se guarda un registro en el historial
CREATE TRIGGER [AUTENTICACION].[TgDeleteLogicoUsuario]
    ON [AUTENTICACION].[USUARIO]
    INSTEAD OF DELETE
AS
BEGIN
    DECLARE @AccionEventoId INT;
    SELECT TOP 1 @AccionEventoId = AccionEventoId FROM AUDITORIA.ACCION_EVENTO
    WHERE AccionEvento = 'ELIMINACION LOGICA';

    UPDATE AUTENTICACION.USUARIO
    SET EstadoId = (SELECT TOP 1 EstadoId FROM GLOBAL.ESTADO 
                    WHERE EntidadId = (SELECT TOP 1 EntidadId FROM GLOBAL.ENTIDAD WHERE Entidad = 'USUARIO') 
                    AND Estado = 'INACTIVO' ORDER BY EstadoId ASC)
    WHERE UsuarioId = (SELECT TOP 1 UsuarioId FROM deleted)

    INSERT INTO AUDITORIA.HISTORIAL(FechaHora,AccionEventoId,Detalle,UsuarioRegistroId)
    SELECT  GETDATE(),
            @AccionEventoId,
            'Se ha eliminado logicamente el usuario con id:  ' + d.UsuarioId,
            d.UsuarioModificiacionId
    FROM deleted AS d
END
GO
ALTER TABLE [AUTENTICACION].[USUARIO] DISABLE TRIGGER [TgDeleteLogicoUsuario]
GO
/****** Object:  Trigger [AUTENTICACION].[TgHistorialInsertUsuario]    Script Date: 8/6/2026 17:27:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Triggers para usuario
-- Tg para cuando se inserta un usuario, se guarda un registro en el historial
CREATE TRIGGER [AUTENTICACION].[TgHistorialInsertUsuario]
    ON [AUTENTICACION].[USUARIO]
    AFTER INSERT
AS
BEGIN
    DECLARE @AccionEventoId INT;
    SELECT TOP 1 @AccionEventoId = AccionEventoId FROM AUDITORIA.ACCION_EVENTO
    WHERE AccionEvento = 'INSERCION';

    INSERT INTO AUDITORIA.HISTORIAL(FechaHora,AccionEventoId,Detalle,UsuarioRegistroId)
    SELECT  GETDATE(),
            @AccionEventoId,
            'Se ha insertado un nuevo usuario con nombre: ' + Usuario + ' con rol: ' +r.RolId,
            i.UsuarioRegistroId
    FROM inserted AS i
    INNER JOIN AUTENTICACION.ROL AS r 
    ON i.RolId = r.RolId;
END 
GO
ALTER TABLE [AUTENTICACION].[USUARIO] DISABLE TRIGGER [TgHistorialInsertUsuario]
GO
/****** Object:  Trigger [AUTENTICACION].[TgHistorialUpdateUsuario]    Script Date: 8/6/2026 17:27:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Tg para cuando se se actualiza un usuario, se guarda un registro en el historial
CREATE TRIGGER [AUTENTICACION].[TgHistorialUpdateUsuario]
    ON [AUTENTICACION].[USUARIO]
    AFTER UPDATE
AS
BEGIN
    DECLARE @AccionEventoId INT;
    SELECT TOP 1 @AccionEventoId = AccionEventoId FROM AUDITORIA.ACCION_EVENTO
    WHERE AccionEvento = 'ACTUALIZACION';

    INSERT INTO AUDITORIA.HISTORIAL(FechaHora,AccionEventoId,Detalle,UsuarioRegistroId)
    SELECT  GETDATE(),
            @AccionEventoId,
            'Se ha modificado el usuario con id: '+ i.UsuarioId +', con nombre: ' + i.Usuario + ', con rol: ' +r.RolId,
            i.UsuarioModificiacionId
    FROM inserted AS i, AUTENTICACION.ROL AS r
    WHERE i.RolId = r.RolId
END 
GO
ALTER TABLE [AUTENTICACION].[USUARIO] DISABLE TRIGGER [TgHistorialUpdateUsuario]
GO
/****** Object:  Trigger [BODEGA].[TgHistorialInsertOrdenProduccion]    Script Date: 8/6/2026 17:27:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Triggers para OrdenDeProduccion
-- Tg para cuando se registra una orden de produccion, se guarda un registro en el historial
CREATE TRIGGER [BODEGA].[TgHistorialInsertOrdenProduccion]
    ON [BODEGA].[ORDEN_PRODUCCION]
    AFTER INSERT
AS
BEGIN
    DECLARE @AccionEventoId INT;
    SELECT TOP 1 @AccionEventoId = AccionEventoId FROM AUDITORIA.ACCION_EVENTO
    WHERE AccionEvento = 'INSERCION';

    INSERT INTO AUDITORIA.HISTORIAL(FechaHora,AccionEventoId,Detalle,UsuarioRegistroId)
    SELECT  GETDATE(),
            @AccionEventoId,
            'Se ha insertado una nueva orden de produccion con No: ' +i.NoOrdenProduccion +', entregada al empleado'+ e.Nombre+', '+e.Apellido,
            i.UsuarioRegistroId
    FROM inserted AS i
    INNER JOIN RRHH.EMPLEADO AS e ON i.EmpleadoId = e.EmpleadoId
END 
GO
ALTER TABLE [BODEGA].[ORDEN_PRODUCCION] DISABLE TRIGGER [TgHistorialInsertOrdenProduccion]
GO
/****** Object:  Trigger [BODEGA].[TgHistorialUpdateOrdenProduccion]    Script Date: 8/6/2026 17:27:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Tg para cuando se se actualiza una orden de produccion, se guarda un registro en el historial
CREATE TRIGGER [BODEGA].[TgHistorialUpdateOrdenProduccion]
    ON [BODEGA].[ORDEN_PRODUCCION]
    AFTER UPDATE
AS
BEGIN
    DECLARE @AccionEventoId INT;
    SELECT TOP 1 @AccionEventoId = AccionEventoId FROM AUDITORIA.ACCION_EVENTO
    WHERE AccionEvento = 'ACTUALIZACION';

    INSERT INTO AUDITORIA.HISTORIAL(FechaHora,AccionEventoId,Detalle,UsuarioRegistroId)
    SELECT  GETDATE(),
            @AccionEventoId,
            'Se ha modificado una orden de produccion con No' + i.NoOrdenProduccion,
            i.UsuarioModificacionId
    FROM inserted AS i
END 
GO
ALTER TABLE [BODEGA].[ORDEN_PRODUCCION] DISABLE TRIGGER [TgHistorialUpdateOrdenProduccion]
GO
/****** Object:  Trigger [BODEGA].[TgIntentoDeleteOrdenProduccion]    Script Date: 8/6/2026 17:27:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Tg para cuando se intenta eliminar una orden de produccion, se guarda un registro en el historial
CREATE TRIGGER [BODEGA].[TgIntentoDeleteOrdenProduccion]
    ON [BODEGA].[ORDEN_PRODUCCION]
    INSTEAD OF DELETE
AS
BEGIN
    DECLARE @AccionEventoId INT;
    SELECT TOP 1 @AccionEventoId = AccionEventoId FROM AUDITORIA.ACCION_EVENTO
    WHERE AccionEvento = 'ELIMINACION';

    INSERT INTO AUDITORIA.HISTORIAL(FechaHora,AccionEventoId,Detalle,UsuarioRegistroId)
    SELECT  GETDATE(),
            @AccionEventoId,
            'Se ha intentado elimina una orden de produccion con id: ' + d.OrdenProduccionId,
            d.UsuarioModificacionId
    FROM deleted AS d
END
GO
ALTER TABLE [BODEGA].[ORDEN_PRODUCCION] DISABLE TRIGGER [TgIntentoDeleteOrdenProduccion]
GO
/****** Object:  Trigger [COMPRA].[TgAuditoriaInsertInventario]    Script Date: 8/6/2026 17:27:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- COMPRA.INVENTARIO
CREATE   TRIGGER [COMPRA].[TgAuditoriaInsertInventario] ON [COMPRA].[INVENTARIO] AFTER INSERT
AS
BEGIN
    INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
    SELECT GETDATE(), (SELECT AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'INSERCION'),
           'Nuevo producto: ' + i.NombreProducto, i.UsuarioRegistroId
    FROM inserted i;
END
GO
ALTER TABLE [COMPRA].[INVENTARIO] DISABLE TRIGGER [TgAuditoriaInsertInventario]
GO
/****** Object:  Trigger [COMPRA].[TgAuditoriaUpdateInventario]    Script Date: 8/6/2026 17:27:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   TRIGGER [COMPRA].[TgAuditoriaUpdateInventario] ON [COMPRA].[INVENTARIO] AFTER UPDATE
AS
BEGIN
    INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
    SELECT GETDATE(), 
           CASE WHEN i.EstadoId <> d.EstadoId AND i.EstadoId = (SELECT EstadoId FROM GLOBAL.ESTADO WHERE Estado = 'AGOTADO' AND EntidadId = (SELECT EntidadId FROM GLOBAL.ENTIDAD WHERE Entidad = 'INVENTARIO'))
                THEN (SELECT AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'ELIMINACION LOGICA')
                ELSE (SELECT AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'ACTUALIZACION')
           END,
           'Producto actualizado: ' + i.NombreProducto, i.UsuarioModificacionId
    FROM inserted i
    INNER JOIN deleted d ON i.InventarioId = d.InventarioId;
END
GO
ALTER TABLE [COMPRA].[INVENTARIO] DISABLE TRIGGER [TgAuditoriaUpdateInventario]
GO
/****** Object:  Trigger [COMPRA].[TgHistorialInsertInventario]    Script Date: 8/6/2026 17:27:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Triggers para inventario
-- Tg para cuando se inserta un articulo en el inventario, se guarda un registro en el historial
CREATE TRIGGER [COMPRA].[TgHistorialInsertInventario]
    ON [COMPRA].[INVENTARIO]
    AFTER INSERT
AS
BEGIN
    DECLARE @AccionEventoId INT;
    SELECT TOP 1 @AccionEventoId = AccionEventoId FROM AUDITORIA.ACCION_EVENTO
    WHERE AccionEvento = 'INSERCION';

    INSERT INTO AUDITORIA.HISTORIAL(FechaHora,AccionEventoId,Detalle,UsuarioRegistroId)
    SELECT  GETDATE(),
            @AccionEventoId,
            'Se ha insertado un nuevo producto con nombre: ' +i.NombreProducto + ', con la cantidad de: '+ i.Cantidad,
            i.UsuarioRegistroId
    FROM inserted AS i
END 
GO
ALTER TABLE [COMPRA].[INVENTARIO] DISABLE TRIGGER [TgHistorialInsertInventario]
GO
/****** Object:  Trigger [COMPRA].[TgHistorialUpdateInventario]    Script Date: 8/6/2026 17:27:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Tg para cuando se se actualiza un articulo en el inventario, se guarda un registro en el historial
CREATE TRIGGER [COMPRA].[TgHistorialUpdateInventario]
    ON [COMPRA].[INVENTARIO]
    AFTER UPDATE
AS
BEGIN
    DECLARE @AccionEventoId INT;
    SELECT TOP 1 @AccionEventoId = AccionEventoId FROM AUDITORIA.ACCION_EVENTO
    WHERE AccionEvento = 'ACTUALIZACION';

    INSERT INTO AUDITORIA.HISTORIAL(FechaHora,AccionEventoId,Detalle,UsuarioRegistroId)
    SELECT  GETDATE(),
            @AccionEventoId,
            'Se ha modificado un producto con id : ' +i.InventarioId+', con nombre: '+i.NombreProducto,
            i.UsuarioRegistroId
    FROM inserted AS i
END 
GO
ALTER TABLE [COMPRA].[INVENTARIO] DISABLE TRIGGER [TgHistorialUpdateInventario]
GO
/****** Object:  Trigger [COMPRA].[TgIntentoDeleteInventario]    Script Date: 8/6/2026 17:27:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Tg para cuando se intenta eliminar un articulo del inventario, se guarda un registro en el historial
CREATE TRIGGER [COMPRA].[TgIntentoDeleteInventario]
    ON [COMPRA].[INVENTARIO]
    INSTEAD OF DELETE
AS
BEGIN
    DECLARE @AccionEventoId INT;
    SELECT TOP 1 @AccionEventoId = AccionEventoId FROM AUDITORIA.ACCION_EVENTO
    WHERE AccionEvento = 'ELIMINACION';

    INSERT INTO AUDITORIA.HISTORIAL(FechaHora,AccionEventoId,Detalle,UsuarioRegistroId)
    SELECT  GETDATE(),
            @AccionEventoId,
            'Se ha intentado eliminar al empleado con id: ' + d.InventarioId,
            d.UsuarioModificacionId
    FROM deleted AS d
END
GO
ALTER TABLE [COMPRA].[INVENTARIO] DISABLE TRIGGER [TgIntentoDeleteInventario]
GO
/****** Object:  Trigger [RRHH].[TgAuditoriaInsertEmpleado]    Script Date: 8/6/2026 17:27:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- RRHH.EMPLEADO
CREATE   TRIGGER [RRHH].[TgAuditoriaInsertEmpleado] ON [RRHH].[EMPLEADO] AFTER INSERT
AS
BEGIN
    INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
    SELECT GETDATE(), (SELECT AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'INSERCION'),
           'Nuevo empleado: ' + i.Nombre + ' ' + i.Apellido, i.UsuarioRegistroId
    FROM inserted i;
END
GO
ALTER TABLE [RRHH].[EMPLEADO] DISABLE TRIGGER [TgAuditoriaInsertEmpleado]
GO
/****** Object:  Trigger [RRHH].[TgAuditoriaUpdateEmpleado]    Script Date: 8/6/2026 17:27:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   TRIGGER [RRHH].[TgAuditoriaUpdateEmpleado] ON [RRHH].[EMPLEADO] AFTER UPDATE
AS
BEGIN
    INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
    SELECT GETDATE(), 
           CASE WHEN i.EstadoId <> d.EstadoId AND i.EstadoId = (SELECT EstadoId FROM GLOBAL.ESTADO WHERE Estado = 'INACTIVO' AND EntidadId = (SELECT EntidadId FROM GLOBAL.ENTIDAD WHERE Entidad = 'EMPLEADO'))
                THEN (SELECT AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'ELIMINACION LOGICA')
                ELSE (SELECT AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'ACTUALIZACION')
           END,
           'Empleado actualizado: ' + i.Nombre + ' ' + i.Apellido, i.UsuarioModificacionId
    FROM inserted i
    INNER JOIN deleted d ON i.EmpleadoId = d.EmpleadoId;
END
GO
ALTER TABLE [RRHH].[EMPLEADO] DISABLE TRIGGER [TgAuditoriaUpdateEmpleado]
GO
/****** Object:  Trigger [RRHH].[TgHistorialInsertEmpleado]    Script Date: 8/6/2026 17:27:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Triggers para empleado
-- Tg para cuando se inserta un empleado, se guarda un registro en el historial
CREATE TRIGGER [RRHH].[TgHistorialInsertEmpleado]
    ON [RRHH].[EMPLEADO]
    AFTER INSERT
AS
BEGIN
    DECLARE @AccionEventoId INT;
    SELECT TOP 1 @AccionEventoId = AccionEventoId FROM AUDITORIA.ACCION_EVENTO
    WHERE AccionEvento = 'INSERCION';

    INSERT INTO AUDITORIA.HISTORIAL(FechaHora,AccionEventoId,Detalle,UsuarioRegistroId)
    SELECT  GETDATE(),
            @AccionEventoId,
            'Se ha insertado un nuevo empleado con nombre: ' +i.Nombre + ', ' +i.Apellido+',; con cargo de: '+ c.CargoId,
            i.UsuarioRegistroId
    FROM inserted AS i
    INNER JOIN RRHH.CARGO AS c
    ON i.CargoId = c.CargoId;
END 
GO
ALTER TABLE [RRHH].[EMPLEADO] DISABLE TRIGGER [TgHistorialInsertEmpleado]
GO
/****** Object:  Trigger [RRHH].[TgHistorialUpdateEmpleado]    Script Date: 8/6/2026 17:27:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Tg para cuando se se actualiza un empleado, se guarda un registro en el historial
CREATE TRIGGER [RRHH].[TgHistorialUpdateEmpleado]
    ON [RRHH].[EMPLEADO]
    AFTER UPDATE
AS
BEGIN
    DECLARE @AccionEventoId INT;
    SELECT TOP 1 @AccionEventoId = AccionEventoId FROM AUDITORIA.ACCION_EVENTO
    WHERE AccionEvento = 'ACTUALIZACION';

    INSERT INTO AUDITORIA.HISTORIAL(FechaHora,AccionEventoId,Detalle,UsuarioRegistroId)
    SELECT  GETDATE(),
            @AccionEventoId,
            'Se ha modificado el empleado con id: '+ i.EmpleadoId +', con nombre: ' + i.Nombre + ', ' +i.Apellido, 
            i.UsuarioModificacionId
    FROM inserted AS i
END 
GO
ALTER TABLE [RRHH].[EMPLEADO] DISABLE TRIGGER [TgHistorialUpdateEmpleado]
GO
/****** Object:  Trigger [RRHH].[TgIntentoDeleteEmpleado]    Script Date: 8/6/2026 17:27:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Tg para cuando se intenta eliminar un empleado, se guarda un registro en el historial
CREATE TRIGGER [RRHH].[TgIntentoDeleteEmpleado]
    ON [RRHH].[EMPLEADO]
    INSTEAD OF DELETE
AS
BEGIN
    DECLARE @AccionEventoId INT;
    SELECT TOP 1 @AccionEventoId = AccionEventoId FROM AUDITORIA.ACCION_EVENTO
    WHERE AccionEvento = 'ELIMINACION';

    INSERT INTO AUDITORIA.HISTORIAL(FechaHora,AccionEventoId,Detalle,UsuarioRegistroId)
    SELECT  GETDATE(),
            @AccionEventoId,
            'Se ha intentado eliminar al empleado con id: ' + d.EmpleadoId,
            d.UsuarioModificacionId
    FROM deleted AS d
END
GO
ALTER TABLE [RRHH].[EMPLEADO] DISABLE TRIGGER [TgIntentoDeleteEmpleado]
GO
/****** Object:  Trigger [VENTA].[TgAuditoriaInsertOrden]    Script Date: 8/6/2026 17:27:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Triggers para VENTA.ORDEN
CREATE   TRIGGER [VENTA].[TgAuditoriaInsertOrden] ON [VENTA].[ORDEN] AFTER INSERT
AS
BEGIN
    INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
    SELECT GETDATE(), (SELECT AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'INSERCION'),
           'Nueva orden ID: ' + CAST(i.OrdenId AS VARCHAR), i.UsuarioRegistroId
    FROM inserted i;
END
GO
ALTER TABLE [VENTA].[ORDEN] DISABLE TRIGGER [TgAuditoriaInsertOrden]
GO
/****** Object:  Trigger [VENTA].[TgAuditoriaUpdateOrden]    Script Date: 8/6/2026 17:27:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   TRIGGER [VENTA].[TgAuditoriaUpdateOrden] ON [VENTA].[ORDEN] AFTER UPDATE
AS
BEGIN
    INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
    SELECT GETDATE(), 
           CASE WHEN i.EstadoId <> d.EstadoId AND i.EstadoId = (SELECT EstadoId FROM GLOBAL.ESTADO WHERE Estado = 'CANCELADA' AND EntidadId = (SELECT EntidadId FROM GLOBAL.ENTIDAD WHERE Entidad = 'ORDEN'))
                THEN (SELECT AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'ELIMINACION LOGICA')
                ELSE (SELECT AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'ACTUALIZACION')
           END,
           'Orden ID ' + CAST(i.OrdenId AS VARCHAR) + ' actualizada', i.UsuarioRegistroId
    FROM inserted i
    INNER JOIN deleted d ON i.OrdenId = d.OrdenId;
END
GO
ALTER TABLE [VENTA].[ORDEN] DISABLE TRIGGER [TgAuditoriaUpdateOrden]
GO
USE [master]
GO
ALTER DATABASE [PUPUSERIA] SET  READ_WRITE 
GO

USE [PUPUSERIA]
GO

-- ============================================================
-- AUDITORIA AUTOMATICA V2
-- Seccion final de reemplazo: columnas, SPs y triggers limpios.
-- Compatible con SQL Server 2016+.
-- ============================================================

IF COL_LENGTH('COMPRA.PROVEEDOR', 'UsuarioRegistroId') IS NULL
    ALTER TABLE COMPRA.PROVEEDOR ADD UsuarioRegistroId INT NULL
GO
IF COL_LENGTH('COMPRA.PROVEEDOR', 'UsuarioModificacionId') IS NULL
    ALTER TABLE COMPRA.PROVEEDOR ADD UsuarioModificacionId INT NULL
GO
IF COL_LENGTH('VENTA.CLIENTE', 'UsuarioRegistroId') IS NULL
    ALTER TABLE VENTA.CLIENTE ADD UsuarioRegistroId INT NULL
GO
IF COL_LENGTH('VENTA.CLIENTE', 'UsuarioModificacionId') IS NULL
    ALTER TABLE VENTA.CLIENTE ADD UsuarioModificacionId INT NULL
GO
IF COL_LENGTH('DELIVERY.REPARTIDOR', 'UsuarioRegistroId') IS NULL
    ALTER TABLE DELIVERY.REPARTIDOR ADD UsuarioRegistroId INT NULL
GO
IF COL_LENGTH('DELIVERY.REPARTIDOR', 'UsuarioModificacionId') IS NULL
    ALTER TABLE DELIVERY.REPARTIDOR ADD UsuarioModificacionId INT NULL
GO
IF COL_LENGTH('AUDITORIA.HISTORIAL', 'Detalle') IS NOT NULL
    ALTER TABLE AUDITORIA.HISTORIAL ALTER COLUMN Detalle VARCHAR(200) NULL
GO

IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_PROVEEDOR_UsuarioRegistro')
    ALTER TABLE COMPRA.PROVEEDOR WITH CHECK ADD CONSTRAINT FK_PROVEEDOR_UsuarioRegistro
    FOREIGN KEY (UsuarioRegistroId) REFERENCES AUTENTICACION.USUARIO(UsuarioId)
GO
IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_PROVEEDOR_UsuarioModificacion')
    ALTER TABLE COMPRA.PROVEEDOR WITH CHECK ADD CONSTRAINT FK_PROVEEDOR_UsuarioModificacion
    FOREIGN KEY (UsuarioModificacionId) REFERENCES AUTENTICACION.USUARIO(UsuarioId)
GO
IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_CLIENTE_UsuarioRegistro')
    ALTER TABLE VENTA.CLIENTE WITH CHECK ADD CONSTRAINT FK_CLIENTE_UsuarioRegistro
    FOREIGN KEY (UsuarioRegistroId) REFERENCES AUTENTICACION.USUARIO(UsuarioId)
GO
IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_CLIENTE_UsuarioModificacion')
    ALTER TABLE VENTA.CLIENTE WITH CHECK ADD CONSTRAINT FK_CLIENTE_UsuarioModificacion
    FOREIGN KEY (UsuarioModificacionId) REFERENCES AUTENTICACION.USUARIO(UsuarioId)
GO
IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_REPARTIDOR_UsuarioRegistro')
    ALTER TABLE DELIVERY.REPARTIDOR WITH CHECK ADD CONSTRAINT FK_REPARTIDOR_UsuarioRegistro
    FOREIGN KEY (UsuarioRegistroId) REFERENCES AUTENTICACION.USUARIO(UsuarioId)
GO
IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_REPARTIDOR_UsuarioModificacion')
    ALTER TABLE DELIVERY.REPARTIDOR WITH CHECK ADD CONSTRAINT FK_REPARTIDOR_UsuarioModificacion
    FOREIGN KEY (UsuarioModificacionId) REFERENCES AUTENTICACION.USUARIO(UsuarioId)
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_HISTORIAL_FechaHora' AND object_id = OBJECT_ID(N'AUDITORIA.HISTORIAL'))
    CREATE NONCLUSTERED INDEX IX_HISTORIAL_FechaHora ON AUDITORIA.HISTORIAL(FechaHora DESC)
GO
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_HISTORIAL_Accion_FechaHora' AND object_id = OBJECT_ID(N'AUDITORIA.HISTORIAL'))
    CREATE NONCLUSTERED INDEX IX_HISTORIAL_Accion_FechaHora ON AUDITORIA.HISTORIAL(AccionEventoId, FechaHora DESC)
GO
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_HISTORIAL_Usuario_FechaHora' AND object_id = OBJECT_ID(N'AUDITORIA.HISTORIAL'))
    CREATE NONCLUSTERED INDEX IX_HISTORIAL_Usuario_FechaHora ON AUDITORIA.HISTORIAL(UsuarioRegistroId, FechaHora DESC)
GO

IF OBJECT_ID(N'AUDITORIA.SpInsertHistorial', N'P') IS NOT NULL DROP PROCEDURE AUDITORIA.SpInsertHistorial
GO
CREATE PROCEDURE AUDITORIA.SpInsertHistorial
    @AccionEventoId INT,
    @Detalle VARCHAR(200),
    @UsuarioRegistroId INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM AUTENTICACION.USUARIO WHERE UsuarioId = @UsuarioRegistroId)
        RAISERROR('El usuario ingresado no existe.', 16, 1);
    ELSE IF @Detalle IS NULL OR LTRIM(RTRIM(@Detalle)) = ''
        RAISERROR('El detalle del historial no puede estar vacio.', 16, 1);
    ELSE
        INSERT INTO AUDITORIA.HISTORIAL (FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
        VALUES (GETDATE(), @AccionEventoId, LEFT(@Detalle, 200), @UsuarioRegistroId);
END
GO

CREATE TRIGGER VENTA.TgAuditCliente
ON VENTA.CLIENTE
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Ins INT, @Upd INT, @DelLog INT, @Del INT, @UsuarioSistemaId INT, @EstadoInactivo INT;
    SELECT @Ins = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'INSERCION';
    SELECT @Upd = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'ACTUALIZACION';
    SELECT @DelLog = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'ELIMINACION LOGICA';
    SELECT @Del = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'ELIMINACION';
    SELECT TOP 1 @UsuarioSistemaId = UsuarioId FROM AUTENTICACION.USUARIO ORDER BY UsuarioId;
    SELECT @EstadoInactivo = es.EstadoId
    FROM GLOBAL.ESTADO es
    INNER JOIN GLOBAL.ENTIDAD en ON es.EntidadId = en.EntidadId
    WHERE en.Entidad = 'CLIENTE' AND es.Estado = 'INACTIVO';

    IF EXISTS(SELECT 1 FROM inserted) AND NOT EXISTS(SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
        SELECT GETDATE(), @Ins,
               LEFT(CONCAT('Nuevo cliente: ', i.NombreCompleto, ' (ID: ', i.ClienteId, ')'), 200),
               COALESCE(NULLIF(i.UsuarioRegistroId, 0), @UsuarioSistemaId)
        FROM inserted i;
        RETURN;
    END

    IF EXISTS(SELECT 1 FROM inserted) AND EXISTS(SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
        SELECT GETDATE(),
               CASE WHEN ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1) AND i.EstadoId = @EstadoInactivo THEN @DelLog ELSE @Upd END,
               LEFT(CASE WHEN ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1) AND i.EstadoId = @EstadoInactivo
                        THEN CONCAT('Cliente desactivado: ', i.NombreCompleto, ' (ID: ', i.ClienteId, ')')
                        ELSE CONCAT('Cliente ', i.NombreCompleto, ' modificado: ',
                            CASE WHEN ISNULL(i.Nombre, '') <> ISNULL(d.Nombre, '') THEN CONCAT('Nombre: ', d.Nombre, ' a ', i.Nombre, '; ') ELSE '' END,
                            CASE WHEN ISNULL(i.Apellido, '') <> ISNULL(d.Apellido, '') THEN CONCAT('Apellido: ', d.Apellido, ' a ', i.Apellido, '; ') ELSE '' END,
                            CASE WHEN ISNULL(i.Telefono, '') <> ISNULL(d.Telefono, '') THEN CONCAT('Telefono: ', d.Telefono, ' a ', i.Telefono, '; ') ELSE '' END,
                            CASE WHEN ISNULL(i.DireccionId, -1) <> ISNULL(d.DireccionId, -1) THEN CONCAT('DireccionId: ', d.DireccionId, ' a ', i.DireccionId, '; ') ELSE '' END,
                            CASE WHEN ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1) THEN CONCAT('Estado: ', ISNULL(eo.Estado, 'NULL'), ' a ', ISNULL(en.Estado, 'NULL'), '; ') ELSE '' END)
                    END, 200),
               COALESCE(NULLIF(i.UsuarioModificacionId, 0), NULLIF(i.UsuarioRegistroId, 0), @UsuarioSistemaId)
        FROM inserted i
        INNER JOIN deleted d ON i.ClienteId = d.ClienteId
        LEFT JOIN GLOBAL.ESTADO eo ON d.EstadoId = eo.EstadoId
        LEFT JOIN GLOBAL.ESTADO en ON i.EstadoId = en.EstadoId
        WHERE ISNULL(i.Nombre, '') <> ISNULL(d.Nombre, '')
           OR ISNULL(i.Apellido, '') <> ISNULL(d.Apellido, '')
           OR ISNULL(i.Telefono, '') <> ISNULL(d.Telefono, '')
           OR ISNULL(i.DireccionId, -1) <> ISNULL(d.DireccionId, -1)
           OR ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1);
        RETURN;
    END

    IF EXISTS(SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
        SELECT GETDATE(), @Del,
               LEFT(CONCAT('Cliente eliminado fisicamente: ', d.NombreCompleto, ' (ID: ', d.ClienteId, ')'), 200),
               COALESCE(NULLIF(d.UsuarioModificacionId, 0), NULLIF(d.UsuarioRegistroId, 0), @UsuarioSistemaId)
        FROM deleted d;
    END
END
GO

CREATE TRIGGER DELIVERY.TgAuditRepartidor
ON DELIVERY.REPARTIDOR
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Ins INT, @Upd INT, @DelLog INT, @Del INT, @UsuarioSistemaId INT, @EstadoNoDisponible INT;
    SELECT @Ins = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'INSERCION';
    SELECT @Upd = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'ACTUALIZACION';
    SELECT @DelLog = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'ELIMINACION LOGICA';
    SELECT @Del = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'ELIMINACION';
    SELECT TOP 1 @UsuarioSistemaId = UsuarioId FROM AUTENTICACION.USUARIO ORDER BY UsuarioId;
    SELECT @EstadoNoDisponible = es.EstadoId
    FROM GLOBAL.ESTADO es
    INNER JOIN GLOBAL.ENTIDAD en ON es.EntidadId = en.EntidadId
    WHERE en.Entidad = 'REPARTIDOR' AND es.Estado = 'NO DISPONIBLE';

    IF EXISTS(SELECT 1 FROM inserted) AND NOT EXISTS(SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
        SELECT GETDATE(), @Ins,
               LEFT(CONCAT('Nuevo repartidor: ', e.Nombre, ' ', e.Apellido, ' (ID: ', i.RepartidorId, ', Placa: ', i.NoPlacaMoto, ')'), 200),
               COALESCE(NULLIF(i.UsuarioRegistroId, 0), @UsuarioSistemaId)
        FROM inserted i
        INNER JOIN RRHH.EMPLEADO e ON i.EmpleadoId = e.EmpleadoId;
        RETURN;
    END

    IF EXISTS(SELECT 1 FROM inserted) AND EXISTS(SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
        SELECT GETDATE(),
               CASE WHEN ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1) AND i.EstadoId = @EstadoNoDisponible THEN @DelLog ELSE @Upd END,
               LEFT(CASE WHEN ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1) AND i.EstadoId = @EstadoNoDisponible
                        THEN CONCAT('Repartidor desactivado: ', e.Nombre, ' ', e.Apellido, ' (ID: ', i.RepartidorId, ')')
                        ELSE CONCAT('Repartidor ', e.Nombre, ' ', e.Apellido, ' modificado: ',
                            CASE WHEN ISNULL(i.EmpleadoId, -1) <> ISNULL(d.EmpleadoId, -1) THEN CONCAT('EmpleadoId: ', d.EmpleadoId, ' a ', i.EmpleadoId, '; ') ELSE '' END,
                            CASE WHEN ISNULL(i.NoPlacaMoto, '') <> ISNULL(d.NoPlacaMoto, '') THEN CONCAT('Placa: ', d.NoPlacaMoto, ' a ', i.NoPlacaMoto, '; ') ELSE '' END,
                            CASE WHEN ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1) THEN CONCAT('Estado: ', ISNULL(eo.Estado, 'NULL'), ' a ', ISNULL(en.Estado, 'NULL'), '; ') ELSE '' END)
                    END, 200),
               COALESCE(NULLIF(i.UsuarioModificacionId, 0), NULLIF(i.UsuarioRegistroId, 0), @UsuarioSistemaId)
        FROM inserted i
        INNER JOIN deleted d ON i.RepartidorId = d.RepartidorId
        INNER JOIN RRHH.EMPLEADO e ON i.EmpleadoId = e.EmpleadoId
        LEFT JOIN GLOBAL.ESTADO eo ON d.EstadoId = eo.EstadoId
        LEFT JOIN GLOBAL.ESTADO en ON i.EstadoId = en.EstadoId
        WHERE ISNULL(i.EmpleadoId, -1) <> ISNULL(d.EmpleadoId, -1)
           OR ISNULL(i.NoPlacaMoto, '') <> ISNULL(d.NoPlacaMoto, '')
           OR ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1);
        RETURN;
    END

    IF EXISTS(SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
        SELECT GETDATE(), @Del,
               LEFT(CONCAT('Repartidor eliminado fisicamente: ', e.Nombre, ' ', e.Apellido, ' (ID: ', d.RepartidorId, ')'), 200),
               COALESCE(NULLIF(d.UsuarioModificacionId, 0), NULLIF(d.UsuarioRegistroId, 0), @UsuarioSistemaId)
        FROM deleted d
        INNER JOIN RRHH.EMPLEADO e ON d.EmpleadoId = e.EmpleadoId;
    END
END
GO

CREATE TRIGGER COMPRA.TgAuditInventario
ON COMPRA.INVENTARIO
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Ins INT, @Upd INT, @DelLog INT, @Del INT, @UsuarioSistemaId INT, @EstadoAgotado INT;
    SELECT @Ins = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'INSERCION';
    SELECT @Upd = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'ACTUALIZACION';
    SELECT @DelLog = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'ELIMINACION LOGICA';
    SELECT @Del = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'ELIMINACION';
    SELECT TOP 1 @UsuarioSistemaId = UsuarioId FROM AUTENTICACION.USUARIO ORDER BY UsuarioId;
    SELECT @EstadoAgotado = es.EstadoId
    FROM GLOBAL.ESTADO es
    INNER JOIN GLOBAL.ENTIDAD en ON es.EntidadId = en.EntidadId
    WHERE en.Entidad = 'INVENTARIO' AND es.Estado = 'AGOTADO';

    IF EXISTS(SELECT 1 FROM inserted) AND NOT EXISTS(SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
        SELECT GETDATE(), @Ins,
               LEFT(CONCAT('Nuevo producto de inventario: ', i.NombreProducto, ' (ID: ', i.InventarioId, ')'), 200),
               COALESCE(NULLIF(i.UsuarioRegistroId, 0), @UsuarioSistemaId)
        FROM inserted i;
        RETURN;
    END

    IF EXISTS(SELECT 1 FROM inserted) AND EXISTS(SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
        SELECT GETDATE(),
               CASE WHEN ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1) AND i.EstadoId = @EstadoAgotado THEN @DelLog ELSE @Upd END,
               LEFT(CASE WHEN ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1) AND i.EstadoId = @EstadoAgotado
                        THEN CONCAT('Producto agotado/desactivado: ', i.NombreProducto, ' (ID: ', i.InventarioId, ')')
                        ELSE CONCAT('Inventario ', i.NombreProducto, ' modificado: ',
                            CASE WHEN ISNULL(i.NombreProducto, '') <> ISNULL(d.NombreProducto, '') THEN CONCAT('Producto: ', d.NombreProducto, ' a ', i.NombreProducto, '; ') ELSE '' END,
                            CASE WHEN ISNULL(i.UnidadDeMedida, '') <> ISNULL(d.UnidadDeMedida, '') THEN CONCAT('Unidad: ', ISNULL(d.UnidadDeMedida, 'NULL'), ' a ', ISNULL(i.UnidadDeMedida, 'NULL'), '; ') ELSE '' END,
                            CASE WHEN ISNULL(i.Cantidad, -1) <> ISNULL(d.Cantidad, -1) THEN CONCAT('Cantidad: ', d.Cantidad, ' a ', i.Cantidad, '; ') ELSE '' END,
                            CASE WHEN ISNULL(i.PrecioCosto, -1) <> ISNULL(d.PrecioCosto, -1) THEN CONCAT('PrecioCosto: ', d.PrecioCosto, ' a ', i.PrecioCosto, '; ') ELSE '' END,
                            CASE WHEN ISNULL(i.TipoInventarioId, -1) <> ISNULL(d.TipoInventarioId, -1) THEN CONCAT('TipoInventarioId: ', d.TipoInventarioId, ' a ', i.TipoInventarioId, '; ') ELSE '' END,
                            CASE WHEN ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1) THEN CONCAT('Estado: ', ISNULL(eo.Estado, 'NULL'), ' a ', ISNULL(en.Estado, 'NULL'), '; ') ELSE '' END)
                    END, 200),
               COALESCE(NULLIF(i.UsuarioModificacionId, 0), NULLIF(i.UsuarioRegistroId, 0), @UsuarioSistemaId)
        FROM inserted i
        INNER JOIN deleted d ON i.InventarioId = d.InventarioId
        LEFT JOIN GLOBAL.ESTADO eo ON d.EstadoId = eo.EstadoId
        LEFT JOIN GLOBAL.ESTADO en ON i.EstadoId = en.EstadoId
        WHERE ISNULL(i.NombreProducto, '') <> ISNULL(d.NombreProducto, '')
           OR ISNULL(i.UnidadDeMedida, '') <> ISNULL(d.UnidadDeMedida, '')
           OR ISNULL(i.Cantidad, -1) <> ISNULL(d.Cantidad, -1)
           OR ISNULL(i.PrecioCosto, -1) <> ISNULL(d.PrecioCosto, -1)
           OR ISNULL(i.TipoInventarioId, -1) <> ISNULL(d.TipoInventarioId, -1)
           OR ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1);
        RETURN;
    END

    IF EXISTS(SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
        SELECT GETDATE(), @Del,
               LEFT(CONCAT('Inventario eliminado fisicamente: ', d.NombreProducto, ' (ID: ', d.InventarioId, ')'), 200),
               COALESCE(NULLIF(d.UsuarioModificacionId, 0), NULLIF(d.UsuarioRegistroId, 0), @UsuarioSistemaId)
        FROM deleted d;
    END
END
GO

CREATE TRIGGER VENTA.TgAuditOrden
ON VENTA.ORDEN
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Ins INT, @Upd INT, @DelLog INT, @Del INT, @UsuarioSistemaId INT, @EstadoCancelada INT;
    SELECT @Ins = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'INSERCION';
    SELECT @Upd = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'ACTUALIZACION';
    SELECT @DelLog = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'ELIMINACION LOGICA';
    SELECT @Del = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'ELIMINACION';
    SELECT TOP 1 @UsuarioSistemaId = UsuarioId FROM AUTENTICACION.USUARIO ORDER BY UsuarioId;
    SELECT @EstadoCancelada = es.EstadoId
    FROM GLOBAL.ESTADO es
    INNER JOIN GLOBAL.ENTIDAD en ON es.EntidadId = en.EntidadId
    WHERE en.Entidad = 'ORDEN' AND es.Estado = 'CANCELADA';

    IF EXISTS(SELECT 1 FROM inserted) AND NOT EXISTS(SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
        SELECT GETDATE(), @Ins,
               LEFT(CONCAT('Nueva orden ID: ', i.OrdenId, ', total: ', i.Total), 200),
               COALESCE(NULLIF(i.UsuarioRegistroId, 0), @UsuarioSistemaId)
        FROM inserted i;
        RETURN;
    END

    IF EXISTS(SELECT 1 FROM inserted) AND EXISTS(SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
        SELECT GETDATE(),
               CASE WHEN ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1) AND i.EstadoId = @EstadoCancelada THEN @DelLog ELSE @Upd END,
               LEFT(CASE WHEN ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1) AND i.EstadoId = @EstadoCancelada
                        THEN CONCAT('Orden cancelada: ID ', i.OrdenId)
                        ELSE CONCAT('Orden ID ', i.OrdenId, ' modificada: ',
                            CASE WHEN ISNULL(i.Total, -1) <> ISNULL(d.Total, -1) THEN CONCAT('Total: ', d.Total, ' a ', i.Total, '; ') ELSE '' END,
                            CASE WHEN ISNULL(i.ClienteId, -1) <> ISNULL(d.ClienteId, -1) THEN CONCAT('ClienteId: ', d.ClienteId, ' a ', i.ClienteId, '; ') ELSE '' END,
                            CASE WHEN ISNULL(i.TipoOrdenId, -1) <> ISNULL(d.TipoOrdenId, -1) THEN CONCAT('TipoOrdenId: ', d.TipoOrdenId, ' a ', i.TipoOrdenId, '; ') ELSE '' END,
                            CASE WHEN ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1) THEN CONCAT('Estado: ', ISNULL(eo.Estado, 'NULL'), ' a ', ISNULL(en.Estado, 'NULL'), '; ') ELSE '' END)
                    END, 200),
               COALESCE(NULLIF(i.UsuarioRegistroId, 0), @UsuarioSistemaId)
        FROM inserted i
        INNER JOIN deleted d ON i.OrdenId = d.OrdenId
        LEFT JOIN GLOBAL.ESTADO eo ON d.EstadoId = eo.EstadoId
        LEFT JOIN GLOBAL.ESTADO en ON i.EstadoId = en.EstadoId
        WHERE ISNULL(i.Total, -1) <> ISNULL(d.Total, -1)
           OR ISNULL(i.ClienteId, -1) <> ISNULL(d.ClienteId, -1)
           OR ISNULL(i.TipoOrdenId, -1) <> ISNULL(d.TipoOrdenId, -1)
           OR ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1);
        RETURN;
    END

    IF EXISTS(SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
        SELECT GETDATE(), @Del,
               LEFT(CONCAT('Orden eliminada fisicamente: ID ', d.OrdenId), 200),
               COALESCE(NULLIF(d.UsuarioRegistroId, 0), @UsuarioSistemaId)
        FROM deleted d;
    END
END
GO

CREATE TRIGGER VENTA.TgAuditVenta
ON VENTA.VENTA
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Ins INT, @Upd INT, @DelLog INT, @Del INT, @UsuarioSistemaId INT, @EstadoAnulada INT;
    SELECT @Ins = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'INSERCION';
    SELECT @Upd = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'ACTUALIZACION';
    SELECT @DelLog = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'ELIMINACION LOGICA';
    SELECT @Del = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'ELIMINACION';
    SELECT TOP 1 @UsuarioSistemaId = UsuarioId FROM AUTENTICACION.USUARIO ORDER BY UsuarioId;
    SELECT @EstadoAnulada = es.EstadoId
    FROM GLOBAL.ESTADO es
    INNER JOIN GLOBAL.ENTIDAD en ON es.EntidadId = en.EntidadId
    WHERE en.Entidad = 'VENTA' AND es.Estado = 'ANULADA';

    IF EXISTS(SELECT 1 FROM inserted) AND NOT EXISTS(SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
        SELECT GETDATE(), @Ins,
               LEFT(CONCAT('Nueva venta: ', i.NoDocumento, ' (ID: ', i.VentaId, ', Orden: ', i.OrdenId, ')'), 200),
               COALESCE(NULLIF(o.UsuarioRegistroId, 0), @UsuarioSistemaId)
        FROM inserted i
        LEFT JOIN VENTA.ORDEN o ON i.OrdenId = o.OrdenId;
        RETURN;
    END

    IF EXISTS(SELECT 1 FROM inserted) AND EXISTS(SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
        SELECT GETDATE(),
               CASE WHEN ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1) AND i.EstadoId = @EstadoAnulada THEN @DelLog ELSE @Upd END,
               LEFT(CASE WHEN ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1) AND i.EstadoId = @EstadoAnulada
                        THEN CONCAT('Venta anulada: ', i.NoDocumento, ' (ID: ', i.VentaId, ')')
                        ELSE CONCAT('Venta ', i.NoDocumento, ' modificada: ',
                            CASE WHEN ISNULL(i.MetodoPago, '') <> ISNULL(d.MetodoPago, '') THEN CONCAT('MetodoPago: ', ISNULL(d.MetodoPago, 'NULL'), ' a ', ISNULL(i.MetodoPago, 'NULL'), '; ') ELSE '' END,
                            CASE WHEN ISNULL(i.MontoRecibido, -1) <> ISNULL(d.MontoRecibido, -1) THEN CONCAT('MontoRecibido: ', ISNULL(CAST(d.MontoRecibido AS VARCHAR(30)), 'NULL'), ' a ', ISNULL(CAST(i.MontoRecibido AS VARCHAR(30)), 'NULL'), '; ') ELSE '' END,
                            CASE WHEN ISNULL(i.Cambio, -1) <> ISNULL(d.Cambio, -1) THEN CONCAT('Cambio: ', ISNULL(CAST(d.Cambio AS VARCHAR(30)), 'NULL'), ' a ', ISNULL(CAST(i.Cambio AS VARCHAR(30)), 'NULL'), '; ') ELSE '' END,
                            CASE WHEN ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1) THEN CONCAT('Estado: ', ISNULL(eo.Estado, 'NULL'), ' a ', ISNULL(en.Estado, 'NULL'), '; ') ELSE '' END)
                    END, 200),
               COALESCE(NULLIF(o.UsuarioRegistroId, 0), @UsuarioSistemaId)
        FROM inserted i
        INNER JOIN deleted d ON i.VentaId = d.VentaId
        LEFT JOIN VENTA.ORDEN o ON i.OrdenId = o.OrdenId
        LEFT JOIN GLOBAL.ESTADO eo ON d.EstadoId = eo.EstadoId
        LEFT JOIN GLOBAL.ESTADO en ON i.EstadoId = en.EstadoId
        WHERE ISNULL(i.MetodoPago, '') <> ISNULL(d.MetodoPago, '')
           OR ISNULL(i.MontoRecibido, -1) <> ISNULL(d.MontoRecibido, -1)
           OR ISNULL(i.Cambio, -1) <> ISNULL(d.Cambio, -1)
           OR ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1);
        RETURN;
    END

    IF EXISTS(SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
        SELECT GETDATE(), @Del,
               LEFT(CONCAT('Venta eliminada fisicamente: ', d.NoDocumento, ' (ID: ', d.VentaId, ')'), 200),
               COALESCE(NULLIF(o.UsuarioRegistroId, 0), @UsuarioSistemaId)
        FROM deleted d
        LEFT JOIN VENTA.ORDEN o ON d.OrdenId = o.OrdenId;
    END
END
GO

CREATE TRIGGER DELIVERY.TgAuditEnvio
ON DELIVERY.ENVIO
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Ins INT, @Upd INT, @DelLog INT, @Del INT, @UsuarioSistemaId INT, @EstadoCancelado INT;
    SELECT @Ins = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'INSERCION';
    SELECT @Upd = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'ACTUALIZACION';
    SELECT @DelLog = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'ELIMINACION LOGICA';
    SELECT @Del = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'ELIMINACION';
    SELECT TOP 1 @UsuarioSistemaId = UsuarioId FROM AUTENTICACION.USUARIO ORDER BY UsuarioId;
    SELECT @EstadoCancelado = es.EstadoId
    FROM GLOBAL.ESTADO es
    INNER JOIN GLOBAL.ENTIDAD en ON es.EntidadId = en.EntidadId
    WHERE en.Entidad = 'ENVIO' AND es.Estado = 'CANCELADO';

    IF EXISTS(SELECT 1 FROM inserted) AND NOT EXISTS(SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
        SELECT GETDATE(), @Ins,
               LEFT(CONCAT('Nuevo envio ID: ', i.EnvioId, ' para orden ', i.OrdenId), 200),
               COALESCE(NULLIF(o.UsuarioRegistroId, 0), @UsuarioSistemaId)
        FROM inserted i
        LEFT JOIN VENTA.ORDEN o ON i.OrdenId = o.OrdenId;
        RETURN;
    END

    IF EXISTS(SELECT 1 FROM inserted) AND EXISTS(SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
        SELECT GETDATE(),
               CASE WHEN ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1) AND i.EstadoId = @EstadoCancelado THEN @DelLog ELSE @Upd END,
               LEFT(CASE WHEN ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1) AND i.EstadoId = @EstadoCancelado
                        THEN CONCAT('Envio cancelado: ID ', i.EnvioId, ' orden ', i.OrdenId)
                        ELSE CONCAT('Envio ID ', i.EnvioId, ' modificado: ',
                            CASE WHEN ISNULL(i.RepartidorId, -1) <> ISNULL(d.RepartidorId, -1) THEN CONCAT('RepartidorId: ', d.RepartidorId, ' a ', i.RepartidorId, '; ') ELSE '' END,
                            CASE WHEN ISNULL(i.DireccionId, -1) <> ISNULL(d.DireccionId, -1) THEN CONCAT('DireccionId: ', d.DireccionId, ' a ', i.DireccionId, '; ') ELSE '' END,
                            CASE WHEN ISNULL(i.Tarifa, -1) <> ISNULL(d.Tarifa, -1) THEN CONCAT('Tarifa: ', d.Tarifa, ' a ', i.Tarifa, '; ') ELSE '' END,
                            CASE WHEN ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1) THEN CONCAT('Estado: ', ISNULL(eo.Estado, 'NULL'), ' a ', ISNULL(en.Estado, 'NULL'), '; ') ELSE '' END)
                    END, 200),
               COALESCE(NULLIF(o.UsuarioRegistroId, 0), @UsuarioSistemaId)
        FROM inserted i
        INNER JOIN deleted d ON i.EnvioId = d.EnvioId
        LEFT JOIN VENTA.ORDEN o ON i.OrdenId = o.OrdenId
        LEFT JOIN GLOBAL.ESTADO eo ON d.EstadoId = eo.EstadoId
        LEFT JOIN GLOBAL.ESTADO en ON i.EstadoId = en.EstadoId
        WHERE ISNULL(i.RepartidorId, -1) <> ISNULL(d.RepartidorId, -1)
           OR ISNULL(i.DireccionId, -1) <> ISNULL(d.DireccionId, -1)
           OR ISNULL(i.Tarifa, -1) <> ISNULL(d.Tarifa, -1)
           OR ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1);
        RETURN;
    END

    IF EXISTS(SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
        SELECT GETDATE(), @Del,
               LEFT(CONCAT('Envio eliminado fisicamente: ID ', d.EnvioId, ' orden ', d.OrdenId), 200),
               COALESCE(NULLIF(o.UsuarioRegistroId, 0), @UsuarioSistemaId)
        FROM deleted d
        LEFT JOIN VENTA.ORDEN o ON d.OrdenId = o.OrdenId;
    END
END
GO

CREATE TRIGGER DELIVERY.TgAuditDireccion
ON DELIVERY.DIRECCION
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Ins INT, @Upd INT, @DelLog INT, @Del INT, @UsuarioSistemaId INT, @EstadoInactivo INT;
    SELECT @Ins = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'INSERCION';
    SELECT @Upd = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'ACTUALIZACION';
    SELECT @DelLog = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'ELIMINACION LOGICA';
    SELECT @Del = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'ELIMINACION';
    SELECT TOP 1 @UsuarioSistemaId = UsuarioId FROM AUTENTICACION.USUARIO ORDER BY UsuarioId;
    SELECT @EstadoInactivo = es.EstadoId
    FROM GLOBAL.ESTADO es
    INNER JOIN GLOBAL.ENTIDAD en ON es.EntidadId = en.EntidadId
    WHERE en.Entidad = 'DIRECCION' AND es.Estado = 'INACTIVO';

    IF EXISTS(SELECT 1 FROM inserted) AND NOT EXISTS(SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
        SELECT GETDATE(), @Ins,
               LEFT(CONCAT('Nueva direccion ID: ', i.DireccionId, ', municipio ', i.MunicipioId), 200),
               @UsuarioSistemaId
        FROM inserted i;
        RETURN;
    END

    IF EXISTS(SELECT 1 FROM inserted) AND EXISTS(SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
        SELECT GETDATE(),
               CASE WHEN ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1) AND i.EstadoId = @EstadoInactivo THEN @DelLog ELSE @Upd END,
               LEFT(CASE WHEN ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1) AND i.EstadoId = @EstadoInactivo
                        THEN CONCAT('Direccion desactivada: ID ', i.DireccionId)
                        ELSE CONCAT('Direccion ID ', i.DireccionId, ' modificada: ',
                            CASE WHEN ISNULL(i.MunicipioId, -1) <> ISNULL(d.MunicipioId, -1) THEN CONCAT('MunicipioId: ', d.MunicipioId, ' a ', i.MunicipioId, '; ') ELSE '' END,
                            CASE WHEN ISNULL(i.ColoniBarrio, '') <> ISNULL(d.ColoniBarrio, '') THEN 'Colonia/Barrio modificada; ' ELSE '' END,
                            CASE WHEN ISNULL(i.NoCasa, '') <> ISNULL(d.NoCasa, '') THEN CONCAT('NoCasa: ', ISNULL(d.NoCasa, 'NULL'), ' a ', ISNULL(i.NoCasa, 'NULL'), '; ') ELSE '' END,
                            CASE WHEN ISNULL(i.PuntoReferencia, '') <> ISNULL(d.PuntoReferencia, '') THEN 'PuntoReferencia modificado; ' ELSE '' END,
                            CASE WHEN ISNULL(i.CoordenadasMaps, '') <> ISNULL(d.CoordenadasMaps, '') THEN 'Coordenadas modificadas; ' ELSE '' END,
                            CASE WHEN ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1) THEN CONCAT('Estado: ', ISNULL(eo.Estado, 'NULL'), ' a ', ISNULL(en.Estado, 'NULL'), '; ') ELSE '' END)
                    END, 200),
               @UsuarioSistemaId
        FROM inserted i
        INNER JOIN deleted d ON i.DireccionId = d.DireccionId
        LEFT JOIN GLOBAL.ESTADO eo ON d.EstadoId = eo.EstadoId
        LEFT JOIN GLOBAL.ESTADO en ON i.EstadoId = en.EstadoId
        WHERE ISNULL(i.MunicipioId, -1) <> ISNULL(d.MunicipioId, -1)
           OR ISNULL(i.ColoniBarrio, '') <> ISNULL(d.ColoniBarrio, '')
           OR ISNULL(i.NoCasa, '') <> ISNULL(d.NoCasa, '')
           OR ISNULL(i.PuntoReferencia, '') <> ISNULL(d.PuntoReferencia, '')
           OR ISNULL(i.CoordenadasMaps, '') <> ISNULL(d.CoordenadasMaps, '')
           OR ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1);
        RETURN;
    END

    IF EXISTS(SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
        SELECT GETDATE(), @Del,
               LEFT(CONCAT('Direccion eliminada fisicamente: ID ', d.DireccionId), 200),
               @UsuarioSistemaId
        FROM deleted d;
    END
END
GO

IF OBJECT_ID(N'AUDITORIA.SpRegistrarAuditoria', N'P') IS NOT NULL DROP PROCEDURE AUDITORIA.SpRegistrarAuditoria
GO
CREATE PROCEDURE AUDITORIA.SpRegistrarAuditoria
    @AccionEvento VARCHAR(75),
    @Detalle VARCHAR(200),
    @UsuarioRegistroId INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @AccionEventoId INT;
    SELECT @AccionEventoId = AccionEventoId
    FROM AUDITORIA.ACCION_EVENTO
    WHERE AccionEvento = @AccionEvento;

    IF @AccionEventoId IS NULL
        RAISERROR('La accion de auditoria no existe.', 16, 1);
    ELSE
        INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
        VALUES (GETDATE(), @AccionEventoId, LEFT(@Detalle, 200), @UsuarioRegistroId);
END
GO

IF OBJECT_ID(N'AUTENTICACION.SpDeleteLogicoUsuario', N'P') IS NOT NULL DROP PROCEDURE AUTENTICACION.SpDeleteLogicoUsuario
GO
CREATE PROCEDURE AUTENTICACION.SpDeleteLogicoUsuario
    @UsuarioId INT,
    @EstadoId INT,
    @UsuarioModificacionId INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS(SELECT 1 FROM AUTENTICACION.USUARIO WHERE UsuarioId = @UsuarioId)
        UPDATE AUTENTICACION.USUARIO
        SET EstadoId = @EstadoId,
            UsuarioModificiacionId = @UsuarioModificacionId
        WHERE UsuarioId = @UsuarioId;
    ELSE
        RAISERROR('El usuario no existe.', 16, 1);
END
GO

IF OBJECT_ID(N'COMPRA.SpDeleteLogicoInventario', N'P') IS NOT NULL DROP PROCEDURE COMPRA.SpDeleteLogicoInventario
GO
CREATE PROCEDURE COMPRA.SpDeleteLogicoInventario
    @InventarioId INT,
    @UsuarioModificacionId INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @EstadoAgotado INT = (
        SELECT es.EstadoId
        FROM GLOBAL.ESTADO es
        INNER JOIN GLOBAL.ENTIDAD en ON es.EntidadId = en.EntidadId
        WHERE en.Entidad = 'INVENTARIO' AND es.Estado = 'AGOTADO'
    );

    IF EXISTS(SELECT 1 FROM COMPRA.INVENTARIO WHERE InventarioId = @InventarioId)
        UPDATE COMPRA.INVENTARIO
        SET EstadoId = @EstadoAgotado,
            UsuarioModificacionId = @UsuarioModificacionId
        WHERE InventarioId = @InventarioId;
    ELSE
        RAISERROR('El producto no existe en el inventario.', 16, 1);
END
GO

IF OBJECT_ID(N'COMPRA.SpInsertProveedor', N'P') IS NOT NULL DROP PROCEDURE COMPRA.SpInsertProveedor
GO
CREATE PROCEDURE COMPRA.SpInsertProveedor
    @nombre VARCHAR(50),
    @direccion VARCHAR(100),
    @telefono VARCHAR(9),
    @noRegistro VARCHAR(8),
    @NIT VARCHAR(16),
    @estado INT,
    @UsuarioRegistroId INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS(SELECT 1 FROM COMPRA.PROVEEDOR WHERE Telefono = @telefono OR NoRegistro = @noRegistro OR NIT = @NIT)
        INSERT INTO COMPRA.PROVEEDOR (Nombre, Direccion, Telefono, NoRegistro, NIT, EstadoId, UsuarioRegistroId)
        VALUES (@nombre, @direccion, @telefono, @noRegistro, @NIT, @estado, @UsuarioRegistroId);
    ELSE
        RAISERROR('Los datos ingresados del proveedor ya existen. Verifique telefono, No. Registro o NIT.', 16, 1);
END
GO

IF OBJECT_ID(N'COMPRA.SpUpdateProveedor', N'P') IS NOT NULL DROP PROCEDURE COMPRA.SpUpdateProveedor
GO
CREATE PROCEDURE COMPRA.SpUpdateProveedor
    @ProveedorId INT,
    @Nombre VARCHAR(50),
    @Direccion VARCHAR(100),
    @Telefono VARCHAR(9),
    @NoRegistro VARCHAR(8),
    @NIT VARCHAR(16),
    @EstadoId INT,
    @UsuarioModificacionId INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS(SELECT 1 FROM COMPRA.PROVEEDOR WHERE ProveedorId = @ProveedorId)
    BEGIN
        RAISERROR('El proveedor no existe.', 16, 1);
        RETURN;
    END

    IF EXISTS(SELECT 1 FROM COMPRA.PROVEEDOR
              WHERE (Telefono = @Telefono OR NoRegistro = @NoRegistro OR NIT = @NIT)
                AND ProveedorId <> @ProveedorId)
    BEGIN
        RAISERROR('No es posible modificar: ya existe un proveedor con ese telefono, No. Registro o NIT.', 16, 1);
        RETURN;
    END

    UPDATE COMPRA.PROVEEDOR
    SET Nombre = @Nombre,
        Direccion = @Direccion,
        Telefono = @Telefono,
        NoRegistro = @NoRegistro,
        NIT = @NIT,
        EstadoId = @EstadoId,
        UsuarioModificacionId = @UsuarioModificacionId
    WHERE ProveedorId = @ProveedorId;
END
GO

IF OBJECT_ID(N'COMPRA.SpSelectAllProveedores', N'P') IS NOT NULL DROP PROCEDURE COMPRA.SpSelectAllProveedores
GO
CREATE PROCEDURE COMPRA.SpSelectAllProveedores
AS
BEGIN
    SET NOCOUNT ON;

    SELECT a.ProveedorId AS 'Codigo',
           a.Nombre,
           a.Direccion,
           a.Telefono,
           a.NoRegistro AS 'No. Registro',
           a.NIT,
           a.EstadoId,
           b.Estado
    FROM COMPRA.PROVEEDOR a
    INNER JOIN GLOBAL.ESTADO b ON a.EstadoId = b.EstadoId
    ORDER BY a.Nombre ASC;
END
GO

IF OBJECT_ID(N'DELIVERY.SpDeleteLogicoRepartidor', N'P') IS NOT NULL DROP PROCEDURE DELIVERY.SpDeleteLogicoRepartidor
GO
CREATE PROCEDURE DELIVERY.SpDeleteLogicoRepartidor
    @RepartidorId INT,
    @EstadoId INT,
    @UsuarioModificacionId INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS(SELECT 1 FROM DELIVERY.REPARTIDOR WHERE RepartidorId = @RepartidorId)
        RAISERROR('El repartidor indicado no existe.', 16, 1);
    ELSE
        UPDATE DELIVERY.REPARTIDOR
        SET EstadoId = @EstadoId,
            UsuarioModificacionId = @UsuarioModificacionId
        WHERE RepartidorId = @RepartidorId;
END
GO

IF OBJECT_ID(N'DELIVERY.SpInsertRepartidor', N'P') IS NOT NULL DROP PROCEDURE DELIVERY.SpInsertRepartidor
GO
CREATE PROCEDURE DELIVERY.SpInsertRepartidor
    @EmpleadoId INT,
    @NoPlacaMoto VARCHAR(7),
    @EstadoId INT,
    @UsuarioRegistroId INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS(SELECT 1 FROM RRHH.EMPLEADO WHERE EmpleadoId = @EmpleadoId)
    BEGIN
        RAISERROR('El empleado indicado no existe.', 16, 1);
        RETURN;
    END

    IF EXISTS(SELECT 1 FROM DELIVERY.REPARTIDOR WHERE EmpleadoId = @EmpleadoId)
    BEGIN
        RAISERROR('El empleado ya esta registrado como repartidor.', 16, 1);
        RETURN;
    END

    IF EXISTS(SELECT 1 FROM DELIVERY.REPARTIDOR WHERE UPPER(NoPlacaMoto) = UPPER(@NoPlacaMoto))
    BEGIN
        RAISERROR('La placa de moto ingresada ya esta registrada.', 16, 1);
        RETURN;
    END

    INSERT INTO DELIVERY.REPARTIDOR(EmpleadoId, NoPlacaMoto, EstadoId, UsuarioRegistroId)
    VALUES (@EmpleadoId, @NoPlacaMoto, @EstadoId, @UsuarioRegistroId);
END
GO

IF OBJECT_ID(N'DELIVERY.SpUpdateRepartidor', N'P') IS NOT NULL DROP PROCEDURE DELIVERY.SpUpdateRepartidor
GO
CREATE PROCEDURE DELIVERY.SpUpdateRepartidor
    @RepartidorId INT,
    @EmpleadoId INT,
    @NoPlacaMoto VARCHAR(7),
    @EstadoId INT,
    @UsuarioModificacionId INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS(SELECT 1 FROM DELIVERY.REPARTIDOR WHERE RepartidorId = @RepartidorId)
    BEGIN
        RAISERROR('El repartidor indicado no existe.', 16, 1);
        RETURN;
    END

    IF NOT EXISTS(SELECT 1 FROM RRHH.EMPLEADO WHERE EmpleadoId = @EmpleadoId)
    BEGIN
        RAISERROR('El empleado indicado no existe.', 16, 1);
        RETURN;
    END

    IF EXISTS(SELECT 1 FROM DELIVERY.REPARTIDOR WHERE UPPER(NoPlacaMoto) = UPPER(@NoPlacaMoto) AND RepartidorId <> @RepartidorId)
    BEGIN
        RAISERROR('La placa de moto ingresada ya esta registrada en otro repartidor.', 16, 1);
        RETURN;
    END

    UPDATE DELIVERY.REPARTIDOR
    SET EmpleadoId = @EmpleadoId,
        NoPlacaMoto = @NoPlacaMoto,
        EstadoId = @EstadoId,
        UsuarioModificacionId = @UsuarioModificacionId
    WHERE RepartidorId = @RepartidorId;
END
GO

IF OBJECT_ID(N'VENTA.SpDeleteLogicoCliente', N'P') IS NOT NULL DROP PROCEDURE VENTA.SpDeleteLogicoCliente
GO
CREATE PROCEDURE VENTA.SpDeleteLogicoCliente
    @ClienteId INT,
    @UsuarioModificacionId INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @EstadoInactivo INT = (
        SELECT es.EstadoId
        FROM GLOBAL.ESTADO es
        INNER JOIN GLOBAL.ENTIDAD en ON es.EntidadId = en.EntidadId
        WHERE en.Entidad = 'CLIENTE' AND es.Estado = 'INACTIVO'
    );

    IF EXISTS(SELECT 1 FROM VENTA.CLIENTE WHERE ClienteId = @ClienteId)
        UPDATE VENTA.CLIENTE
        SET EstadoId = @EstadoInactivo,
            UsuarioModificacionId = @UsuarioModificacionId
        WHERE ClienteId = @ClienteId;
    ELSE
        RAISERROR('El cliente no existe.', 16, 1);
END
GO

IF OBJECT_ID(N'VENTA.SpInsertCliente', N'P') IS NOT NULL DROP PROCEDURE VENTA.SpInsertCliente
GO
CREATE PROCEDURE VENTA.SpInsertCliente
    @Nombre VARCHAR(25),
    @Apellido VARCHAR(25),
    @Telefono VARCHAR(10),
    @CorreoElectronico VARCHAR(100) = NULL,
    @DireccionId INT,
    @EstadoId INT,
    @UsuarioRegistroId INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS(SELECT 1 FROM DELIVERY.DIRECCION WHERE DireccionId = @DireccionId)
    BEGIN
        RAISERROR('La direccion no existe.', 16, 1);
        RETURN;
    END

    IF EXISTS(SELECT 1 FROM VENTA.CLIENTE WHERE Telefono = @Telefono AND DireccionId = @DireccionId)
    BEGIN
        RAISERROR('El cliente ya existe con esa direccion.', 16, 1);
        RETURN;
    END

    DECLARE @NombreBase VARCHAR(50) = @Nombre + ' ' + @Apellido;
    DECLARE @Count INT;
    SELECT @Count = COUNT(*) FROM VENTA.CLIENTE WHERE Telefono = @Telefono;

    DECLARE @NombreCompleto VARCHAR(100);
    IF @Count > 0
        SET @NombreCompleto = @NombreBase + ' (' + CAST(@Count + 1 AS VARCHAR) + ')';
    ELSE
        SET @NombreCompleto = @NombreBase;

    INSERT INTO VENTA.CLIENTE(Nombre, Apellido, NombreCompleto, Telefono, CorreoElectronico, DireccionId, EstadoId, UsuarioRegistroId)
    VALUES (@Nombre, @Apellido, @NombreCompleto, @Telefono, @CorreoElectronico, @DireccionId, @EstadoId, @UsuarioRegistroId);
END
GO

IF OBJECT_ID(N'VENTA.SpUpdateCliente', N'P') IS NOT NULL DROP PROCEDURE VENTA.SpUpdateCliente
GO
CREATE PROCEDURE VENTA.SpUpdateCliente
    @ClienteId INT,
    @Nombre VARCHAR(25),
    @Apellido VARCHAR(25),
    @NombreCompleto VARCHAR(100),
    @Telefono VARCHAR(10),
    @CorreoElectronico VARCHAR(100) = NULL,
    @DireccionId INT,
    @EstadoId INT,
    @UsuarioModificacionId INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS(SELECT 1 FROM VENTA.CLIENTE WHERE ClienteId = @ClienteId)
    BEGIN
        RAISERROR('El cliente no ha sido encontrado.', 16, 1);
        RETURN;
    END

    IF NOT EXISTS(SELECT 1 FROM DELIVERY.DIRECCION WHERE DireccionId = @DireccionId)
    BEGIN
        RAISERROR('La direccion no existe.', 16, 1);
        RETURN;
    END

    IF EXISTS(SELECT 1 FROM VENTA.CLIENTE WHERE Telefono = @Telefono AND DireccionId = @DireccionId AND ClienteId <> @ClienteId)
    BEGIN
        RAISERROR('Ya existe otro cliente con ese telefono en la misma direccion.', 16, 1);
        RETURN;
    END

    UPDATE VENTA.CLIENTE
    SET Nombre = @Nombre,
        Apellido = @Apellido,
        NombreCompleto = @NombreCompleto,
        Telefono = @Telefono,
        CorreoElectronico = @CorreoElectronico,
        DireccionId = @DireccionId,
        EstadoId = @EstadoId,
        UsuarioModificacionId = @UsuarioModificacionId
    WHERE ClienteId = @ClienteId;
END
GO

-- Eliminar triggers anteriores y cualquier version V2 previa.
IF OBJECT_ID(N'AUTENTICACION.TgAuditoriaInsertUsuario', N'TR') IS NOT NULL DROP TRIGGER AUTENTICACION.TgAuditoriaInsertUsuario
GO
IF OBJECT_ID(N'AUTENTICACION.TgAuditoriaUpdateUsuario', N'TR') IS NOT NULL DROP TRIGGER AUTENTICACION.TgAuditoriaUpdateUsuario
GO
IF OBJECT_ID(N'AUTENTICACION.TgDeleteLogicoUsuario', N'TR') IS NOT NULL DROP TRIGGER AUTENTICACION.TgDeleteLogicoUsuario
GO
IF OBJECT_ID(N'AUTENTICACION.TgHistorialInsertUsuario', N'TR') IS NOT NULL DROP TRIGGER AUTENTICACION.TgHistorialInsertUsuario
GO
IF OBJECT_ID(N'AUTENTICACION.TgHistorialUpdateUsuario', N'TR') IS NOT NULL DROP TRIGGER AUTENTICACION.TgHistorialUpdateUsuario
GO
IF OBJECT_ID(N'BODEGA.TgHistorialInsertOrdenProduccion', N'TR') IS NOT NULL DROP TRIGGER BODEGA.TgHistorialInsertOrdenProduccion
GO
IF OBJECT_ID(N'BODEGA.TgHistorialUpdateOrdenProduccion', N'TR') IS NOT NULL DROP TRIGGER BODEGA.TgHistorialUpdateOrdenProduccion
GO
IF OBJECT_ID(N'BODEGA.TgIntentoDeleteOrdenProduccion', N'TR') IS NOT NULL DROP TRIGGER BODEGA.TgIntentoDeleteOrdenProduccion
GO
IF OBJECT_ID(N'COMPRA.TgAuditoriaInsertInventario', N'TR') IS NOT NULL DROP TRIGGER COMPRA.TgAuditoriaInsertInventario
GO
IF OBJECT_ID(N'COMPRA.TgAuditoriaUpdateInventario', N'TR') IS NOT NULL DROP TRIGGER COMPRA.TgAuditoriaUpdateInventario
GO
IF OBJECT_ID(N'COMPRA.TgHistorialInsertInventario', N'TR') IS NOT NULL DROP TRIGGER COMPRA.TgHistorialInsertInventario
GO
IF OBJECT_ID(N'COMPRA.TgHistorialUpdateInventario', N'TR') IS NOT NULL DROP TRIGGER COMPRA.TgHistorialUpdateInventario
GO
IF OBJECT_ID(N'COMPRA.TgIntentoDeleteInventario', N'TR') IS NOT NULL DROP TRIGGER COMPRA.TgIntentoDeleteInventario
GO
IF OBJECT_ID(N'RRHH.TgAuditoriaInsertEmpleado', N'TR') IS NOT NULL DROP TRIGGER RRHH.TgAuditoriaInsertEmpleado
GO
IF OBJECT_ID(N'RRHH.TgAuditoriaUpdateEmpleado', N'TR') IS NOT NULL DROP TRIGGER RRHH.TgAuditoriaUpdateEmpleado
GO
IF OBJECT_ID(N'RRHH.TgHistorialInsertEmpleado', N'TR') IS NOT NULL DROP TRIGGER RRHH.TgHistorialInsertEmpleado
GO
IF OBJECT_ID(N'RRHH.TgHistorialUpdateEmpleado', N'TR') IS NOT NULL DROP TRIGGER RRHH.TgHistorialUpdateEmpleado
GO
IF OBJECT_ID(N'RRHH.TgIntentoDeleteEmpleado', N'TR') IS NOT NULL DROP TRIGGER RRHH.TgIntentoDeleteEmpleado
GO
IF OBJECT_ID(N'VENTA.TgAuditoriaInsertOrden', N'TR') IS NOT NULL DROP TRIGGER VENTA.TgAuditoriaInsertOrden
GO
IF OBJECT_ID(N'VENTA.TgAuditoriaUpdateOrden', N'TR') IS NOT NULL DROP TRIGGER VENTA.TgAuditoriaUpdateOrden
GO
IF OBJECT_ID(N'AUTENTICACION.TgAuditUsuario', N'TR') IS NOT NULL DROP TRIGGER AUTENTICACION.TgAuditUsuario
GO
IF OBJECT_ID(N'RRHH.TgAuditEmpleado', N'TR') IS NOT NULL DROP TRIGGER RRHH.TgAuditEmpleado
GO
IF OBJECT_ID(N'COMPRA.TgAuditProveedor', N'TR') IS NOT NULL DROP TRIGGER COMPRA.TgAuditProveedor
GO
IF OBJECT_ID(N'VENTA.TgAuditCliente', N'TR') IS NOT NULL DROP TRIGGER VENTA.TgAuditCliente
GO
IF OBJECT_ID(N'DELIVERY.TgAuditRepartidor', N'TR') IS NOT NULL DROP TRIGGER DELIVERY.TgAuditRepartidor
GO
IF OBJECT_ID(N'COMPRA.TgAuditInventario', N'TR') IS NOT NULL DROP TRIGGER COMPRA.TgAuditInventario
GO
IF OBJECT_ID(N'VENTA.TgAuditOrden', N'TR') IS NOT NULL DROP TRIGGER VENTA.TgAuditOrden
GO
IF OBJECT_ID(N'VENTA.TgAuditVenta', N'TR') IS NOT NULL DROP TRIGGER VENTA.TgAuditVenta
GO
IF OBJECT_ID(N'DELIVERY.TgAuditEnvio', N'TR') IS NOT NULL DROP TRIGGER DELIVERY.TgAuditEnvio
GO
IF OBJECT_ID(N'DELIVERY.TgAuditDireccion', N'TR') IS NOT NULL DROP TRIGGER DELIVERY.TgAuditDireccion
GO

CREATE TRIGGER AUTENTICACION.TgAuditUsuario
ON AUTENTICACION.USUARIO
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Ins INT, @Upd INT, @DelLog INT, @Del INT, @UsuarioSistemaId INT, @EstadoInactivo INT;
    SELECT @Ins = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'INSERCION';
    SELECT @Upd = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'ACTUALIZACION';
    SELECT @DelLog = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'ELIMINACION LOGICA';
    SELECT @Del = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'ELIMINACION';
    SELECT TOP 1 @UsuarioSistemaId = UsuarioId FROM AUTENTICACION.USUARIO ORDER BY UsuarioId;
    SELECT @EstadoInactivo = es.EstadoId
    FROM GLOBAL.ESTADO es
    INNER JOIN GLOBAL.ENTIDAD en ON es.EntidadId = en.EntidadId
    WHERE en.Entidad = 'USUARIO' AND es.Estado = 'INACTIVO';

    IF EXISTS(SELECT 1 FROM inserted) AND NOT EXISTS(SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
        SELECT GETDATE(), @Ins,
               LEFT(CONCAT('Nuevo usuario: ', i.Usuario, ' (ID: ', i.UsuarioId, ')'), 200),
               COALESCE(NULLIF(i.UsuarioRegistroId, 0), @UsuarioSistemaId)
        FROM inserted i;
        RETURN;
    END

    IF EXISTS(SELECT 1 FROM inserted) AND EXISTS(SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
        SELECT GETDATE(),
               CASE WHEN ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1) AND i.EstadoId = @EstadoInactivo THEN @DelLog ELSE @Upd END,
               LEFT(CASE WHEN ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1) AND i.EstadoId = @EstadoInactivo
                        THEN CONCAT('Usuario desactivado: ', i.Usuario, ' (ID: ', i.UsuarioId, ')')
                        ELSE CONCAT('Usuario ', i.Usuario, ' modificado: ',
                            CASE WHEN ISNULL(i.Usuario, '') <> ISNULL(d.Usuario, '') THEN CONCAT('Usuario: ', d.Usuario, ' a ', i.Usuario, '; ') ELSE '' END,
                            CASE WHEN ISNULL(i.Clave, '') <> ISNULL(d.Clave, '') THEN 'Clave modificada; ' ELSE '' END,
                            CASE WHEN ISNULL(i.EmpleadoId, -1) <> ISNULL(d.EmpleadoId, -1) THEN CONCAT('EmpleadoId: ', ISNULL(CAST(d.EmpleadoId AS VARCHAR(20)), 'NULL'), ' a ', ISNULL(CAST(i.EmpleadoId AS VARCHAR(20)), 'NULL'), '; ') ELSE '' END,
                            CASE WHEN ISNULL(i.RolId, -1) <> ISNULL(d.RolId, -1) THEN CONCAT('RolId: ', d.RolId, ' a ', i.RolId, '; ') ELSE '' END,
                            CASE WHEN ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1) THEN CONCAT('Estado: ', ISNULL(eo.Estado, 'NULL'), ' a ', ISNULL(en.Estado, 'NULL'), '; ') ELSE '' END)
                    END, 200),
               COALESCE(NULLIF(i.UsuarioModificiacionId, 0), NULLIF(i.UsuarioRegistroId, 0), @UsuarioSistemaId)
        FROM inserted i
        INNER JOIN deleted d ON i.UsuarioId = d.UsuarioId
        LEFT JOIN GLOBAL.ESTADO eo ON d.EstadoId = eo.EstadoId
        LEFT JOIN GLOBAL.ESTADO en ON i.EstadoId = en.EstadoId
        WHERE ISNULL(i.Usuario, '') <> ISNULL(d.Usuario, '')
           OR ISNULL(i.Clave, '') <> ISNULL(d.Clave, '')
           OR ISNULL(i.EmpleadoId, -1) <> ISNULL(d.EmpleadoId, -1)
           OR ISNULL(i.RolId, -1) <> ISNULL(d.RolId, -1)
           OR ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1);
        RETURN;
    END

    IF EXISTS(SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
        SELECT GETDATE(), @Del,
               LEFT(CONCAT('Usuario eliminado fisicamente: ', d.Usuario, ' (ID: ', d.UsuarioId, ')'), 200),
               COALESCE(NULLIF(d.UsuarioModificiacionId, 0), NULLIF(d.UsuarioRegistroId, 0), @UsuarioSistemaId)
        FROM deleted d;
    END
END
GO

CREATE TRIGGER RRHH.TgAuditEmpleado
ON RRHH.EMPLEADO
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Ins INT, @Upd INT, @DelLog INT, @Del INT, @UsuarioSistemaId INT, @EstadoInactivo INT;
    SELECT @Ins = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'INSERCION';
    SELECT @Upd = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'ACTUALIZACION';
    SELECT @DelLog = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'ELIMINACION LOGICA';
    SELECT @Del = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'ELIMINACION';
    SELECT TOP 1 @UsuarioSistemaId = UsuarioId FROM AUTENTICACION.USUARIO ORDER BY UsuarioId;
    SELECT @EstadoInactivo = es.EstadoId
    FROM GLOBAL.ESTADO es
    INNER JOIN GLOBAL.ENTIDAD en ON es.EntidadId = en.EntidadId
    WHERE en.Entidad = 'EMPLEADO' AND es.Estado = 'INACTIVO';

    IF EXISTS(SELECT 1 FROM inserted) AND NOT EXISTS(SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
        SELECT GETDATE(), @Ins,
               LEFT(CONCAT('Nuevo empleado: ', i.Nombre, ' ', i.Apellido, ' (ID: ', i.EmpleadoId, ')'), 200),
               COALESCE(NULLIF(i.UsuarioRegistroId, 0), @UsuarioSistemaId)
        FROM inserted i;
        RETURN;
    END

    IF EXISTS(SELECT 1 FROM inserted) AND EXISTS(SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
        SELECT GETDATE(),
               CASE WHEN ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1) AND i.EstadoId = @EstadoInactivo THEN @DelLog ELSE @Upd END,
               LEFT(CASE WHEN ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1) AND i.EstadoId = @EstadoInactivo
                        THEN CONCAT('Empleado desactivado: ', i.Nombre, ' ', i.Apellido, ' (ID: ', i.EmpleadoId, ')')
                        ELSE CONCAT('Empleado ', i.Nombre, ' ', i.Apellido, ' modificado: ',
                            CASE WHEN ISNULL(i.Nombre, '') <> ISNULL(d.Nombre, '') THEN CONCAT('Nombre: ', d.Nombre, ' a ', i.Nombre, '; ') ELSE '' END,
                            CASE WHEN ISNULL(i.Apellido, '') <> ISNULL(d.Apellido, '') THEN CONCAT('Apellido: ', d.Apellido, ' a ', i.Apellido, '; ') ELSE '' END,
                            CASE WHEN ISNULL(i.Telefono, '') <> ISNULL(d.Telefono, '') THEN CONCAT('Telefono: ', d.Telefono, ' a ', i.Telefono, '; ') ELSE '' END,
                            CASE WHEN ISNULL(i.Email, '') <> ISNULL(d.Email, '') THEN CONCAT('Email: ', ISNULL(d.Email, 'NULL'), ' a ', ISNULL(i.Email, 'NULL'), '; ') ELSE '' END,
                            CASE WHEN ISNULL(i.Direccion, '') <> ISNULL(d.Direccion, '') THEN 'Direccion modificada; ' ELSE '' END,
                            CASE WHEN ISNULL(i.CargoId, -1) <> ISNULL(d.CargoId, -1) THEN CONCAT('CargoId: ', d.CargoId, ' a ', i.CargoId, '; ') ELSE '' END,
                            CASE WHEN ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1) THEN CONCAT('Estado: ', ISNULL(eo.Estado, 'NULL'), ' a ', ISNULL(en.Estado, 'NULL'), '; ') ELSE '' END)
                    END, 200),
               COALESCE(NULLIF(i.UsuarioModificacionId, 0), NULLIF(i.UsuarioRegistroId, 0), @UsuarioSistemaId)
        FROM inserted i
        INNER JOIN deleted d ON i.EmpleadoId = d.EmpleadoId
        LEFT JOIN GLOBAL.ESTADO eo ON d.EstadoId = eo.EstadoId
        LEFT JOIN GLOBAL.ESTADO en ON i.EstadoId = en.EstadoId
        WHERE ISNULL(i.Nombre, '') <> ISNULL(d.Nombre, '')
           OR ISNULL(i.Apellido, '') <> ISNULL(d.Apellido, '')
           OR ISNULL(i.Telefono, '') <> ISNULL(d.Telefono, '')
           OR ISNULL(i.Email, '') <> ISNULL(d.Email, '')
           OR ISNULL(i.Direccion, '') <> ISNULL(d.Direccion, '')
           OR ISNULL(i.CargoId, -1) <> ISNULL(d.CargoId, -1)
           OR ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1);
        RETURN;
    END

    IF EXISTS(SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
        SELECT GETDATE(), @Del,
               LEFT(CONCAT('Empleado eliminado fisicamente: ', d.Nombre, ' ', d.Apellido, ' (ID: ', d.EmpleadoId, ')'), 200),
               COALESCE(NULLIF(d.UsuarioModificacionId, 0), NULLIF(d.UsuarioRegistroId, 0), @UsuarioSistemaId)
        FROM deleted d;
    END
END
GO

CREATE TRIGGER COMPRA.TgAuditProveedor
ON COMPRA.PROVEEDOR
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Ins INT, @Upd INT, @DelLog INT, @Del INT, @UsuarioSistemaId INT, @EstadoInactivo INT;
    SELECT @Ins = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'INSERCION';
    SELECT @Upd = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'ACTUALIZACION';
    SELECT @DelLog = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'ELIMINACION LOGICA';
    SELECT @Del = AccionEventoId FROM AUDITORIA.ACCION_EVENTO WHERE AccionEvento = 'ELIMINACION';
    SELECT TOP 1 @UsuarioSistemaId = UsuarioId FROM AUTENTICACION.USUARIO ORDER BY UsuarioId;
    SELECT @EstadoInactivo = es.EstadoId
    FROM GLOBAL.ESTADO es
    INNER JOIN GLOBAL.ENTIDAD en ON es.EntidadId = en.EntidadId
    WHERE en.Entidad = 'PROVEEDOR' AND es.Estado = 'INACTIVO';

    IF EXISTS(SELECT 1 FROM inserted) AND NOT EXISTS(SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
        SELECT GETDATE(), @Ins,
               LEFT(CONCAT('Nuevo proveedor: ', i.Nombre, ' (ID: ', i.ProveedorId, ')'), 200),
               COALESCE(NULLIF(i.UsuarioRegistroId, 0), @UsuarioSistemaId)
        FROM inserted i;
        RETURN;
    END

    IF EXISTS(SELECT 1 FROM inserted) AND EXISTS(SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
        SELECT GETDATE(),
               CASE WHEN ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1) AND i.EstadoId = @EstadoInactivo THEN @DelLog ELSE @Upd END,
               LEFT(CASE WHEN ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1) AND i.EstadoId = @EstadoInactivo
                        THEN CONCAT('Proveedor desactivado: ', i.Nombre, ' (ID: ', i.ProveedorId, ')')
                        ELSE CONCAT('Proveedor ', i.Nombre, ' modificado: ',
                            CASE WHEN ISNULL(i.Nombre, '') <> ISNULL(d.Nombre, '') THEN CONCAT('Nombre: ', d.Nombre, ' a ', i.Nombre, '; ') ELSE '' END,
                            CASE WHEN ISNULL(i.Direccion, '') <> ISNULL(d.Direccion, '') THEN 'Direccion modificada; ' ELSE '' END,
                            CASE WHEN ISNULL(i.Telefono, '') <> ISNULL(d.Telefono, '') THEN CONCAT('Telefono: ', d.Telefono, ' a ', i.Telefono, '; ') ELSE '' END,
                            CASE WHEN ISNULL(i.NoRegistro, '') <> ISNULL(d.NoRegistro, '') THEN CONCAT('NoRegistro: ', d.NoRegistro, ' a ', i.NoRegistro, '; ') ELSE '' END,
                            CASE WHEN ISNULL(i.NIT, '') <> ISNULL(d.NIT, '') THEN CONCAT('NIT: ', d.NIT, ' a ', i.NIT, '; ') ELSE '' END,
                            CASE WHEN ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1) THEN CONCAT('Estado: ', ISNULL(eo.Estado, 'NULL'), ' a ', ISNULL(en.Estado, 'NULL'), '; ') ELSE '' END)
                    END, 200),
               COALESCE(NULLIF(i.UsuarioModificacionId, 0), NULLIF(i.UsuarioRegistroId, 0), @UsuarioSistemaId)
        FROM inserted i
        INNER JOIN deleted d ON i.ProveedorId = d.ProveedorId
        LEFT JOIN GLOBAL.ESTADO eo ON d.EstadoId = eo.EstadoId
        LEFT JOIN GLOBAL.ESTADO en ON i.EstadoId = en.EstadoId
        WHERE ISNULL(i.Nombre, '') <> ISNULL(d.Nombre, '')
           OR ISNULL(i.Direccion, '') <> ISNULL(d.Direccion, '')
           OR ISNULL(i.Telefono, '') <> ISNULL(d.Telefono, '')
           OR ISNULL(i.NoRegistro, '') <> ISNULL(d.NoRegistro, '')
           OR ISNULL(i.NIT, '') <> ISNULL(d.NIT, '')
           OR ISNULL(i.EstadoId, -1) <> ISNULL(d.EstadoId, -1);
        RETURN;
    END

    IF EXISTS(SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO AUDITORIA.HISTORIAL(FechaHora, AccionEventoId, Detalle, UsuarioRegistroId)
        SELECT GETDATE(), @Del,
               LEFT(CONCAT('Proveedor eliminado fisicamente: ', d.Nombre, ' (ID: ', d.ProveedorId, ')'), 200),
               COALESCE(NULLIF(d.UsuarioModificacionId, 0), NULLIF(d.UsuarioRegistroId, 0), @UsuarioSistemaId)
        FROM deleted d;
    END
END
GO

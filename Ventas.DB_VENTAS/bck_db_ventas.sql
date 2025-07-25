USE [master]
GO
/****** copia de seguridad de la base de datos ******/
CREATE DATABASE [DB_VENTAS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_VENTAS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\DB_VENTAS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DB_VENTAS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\DB_VENTAS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [DB_VENTAS] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_VENTAS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_VENTAS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_VENTAS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_VENTAS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_VENTAS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_VENTAS] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_VENTAS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB_VENTAS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_VENTAS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_VENTAS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_VENTAS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_VENTAS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_VENTAS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_VENTAS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_VENTAS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_VENTAS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DB_VENTAS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_VENTAS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_VENTAS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_VENTAS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_VENTAS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_VENTAS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_VENTAS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_VENTAS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DB_VENTAS] SET  MULTI_USER 
GO
ALTER DATABASE [DB_VENTAS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_VENTAS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_VENTAS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_VENTAS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DB_VENTAS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DB_VENTAS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DB_VENTAS] SET QUERY_STORE = ON
GO
ALTER DATABASE [DB_VENTAS] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [DB_VENTAS]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 24/07/2025 7:13:44 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[cli_identificacion] [varchar](50) NOT NULL,
	[cli_nombre] [varchar](200) NOT NULL,
	[cli_telefono] [varchar](10) NOT NULL,
	[cli_direccion] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[cli_identificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PuntoDeVenta]    Script Date: 24/07/2025 7:13:44 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PuntoDeVenta](
	[punven_nit] [varchar](9) NOT NULL,
	[punven_nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_PuntoDeVenta] PRIMARY KEY CLUSTERED 
(
	[punven_nit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 24/07/2025 7:13:44 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[ven_codigo] [varchar](20) NOT NULL,
	[ven_fecha] [datetime] NOT NULL,
	[ven_cli_identificacion] [varchar](50) NOT NULL,
	[ven_punven_nit] [varchar](9) NOT NULL,
	[ven_producto] [varchar](20) NOT NULL,
	[ven_total] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Venta] PRIMARY KEY CLUSTERED 
(
	[ven_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Cliente] ([cli_identificacion], [cli_nombre], [cli_telefono], [cli_direccion]) VALUES (N'1001234567', N'Carlos Ramirez', N'3001234567', N'Cra 45 #12-34')
INSERT [dbo].[Cliente] ([cli_identificacion], [cli_nombre], [cli_telefono], [cli_direccion]) VALUES (N'1002234568', N'Luisa Fernanda', N'3002234568', N'Calle 56 #78-90')
INSERT [dbo].[Cliente] ([cli_identificacion], [cli_nombre], [cli_telefono], [cli_direccion]) VALUES (N'1003234569', N'Andres Gomez', N'3003234569', N'Av. Las Palmas 123')
INSERT [dbo].[Cliente] ([cli_identificacion], [cli_nombre], [cli_telefono], [cli_direccion]) VALUES (N'1004234570', N'Maria Camila', N'3004234570', N'Cl 10 #20-30')
INSERT [dbo].[Cliente] ([cli_identificacion], [cli_nombre], [cli_telefono], [cli_direccion]) VALUES (N'1005234571', N'Juan Esteban', N'3005234571', N'Transv 22 #45-67')
INSERT [dbo].[Cliente] ([cli_identificacion], [cli_nombre], [cli_telefono], [cli_direccion]) VALUES (N'1006234572', N'Daniela Ortiz', N'3006234572', N'Av. El Poblado 300')
INSERT [dbo].[Cliente] ([cli_identificacion], [cli_nombre], [cli_telefono], [cli_direccion]) VALUES (N'1007234573', N'Santiago Ruiz', N'3007234573', N'Cra 7 #66-55')
INSERT [dbo].[Cliente] ([cli_identificacion], [cli_nombre], [cli_telefono], [cli_direccion]) VALUES (N'1008234574', N'Valentina Lopez', N'3008234574', N'Cl 100 #10-20')
INSERT [dbo].[Cliente] ([cli_identificacion], [cli_nombre], [cli_telefono], [cli_direccion]) VALUES (N'1009234575', N'Sebastian Mejia', N'3009234575', N'Cl 45 #77-89')
INSERT [dbo].[Cliente] ([cli_identificacion], [cli_nombre], [cli_telefono], [cli_direccion]) VALUES (N'1010234576', N'Laura Sanchez', N'3010234576', N'Av. Boyacá 200')
INSERT [dbo].[Cliente] ([cli_identificacion], [cli_nombre], [cli_telefono], [cli_direccion]) VALUES (N'1011234577', N'Mateo Hernandez', N'3011234577', N'Cra 11 #45-67')
INSERT [dbo].[Cliente] ([cli_identificacion], [cli_nombre], [cli_telefono], [cli_direccion]) VALUES (N'1012234578', N'Isabella Torres', N'3012234578', N'Cl 90 #12-15')
INSERT [dbo].[Cliente] ([cli_identificacion], [cli_nombre], [cli_telefono], [cli_direccion]) VALUES (N'1013234579', N'Felipe Rios', N'3013234579', N'Av. 1 de Mayo #8-40')
INSERT [dbo].[Cliente] ([cli_identificacion], [cli_nombre], [cli_telefono], [cli_direccion]) VALUES (N'1014234580', N'Camila Perez', N'3014234580', N'Cl 80 #9-90')
INSERT [dbo].[Cliente] ([cli_identificacion], [cli_nombre], [cli_telefono], [cli_direccion]) VALUES (N'1015234581', N'Nicolas Castro', N'3015234581', N'Cra 30 #12-60')
INSERT [dbo].[Cliente] ([cli_identificacion], [cli_nombre], [cli_telefono], [cli_direccion]) VALUES (N'1999000112', N'TEST', N'TELEFONO', N'DIRECCION')
INSERT [dbo].[Cliente] ([cli_identificacion], [cli_nombre], [cli_telefono], [cli_direccion]) VALUES (N'9146181', N'FREDDY GAVIRIA', N'9001231231', N'CASA')
GO
INSERT [dbo].[PuntoDeVenta] ([punven_nit], [punven_nombre]) VALUES (N'800111001', N'PV. Centro')
INSERT [dbo].[PuntoDeVenta] ([punven_nit], [punven_nombre]) VALUES (N'800111002', N'PV. Norte')
INSERT [dbo].[PuntoDeVenta] ([punven_nit], [punven_nombre]) VALUES (N'800111003', N'PV. Sur')
GO
INSERT [dbo].[Venta] ([ven_codigo], [ven_fecha], [ven_cli_identificacion], [ven_punven_nit], [ven_producto], [ven_total]) VALUES (N'VEN001', CAST(N'2025-07-24T06:04:49.777' AS DateTime), N'1005234571', N'800111001', N'P001', CAST(150000.00 AS Decimal(18, 2)))
INSERT [dbo].[Venta] ([ven_codigo], [ven_fecha], [ven_cli_identificacion], [ven_punven_nit], [ven_producto], [ven_total]) VALUES (N'VEN0012', CAST(N'2025-07-24T00:00:00.000' AS DateTime), N'1999000112', N'800111003', N'PRO123100', CAST(800000.00 AS Decimal(18, 2)))
INSERT [dbo].[Venta] ([ven_codigo], [ven_fecha], [ven_cli_identificacion], [ven_punven_nit], [ven_producto], [ven_total]) VALUES (N'VEN0013', CAST(N'2025-07-24T00:00:00.000' AS DateTime), N'1003234569', N'800111001', N'PRO123100', CAST(900000.00 AS Decimal(18, 2)))
INSERT [dbo].[Venta] ([ven_codigo], [ven_fecha], [ven_cli_identificacion], [ven_punven_nit], [ven_producto], [ven_total]) VALUES (N'VEN0014', CAST(N'2025-07-24T00:00:00.000' AS DateTime), N'1005234571', N'800111002', N'PRO123101', CAST(120000.00 AS Decimal(18, 2)))
INSERT [dbo].[Venta] ([ven_codigo], [ven_fecha], [ven_cli_identificacion], [ven_punven_nit], [ven_producto], [ven_total]) VALUES (N'VEN0015', CAST(N'2025-07-24T00:00:00.000' AS DateTime), N'1007234573', N'800111002', N'PRO123102', CAST(123555.00 AS Decimal(18, 2)))
INSERT [dbo].[Venta] ([ven_codigo], [ven_fecha], [ven_cli_identificacion], [ven_punven_nit], [ven_producto], [ven_total]) VALUES (N'VEN0016', CAST(N'2025-07-24T00:00:00.000' AS DateTime), N'1012234578', N'800111001', N'PRO123103', CAST(4440000.00 AS Decimal(18, 2)))
INSERT [dbo].[Venta] ([ven_codigo], [ven_fecha], [ven_cli_identificacion], [ven_punven_nit], [ven_producto], [ven_total]) VALUES (N'VEN0017', CAST(N'2025-07-24T00:00:00.000' AS DateTime), N'1015234581', N'800111003', N'PRO123103', CAST(780000.00 AS Decimal(18, 2)))
INSERT [dbo].[Venta] ([ven_codigo], [ven_fecha], [ven_cli_identificacion], [ven_punven_nit], [ven_producto], [ven_total]) VALUES (N'VEN002', CAST(N'2025-07-24T00:00:00.000' AS DateTime), N'1005234571', N'800111001', N'P0089', CAST(23500.00 AS Decimal(18, 2)))
INSERT [dbo].[Venta] ([ven_codigo], [ven_fecha], [ven_cli_identificacion], [ven_punven_nit], [ven_producto], [ven_total]) VALUES (N'VEN003', CAST(N'2025-07-24T06:04:49.777' AS DateTime), N'1005234571', N'800111001', N'P001', CAST(150000.00 AS Decimal(18, 2)))
INSERT [dbo].[Venta] ([ven_codigo], [ven_fecha], [ven_cli_identificacion], [ven_punven_nit], [ven_producto], [ven_total]) VALUES (N'VEN004', CAST(N'2025-07-24T00:00:00.000' AS DateTime), N'1002234568', N'800111002', N'PRO001', CAST(1231.00 AS Decimal(18, 2)))
INSERT [dbo].[Venta] ([ven_codigo], [ven_fecha], [ven_cli_identificacion], [ven_punven_nit], [ven_producto], [ven_total]) VALUES (N'VEN007', CAST(N'2025-07-24T00:00:00.000' AS DateTime), N'1014234580', N'800111003', N'PRO123155', CAST(900000.00 AS Decimal(18, 2)))
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Cliente] FOREIGN KEY([ven_cli_identificacion])
REFERENCES [dbo].[Cliente] ([cli_identificacion])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_Cliente]
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_PuntoDeVenta] FOREIGN KEY([ven_punven_nit])
REFERENCES [dbo].[PuntoDeVenta] ([punven_nit])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_PuntoDeVenta]
GO
/****** Object:  StoredProcedure [dbo].[actualizar_venta]    Script Date: 24/07/2025 7:13:44 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[actualizar_venta]
    @codigo VARCHAR(20),
    @fecha DATETIME,
    @cli_identificacion VARCHAR(50),
    @punven_nit VARCHAR(9),
    @producto VARCHAR(20),
    @total DECIMAL(18, 2)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Venta WHERE ven_codigo = @codigo)
    BEGIN
        RETURN -1; 
    END

    UPDATE Venta
    SET
        ven_fecha = @fecha,
        ven_cli_identificacion = @cli_identificacion,
        ven_punven_nit = @punven_nit,
        ven_producto = @producto,
        ven_total = @total
    WHERE
        ven_codigo = @codigo;
   
END;
GO
/****** Object:  StoredProcedure [dbo].[consultar_cliente]    Script Date: 24/07/2025 7:13:44 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[consultar_cliente] 
AS
BEGIN
	SELECT 
			[cli_identificacion]
			,[cli_nombre]
			,[cli_telefono]
			,[cli_direccion]
	FROM [dbo].[Cliente]
			 
END
GO
/****** Object:  StoredProcedure [dbo].[consultar_venta_codigo]    Script Date: 24/07/2025 7:13:44 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[consultar_venta_codigo]
    @codigo VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        ven_codigo,
        ven_fecha,
        ven_cli_identificacion,
        ven_punven_nit,
        ven_producto,
        ven_total
    FROM
        [dbo].[Venta]
    WHERE
        ven_codigo = @codigo;
END;
GO
/****** Object:  StoredProcedure [dbo].[consultar_ventas]    Script Date: 24/07/2025 7:13:44 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[consultar_ventas]
AS
BEGIN
	SELECT 
	 ven_codigo
	,ven_fecha
	,cli_nombre
	,punven_nombre
	,ven_producto
	,ven_total
	FROM [dbo].[Venta]
	JOIN [dbo].[Cliente]	ON ven_cli_identificacion = [cli_identificacion]
	JOIN [dbo].[PuntoDeVenta] ON ven_punven_nit = punven_nit
			 
END
GO
/****** Object:  StoredProcedure [dbo].[eliminar_venta]    Script Date: 24/07/2025 7:13:44 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eliminar_venta]
    @codigo VARCHAR(20)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Venta WHERE ven_codigo = @codigo)
    BEGIN
        RETURN -1; -- no existe
    END

    DELETE FROM Venta
    WHERE ven_codigo = @codigo;

    IF @@ROWCOUNT = 0
    BEGIN
        RETURN 1; -- no se pudo eliminar
    END
    ELSE
    BEGIN
        RETURN 0; -- ok
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[registrar_cliente]    Script Date: 24/07/2025 7:13:44 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[registrar_cliente] 

	 @identificacion varchar(50)
	,@nombre varchar(200)
	,@telefono varchar(10)
	,@direccion varchar(200)

AS
BEGIN
	INSERT INTO [dbo].[Cliente]
			   ([cli_identificacion]
			   ,[cli_nombre]
			   ,[cli_telefono]
			   ,[cli_direccion])
		 VALUES
			   (@identificacion
			   ,@nombre
			   ,@telefono
			   ,@direccion);
END
GO
/****** Object:  StoredProcedure [dbo].[registrar_venta]    Script Date: 24/07/2025 7:13:44 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[registrar_venta]
    @codigo VARCHAR(20),
    @fecha DATETIME, 
    @cli_identificacion VARCHAR(50),
    @punven_nit VARCHAR(9),
    @producto VARCHAR(20),
    @total DECIMAL(18, 2)
AS
BEGIN
    INSERT INTO Venta (
        ven_codigo,
        ven_fecha,
        ven_cli_identificacion,
        ven_punven_nit,
        ven_producto,
        ven_total
    )
    VALUES (
        @codigo,
        @fecha,
        @cli_identificacion,
        @punven_nit,
        @producto,
        @total
    );
END;
GO
USE [master]
GO
ALTER DATABASE [DB_VENTAS] SET  READ_WRITE 
GO

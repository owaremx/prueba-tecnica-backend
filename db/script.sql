USE [master]
GO
/****** Object:  Database [prueba]    Script Date: 06/09/2024 08:13:17 a. m. ******/
CREATE DATABASE [prueba]
 go

 use prueba;
 go

/****** Object:  Table [dbo].[Empleados]    Script Date: 06/09/2024 08:13:17 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fotografia] [varchar](max) NULL,
	[Nombre] [nvarchar](200) NULL,
	[Apellido] [nvarchar](200) NULL,
	[PuestoId] [int] NULL,
	[FechaNacimiento] [date] NULL,
	[FechaContratacion] [date] NULL,
	[Direccion] [nvarchar](max) NULL,
	[Telefono] [nvarchar](20) NULL,
	[CorreoElectronico] [nvarchar](255) NULL,
	[EstadoId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estados]    Script Date: 06/09/2024 08:13:17 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estados](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Puestos]    Script Date: 06/09/2024 08:13:17 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Puestos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Estados] ON 
GO
INSERT [dbo].[Estados] ([Id], [Nombre]) VALUES (1, N'Veracruz')
GO
INSERT [dbo].[Estados] ([Id], [Nombre]) VALUES (2, N'Puebla')
GO
INSERT [dbo].[Estados] ([Id], [Nombre]) VALUES (3, N'Campeche')
GO
INSERT [dbo].[Estados] ([Id], [Nombre]) VALUES (4, N'Tabasco')
GO
INSERT [dbo].[Estados] ([Id], [Nombre]) VALUES (5, N'Yucatán')
GO
INSERT [dbo].[Estados] ([Id], [Nombre]) VALUES (6, N'Quintana Roo')
GO
SET IDENTITY_INSERT [dbo].[Estados] OFF
GO
SET IDENTITY_INSERT [dbo].[Puestos] ON 
GO
INSERT [dbo].[Puestos] ([Id], [Nombre]) VALUES (1, N'Director General')
GO
INSERT [dbo].[Puestos] ([Id], [Nombre]) VALUES (2, N'Jefe de área')
GO
INSERT [dbo].[Puestos] ([Id], [Nombre]) VALUES (3, N'Analista')
GO
SET IDENTITY_INSERT [dbo].[Puestos] OFF
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [fk_empleado_estado] FOREIGN KEY([EstadoId])
REFERENCES [dbo].[Estados] ([Id])
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [fk_empleado_estado]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [fk_empleado_puesto] FOREIGN KEY([PuestoId])
REFERENCES [dbo].[Puestos] ([Id])
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [fk_empleado_puesto]
GO
USE [master]
GO
ALTER DATABASE [prueba] SET  READ_WRITE 
GO

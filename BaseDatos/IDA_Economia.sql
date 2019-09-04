USE [IDA_Economia]
GO
/****** Object:  Table [dbo].[CatCapital]    Script Date: 03/09/2019 11:56:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatCapital](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Valor] [nvarchar](50) NULL,
	[Creado] [datetime] NULL,
	[Modificado] [datetime] NULL,
	[UsuarioModificado] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CatDinero]    Script Date: 03/09/2019 11:56:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatDinero](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Valor] [nvarchar](50) NULL,
	[Creado] [datetime] NULL,
	[Modificado] [datetime] NULL,
	[UsuarioModificado] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CatDivisa]    Script Date: 03/09/2019 11:56:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatDivisa](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Valor] [nvarchar](50) NULL,
	[Creado] [datetime] NULL,
	[Modificado] [datetime] NULL,
	[UsuarioModificado] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CatRol]    Script Date: 03/09/2019 11:56:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatRol](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Rol] [nvarchar](50) NULL,
	[Descripcion] [nvarchar](100) NULL,
	[Creado] [datetime] NULL,
	[Modificado] [datetime] NULL,
	[UsuarioModificado] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Log]    Script Date: 03/09/2019 11:56:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Usuario] [nvarchar](50) NOT NULL,
	[Creado] [datetime] NOT NULL,
	[Modulo] [nvarchar](50) NOT NULL,
	[Empresa] [nvarchar](200) NOT NULL,
	[Resumen] [nvarchar](50) NOT NULL,
	[Detalle] [nvarchar](1000) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogDetalle]    Script Date: 03/09/2019 11:56:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogDetalle](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdLog] [bigint] NOT NULL,
	[Empresa] [nvarchar](50) NULL,
	[Fecha] [datetime] NULL,
	[Valor] [decimal](18, 7) NULL,
	[Usuario] [nvarchar](50) NULL,
	[Creado] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 03/09/2019 11:56:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdRol] [bigint] NOT NULL,
	[Nombre] [nvarchar](100) NULL,
	[Usuario] [nvarchar](30) NULL,
	[Password] [nvarchar](30) NULL,
	[Creado] [datetime] NULL,
	[Modificado] [datetime] NULL,
	[UsuarioModificado] [nvarchar](30) NULL,
	[Estatus] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[InsertLog]    Script Date: 03/09/2019 11:56:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertLog] 
	-- Add the parameters for the stored procedure here
	@Usuario nvarchar(50),
	--@Creado datetime,
	@Modulo nvarchar(50),
	@Empresa nvarchar(100) = NULL,
	@Resumen nvarchar(100) = NULL,
	@Detalle nvarchar(1000) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Log (Usuario, Creado, Modulo, Empresa, Resumen, Detalle)
    VALUES(@Usuario, GETDATE(), @Modulo, @Empresa, @Resumen, @Detalle)

END
GO
/****** Object:  StoredProcedure [dbo].[InsertLogDetalle]    Script Date: 03/09/2019 11:56:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertLogDetalle] 
	-- Add the parameters for the stored procedure here
	@IdLog bigint,
	@Empresa nvarchar(50),
	@Fecha datetime,
	@Valor decimal(18,7),
	@Usuario nvarchar(50)--,
	--@Creado datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO LogDetalle (IdLog, Empresa, Fecha, Valor, Usuario, Creado)
    VALUES(@IdLog, @Empresa, @Fecha, @Valor, @Usuario, GETDATE())

END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerCatCapital]    Script Date: 03/09/2019 11:56:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerCatCapital] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select Id, Nombre, Valor, Creado, Modificado, UsuarioModificado
	from CatCapital
	FOR JSON PATH, INCLUDE_NULL_VALUES, WITHOUT_ARRAY_WRAPPER

END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerCatDinero]    Script Date: 03/09/2019 11:56:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerCatDinero] 
	-- Add the parameters for the stored procedure here 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select Id, Nombre, Valor, Creado, Modificado, UsuarioModificado
	from CatDinero
	FOR JSON PATH, INCLUDE_NULL_VALUES, WITHOUT_ARRAY_WRAPPER

END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerCatDivisa]    Script Date: 03/09/2019 11:56:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerCatDivisa] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select Id, Nombre, Valor, Creado, Modificado, UsuarioModificado
	from CatDivisa
	FOR JSON PATH, INCLUDE_NULL_VALUES, WITHOUT_ARRAY_WRAPPER

END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerLog]    Script Date: 03/09/2019 11:56:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerLog] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select Id, Usuario, Creado, Modulo, Empresa, Resumen, Detalle
	from Log
	FOR JSON PATH, INCLUDE_NULL_VALUES, WITHOUT_ARRAY_WRAPPER

END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerLogDetalle]    Script Date: 03/09/2019 11:56:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerLogDetalle] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select Id, IdLog, Empresa, Fecha, Valor, Usuario, Creado
	from LogDetalle
	FOR JSON PATH, INCLUDE_NULL_VALUES, WITHOUT_ARRAY_WRAPPER

END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerUsuario]    Script Date: 03/09/2019 11:56:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerUsuario] 
	-- Add the parameters for the stored procedure here
	@Usuario nvarchar(50) = NULL 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select usu.Id, usu.IdRol, rol.Rol, usu.Usuario Login, usu.Password, usu.Nombre
	from Usuario usu
	inner join CatRol rol on usu.IdRol = rol.Id
	where usu.Usuario = @Usuario or @Usuario is NULL
	FOR JSON PATH, INCLUDE_NULL_VALUES, WITHOUT_ARRAY_WRAPPER

END
GO

USE [IDA_Economia]
GO
/****** Object:  Table [dbo].[CatCapital]    Script Date: 08/10/2019 05:31:36 p. m. ******/
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
/****** Object:  Table [dbo].[CatDinero]    Script Date: 08/10/2019 05:31:37 p. m. ******/
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
/****** Object:  Table [dbo].[CatDivisa]    Script Date: 08/10/2019 05:31:37 p. m. ******/
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
/****** Object:  Table [dbo].[CatPantalla]    Script Date: 08/10/2019 05:31:37 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatPantalla](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdRol] [bigint] NOT NULL,
	[IdPantalla] [bigint] NOT NULL,
	[Nombre] [nvarchar](100) NULL,
	[Descripcion] [nvarchar](300) NOT NULL,
	[URL] [nvarchar](200) NOT NULL,
	[Icono] [nvarchar](50) NULL,
	[Creado] [datetime] NULL,
	[Modificado] [datetime] NULL,
	[UsuarioModificado] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CatRol]    Script Date: 08/10/2019 05:31:37 p. m. ******/
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
/****** Object:  Table [dbo].[Log]    Script Date: 08/10/2019 05:31:37 p. m. ******/
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
/****** Object:  Table [dbo].[LogDetalleCapital]    Script Date: 08/10/2019 05:31:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogDetalleCapital](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdLog] [bigint] NOT NULL,
	[Numero] [bigint] NOT NULL,
	[Rendimiento] [decimal](18, 7) NOT NULL,
	[Sigma] [decimal](18, 7) NOT NULL,
	[Empresa] [nvarchar](50) NOT NULL,
	[Valor] [decimal](18, 7) NOT NULL,
	[Usuario] [nvarchar](50) NOT NULL,
	[Creado] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogDetalleDinero]    Script Date: 08/10/2019 05:31:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogDetalleDinero](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdLog] [bigint] NOT NULL,
	[Empresa] [nvarchar](50) NULL,
	[Fecha] [datetime] NULL,
	[Valor] [decimal](18, 7) NULL,
	[Usuario] [nvarchar](50) NULL,
	[Creado] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogDetalleDivisa]    Script Date: 08/10/2019 05:31:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogDetalleDivisa](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdLog] [bigint] NOT NULL,
	[Empresa] [nvarchar](50) NULL,
	[Fecha] [datetime] NULL,
	[Valor] [decimal](18, 7) NULL,
	[Usuario] [nvarchar](50) NULL,
	[Creado] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 08/10/2019 05:31:38 p. m. ******/
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
/****** Object:  StoredProcedure [dbo].[InsertLog]    Script Date: 08/10/2019 05:31:38 p. m. ******/
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
	@Detalle nvarchar(1000) = NULL,
	@IdLog bigint output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	BEGIN TRY

		-- Insert statements for procedure here
		INSERT INTO Log (Usuario, Creado, Modulo, Empresa, Resumen, Detalle)
		VALUES(@Usuario, GETDATE(), @Modulo, @Empresa, @Resumen, @Detalle)

		SET @IdLog = (SELECT @@IDENTITY)

		SELECT 'OK' AS MENSAJE
		FOR JSON PATH, INCLUDE_NULL_VALUES, WITHOUT_ARRAY_WRAPPER

	END TRY
	BEGIN CATCH
		
		SELECT 'ERROR: ' + ERROR_MESSAGE() AS MENSAJE
		FOR JSON PATH, INCLUDE_NULL_VALUES, WITHOUT_ARRAY_WRAPPER

	END CATCH

END
GO
/****** Object:  StoredProcedure [dbo].[InsertLogDetalleCapital]    Script Date: 08/10/2019 05:31:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertLogDetalleCapital] 
	-- Add the parameters for the stored procedure here
	@IdLog bigint,
	@Numero bigint,
	@Rendimiento decimal(18,7),
	@Sigma decimal(18, 7),
	@Empresa nvarchar(50),
	@Valor decimal(18,7),
	@Usuario nvarchar(50)--,
	--@Creado datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	BEGIN TRY

		-- Insert statements for procedure here
		INSERT INTO LogDetalleCapital (IdLog, Numero, Rendimiento, Sigma, Empresa, Valor, Usuario, Creado)
		VALUES(@IdLog, @Numero, @Rendimiento, @Sigma, @Empresa, @Valor, @Usuario, GETDATE())

		SELECT 'OK' AS MENSAJE
		FOR JSON PATH, INCLUDE_NULL_VALUES, WITHOUT_ARRAY_WRAPPER

	END TRY
	BEGIN CATCH

		SELECT 'ERROR: ' + ERROR_MESSAGE() AS MENSAJE
		FOR JSON PATH, INCLUDE_NULL_VALUES, WITHOUT_ARRAY_WRAPPER

	END CATCH

END
GO
/****** Object:  StoredProcedure [dbo].[InsertLogDetalleDinero]    Script Date: 08/10/2019 05:31:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertLogDetalleDinero] 
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

	BEGIN TRY

		-- Insert statements for procedure here
		INSERT INTO LogDetalleDinero (IdLog, Empresa, Fecha, Valor, Usuario, Creado)
		VALUES(@IdLog, @Empresa, @Fecha, @Valor, @Usuario, GETDATE())

		SELECT 'OK' AS MENSAJE
		FOR JSON PATH, INCLUDE_NULL_VALUES, WITHOUT_ARRAY_WRAPPER

	END TRY
	BEGIN CATCH

		SELECT 'ERROR: ' + ERROR_MESSAGE() AS MENSAJE
		FOR JSON PATH, INCLUDE_NULL_VALUES, WITHOUT_ARRAY_WRAPPER

	END CATCH

END
GO
/****** Object:  StoredProcedure [dbo].[InsertLogDetalleDivisa]    Script Date: 08/10/2019 05:31:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertLogDetalleDivisa] 
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

	BEGIN TRY

		-- Insert statements for procedure here
		INSERT INTO LogDetalleDivisa (IdLog, Empresa, Fecha, Valor, Usuario, Creado)
		VALUES(@IdLog, @Empresa, @Fecha, @Valor, @Usuario, GETDATE())

		SELECT 'OK' AS MENSAJE
		FOR JSON PATH, INCLUDE_NULL_VALUES, WITHOUT_ARRAY_WRAPPER

	END TRY
	BEGIN CATCH

		SELECT 'ERROR: ' + ERROR_MESSAGE() AS MENSAJE
		FOR JSON PATH, INCLUDE_NULL_VALUES, WITHOUT_ARRAY_WRAPPER

	END CATCH

END
GO
/****** Object:  StoredProcedure [dbo].[InsertUsuario]    Script Date: 08/10/2019 05:31:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertUsuario] 
	-- Add the parameters for the stored procedure here
	@IdRol bigint,
	--@Creado datetime,
	@Nombre nvarchar(50),
	@Usuario nvarchar(50),
	@Password nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	BEGIN TRY

		-- Insert statements for procedure here
		INSERT INTO Usuario(IdRol, Nombre, Usuario, Password, Creado, Modificado, UsuarioModificado, Estatus)
		VALUES(@IdRol, @Nombre, @Usuario, @Password, GETDATE(), NULL, NULL, 1)

		select usu.Id, usu.IdRol, rol.Rol, usu.Usuario Login, usu.Password, usu.Nombre, usu.Estatus
		from Usuario usu
		inner join CatRol rol on usu.IdRol = rol.Id
		where usu.Id = @@IDENTITY
		FOR JSON PATH, INCLUDE_NULL_VALUES, WITHOUT_ARRAY_WRAPPER

	END TRY
	BEGIN CATCH
		
		SELECT 'ERROR: ' + ERROR_MESSAGE() AS MENSAJE
		FOR JSON PATH, INCLUDE_NULL_VALUES, WITHOUT_ARRAY_WRAPPER

	END CATCH

END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerCatCapital]    Script Date: 08/10/2019 05:31:38 p. m. ******/
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
/****** Object:  StoredProcedure [dbo].[ObtenerCatDinero]    Script Date: 08/10/2019 05:31:38 p. m. ******/
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
/****** Object:  StoredProcedure [dbo].[ObtenerCatDivisa]    Script Date: 08/10/2019 05:31:38 p. m. ******/
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
/****** Object:  StoredProcedure [dbo].[ObtenerCatPantalla]    Script Date: 08/10/2019 05:31:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerCatPantalla] 
	-- Add the parameters for the stored procedure here
	@IdRol bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	BEGIN TRY

		-- Insert statements for procedure here
		SELECT p.Id, p.IdRol, c.Rol, p.IdPantalla, p.Nombre, p.Descripcion, p.URL, p.Icono, p.Creado, p.Modificado, p.UsuarioModificado
		FROM CatPantalla p
		INNER JOIN CatRol c on p.IdRol = c.Id
		WHERE p.IdRol = @IdRol
		FOR JSON PATH, INCLUDE_NULL_VALUES, WITHOUT_ARRAY_WRAPPER

	END TRY
	BEGIN CATCH
		
		SELECT 'ERROR: ' + ERROR_MESSAGE() AS MENSAJE
		FOR JSON PATH, INCLUDE_NULL_VALUES, WITHOUT_ARRAY_WRAPPER

	END CATCH

END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerCatRol]    Script Date: 08/10/2019 05:31:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerCatRol] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select Id, Rol, Descripcion, Creado, Modificado, UsuarioModificado
	from CatRol
	FOR JSON PATH, INCLUDE_NULL_VALUES, WITHOUT_ARRAY_WRAPPER

END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerLog]    Script Date: 08/10/2019 05:31:38 p. m. ******/
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
	@Usuario nvarchar(50) = null,
	@FechaInicio datetime = null,
	@FechaFinal datetime = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select Id, Usuario, Creado, Modulo, Empresa, Resumen, Detalle--, null DetalleDivisa, null DetalleDinero, '[' +
	--(
	--	select lc.Id, lc.IdLog, lc.Numero, lc.Rendimiento, lc.Sigma, lc.Empresa, lc.Valor, lc.Usuario, lc.Creado
	--	from LogDetalleCapital lc
	--	where l.Id = lc.IdLog
	--	FOR JSON PATH, INCLUDE_NULL_VALUES, WITHOUT_ARRAY_WRAPPER
	--) + ']' DetalleCapital
	from Log l
	where (l.Usuario = @Usuario or @Usuario is null) and
			(l.Creado >= CONVERT(datetime, CONVERT(VARCHAR(10), @FechaInicio, 101) + ' 00:00:00') and 
			l.Creado <= CONVERT(datetime, CONVERT(VARCHAR(10), @FechaFinal, 101) + ' 23:59:59'))
	--order by l.Id desc
	FOR JSON PATH, INCLUDE_NULL_VALUES, WITHOUT_ARRAY_WRAPPER

	--DETALLE DIVISA
	select ld.Id, ld.IdLog, ld.Empresa, ld.Fecha, ld.Valor, ld.Usuario, ld.Creado
	from Log l
	inner join LogDetalleDivisa ld on l.Id = ld.IdLog
	where (l.Usuario = @Usuario or @Usuario is null) and
		(l.Creado >= CONVERT(datetime, CONVERT(VARCHAR(10), @FechaInicio, 101) + ' 00:00:00') and 
		l.Creado <= CONVERT(datetime, CONVERT(VARCHAR(10), @FechaFinal, 101) + ' 23:59:59'))
		--and l.Id = 10034
	FOR JSON PATH, INCLUDE_NULL_VALUES, WITHOUT_ARRAY_WRAPPER

	--DETALLE DINERO
	select ldi.Id, ldi.IdLog, ldi.Empresa, ldi.Fecha, ldi.Valor, ldi.Usuario, ldi.Creado
	from Log l
	inner join LogDetalleDinero ldi on l.Id = ldi.IdLog
	where (l.Usuario = @Usuario or @Usuario is null) and
		(l.Creado >= CONVERT(datetime, CONVERT(VARCHAR(10), @FechaInicio, 101) + ' 00:00:00') and 
		l.Creado <= CONVERT(datetime, CONVERT(VARCHAR(10), @FechaFinal, 101) + ' 23:59:59'))
		--and l.Id = 10034
	FOR JSON PATH, INCLUDE_NULL_VALUES, WITHOUT_ARRAY_WRAPPER

	--DETALLE CAPITAL
	select lc.Id, lc.IdLog, lc.Numero, lc.Rendimiento, lc.Sigma, lc.Empresa, lc.Valor, lc.Usuario, lc.Creado
	from Log l 
	inner join LogDetalleCapital lc on l.Id = lc.IdLog
	where (l.Usuario = @Usuario or @Usuario is null) and
		(l.Creado >= CONVERT(datetime, CONVERT(VARCHAR(10), @FechaInicio, 101) + ' 00:00:00') and 
		l.Creado <= CONVERT(datetime, CONVERT(VARCHAR(10), @FechaFinal, 101) + ' 23:59:59'))
		--and l.Id = 10034
	FOR JSON PATH, INCLUDE_NULL_VALUES, WITHOUT_ARRAY_WRAPPER
	

END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerLogDetalleCapital]    Script Date: 08/10/2019 05:31:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerLogDetalleCapital] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select Id, IdLog, Numero, Rendimiento, Sigma, Empresa, Valor, Usuario, Creado
	from LogDetalleCapital
	FOR JSON PATH, INCLUDE_NULL_VALUES, WITHOUT_ARRAY_WRAPPER

END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerLogDetalleDinero]    Script Date: 08/10/2019 05:31:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerLogDetalleDinero] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select Id, IdLog, Empresa, Fecha, Valor, Usuario, Creado
	from LogDetalleDinero
	FOR JSON PATH, INCLUDE_NULL_VALUES, WITHOUT_ARRAY_WRAPPER

END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerLogDetalleDivisa]    Script Date: 08/10/2019 05:31:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerLogDetalleDivisa] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select Id, IdLog, Empresa, Fecha, Valor, Usuario, Creado
	from LogDetalleDivisa
	FOR JSON PATH, INCLUDE_NULL_VALUES, WITHOUT_ARRAY_WRAPPER

END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerUsuario]    Script Date: 08/10/2019 05:31:38 p. m. ******/
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
	@Usuario nvarchar(50) = NULL,
	@Nombre nvarchar(50) = NULL,
	@IdRol bigint = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select usu.Id, usu.IdRol, rol.Rol, usu.Usuario Login, usu.Password, usu.Nombre, usu.Estatus
	from Usuario usu
	inner join CatRol rol on usu.IdRol = rol.Id
	where --usu.Estatus = 1 and
			(usu.Usuario = @Usuario or @Usuario is NULL) and
			(usu.Nombre like '%' + @Nombre + '%' or @Nombre is null) and
			(usu.IdRol = @IdRol or @IdRol is null)
	FOR JSON PATH, INCLUDE_NULL_VALUES, WITHOUT_ARRAY_WRAPPER

END
GO
/****** Object:  StoredProcedure [dbo].[UpdateUsuario]    Script Date: 08/10/2019 05:31:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateUsuario] 
	-- Add the parameters for the stored procedure here
	@Id bigint,
	@IdRol bigint,
	--@Creado datetime,
	@Nombre nvarchar(50),
	@Usuario nvarchar(50),
	@Password nvarchar(50),
	@Estatus int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	BEGIN TRY

		-- Insert statements for procedure here
		UPDATE Usuario
		SET IdRol = @IdRol, 
			Nombre = @Nombre, 
			Usuario = @Usuario, 
			Password = @Password, 
			Modificado = GETDATE(), 
			UsuarioModificado = @Usuario,
			Estatus = @Estatus
		WHERE Id = @Id

		select usu.Id, usu.IdRol, rol.Rol, usu.Usuario Login, usu.Password, usu.Nombre, usu.Estatus
		from Usuario usu
		inner join CatRol rol on usu.IdRol = rol.Id
		where usu.Id = @Id
		FOR JSON PATH, INCLUDE_NULL_VALUES, WITHOUT_ARRAY_WRAPPER

	END TRY
	BEGIN CATCH
		
		SELECT 'ERROR: ' + ERROR_MESSAGE() AS MENSAJE
		FOR JSON PATH, INCLUDE_NULL_VALUES, WITHOUT_ARRAY_WRAPPER

	END CATCH

END
GO

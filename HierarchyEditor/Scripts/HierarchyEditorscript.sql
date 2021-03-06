USE [CATDB]
GO
/****** Object:  UserDefinedTableType [dbo].[FST_type]    Script Date: 3/25/2022 12:05:19 PM ******/
CREATE TYPE [dbo].[FST_type] AS TABLE(
	[SNo] [int] NULL,
	[ID] [int] NULL,
	[String] [varchar](50) NULL,
	[Operation] [varchar](1) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[operation]    Script Date: 3/25/2022 12:05:19 PM ******/
CREATE TYPE [dbo].[operation] AS TABLE(
	[ID] [int] NULL,
	[String] [varchar](50) NULL,
	[Operation] [varchar](50) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[operation_type]    Script Date: 3/25/2022 12:05:19 PM ******/
CREATE TYPE [dbo].[operation_type] AS TABLE(
	[SNo] [int] NULL,
	[ID] [int] NULL,
	[String] [varchar](50) NULL,
	[Operation] [varchar](50) NULL
)
GO
/****** Object:  Table [dbo].[FST_HIERARCHY]    Script Date: 3/25/2022 12:05:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FST_HIERARCHY](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HierID] [int] NULL,
	[ParentID] [int] NULL,
	[HierType] [varchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FST_STRING]    Script Date: 3/25/2022 12:05:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FST_STRING](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[String] [varchar](50) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FST_HIERARCHY] ADD  DEFAULT ('CAT') FOR [HierType]
GO
/****** Object:  StoredProcedure [dbo].[AddDeleteEdit_Data]    Script Date: 3/25/2022 12:05:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddDeleteEdit_Data]
	-- Add the parameters for the stored procedure here
	@datatable FST_type READONLY
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	DECLARE @c INTEGER;
	SET @c = (select COUNT(*) FROM @datatable);
	DECLARE @f INTEGER = 1;
	WHILE @f<=@c
	BEGIN
		BEGIN TRY
			DECLARE @op NVARCHAR(1) = (select Operation FROM @datatable WHERE SNo = @f);
			DECLARE @ID INTEGER;
			DECLARE @String NVARCHAR(50)
			IF(@op = 'A')
			BEGIN
				SET @ID = (select ID FROM @datatable WHERE SNo = @f);
				SET @String  = (select String FROM @datatable WHERE SNo = @f);
				Insert into FST_STRING(String) Values(@String);
				Insert into FST_HIERARCHY(HierID,ParentId) Values(IDENT_CURRENT('FST_STRING'),@ID);
				Select 1;
			END
			ELSE IF(@op = 'D')
			BEGIN
				SET @ID = (select ID FROM @datatable WHERE SNo = @f);
				Delete from FST_STRING where ID = @ID;
				Delete from FST_HIERARCHY where HierID = @ID;
				Select 1;
			END
			ELSE
			BEGIN
				SET @ID = (select ID FROM @datatable WHERE SNo = @f);
				SET @String  = (select String FROM @datatable WHERE SNo = @f);
				UPDATE FST_STRING SET String = @String Where ID = @ID;
				Select 1;
			END
			SET @f = @f + 1;
		END TRY
		BEGIN CATCH
			SELECT 0;
		END CATCH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[GetData]    Script Date: 3/25/2022 12:05:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetData]
	-- Add the parameters for the stored procedure here
	@ParentID INT
AS
BEGIN
	SELECT FST_STRING.ID, FST_STRING.String, FST_HIERARCHY.ParentID 
	FROM FST_STRING INNER JOIN FST_HIERARCHY 
	ON FST_STRING.ID = FST_HIERARCHY.HierID
	WHERE FST_HIERARCHY.ParentID = @ParentID;
END
GO

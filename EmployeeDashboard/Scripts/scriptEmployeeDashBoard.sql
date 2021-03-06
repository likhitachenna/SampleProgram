USE [company]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 02/03/2022 18:25:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](255) NULL,
	[LastName] [varchar](255) NULL,
	[DOB] [date] NULL,
	[Address] [varchar](255) NULL,
	[Bloodgroup] [varchar](255) NULL,
	[Contact] [bigint] NULL,
	[Gender] [varchar](1) NULL,
	[DateBirth] [date] NULL,
	[UpdateDate] [date] NULL,
	[DateDeath] [date] NULL,
UNIQUE NONCLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employee] ADD  DEFAULT ('9999-12-31') FOR [DateDeath]
GO
/****** Object:  StoredProcedure [dbo].[Employee_Delete]    Script Date: 02/03/2022 18:25:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Employee_Delete]
	-- Add the parameters for the stored procedure here
	@EmployeeID INT
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		UPDATE Employee SET DateDeath = CAST(GETDATE() as DATE) WHERE EmployeeID = @EmployeeId;
		SELECT 1;
	END TRY
	BEGIN CATCH
		SELECT 0;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[Employee_Display]    Script Date: 02/03/2022 18:25:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Employee_Display]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
    -- Insert statements for procedure here
	SELECT EmployeeId,FirstName,LastName,DOB,Address,Bloodgroup,Contact,Gender from Employee Where DateDeath = '9999-12-31' ORDER BY EmployeeID ASC;
END
GO
/****** Object:  StoredProcedure [dbo].[Employee_Insert]    Script Date: 02/03/2022 18:25:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Employee_Insert]
	-- Add the parameters for the stored procedure here
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@DOB DATETIME,
	@Address NVARCHAR(100),
	@Bloodgroup NVARCHAR(10),
	@Contact BIGINT,
	@Gender NVARCHAR(1)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	BEGIN TRY
		INSERT INTO Employee(FirstName, LastName, DOB, Address, Bloodgroup, Contact, Gender, DateBirth, UpdateDate)
		VALUES (@FirstName, @LastName, @DOB, @Address, @Bloodgroup, @Contact, @Gender , CAST(GETDATE() as DATE), CAST(GETDATE() as DATE));
		SELECT IDENT_CURRENT('Employee');
	END TRY
	BEGIN CATCH
		SELECT 0;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[Employee_Update]    Script Date: 02/03/2022 18:25:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Employee_Update]
	-- Add the parameters for the stored procedure here
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@DOB DATETIME,
	@Address NVARCHAR(100),
	@Bloodgroup NVARCHAR(10),
	@Contact BIGINT,
	@Gender NVARCHAR(10),
	@EmployeeId BIGINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	BEGIN TRY
		UPDATE Employee SET FirstName = @FirstName, LastName = @LastName, DOB = @DOB, Address = @Address, Bloodgroup = @Bloodgroup, Contact = @Contact, Gender = @Gender, UpdateDate = CAST(GETDATE() as DATE) WHERE EmployeeID = @EmployeeId;
		SELECT 1;
	END TRY
	BEGIN CATCH
		SELECT 0;
	END CATCH
    -- Insert statements for procedure here
END
GO

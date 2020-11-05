-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE spAddEmployee
(
	@Name varchar(50),
	@PhoneNumber varchar(10),
	@Address varchar(30),
	@Gender char(1)
)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO employee values(@Name, @PhoneNumber, @Address, @Gender)
END
GO
SELECT * FROM employee;

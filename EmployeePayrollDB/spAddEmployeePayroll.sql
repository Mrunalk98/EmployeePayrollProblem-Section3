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
CREATE PROCEDURE spAddEmployeePayroll
(
	@BasicPay decimal(10,2),	
	@Deductions decimal(10,2),
	@IncomeTax decimal(10,2),
	@StartDate datetime,
	@Emp_ID int
)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO payroll values(@BasicPay, @Deductions, @IncomeTax, @StartDate, @Emp_ID)
END
GO
SELECT * FROM payroll;

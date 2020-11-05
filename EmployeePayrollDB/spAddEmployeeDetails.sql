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
CREATE PROCEDURE spAddEmployeeDetail
(	-- Add the parameters for the stored procedure here
	@Name varchar(50),
	@StartDate datetime,
	@Salary decimal(12,2),
	@Gender char(1),
	@PhoneNumber varchar(10),
	@Address varchar(30),
	@Department varchar(30),
	@BasicPay decimal(10,2),	
	@Deductions decimal(10,2),
	@TaxablePay decimal(10,2),
	@IncomeTax decimal(10,2),
	@NetPay decimal(10,2)
)
AS
BEGIN
	SET NOCOUNT ON 
	INSERT INTO employee_payroll values(@Name, @StartDate, @Salary, @Gender, @PhoneNumber, @Address, @Department, @BasicPay, @Deductions, @TaxablePay, @IncomeTax, @NetPay)
END

GO

SELECT * FROM employee_payroll;
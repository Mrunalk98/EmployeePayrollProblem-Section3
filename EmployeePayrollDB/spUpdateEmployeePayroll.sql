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
CREATE PROCEDURE spUpdateEmployeePayroll
(
	@Payroll_ID int,
	@BasicPay decimal(10,2),	
	@Deductions decimal(10,2),
	@IncomeTax decimal(10,2),
	@Emp_ID int
)
AS
BEGIN
	SET XACT_ABORT ON;
	BEGIN TRY
		BEGIN TRANSACTION;
			UPDATE payroll
			set BasicPay = @BasicPay, Deductions = @Deductions, IncomeTax = @IncomeTax
			where Payroll_ID = @Payroll_ID and Emp_ID = @Emp_ID
			select e.Emp_ID, Emp_Name, p.BasicPay, p.Deductions, p.TaxablePay, p.IncomeTax, p.NetPay
			from employee e inner join payroll p
			on e.Emp_ID = p.Emp_ID where p.Payroll_ID=@Payroll_ID;
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		select ERROR_NUMBER() as ErrorNumber, ERROR_MESSAGE() as ErrorMessage;
		IF (XACT_STATE()) = -1
			BEGIN
				PRINT N'The transaction is in an uncommittable state' + 'Rolling back transaction.'
				ROLLBACK TRANSACTION
			END;
		IF (XACT_STATE()) = 1
			BEGIN
				PRINT N'The transaction is committable' + 'Committing transaction.'
				COMMIT TRANSACTION
			END;
	END CATCH
END

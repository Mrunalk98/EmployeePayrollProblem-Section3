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
	@Name varchar(50),
	@PhoneNumber varchar(10),
	@Address varchar(30),
	@Gender char(1),
	@BasicPay decimal(10,2),	
	@Deductions decimal(10,2),
	@IncomeTax decimal(10,2),
	@StartDate datetime
)
AS
BEGIN
	SET XACT_ABORT ON;
	BEGIN TRY
		BEGIN TRANSACTION;		
			INSERT INTO employee values(@Name, @PhoneNumber, @Address, @Gender);
			INSERT INTO payroll values(@BasicPay, @Deductions, @IncomeTax, @StartDate, (SELECT Emp_ID FROM employee WHERE Emp_ID=(SELECT MAX(Emp_ID) FROM employee)));
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
GO


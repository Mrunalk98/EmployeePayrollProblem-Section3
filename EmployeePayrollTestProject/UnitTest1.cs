using EmployeePayrollProblem_Section3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeePayrollTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenPayrollDetails_UpdatePayrollData()
        {
            EmployeeRepo repo = new EmployeeRepo();
            PayrollUpdateModel payrollUpdateModel = new PayrollUpdateModel()
            {
                Payroll_ID = 6,
                BasicPay = 6000.00,
                Deductions = 500,
                IncomeTax = 500,
                Emp_ID = 1008
            };

            double Emp_BasicPay = repo.UpdateEmployeePayroll(payrollUpdateModel);

            Assert.AreEqual(payrollUpdateModel.BasicPay, Emp_BasicPay);
        }

        [TestMethod]
        public void GivenEmployeeDetails_AddPayrollDetails()
        {
            EmployeeRepo repo = new EmployeeRepo();
            EmployeeModel employeeModel = new EmployeeModel()
            {
                Name = "Lawrene",
                PhoneNumber = "8885568964",
                Address = "LA",
                Gender = 'F'
            };
            PayrollUpdateModel payrollUpdateModel = new PayrollUpdateModel()
            {
                BasicPay = 6000.00,
                Deductions = 500,
                IncomeTax = 500
            };

            int Emp_ID = repo.AddEmployeeToPayroll(payrollUpdateModel, employeeModel);

            Assert.AreEqual(employeeModel.ID, Emp_ID);
        }
    }
}

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
                Payroll_ID = 1,
                BasicPay = 4000,
                Deductions = 200,
                IncomeTax = 100,
                Emp_ID = 1001
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
                Name = "Terrisa",
                PhoneNumber = "7775568964",
                Address = "SA",
                Gender = 'F',
                BasicPay = 5500,
                Deductions = 500,
                IncomeTax = 300
            };
           
            int Emp_ID = repo.AddEmployeeToPayroll(employeeModel);

            Assert.AreEqual(employeeModel.Emp_ID, Emp_ID);
        }

    }
}

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
    }
}

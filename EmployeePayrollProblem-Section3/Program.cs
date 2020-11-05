using System;

namespace EmployeePayrollProblem_Section3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Payroll Problem -Section3!");
            EmployeeRepo employeeRepo = new EmployeeRepo();
            EmployeeModel employee = new EmployeeModel();
            PayrollUpdateModel payroll = new PayrollUpdateModel();

            employee.Name = "Lawrene";
            employee.PhoneNumber = "8885568964";
            employee.Address = "LA";
            employee.Gender = 'F';

            payroll.BasicPay = 5000.00;
            payroll.Deductions = 500;
            payroll.IncomeTax = 200;

            //employeeRepo.AddEmployeeToPayroll(payroll, employee);
            //employeeRepo.GetEmployee();
        }
    }
}

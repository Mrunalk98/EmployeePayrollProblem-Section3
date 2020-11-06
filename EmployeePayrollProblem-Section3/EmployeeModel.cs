using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayrollProblem_Section3
{
    public class EmployeeModel
    {
        public int Emp_ID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public char Gender { get; set; }
        public int Payroll_ID { get; set; }
        public double BasicPay { get; set; }
        public double Deductions { get; set; }
        public double IncomeTax { get; set; }
    }

}

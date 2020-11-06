using EmployeePayrollProblem_Section3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeePayrollTestProject
{
    [TestClass]
    public class MultiThreadingTest
    {
        // UC 1
        [TestMethod]
        public void GivenMultipleEmployeeDetails_AddPayrollDetails_WithoutUsingThread()
        {
            EmployeeRepo repo = new EmployeeRepo();
            List<EmployeeModel> employees = new List<EmployeeModel>()
            {
                new EmployeeModel() { Name = "Terrisa", PhoneNumber = "7775568964", Address = "SA", Gender = 'F', BasicPay = 5500, Deductions = 500, IncomeTax = 300},
                new EmployeeModel() { Name = "Joe", PhoneNumber = "7788968964", Address = "LA", Gender = 'M', BasicPay = 8000, Deductions = 1000, IncomeTax = 500},
                new EmployeeModel() { Name = "Abc", PhoneNumber = "7456768964", Address = "PA", Gender = 'M', BasicPay = 7000, Deductions = 1500, IncomeTax = 500}
            };
            DateTime startTime = DateTime.Now;
            foreach(EmployeeModel employee in employees)
            {
                repo.AddEmployeeToPayroll(employee);
            }
            DateTime stopTime = DateTime.Now;
            Console.WriteLine("Duration without Thread : " + (stopTime - startTime));
        }

        // UC 2
        [TestMethod]
        public void GivenMultipleEmployeeDetails_AddPayrollDetails_UsingThread()
        {
            EmployeeRepo repo = new EmployeeRepo();
            List<EmployeeModel> employees = new List<EmployeeModel>()
            {
                new EmployeeModel() { Name = "Terrisa", PhoneNumber = "7775568964", Address = "SA", Gender = 'F', BasicPay = 5500, Deductions = 500, IncomeTax = 300},
                new EmployeeModel() { Name = "Joe", PhoneNumber = "7788968964", Address = "LA", Gender = 'M', BasicPay = 8000, Deductions = 1000, IncomeTax = 500},
                new EmployeeModel() { Name = "Abc", PhoneNumber = "7456768964", Address = "PA", Gender = 'M', BasicPay = 7000, Deductions = 1500, IncomeTax = 500}
            };
            DateTime startTime = DateTime.Now;
            foreach (EmployeeModel employee in employees)
            {
                Task Thread = new Task(() =>
                {
                    repo.AddEmployeeToPayroll(employee);
                    Console.WriteLine("Employee added : " + employee.Name);
                });
                Thread.Start();
            }
            Console.WriteLine("Total number of employees : " + employees.Count);
            DateTime stopTime = DateTime.Now;
            Console.WriteLine("Duration with thread : " + (stopTime - startTime));
        }
    }
}

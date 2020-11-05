using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollProblem_Section3
{

    public class EmployeeRepo
    {
        public static string connectionString = @"data source=(localDB)\testDB; database=payroll_service;";

        SqlConnection connection = new SqlConnection(connectionString);
    }

}

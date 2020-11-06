using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollProblem_Section3
{

    public class EmployeeRepo
    {
        // UC 2
        public void GetEmployee()
        {
            string connectionString = @"data source=(localDB)\testDB; database=payroll_service;";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (connection)
                {
                    string query = @"SELECT Emp_ID, Emp_Name, Emp_Phone, Emp_Address, Emp_Gender FROM employee;";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeeModel.Emp_ID = dr.GetInt32(0);
                            employeeModel.Name = dr.GetString(1);
                            employeeModel.PhoneNumber = dr.GetString(2);
                            employeeModel.Address = dr.GetString(3);
                            employeeModel.Gender = dr.GetString(4)[0];
                            Console.WriteLine("{0}, {1}, {2}, {3}, {4}", employeeModel.Emp_ID, employeeModel.Name, employeeModel.PhoneNumber, employeeModel.Address, employeeModel.Gender);

                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found ");
                    }
                    dr.Close();
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        // UC 3
        public double UpdateEmployeePayroll(PayrollUpdateModel payrollModel)
        {
            string connectionString = @"data source=(localDB)\testDB; database=payroll_service;";
            SqlConnection connection = new SqlConnection(connectionString);
            double payroll = 0;
            try
            {
                using (connection)
                {
                    EmployeeModel employeeModel = new EmployeeModel();
                    SqlCommand command = new SqlCommand("spUpdateEmployeePayroll", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Payroll_ID", payrollModel.Payroll_ID);
                    command.Parameters.AddWithValue("@BasicPay", payrollModel.BasicPay);
                    command.Parameters.AddWithValue("@Deductions", payrollModel.Deductions);
                    command.Parameters.AddWithValue("@IncomeTax", payrollModel.IncomeTax);
                    command.Parameters.AddWithValue("@Emp_ID", payrollModel.Emp_ID);

                    connection.Open();

                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeeModel.Emp_ID = Convert.ToInt32(dr["Emp_ID"]);
                            employeeModel.Name = dr["Emp_Name"].ToString();
                            employeeModel.BasicPay = Convert.ToDouble(dr["BasicPay"]);
                            Console.WriteLine("{0}, {1}", employeeModel.Name, employeeModel.BasicPay);
                            payroll = employeeModel.BasicPay;
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    dr.Close();
                    connection.Close();
                    return payroll;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        //UC 7
        public int AddEmployeeToPayroll(EmployeeModel employeeModel)
        {
            string connectionString = @"data source=(localDB)\testDB; database=payroll_service;";
            SqlConnection connection = new SqlConnection(connectionString);
            int emp_ID = 0;
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("spAddEmployeePayroll", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", employeeModel.Name);
                    command.Parameters.AddWithValue("@PhoneNumber", employeeModel.PhoneNumber);
                    command.Parameters.AddWithValue("@Address", employeeModel.Address);
                    command.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                    command.Parameters.AddWithValue("@BasicPay", employeeModel.BasicPay);
                    command.Parameters.AddWithValue("@Deductions", employeeModel.Deductions);
                    command.Parameters.AddWithValue("@IncomeTax", employeeModel.IncomeTax);
                    command.Parameters.AddWithValue("@StartDate", DateTime.Now);
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result != 0)
                    {
                        string query = @"SELECT MAX(Emp_ID) FROM employee;";
                        SqlCommand cmd = new SqlCommand(query, connection);
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                employeeModel.Emp_ID = dr.GetInt32(0);
                                emp_ID = employeeModel.Emp_ID;
                            }
                        }
                    }
                    connection.Close();
                    return emp_ID;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

    }

}

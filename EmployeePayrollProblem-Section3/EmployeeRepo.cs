using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollProblem_Section3
{

    public class EmployeeRepo
    {
        public static string connectionString = @"data source=(localDB)\testDB; database=payroll_service;";
        SqlConnection connection = new SqlConnection(connectionString);

        // UC 2
        public void GetEmployee()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"SELECT Emp_ID, Emp_Name, Emp_Phone, Emp_Address, Emp_Gender FROM employee;";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeeModel.ID = dr.GetInt32(0);
                            employeeModel.Name = dr.GetString(1);
                            employeeModel.PhoneNumber = dr.GetString(2);
                            employeeModel.Address = dr.GetString(3);
                            employeeModel.Gender = dr.GetString(4)[0];
                            Console.WriteLine("{0}, {1}, {2}, {3}, {4}", employeeModel.ID, employeeModel.Name, employeeModel.PhoneNumber, employeeModel.Address, employeeModel.Gender);

                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found ");
                    }
                    dr.Close();
                    this.connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        // UC 3
        public double UpdateEmployeePayroll(PayrollUpdateModel payrollModel)
        {
            double payroll = 0;
            try
            {
                using (this.connection)
                {
                    EmployeeModel employeeModel = new EmployeeModel();
                    SqlCommand command = new SqlCommand("spUpdateEmployeePayroll", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Payroll_ID", payrollModel.Payroll_ID);
                    command.Parameters.AddWithValue("@BasicPay", payrollModel.BasicPay);
                    command.Parameters.AddWithValue("@Deductions", payrollModel.Deductions);
                    command.Parameters.AddWithValue("@IncomeTax", payrollModel.IncomeTax);
                    command.Parameters.AddWithValue("@Emp_ID", payrollModel.Emp_ID);

                    this.connection.Open();

                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeeModel.ID = Convert.ToInt32(dr["Emp_ID"]);
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
                    this.connection.Close();
                    return payroll;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        //UC 7
        public int AddEmployeeToPayroll(PayrollUpdateModel payrollModel, EmployeeModel employeeModel)
        {
            int emp_ID = 0;
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spAddEmployeePayroll", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", employeeModel.Name);
                    command.Parameters.AddWithValue("@PhoneNumber", employeeModel.PhoneNumber);
                    command.Parameters.AddWithValue("@Address", employeeModel.Address);
                    command.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                    command.Parameters.AddWithValue("@BasicPay", payrollModel.BasicPay);
                    command.Parameters.AddWithValue("@Deductions", payrollModel.Deductions);
                    command.Parameters.AddWithValue("@IncomeTax", payrollModel.IncomeTax);
                    command.Parameters.AddWithValue("@StartDate", DateTime.Now);
                    this.connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result != 0)
                    {
                        string query = @"SELECT MAX(Emp_ID) FROM employee;";
                        SqlCommand cmd = new SqlCommand(query, this.connection);
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                employeeModel.ID = dr.GetInt32(0);
                                emp_ID = employeeModel.ID;
                            }
                        }
                    }
                    return emp_ID;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        public void DeleteEmployeeFromEmployeeTable(EmployeeModel employee)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spDeleteEmployee", this.connection);
                    command.Parameters.AddWithValue("@Name", employee.Name);
                    command.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                    command.Parameters.AddWithValue("@Gender", employee.Gender);
                    command.Parameters.AddWithValue("@Address", employee.Address);
                    int deleteResult = command.ExecuteNonQuery();

                    if (deleteResult == 0)
                    {
                        Console.WriteLine("No data found");
                    }
                    
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }

}

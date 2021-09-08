using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EmployeeManagement.Model.SalaryModel;

namespace EmployeeManagement
{
   public class Salary
    {
        private static SqlConnection ConnectionSetup()
        {
            return new SqlConnection(@"Data Source = (LocalDb)\localDb; Initial Catalog = payroll_service; Integrated Security = True");
        }
        public int UpdateEmployeeSalary(SalaryUpdateModel salaryUpdateModel)
        {
            SqlConnection SalaryConnection = ConnectionSetup();
            int salary = 0;
            try
            {
                using (SalaryConnection)
                {
                    string id = "2";

                    string query = @"SELECT * FROM EmployeeTable WHERE EmpId =" + Convert.ToInt32(id);
                    SalaryDataModel displayModel = new SalaryDataModel();
                    SqlCommand command = new SqlCommand("spUpdateEmployeeSalary", SalaryConnection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", salaryUpdateModel.SalaryId);
                    command.Parameters.AddWithValue("@Month", salaryUpdateModel.Month);
                    command.Parameters.AddWithValue("@Salary", salaryUpdateModel.EmployeeSalary);
                    command.Parameters.AddWithValue("@EmpId", salaryUpdateModel.EmployeeId);
                    SalaryConnection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            displayModel.EmployeeID = Convert.ToInt32(dr["EmpId"]);
                            displayModel.EmployeeName = dr["EmpName"].ToString();
                            displayModel.EmployeeSalary = Convert.ToInt32(dr["EmpSalary"]);
                            displayModel.Month = dr["SalaryMonth"].ToString();
                            displayModel.SalaryId = Convert.ToInt32(dr["SalaryId"]);

                            Console.WriteLine(displayModel.EmployeeName + " " + displayModel.EmployeeSalary + " " + displayModel.Month + "\n");
                            salary = Convert.ToInt32(displayModel.EmployeeSalary);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                SalaryConnection.Close();
            }
            return salary;
        }
    }
}

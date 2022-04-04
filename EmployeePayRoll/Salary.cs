using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayRoll
{
    public class Salary
    {
        private static SqlConnection ConnectionSetup()
        {
            return new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PayRoll_Service_115;Integrated Security=True");
        }
        public int UpdateEmployeeSalary(SalaryUpdateModel salaryUpdateModel)
        {
            SqlConnection sqlConnection = ConnectionSetup();
            int Salary = 0;
            try
            {
                using (sqlConnection)
                {
                    SalaryDetailModel displayModel = new SalaryDetailModel();
                    SqlCommand command = new SqlCommand("spUpdateEmployeeSalary", sqlConnection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", salaryUpdateModel.SalaryId);
                    command.Parameters.AddWithValue("@month", salaryUpdateModel.Month);
                    command.Parameters.AddWithValue("@salary", salaryUpdateModel.EmployeeSalary);
                    command.Parameters.AddWithValue("@EmpId", salaryUpdateModel.EmployeeId);
                    sqlConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            displayModel.EmployeeId = Convert.ToInt32(reader["EmpId"]);
                            displayModel.EmployeeName = reader["EmpName"].ToString();
                            displayModel.EmployeeSalary = Convert.ToInt32(reader["Salary"]);
                            displayModel.Month = reader["SalaryMonth"].ToString();
                            displayModel.SalaryId = Convert.ToInt32(reader["SalaryId"]);
                        }
                        Console.WriteLine("{0},{1},{2}", displayModel.EmployeeName, displayModel.EmployeeSalary, displayModel.Month);
                        Salary = displayModel.EmployeeSalary;

                    }
                    else
                    {
                        Console.WriteLine("No Data found");
                    }
                }
            }
            catch (Exception E)
            {

            }
            finally
            {
                sqlConnection.Close();
            }
            return Salary;
        }
    }
}

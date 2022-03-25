using System;

namespace EmployeePayRoll
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Payroll");

            EmployeeRepo repo = new EmployeeRepo();
            EmployeeModel employee = new EmployeeModel();

            employee.EmployeeName = "Bruce";
            employee.PhoneNumber = "8067543212";
            employee.Address = "Chennai";
            employee.Department = "HR";
            employee.Gender = 'M';
            employee.BasicPay = 2200.00;
            employee.Deductions = 1200.00;
            employee.TaxablePay = 200.00;
            employee.Tax = 300.00;
            employee.NetPay = 2500.00;
            employee.City = "Chennai";
            employee.Country = "India";

            repo.AddEmployee(employee);
        }
    }
}
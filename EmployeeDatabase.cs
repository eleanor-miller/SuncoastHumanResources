using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace SuncoastHumanResources
{
    class EmployeeDatabase
    {
        //var employees = new List<Employee>();
        private List<Employee> Employees { get; set; } = new List<Employee>();

        // Method to load employees (doesn't return anything, just populates Employees List)
        public void LoadEmployees()
        {
            if (File.Exists("employees.csv"))
            {
                var fileReader = new StreamReader("employees.csv");

                var csvReader = new CsvReader(fileReader, CultureInfo.InvariantCulture);


                Employees = csvReader.GetRecords<Employee>().ToList();

                fileReader.Close();
            }
        }

        // Write the list Employee to a file
        public void SaveEmployees()
        {
            var fileWriter = new StreamWriter("employees.csv");

            var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);

            csvWriter.WriteRecords(Employees);

            fileWriter.Close();
        }

        // CREATE Add employee
        public void AddEmployee(Employee newEmployee)
        {
            Employees.Add(newEmployee);
        }

        // READ Get all the employees
        public List<Employee> GetAllEmployees()
        {
            return Employees;
        }

        // READ Find one employee
        public Employee FindOneEmployee(string nameToFind)
        {
            Employee foundEmployee = Employees.FirstOrDefault(employee => employee.Name.ToUpper().Contains(nameToFind.ToUpper()));

            return foundEmployee;
        }

        // DELETE Delete employee
        public void DeleteEmployee(Employee employeeToDelete)
        {
            Employees.Remove(employeeToDelete);
        }
    }
}
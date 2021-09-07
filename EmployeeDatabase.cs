using System.Collections.Generic;
using System.Linq;

namespace SuncoastHumanResources
{
    class EmployeeDatabase
    {
        //var employees = new List<Employee>();
        private List<Employee> Employees { get; set; } = new List<Employee>();

        // Method to load employees (doesn't return anything, just populates Employees List)
        public void LoadEmployees()
        {

        }

        // Write the list Employee to a file
        public void SaveEmployees()
        {

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
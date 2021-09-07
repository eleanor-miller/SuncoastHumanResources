using System;

namespace SuncoastHumanResources
{
    class Program
    {
        static void DisplayGreeting()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("    Welcome to Our Employee Database    ");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
        }

        static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();

            return userInput;
        }

        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);

            if (isThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Sorry, that isn't a valid input, I'm using 0 as your answer.");
                return 0;
            }
        }

        static void Main(string[] args)
        {
            var database = new EmployeeDatabase();
            database.LoadEmployees();

            DisplayGreeting();

            // Should we keep showing the menu?
            var keepGoing = true;

            // While the user hasn't said QUIT yet
            while (keepGoing)
            {
                // Insert a blank line then prompt them and get their answer (force uppercase)
                Console.WriteLine();
                Console.WriteLine("What do you want to do?\n(A)dd an employee\n(D)elete an employee\n(F)ind an employee\n(S)how all the employees\n(U)pdate an employee\n(Q)uit\n: ");
                var choice = Console.ReadLine().ToUpper();

                switch (choice)
                {
                    case "Q":
                        keepGoing = false;
                        break;

                    case "D":
                        DeleteEmployee(database);
                        break;

                    case "F":
                        ShowEmployee(database);
                        break;

                    case "S":
                        ShowAllEmployees(database);
                        break;

                    case "A":
                        AddEmployee(database);
                        break;

                    case "U":
                        UpdateEmployee(database);
                        break;

                    default:
                        Console.WriteLine("Not a valid response! ");
                        break;
                }
                database.SaveEmployees();
            }
        }

        private static void DeleteEmployee(EmployeeDatabase database)
        {
            // DELETE (out of CREATE - READ - UPDATE - DELETE [CRUD])
            // Get the employee name we are searching for
            var nameToSearchFor = PromptForString("What name are you looking for? ");

            // Search the database to see if they exist
            Employee foundEmployee = database.FindOneEmployee(nameToSearchFor);

            // If we didn't find anyone
            if (foundEmployee == null)
            {
                Console.WriteLine("No such employee!");
            }
            else
            {
                Console.WriteLine($"{foundEmployee.Name} is in department {foundEmployee.Department} and makes ${foundEmployee.Salary}");

                var confirm = PromptForString("Are you sure? [Y/N] ").ToUpper();

                if (confirm == "Y")
                {
                    database.DeleteEmployee(foundEmployee);
                }
            }
        }

        private static void ShowEmployee(EmployeeDatabase database)
        {
            // - Prompt for the name
            var nameToSearchFor = PromptForString("What name are you looking for? ");

            // - Use Linq to find result
            Employee foundEmployee = database.FindOneEmployee(nameToSearchFor);

            // - After the loop, foundEmployee is either null (not found) or refers to the matching item
            if (foundEmployee == null)
            {
                // - Show a message if `null`
                Console.WriteLine("No such person!");
            }
            else
            {
                // - Otherwise show the details. 
                Console.WriteLine($"{foundEmployee.Name} is in department {foundEmployee.Department} and makes ${foundEmployee.Salary}");
            }
        }

        private static void UpdateEmployee(EmployeeDatabase database)
        {
            // UPDATE (out of CREATE - READ - UPDATE - DELETE [CRUD])
            // Get the employee name we are searching for
            var nameToSearchFor = PromptForString("What name are you looking for? ");
            // Search the database to see if they exist
            Employee foundEmployee = database.FindOneEmployee(nameToSearchFor);
            // If we didn't find anyone
            if (foundEmployee == null)
            {
                // Show that the person doesn't exist
                Console.WriteLine("No such employee!");
            }
            else
            {
                Console.WriteLine($"{foundEmployee.Name} is in department {foundEmployee.Department} and makes ${foundEmployee.Salary}");
                var changeChoice = PromptForString("What do you want to change [Name/Department/Salary]? ").ToUpper();

                //    - if name
                //      - prompt for a new name
                if (changeChoice == "NAME")
                {
                    foundEmployee.Name = PromptForString("What is the new name? ");
                }
                //    - if the department
                //      - prompt for a new department
                if (changeChoice == "DEPARTMENT")
                {
                    foundEmployee.Department = PromptForInteger("What is the new department number? ");
                }
                //    - if salary
                //      - prompt for a new salary
                if (changeChoice == "SALARY")
                {
                    foundEmployee.Salary = PromptForInteger("What is the new yearly salary? ");
                }
            }
        }

        private static void AddEmployee(EmployeeDatabase database)
        {
            // CREATE (out of CREATE - READ - UPDATE - DELETE [CRUD])
            // Make a new employee object
            var employee = new Employee();

            // Prompt for values and save them in the employee's properties
            employee.Name = PromptForString("What is your name? ");
            employee.Department = PromptForInteger("What is your department number? ");
            employee.Salary = PromptForInteger("What is your yearly salary (in dollars)? ");

            Console.WriteLine($"Hello, {employee.Name} you make {employee.MonthlySalary()} dollars per month.");

            database.AddEmployee(employee);
        }

        private static void ShowAllEmployees(EmployeeDatabase database)
        {
            // READ (out of CREATE - READ - UPDATE - DELETE [CRUD])
            foreach (var employee in database.GetAllEmployees())
            {
                // And print details
                Console.WriteLine($"{employee.Name} is in department {employee.Department} and makes ${employee.Salary}");
            }
        }
    }
}
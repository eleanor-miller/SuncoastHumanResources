﻿using System;
using System.Collections.Generic;

namespace SuncoastHumanResources
{
  class Employee
  {
    public string Name { get; set; }
    public int Department { get; set; }
    public int Salary { get; set; }
    public int MonthlySalary()
    {
      return Salary / 12;
    }
  }

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
      var employees = new List<Employee>();

      DisplayGreeting();

      // Should we keep showing the menu?
      var keepGoing = true;

      // While the user hasn't said QUIT yet
      while (keepGoing)
      {
        // Insert a blank line then prompt them and get their answer (force uppercase)
        Console.WriteLine();
        Console.WriteLine("What do you want to do?\n(A)dd an employee\n(S)how all the employees\n(Q)uit\n: ");
        var choice = Console.ReadLine().ToUpper();

        if (choice == "Q")
        {
          // They said quit, so set our keepGoing to false
          keepGoing = false;
        }
        else
        if (choice == "S")
        {
          // READ (out of CREATE - READ - UPDATE - DELETE [CRUD])
          foreach(var employee in employees)
          {
            // And print details
            Console.WriteLine($"{employee.Name} is in department {employee.Department} and makes ${employee.Salary}");
          }
        }
        else
        {
          // CREATE (out of CREATE - READ - UPDATE - DELETE [CRUD])
          // Make a new employee object
          var employee = new Employee();

          // Prompt for values and save them in the employee's properties
          employee.Name = PromptForString("What is your name? ");
          employee.Department = PromptForInteger("What is your department number? ");
          employee.Salary = PromptForInteger("What is your yearly salary (in dollars)? ");

          Console.WriteLine($"Hello, {employee.Name} you make {employee.MonthlySalary()} dollars per month.");
    
          employees.Add(employee);
        }

        // end of the `while` statement
      }
    }
  }
}
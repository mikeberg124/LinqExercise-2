using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //: Print the Sum of numbers

            Console.WriteLine($"Sum of the numbers");
            Console.WriteLine(numbers.Sum());
            Console.WriteLine( );

            //: Print the Average of numbers

            Console.WriteLine($"Avg of the numbers");
            Console.WriteLine(numbers.Average());
            Console.WriteLine();

            //: Order numbers in ascending order and print to the console
            Console.WriteLine("Numbers in ascending order");
            numbers.OrderBy(x=> x) .ToList().ForEach(x => Console.WriteLine(x)) ;
            Console.WriteLine();


            //: Order numbers in descending order and print to the console

            Console.WriteLine("Numbers in descending order");
            numbers.OrderByDescending(x => x).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine();




            //: Print to the console only the numbers greater than 6

            Console.WriteLine("Numbers greater than 6");
            numbers.Where(x => x > 6).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine();



            //: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**

            Console.WriteLine("First four in ascending order");
            var printFour = numbers.OrderBy(x => x).Take(4);
            foreach (var item in printFour)
            {
                Console.WriteLine(item);
            }



            //: Change the value at index 4 to your age, then print the numbers in descending order


            Console.WriteLine();
            //numbers[4] = 22;

            numbers.SetValue(22, 4);
            numbers.OrderByDescending(x=>x).ToList().ForEach(x => Console.WriteLine(x));






            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            Console.WriteLine();
            employees.Where(x => x.FirstName.StartsWith("S") || x.FirstName.StartsWith("C"))
                .OrderBy(x => x.FirstName)
                .ToList()
                .ForEach(x => Console.WriteLine(x.FirstName));


            //: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            var specificEmployees=employees.Where(x => x.Age > 26).OrderBy(x => x.Age).ThenBy(x => x.FullName);
            foreach (var x in specificEmployees)
            {
                Console.WriteLine();
                Console.WriteLine($"FullName: {x.FullName}");
                Console.WriteLine($"Age: {x.Age}");
            }




            //: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.

            Console.WriteLine();
            var filter = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            var sum = filter.Sum(x => x.YearsOfExperience);
            Console.WriteLine($"SUM of YOE: {sum}");
            Console.WriteLine();
            var average = filter.Average(x => x.YearsOfExperience);
            Console.WriteLine($"AVERAGE of YOE:{Math.Round(average,2)}");





            //: Add an employee to the end of the list without using employees.Add()

            Console.WriteLine();

            var instance = new Employee("Sam", "Sammy",30,12) ;
            



            employees.Append(instance).ToList()
            .ForEach(x=> Console.WriteLine($"FullName:{x.FullName} YOE:{x.YearsOfExperience}  Age:{x.Age} "));


            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}

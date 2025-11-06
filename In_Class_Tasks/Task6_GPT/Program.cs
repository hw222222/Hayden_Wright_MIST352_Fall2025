/*
chatgpt prompt was:

In C#, Imagine a system with a main menu where admins can create or view Cars in the showroom, add or view Employees, and manage Accounts.

See the screen below for an example of what the system’s sequence diagram might look like.

Your task:

Create a new in-class task named Task6 inside your In-Class Tasks folder.
Make the three classes listed below.
In your Main, create three objects from each class and display their info.

 */

// i could probably get it to do a better job if i wrote some of the code myself before prompting it because it didn't even bother
// to create seperate c# files
using System;

namespace InClassTasks
{
    // Car class
    public class Car
    {
        public string VIN { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }

        public Car(string vin, string make, string model, int year, double price)
        {
            VIN = vin;
            Make = make;
            Model = model;
            Year = year;
            Price = price;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"VIN: {VIN}, Make: {Make}, Model: {Model}, Year: {Year}, Price: ${Price}");
        }
    }

    // Employee class
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }

        public Employee(int id, string name, string position, double salary)
        {
            ID = id;
            Name = name;
            Position = position;
            Salary = salary;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {ID}, Name: {Name}, Position: {Position}, Salary: ${Salary}");
        }
    }

    // Account class
    public class Account
    {
        public int AccountNumber { get; set; }
        public string Owner { get; set; }
        public double Balance { get; set; }

        public Account(int accountNumber, string owner, double balance)
        {
            AccountNumber = accountNumber;
            Owner = owner;
            Balance = balance;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Account #: {AccountNumber}, Owner: {Owner}, Balance: ${Balance}");
        }
    }

    // Main program
    class Task6
    {
        static void Main(string[] args)
        {
            // Create 3 Car objects
            Car car1 = new Car("A123", "Toyota", "Camry", 2022, 28000);
            Car car2 = new Car("B456", "Honda", "Civic", 2023, 25000);
            Car car3 = new Car("C789", "Ford", "Mustang", 2024, 45000);

            // Create 3 Employee objects
            Employee emp1 = new Employee(1, "Alice Johnson", "Manager", 75000);
            Employee emp2 = new Employee(2, "Bob Smith", "Sales", 55000);
            Employee emp3 = new Employee(3, "Carol Lee", "Technician", 50000);

            // Create 3 Account objects
            Account acc1 = new Account(1001, "Alice Johnson", 5000);
            Account acc2 = new Account(1002, "Bob Smith", 3200);
            Account acc3 = new Account(1003, "Carol Lee", 7200);

            Console.WriteLine("---- Cars ----");
            car1.DisplayInfo();
            car2.DisplayInfo();
            car3.DisplayInfo();

            Console.WriteLine("\n---- Employees ----");
            emp1.DisplayInfo();
            emp2.DisplayInfo();
            emp3.DisplayInfo();

            Console.WriteLine("\n---- Accounts ----");
            acc1.DisplayInfo();
            acc2.DisplayInfo();
            acc3.DisplayInfo();
        }
    }
}

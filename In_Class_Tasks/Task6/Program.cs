using System;

namespace Task6
{
    internal class Program
    {
        public static void Main()
        {
            try
            {
                // Car
                var car1 = new Car("Honda", "Accord", 2018);
                var car2 = new Car("Ford", "F-150");
                var car3 = new Car();
                car1.DisplayInfo();
                car2.DisplayInfo();
                car3.DisplayInfo();

                //  employee 
                var emp1 = new Employee("Sidney Brown", 30, 40);
                var emp2 = new Employee("Harry South");
                var emp3 = new Employee();
                emp1.DisplaySummary();
                emp2.DisplaySummary();
                emp3.DisplaySummary();

                // Account 
                var acc1 = new Account(1001, "Sidney Brown", 1250.0);
                var acc2 = new Account(1002, "Harry South");
                var acc3 = new Account();
                acc1.Deposit(150.0);
                acc2.Deposit(300.0);
                acc1.Withdraw(50.0);
                acc3.Withdraw(10.0);
                acc1.DisplayInfo();
                acc2.DisplayInfo();
                acc3.DisplayInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
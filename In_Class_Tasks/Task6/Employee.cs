using System;

namespace Task6
{
    public class Employee
    {
        // Fields
        private string _name;
        private double _hourlyRate;
        private int _hoursPerWeek;

        // Properties
        public string Name
        {
            get => _name;
            set => _name = string.IsNullOrWhiteSpace(value) ? "New Hire" : value.Trim();
        }

        public double HourlyRate
        {
            get => _hourlyRate;
            set => _hourlyRate = value > 0 ? value : 15.0;
        }

        public int HoursPerWeek
        {
            get => _hoursPerWeek;
            set => _hoursPerWeek = value > 0 && value <= 60 ? value : 40;
        }

        public double AnnualSalary => HourlyRate * HoursPerWeek * 52;

        // Constructors
        public Employee()
        {
            Name = "New Hire";
            HourlyRate = 15.0;
            HoursPerWeek = 40;
        }

        public Employee(string name)
        {
            Name = name;
            HourlyRate = 15.0;
            HoursPerWeek = 40;
        }

        public Employee(string name, double rate, int hours)
        {
            Name = name;
            HourlyRate = rate;
            HoursPerWeek = hours;
        }

        // Methods
        public void DisplaySummary() // Used car and account's method formatting to keep everything consistent
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine($"Employee: {Name}");
            Console.WriteLine($"Hourly Rate: ${HourlyRate:F2}");
            Console.WriteLine($"Hours/Week: {HoursPerWeek}");
            Console.WriteLine($"Annual Salary: ${AnnualSalary:F2}");
            Console.WriteLine("-------------------------------------------------\n");
        }
    }
}
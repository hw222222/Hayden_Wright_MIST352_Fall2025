using System;

namespace Task6
{
    public class Car
    {
        // Fields
        private string _make;
        private string _model;
        private int _year;

        // Properties
        public string Make
        {
            get => _make;
            set => _make = string.IsNullOrWhiteSpace(value) ? "Unknown" : value.Trim();
        }

        public string Model
        {
            get => _model;
            set => _model = string.IsNullOrWhiteSpace(value) ? "Unknown" : value.Trim();
        }

        public int Year
        {
            get => _year;
            set => _year = value > 1885 && value <= DateTime.Now.Year + 1 ? value : DateTime.Now.Year;
        }

        // Constructors
        public Car()
        {
            Make = "Generic";
            Model = "Car";
            Year = DateTime.Now.Year;
        }

        public Car(string make, string model)
        {
            Make = make;
            Model = model;
            Year = DateTime.Now.Year;
        }

        public Car(string make, string model, int year)
        {
            Make = make;
            Model = model;
            Year = year;
        }

        // Methods
        public void DisplayInfo()
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine($"Car: {Make} {Model} ({Year})");
            Console.WriteLine("-------------------------------------------------\n");
        }
    }
}
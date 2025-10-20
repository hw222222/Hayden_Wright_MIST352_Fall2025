// ===================================================
// MIST 352 — In-Class Activity 5
// Title: Tip & Tax Splitter Pro
// ---------------------------------------------------
// Totals a restaurant bill, adds tax and tip,
// and splits the final total between a group.
// You’ll fill in three methods to get it running.
// ===================================================
using System;

namespace TipTaxSplitterPro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Tip & Tax Splitter Pro ===");

            // Start with a quick intro
            ShowMenu();

            // Pre-set list of food items (no file needed)
            double[] arrItems = { 12.50, 9.00, 15.99, 4.25, 7.75, 10.50 };
            int intCount = arrItems.Length;

            // Ask user for tax, tip, and number of people
            Console.Write("Tax rate (decimal, e.g., 0.07): ");
            double tax = double.TryParse(Console.ReadLine(), out double t) && t >= 0 ? t : 0;

            Console.Write("Tip rate (decimal, e.g., 0.18): ");
            double tip = double.TryParse(Console.ReadLine(), out double p) && p >= 0 ? p : 0;

            Console.Write("How many people? ");
            int people = int.TryParse(Console.ReadLine(), out int n) && n > 0 ? n : 1;

            // Add up the menu prices
            double subtotal = ComputeSubtotal(arrItems, intCount);
            Console.WriteLine($"[SUBTOTAL] {subtotal:0.00}");

            // Apply tax
            double withTax = subtotal * (1 + tax);
            Console.WriteLine($"[WITH_TAX] {withTax:0.00}");

            // Add the tip — this updates the total in place
            ApplyTip(ref withTax, tip);
            Console.WriteLine($"[WITH_TAX_TIP] {withTax:0.00}");

            // Figure out how much each person owes
            double perHead = PerPerson(withTax, people);
            Console.WriteLine($"[PER_PERSON] {perHead:0.00}");

            Console.WriteLine("=== Done ===");
        }

        // Simple intro screen explaining what the program does
        static void ShowMenu()
        {
            Console.WriteLine("This program totals a meal, adds tax and tip, and splits it evenly.");
            Console.WriteLine("You’ll just enter the tax rate, tip rate, and how many people are paying.");
            Console.WriteLine("Everything else happens automatically.");
            Console.WriteLine();
        }

        // Adds up the total of all menu items
        static double ComputeSubtotal(double[] arr, int count)
        {
            if (arr == null || count <= 0) return 0.0;

            double total = 0.0;
            int limit = Math.Min(count, arr.Length);

            for (int i = 0; i < limit; i++)
            {
                if (arr[i] > 0) total += arr[i];
            }

            return total;
        }

        // Adds tip on top of the current total
        static void ApplyTip(ref double amountWithTax, double tipRate)
        {
            if (tipRate > 0)
            {
                amountWithTax *= (1 + tipRate);
            }
        }

        // Divides the totl between however many people are paying
        static double PerPerson(double grandTotal, int people)
        {
            if (people <= 0) people = 1;
            return grandTotal / people;
        }
    }
}

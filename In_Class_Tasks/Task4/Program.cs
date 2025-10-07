using System;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Define thwe array of integers
            int[] intNumbers = { 6, 7, 15, 20, 8, 12 };

            // 1 Print my array contents
            PrintArray(intNumbers);

            // 2 Find the average and print result
            double dblAverage = FindAverage(intNumbers);
            Console.WriteLine($"The average is: {dblAverage:F2}");

            // 3, Ask user for number to search
            Console.Write("Enter a number to search: ");
            if (!int.TryParse(Console.ReadLine(), out int intTarget))
            {
                Console.WriteLine("Invalid entry. Defaulting to 0.");
                intTarget = 0;
            }

            // 4. Search for number in the array
            SearchNumber(intNumbers, intTarget);

            // BONUS part - Find and display maximum value
            int intMax = FindMax(intNumbers);
            Console.WriteLine($"The maximum number in the array is: {intMax}");

            Console.WriteLine("\nPress Enter to exit.");
            Console.ReadLine();
        }

        /// <summary>
        /// Prints all elements of an integer array on one line
        /// </summary>
        static void PrintArray(int[] intArray)
        {
            Console.WriteLine("Array elements:");
            foreach (int num in intArray)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// calculates and returns the average of an integer array.
        /// </summary>
        static double FindAverage(int[] intArray)
        {
            if (intArray.Length == 0)
                return 0;

            double dblSum = 0;
            foreach (int num in intArray)
            {
                dblSum += num;
            }
            return dblSum / intArray.Length;
        }

        /// <summary>
        /// Searches for a target number in the array and prints if it was found or not.
        /// </summary>
        static void SearchNumber(int[] intArray, int intTarget)
        {
            bool boolFound = false;
            foreach (int num in intArray)
            {
                if (num == intTarget)
                {
                    boolFound = true;
                    break;
                }
            }

            if (boolFound)
            {
                Console.WriteLine($"{intTarget} was found in the array!");
            }
            else
            {
                Console.WriteLine($"{intTarget} was NOT found in the array.");
            }
        }

        /// <summary>
        /// BONUS part - Finds and returns the maximum value in the array
        /// </summary>
        static int FindMax(int[] intArray)
        {
            int intMax = intArray[0];
            for (int i = 1; i < intArray.Length; i++)
            {
                if (intArray[i] > intMax)
                {
                    intMax = intArray[i];
                }
            }
            return intMax;
        }
    }
}

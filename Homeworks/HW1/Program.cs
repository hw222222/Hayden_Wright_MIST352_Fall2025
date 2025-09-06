// Author: Hayden Wright
// Class: MIST 352-Fall2025
// HW #1
// This program collects 4 products with 5 variables, fixes formatting issues in capitalization, and prints them in an organized table

using System;

namespace HW1
{
    class Program
    {
        static void Main(string[] args)
        {   
            // INTRO NOTE: I made sure to follow camel case for variable names and put int, dec, and str prefixes so i wouldn't get lost. 
            // Product #1
            Console.WriteLine("\nProduct #1");

            Console.Write("Enter product name: ");
            // reads the user input and stores it in a string, or the respective variable type in other oens
            string strName1 = Console.ReadLine();
            //makes the whole string lowercase to avoid something like "coCa"
            strName1 = strName1.ToLower();
            // capitalizes the first letter by getting the first letter (it's between 0 and 1), making it upper case and then adding everything
            // after the first letter to it
            strName1 = strName1.Substring(0, 1).ToUpper() + strName1.Substring(1);

            Console.Write("Enter serial number (whole number): ");
            int intSerial1 = int.Parse(Console.ReadLine());

            // had to swap integer for decimal to allow for cents
            Console.Write("Enter price: (no dollar sign): ");
            decimal decPrice1 = decimal.Parse(Console.ReadLine());

            Console.Write("Enter quantity (whole number): ");
            
            int intQty1 = int.Parse(Console.ReadLine());

            Console.Write("Enter category: ");
            string strCategory1 = Console.ReadLine();
            strCategory1 = strCategory1.ToLower();
            strCategory1 = strCategory1.Substring(0, 1).ToUpper() + strCategory1.Substring(1);

            // Product #2 

            // basically copy and pasted product #1 with variable names changed for all 4 products
            Console.WriteLine("\nProduct #2");

            Console.Write("Enter product name: ");
            string strName2 = Console.ReadLine();
            strName2 = strName2.ToLower();
            strName2 = strName2.Substring(0, 1).ToUpper() + strName2.Substring(1);

            Console.Write("Enter serial number (whole number): ");
            int intSerial2 = int.Parse(Console.ReadLine());

            Console.Write("Enter price: (no dollar sign): ");
            decimal decPrice2 = decimal.Parse(Console.ReadLine());

            Console.Write("Enter quantity (whole number): ");
            int intQty2 = int.Parse(Console.ReadLine());
            Console.Write("Enter category: ");
            string strCategory2 = Console.ReadLine();
            strCategory2 = strCategory2.ToLower();
            strCategory2 = strCategory2.Substring(0, 1).ToUpper() + strCategory2.Substring(1);

            // Product #3
            Console.WriteLine("\nProduct #3");

            Console.Write("Enter product name: ");
            string strName3 = Console.ReadLine();
            strName3 = strName3.ToLower();
            strName3 = strName3.Substring(0, 1).ToUpper() + strName3.Substring(1);

            Console.Write("Enter serial number (whole number): ");
            int intSerial3 = int.Parse(Console.ReadLine());

            Console.Write("Enter price (no dollar sign): ");
            decimal decPrice3 = decimal.Parse(Console.ReadLine());

            Console.Write("Enter quantity (whole number): ");
            int intQty3 = int.Parse(Console.ReadLine());

            Console.Write("Enter category: ");
            string strCategory3 = Console.ReadLine();
            strCategory3 = strCategory3.ToLower();
            strCategory3 = strCategory3.Substring(0, 1).ToUpper() + strCategory3.Substring(1);

            // Product #4
            Console.WriteLine("\nProduct #4");

            Console.Write("Enter product name: ");
            string strName4 = Console.ReadLine();
            strName4 = strName4.ToLower();
            strName4 = strName4.Substring(0, 1).ToUpper() + strName4.Substring(1);

            Console.Write("Enter serial number (whole number): ");
            int intSerial4 = int.Parse(Console.ReadLine());

            Console.Write("Enter price (no dollar sign): ");
            decimal decPrice4 = decimal.Parse(Console.ReadLine());

            Console.Write("Enter quantity (whole number): ");
            int intQty4 = int.Parse(Console.ReadLine());

            Console.Write("Enter category: ");
            string strCategory4 = Console.ReadLine();
            strCategory4 = strCategory4.ToLower();
            // i might be wrong but I don't think there's a way to make it capitalize "Red bUll" to "Red Bull" without using if statements,
            // trying to limit the program to just chaper 1 & 2 concepts
            strCategory4 = strCategory4.Substring(0, 1).ToUpper() + strCategory4.Substring(1);

            // table printing starts here
            Console.WriteLine();
            Console.WriteLine(new string('-', 110));
            // 16 seemed to be just the right amount of space for items and numbers
            Console.WriteLine("||" +
                // .PadRight makes sure everything fits, since for example it would add 13 spaces after a 3 letter word to make it 16 characters long
                " Name".PadRight(16) + "||" +
                " Serial".PadRight(16) + "||" +
                " Price".PadRight(16) + "||" +
                " Quantity".PadRight(16) + "||" +
                " Category".PadRight(16) + "||" +
                " Total Price".PadRight(16) + "||");

            // had to play around with this but 110 works to get it exactly uniform
            Console.WriteLine(new string('-', 110));
            //this section was copy and pasted to get all 4 products on the table
            Console.WriteLine("||" +
            // only one writeline per product and then used + to get everything together while remaining properly spaced on the same row
                (" " + strName1).PadRight(16) + "||" +
                (" " + intSerial1.ToString()).PadRight(16) + "||" +
                // had to do some formatting to get the prices to show up as $0.00
                //also used the " $" + to get the dollar sign to show up
                (" $" + decPrice1.ToString("0.00")).PadRight(16) + "||" +
                (" " + intQty1.ToString()).PadRight(16) + "||" +
                (" " + strCategory1).PadRight(16) + "||" +
                // calculating total price here by multiplying price by quantity
                (" $" + (decPrice1 * intQty1).ToString("0.00")).PadRight(16) + "||");

            Console.WriteLine("||" +
                (" " + strName2).PadRight(16) + "||" +
                (" " + intSerial2.ToString()).PadRight(16) + "||" +
                (" $" + decPrice2.ToString("0.00")).PadRight(16) + "||" +
                (" " + intQty2.ToString()).PadRight(16) + "||" +
                (" " + strCategory2).PadRight(16) + "||" +
                (" $" + (decPrice2 * intQty2).ToString("0.00")).PadRight(16) + "||");

            Console.WriteLine("||" +
                (" " + strName3).PadRight(16) + "||" +
                (" " + intSerial3.ToString()).PadRight(16) + "||" +
                (" $" + decPrice3.ToString("0.00")).PadRight(16) + "||" +
                (" " + intQty3.ToString()).PadRight(16) + "||" +
                (" " + strCategory3).PadRight(16) + "||" +
                (" $" + (decPrice3 * intQty3).ToString("0.00")).PadRight(16) + "||");

            Console.WriteLine("||" +
                (" " + strName4).PadRight(16) + "||" +
                (" " + intSerial4.ToString()).PadRight(16) + "||" +
                (" $" + decPrice4.ToString("0.00")).PadRight(16) + "||" +
                (" " + intQty4.ToString()).PadRight(16) + "||" +
                (" " + strCategory4).PadRight(16) + "||" +
                (" $" + (decPrice4 * intQty4).ToString("0.00")).PadRight(16) + "||");

        }
    }
}

using System;

namespace InClass3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // gathering item count

            Console.WriteLine("How many items are in this order?");
            // modeled this if loop to do the rest of the data entry for quantities, price, etc
            if (!int.TryParse(Console.ReadLine(), out int intItemCount) || intItemCount < 0)
            {
                Console.WriteLine("Invalid input. Defaulting to 0 items.");
                intItemCount = 0;
            }

            // declaring arrays for everything outlined in the pseudocode 
            string[] strNames = new string[intItemCount];
            double[] dblPrices = new double[intItemCount];
            int[] intQtys = new int[intItemCount];
            int[] intStocks = new int[intItemCount];
            double[] dblLineTotals = new double[intItemCount];
            double[] dblLineDiscounts = new double[intItemCount];
            bool[] boolReorder = new bool[intItemCount];
            //into POS message like on the screenshot provided
            Console.WriteLine();
            Console.WriteLine("=== Mini POS: Enter item details ===");
            Console.WriteLine();
            // business rules to default invalid enteries to zero, apart from product name obviously 
            for (int i = 0; i < intItemCount; i++)
            {
                Console.WriteLine("Enter product name");
                //solves for a scenario where the user has an empty entry 
                strNames[i] = Console.ReadLine() ?? string.Empty;

                Console.WriteLine("Enter unit price (e.g., 12.51)");
                if (!double.TryParse(Console.ReadLine(), out dblPrices[i]) || dblPrices[i] < 0)
                {
                    Console.WriteLine("Invalid. Defaulting to 0");
                    dblPrices[i] = 0;
                }

                Console.WriteLine("Enter quantity (integer)");
                if (!int.TryParse(Console.ReadLine(), out intQtys[i]) || intQtys[i] < 0)
                {
                    Console.WriteLine("Invalid. Defaulting to 0");
                    intQtys[i] = 0;
                }

                Console.WriteLine("Enter stock on hand (integer)");
                if (!int.TryParse(Console.ReadLine(), out intStocks[i]) || intStocks[i] < 0)
                {
                    Console.WriteLine("Invalid. Defaulting to 0");
                    intStocks[i] = 0;
                }
                // declaring double here for gross
                double dblGross = dblPrices[i] * intQtys[i];

                // Bulk discount of 5% appled
                if (intQtys[i] >= 10)
                {
                    dblLineDiscounts[i] = dblGross * 0.05;
                }
                else
                {
                    dblLineDiscounts[i] = 0;
                }

                dblLineTotals[i] = dblGross - dblLineDiscounts[i];

                // flags low stock with a bool
                int intPostSaleStock = intStocks[i] - intQtys[i];
                boolReorder[i] = intPostSaleStock < 5;
            }

            // calcs the totals
            double dblSubtotal = 0;
            for (int i = 0; i < intItemCount; i++)
            {
                dblSubtotal += dblLineTotals[i];
            }
            // calculates the sales tax amount and adds it for the grand total 
            double dblTax = dblSubtotal * 0.06;
            //it would be cool to have a system for this and kind of more realistic if
            //it let you apply a sales tax waiver within the program in some scenarios

            // could also just do dblSubtotal + 1.06; since taxrate isn't modified whatsoever in the program regardless
            double dblGrand = dblSubtotal + dblTax;

            // print and output section
            Console.WriteLine();
            Console.WriteLine("=== Order Summary ===");
            Console.WriteLine("Name".PadRight(20) +
                              "Price".PadLeft(8) +
                              "Qty".PadLeft(6) +
                              "Gross".PadLeft(10) +
                              "Disc".PadLeft(10) +
                              "Line Total".PadLeft(15) +
                              "Reorder".PadLeft(10));
            // the new string thing here for writeline lets me tweak the exact amount of dashes so it's faster to make it look clean
            Console.WriteLine(new string('-', 80));

            for (int i = 0; i < intItemCount; i++)
            {
                //had to run the double multiplication here again for some reason to get dblGross to output properly
                double dblGross = dblPrices[i] * intQtys[i];
                string reorderFlag = boolReorder[i] ? "YES" : "NO";
                // used the same padding strategy i used on the first homework to sucessfully output a clean looking table
                Console.WriteLine(strNames[i].PadRight(20) +
                                  dblPrices[i].ToString("0.00").PadLeft(8) +
                                  intQtys[i].ToString().PadLeft(6) +
                                  dblGross.ToString("0.00").PadLeft(10) +
                                  dblLineDiscounts[i].ToString("0.00").PadLeft(10) +
                                  dblLineTotals[i].ToString("0.00").PadLeft(15) +
                                  reorderFlag.PadLeft(10));
            }
            Console.WriteLine(new string('-', 80));
            //this keeps the pricing point in an orderly fashion eg 12.59
            Console.WriteLine("Subtotal:".PadLeft(20) + dblSubtotal.ToString("0.00").PadLeft(10));
            Console.WriteLine($"Tax (6%):".PadLeft(20) + dblTax.ToString("0.00").PadLeft(10));
            Console.WriteLine("GRAND TOTAL:".PadLeft(20) + dblGrand.ToString("0.00").PadLeft(10));
            Console.WriteLine();
            // this should now almost perfectly match the screenshot output
            Console.WriteLine("Done. Press Enter to exit.");
            Console.ReadLine();
        }
    }
}

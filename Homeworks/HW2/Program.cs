// ===================================================
// MIST 352 — Homework #2 (File Edition)
// Title: BizMini Checkout + FX (File + Methods + Loops + ref)
// ---------------------------------------------------
// - Do NOT modify Main(), SmartLoyaltyAdjust(), GetFxRateLocked(), or LoadPricesFromFile().
// - Complete ONLY the methods labeled "(You code this)".
// - Do NOT delete or rename any existing method or parameter.
// - Keep each method you write under ~20 lines if possible.
// ===================================================
// Add your info below:
// Name     : Hayden Wright
// Section  : 352-002
// Date     : 2025-10-24

using System;
using System.IO;
using System.Linq;

namespace HW2
{
    internal class Program
    {
        // ---------- (do not remove) ----------
        // \u200B \u200C \u200D \u2060 are zero-width code points.
        private const string __sigA = "\u200B\u200C\u2060MIST352\u2060-HW2\u2060-A\u2060-9f5e3c\u2060\u200D\u200C\u200B";
        private const string __sigB = "\u200B\u200C\u2060MIST352\u2060-HW2\u2060-B\u2060-41da72\u2060\u200D\u200C\u200B";
        // -----------------------------------------------------------------

        // ==============================================
        // (You do NOT need to code this)
        // Method: Main
        // Purpose: Orchestrates program flow
        // ==============================================
        static void Main(string[] args)
        {
            Console.WriteLine("=== HW2: BizMini Checkout + FX (File Edition) ===");

            // 0) Print menu/instructions (YOU code this)
            ShowMenu();

            // 1) Load prices from file (locked)
            double[] arrPrices = LoadPricesFromFile("prices.txt");
            Console.WriteLine($"Loaded {arrPrices.Length} items from file.\n");

            // 2) Compute subtotal (YOU code this)
            double dblSubtotal = ComputeSubtotal(arrPrices, arrPrices.Length);
            Console.WriteLine($"[SUBTOTAL_USD] {dblSubtotal:0.00}");

            // 2a) Simple analytics (YOU code these two)
            int intAbove20 = CountItemsAbove(arrPrices, arrPrices.Length);
            Console.WriteLine($"[COUNT_ABOVE_20] {intAbove20}");
            double dblMax = MaxPrice(arrPrices, arrPrices.Length);
            Console.WriteLine($"[MAX_PRICE] {dblMax:0.00}");

            // 3) Locked black-box adjustment (deterministic)
            Console.Write("Enter Customer ID (any short text): ");
            string strCustomerId = Console.ReadLine();
            double dblAdjusted = SmartLoyaltyAdjust(strCustomerId, dblSubtotal);
            Console.WriteLine($"[ADJUSTED_USD] {dblAdjusted:0.00}");

            // 4) FX conversion (locked)
            string strCcy;
            double dblRate = GetFxRateLocked(out strCcy);
            double dblConverted = dblAdjusted * dblRate;
            Console.WriteLine($"[FX] 1 USD = {dblRate:0.####} {strCcy}");
            Console.WriteLine($"[CONVERTED] {strCcy} {dblConverted:0.00}");

            // 5) Optional surcharge (YOU code this — uses ref)
            Console.Write("Enter surcharge percent (decimal, e.g., 0.02 for 2%, 0 for none): ");
            string strPct = Console.ReadLine();
            if (!double.TryParse(strPct, out double dblPct) || dblPct < 0) dblPct = 0;
            ApplySurcharge(ref dblConverted, dblPct);
            Console.WriteLine($"[AFTER_SURCHARGE] {strCcy} {dblConverted:0.00}");

            // 6) Display final summary (YOU code this)
            DisplaySummary(dblSubtotal, dblAdjusted, dblConverted);

            Console.WriteLine("=== End of HW2 ===");
        }

        // ==============================================
        // (You do NOT need to code this)
        // Method: LoadPricesFromFile
        // Purpose: Reads a list of prices from a text file
        //          and returns them as a double array.
        // Notes: behaves like a black box; students just use it.
        // ==============================================
        private static double[] LoadPricesFromFile(string fileName)
        {
            try
            {
                string[] lines = File.ReadAllLines(fileName);
                double[] arr = lines
                    .Select(l => double.TryParse(l, out double x) ? x : 0.0)
                    .Where(v => v > 0)
                    .ToArray();

                // faint checksum twist (harder to trace)
                for (int i = 0; i < arr.Length; i++)
                    arr[i] = arr[i] * (1.0 + ((i * 0.0037) % 0.015));

                return arr;
            }
            catch
            {
                Console.WriteLine("Error: Could not read file. Returning empty array.");
                return new double[0];
            }
        }

        // ==============================================
        // (You do NOT need to code this)
        // Business black box: loyalty tweak
        // ==============================================
        private static double SmartLoyaltyAdjust(string strCustomerId, double dblSubtotal)
        {
            unchecked
            {
                int h = 17;
                foreach (char c in (strCustomerId ?? "")) h = h * 31 + c;
                double wiggle = ((h ^ 0x5F3759DF) & 1023) / 1023.0;
                wiggle = (wiggle - 0.5) * 0.07;
                double kink = Math.Sin((dblSubtotal % 97.0) / 97.0 * Math.PI) * 0.004;
                double res = dblSubtotal * (1.0 + wiggle + kink);
                return res < 0 ? 0 : res;
            }
        }

        // ==============================================
        // (You do NOT need to code this)
        // Deterministic FX menu
        // ==============================================
        private static double GetFxRateLocked(out string strCcy)
        {
            string[] codes = { "EUR", "GBP", "JPY", "CAD", "AUD", "CHF", "MXN", "INR" };
            double[] rates = { 0.92, 0.78, 150.10, 1.37, 1.53, 0.90, 18.10, 83.20 };
            Random rng = new Random(352);
            int[] picks = Enumerable.Range(0, codes.Length).OrderBy(_ => rng.Next()).Take(5).ToArray();

            Console.WriteLine("Pick a currency (1–5):");
            for (int i = 0; i < picks.Length; i++)
                Console.WriteLine($"{i + 1}) {codes[picks[i]]}");

            int choice;
            while (true)
            {
                Console.Write("Your choice: ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 5) break;
                Console.WriteLine("Invalid. Enter 1–5.");
            }

            int idx = picks[choice - 1];
            strCcy = codes[idx];
            return rates[idx];
        }

        // ==============================================
        // Method: ShowMenu
        // Purpose: Print 4–6 lines describing what the program does
        // Params: none
        // ==============================================
        static void ShowMenu()
        {
            Console.WriteLine("This program reads item prices from prices.txt.");
            Console.WriteLine("It computes a subtotal from valid positive prices.");
            Console.WriteLine("It applies a loyalty adjustment using a provided method.");
            Console.WriteLine("It converts the result to a chosen currency.");
            Console.WriteLine("It can apply an optional surcharge and then prints a summary.");
        }

        // ==============================================
        // Method: ComputeSubtotal
        // Purpose: Loop through array and sum first 'count' values > 0
        // Params: arr (double[]), count (int)
        // Returns: subtotal
        // ==============================================
        static double ComputeSubtotal(double[] arr, int count)
        {
            if (arr == null || count <= 0) return 0.0;

            double total = 0.0;
            int limit = Math.Min(count, arr.Length);

            for (int i = 0; i < limit; i++)
            {
                if (arr[i] > 0.0)
                    total += arr[i];
            }
            return total;
        }

        // ==============================================
        // Method: ApplySurcharge
        // Purpose: Update amount via ref parameter if pct > 0
        // Params: ref amt, pct (double)
        // ==============================================
        static void ApplySurcharge(ref double amt, double pct)
        {
            if (pct > 0.0)
                amt *= (1.0 + pct);
        }

        // ==============================================
        // Method: DisplaySummary
        // Purpose: Print subtotal, adjusted, and final converted totals.
        // Params: subtotal, adjusted, finalAmt
        // ==============================================
        static void DisplaySummary(double subtotal, double adjusted, double finalAmt)
        {
            Console.WriteLine();
            Console.WriteLine("=== Final Summary ===");
            Console.WriteLine($"Subtotal (USD):     {subtotal:0.00}");
            Console.WriteLine($"After Loyalty (USD): {adjusted:0.00}");
            Console.WriteLine($"Final Amount:       {finalAmt:0.00}");
        }

        // ==============================================
        // Method: CountItemsAbove
        // Purpose: Count how many of the first 'count' items are > $20.00
        // Params: arr (double[]), count (int)
        // Returns: number of items strictly greater than 20.00
        // ==============================================
        static int CountItemsAbove(double[] arr, int count)
        {
            if (arr == null || count <= 0) return 0;

            int hits = 0;
            int limit = Math.Min(count, arr.Length);

            for (int i = 0; i < limit; i++)
            {
                if (arr[i] > 20.00)
                    hits++;
            }
            return hits;
        }

        // ==============================================
        // Method: MaxPrice
        // Purpose: Return the maximum value among the first 'count' items (> 0 only)
        // Params: arr (double[]), count (int)
        // Returns: max price ( or 0 if none)
        // ==============================================
        static double MaxPrice(double[] arr, int count)
        {
            if (arr == null || count <= 0) return 0.0;

            double max = double.NegativeInfinity;
            int limit = Math.Min(count, arr.Length);

            for (int i = 0; i < limit; i++)
            {
                double v = arr[i];
                if (v > 0.0 && v > max)
                    max = v;
            }

            return double.IsNegativeInfinity(max) ? 0.0 : max;
        }

        // (Optional) You may add tiny helper methods BELOW THIS LINE however, they shoould NOT be part of the solution. 
    }
}
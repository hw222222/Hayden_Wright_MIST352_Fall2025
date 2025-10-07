using System;

namespace Methods_Arrays_Switch_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strNames = { "Sarah", "Ahmad", "John", "Tiffany", "Mike", "Rachel" };
            char chrUserChoice = 'A';

            while (chrUserChoice != 'X') ;
            {
                Console.WriteLine("Choose an option from below:");
                Console.WriteLine("A- Print out all names \n B- Search for a name \n X to exit");
                chrUserChoice = Console.ReadKey().KeyChar;
                if (chrUserChoice == 'A') { }
                else if (chrUserChoice == 'B') { }

            }

            for (int intIndex = 0; intIndex < strNames.Length; intIndex++)
            {
                
            }
        }
    }
}
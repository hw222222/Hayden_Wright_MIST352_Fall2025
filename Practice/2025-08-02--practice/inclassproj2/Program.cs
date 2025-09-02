// See https://aka.ms/new-console-template for more information

using System.Runtime.CompilerServices;

namespace Practice2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // defined 2 variables
            double dblVal1, dblVal2;

            // ask user for input 1
            Console.WriteLine("Give me value 1");
            dblVal1 = Convert.ToDouble(Console.ReadLine());
            //Console.WriteLine(dblVal1);

            // ask user for input 1
            Console.WriteLine("Give me value 2");
            dblVal2 = Convert.ToDouble(Console.ReadLine());
            //Console.WriteLine(dblVal2);

            Console.WriteLine(dblVal1 + dblVal2);
            Console.WriteLine($"The Sum of {dblVal1} and {dblVal2} is {dblVal1 + dblVal2}");
        }
    }
}
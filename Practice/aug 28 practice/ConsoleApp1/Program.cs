// See https://aka.ms/new-console-template for more information
using System.Net.Security;
namespace Practice1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, welcome to practice 1");
            Console.WriteLine("This portion shows us how to print a thing out");
            // ########### Functionality1 #############
            Console.WriteLine("-----------You now are in functionality 1-----------");
            Console.WriteLine("A circle with a radius of 1 is 3.14");
            // The forumula for area of a circle is r * r 8 3.14, where r is the radius
            // r stores the radius
            double thatRadius = 10.5;
            // a stores the area
            double theArea = thatRadius * thatRadius * 3.14;
            string n = "circle 1";
            //Console.WriteLine("A circle with a radius of " + r + " is " + a);
            //Console.WriteLine("A circle with a radius of {0} is {1}", r, a);
            Console.WriteLine($"{n} with a radius of {thatRadius} is {theArea}");
            Console.WriteLine("-----------End of functionality 1-----------");



        }
    }
}
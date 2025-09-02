//Name: Hayden Wright
// Task 1
// Date Tuesday 8/26/25
// This program simply prints out some messages to the user. Nothing fancy.
// Used copilot to help troubleshoot issues I was having on Mac with the NET framework while configuring the project file.
// This message displays headers of my table.
namespace Task1
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World! This is my first C# application.");
            Console.Write("Today is Tuesday 8/26/25\n");
            Console.WriteLine("================================");
            Console.WriteLine(" Name\t\temail\t\tage\t\taddress");
            Console.WriteLine(" Sarah\t\tsarah@email.com\t\t25\t\tFairmont"); 
            Console.WriteLine(" MJ Ahmad\t\tmahmad2@mix.wvu.edu\t\t41\t\tMorgantown");
            Console.WriteLine(" Name email age address");
            Console.WriteLine("================================");
        }
    }
}
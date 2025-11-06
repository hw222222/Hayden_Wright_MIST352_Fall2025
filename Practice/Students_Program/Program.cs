using System;
using System.Security.Cryptography.X509Certificates;

namespace Students_Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Student hw = new Student();
            Student sarah = new Student();
            hw.strName = "Hayden Wright";
            hw.dblGpa = 3.1;

            hw.PrintInfo();
            
        }
    }
}
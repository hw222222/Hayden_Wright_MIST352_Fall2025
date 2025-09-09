using System;
namespace Practice4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string strData = "hayden john wright";
            Console.WriteLine(strData.Length);

            // remove left side spaces
            //strData = strData.TrimStart();
            // remove right side spaces
            //strData = strData.TrimEnd();
            //Console.WriteLine("Use TrimStart anc test");
            //Console.WriteLine(strData);

            // print out the text's length
            //Console.WriteLine(strData.Length);

            // lets find some data in the text
            //Console.WriteLine(strData.IndexOf(" "));
            //int intIndexOf = strData.IndexOf("S");

            int intFirstSpace = strData.IndexOf(" ");   
            int intLastSpace = strData.LastIndexOf(" ");
            Console.Write($"The first name is {strData.Substring(0, 1).ToUpper()}");
            Console.WriteLine($"{strData.Substring(1, intFirstSpace)}");
            Console.WriteLine($"The middle name is {strData.Substring(intFirstSpace, intLastSpace - intFirstSpace)}");
            Console.WriteLine($"The last name is {strData.Substring(intLastSpace)}");


        }
    }
}
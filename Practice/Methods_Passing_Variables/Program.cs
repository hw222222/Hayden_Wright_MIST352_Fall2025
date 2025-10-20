using System;
using System.ComponentModel.DataAnnotations;

namespace Methods_Passing_Variables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isValid = new EmailAddressAttribute().IsValid("youremailheretesttest");
            Console.WriteLine($"Is valid: {isValid}");
        }
    }
}
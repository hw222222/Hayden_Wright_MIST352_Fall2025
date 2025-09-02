// See https://aka.ms/new-console-template for more information
using System;

internal class Program
{
    static void Main(string[] args)
    {
        string strName = " ";
        Console.WriteLine("Give me your name: ");
        strName = Console.ReadLine();
        double dblGrade1, dblGrade2, dblGrade3, dblGPA;
        // Console.WriteLine(strName);

        // Accept Grade 1
        Console.WriteLine("What is grade 1? ");
        dblGrade1 = Double.Parse(Console.ReadLine());

        // Accept Grade 2
        Console.WriteLine("What is grade 2? ");
        dblGrade2 = Double.Parse(Console.ReadLine());

        //accept Grade 3
        Console.WriteLine("What is grade 3? ");
        dblGrade3 = Double.Parse(Console.ReadLine());

        dblGPA = (dblGrade1 + dblGrade2 + dblGrade3) / 3;

        Console.WriteLine($"Hello {strName}, your grades {dblGrade1}, {dblGrade2}, and {dblGrade3} equal a gpa of {dblGPA}");

        bool blnFail = dblGPA<50;
        Console.WriteLine($"failed? {blnFail}");

    }
}
/*
Thursday 9/11/2025

*/
using System;

namespace Chapter3_Arrays_Loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            // define an array of grades and assessmentss
            string[] strAssessments = { "TASK1", "HW1", "TASK2", "QUIZ1", "EXAM1", "HW2", "task3", "QUIZ2" };
            float[] fltGrades = { 90, 88, 70, 95, 60, 50, 77, 50 };

            // for loop to access/ read/ manipulate contents of the array
            for (int intIndex = 0; intIndex < strAssessments.Length; intIndex++)
            {
                Console.WriteLine($"Assessment: {strAssessments[intIndex]}\t\t Grade {fltGrades[intIndex]}");
            }

            Console.WriteLine("==============================");
            Console.WriteLine("prints all the first assignments/grades.");

            for (int intIndex = 0; intIndex < strAssessments.Length; intIndex++)
            {
                if (strAssessments[intIndex].Contains("1"))
                {
                    Console.WriteLine($"Assessment: {strAssessments[intIndex]}\t\t Grade {fltGrades[intIndex]}");
                }
            }
            // next class code the ABCDF grading scale
            Console.WriteLine("==============================");
            Console.WriteLine("Printout homeworks and tasks only and their grades.");

            for (int intIndex = 0; intIndex < strAssessments.Length; intIndex++)
            {
                if (strAssessments[intIndex].ToLower().Contains("HW".ToLower()) || strAssessments[intIndex].ToLower().Contains("Task".ToLower()))
                {
                    Console.WriteLine($"Assessment: {strAssessments[intIndex]}\t\t Grade {fltGrades[intIndex]}");
                }
            }
            */

            double dblGrade = Double.Parse(Console.ReadLine());
            
            if(dblGrade>100 || dblGrade<0)
            {
                Console.WriteLine("Invalid Input");
            }
            else

            if (dblGrade >= 90)
            {
                Console.WriteLine("A");
            }
            else if (dblGrade >= 80)
            {
                Console.WriteLine("B");
            }
            else if (dblGrade >= 70)
            {
                Console.WriteLine("C");
            }
            else if (dblGrade >= 60)
            {
                Console.WriteLine("D");
            }
            else
            {
                Console.WriteLine("F");
            }


        }
    }
}
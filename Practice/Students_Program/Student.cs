using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Student
{
    private string ID;
    public string strName;
    public double dblGpa;
    public string strFirstName;
    public string strLastName;

    public void PrintInfo()
    {
        Console.WriteLine($" {strName} has GPA {dblGpa}");
    }
}
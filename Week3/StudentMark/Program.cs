using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public string Name { get; set; }
    public double GPA { get; set; }

    public Student(string name, double gpa)
    {
        Name = name;
        GPA = gpa;
    }
}

//User input missing

public class Program
{
    public static void Main()
    {
        // Create a list of students
        List<Student> students = new List<Student>
        {
            new Student("Abi", 3.9),
            new Student("Sathiya", 3.2),
            new Student("Umar", 3.8),
            new Student("Ryaan", 4.0),
            new Student("Vihaan", 2.9)
        };

        // Filter students with GPA greater than 3.5 using LINQ
        var topStudents = from student in students
                          where student.GPA > 3.5
                          select student;

        // Output the result
        foreach (var student in topStudents)
        {
            Console.WriteLine($"{student.Name} - GPA: {student.GPA}");
        }
    }
}

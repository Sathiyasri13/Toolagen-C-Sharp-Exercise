using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        // Step 1: Create an empty dictionary to store student names and scores
        Dictionary<string, int> studentScores = new Dictionary<string, int>();

        // Step 2: Ask how many students the user wants to enter
        Console.WriteLine("How many students' scores would you like to enter?");
        int numberOfStudents = int.Parse(Console.ReadLine());

        // Step 3: Collect student names and scores from the user
        for (int i = 0; i < numberOfStudents; i++)
        {
            Console.WriteLine($"Enter name of student #{i + 1}:");
            string? studentName = Console.ReadLine();

            Console.WriteLine($"Enter score for {studentName}:");
            int score = int.Parse(Console.ReadLine());

            // Add to dictionary
            studentScores[studentName] = score;
        }

        // Step 4: Print the student's name and their score
        Console.WriteLine("\nStudent Scores:");
        foreach (var entry in studentScores)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }
    }
}

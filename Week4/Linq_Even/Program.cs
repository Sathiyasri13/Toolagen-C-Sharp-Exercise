using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        // Step 1: Create a list of numbers from 1 to 10
        List<int> numbers = Enumerable.Range(1, 10).ToList();

        // Step 2: Use LINQ query syntax to filter even numbers
        var evenNumbers = from num in numbers
                          where num % 2 == 0
                          select num;

        // Step 3: Print the even numbers
        Console.WriteLine("Even numbers from 1 to 10:");
        foreach (var num in evenNumbers)
        {
            Console.WriteLine(num);
        }
    }
}

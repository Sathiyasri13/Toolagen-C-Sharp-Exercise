using System;

public class Program
{
    // Generic method to swap two variables of any type
    public static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }

    public static void Main(string[] args)
    {
        // Example 1: Swapping two integers (User input)
        Console.WriteLine("Enter the first integer: ");
        int x = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the second integer: ");
        int y = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"Before swap: x = {x}, y = {y}");
        Swap(ref x, ref y);
        Console.WriteLine($"After swap: x = {x}, y = {y}");

        // Example 2: Swapping two strings (User input)
        Console.WriteLine("\nEnter the first string: ");
        string? str1 = Console.ReadLine();

        Console.WriteLine("Enter the second string: ");
        string? str2 = Console.ReadLine();

        Console.WriteLine($"Before swap: str1 = {str1}, str2 = {str2}");
        Swap(ref str1, ref str2);
        Console.WriteLine($"After swap: str1 = {str1}, str2 = {str2}");

    }
}

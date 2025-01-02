using System;

class Program
{
    static void Main()
    {
        // Prompt the user to enter the first string
        // This is accepting the number as well, please check
        Console.Write("Enter the first string: ");
        string? str1 = Console.ReadLine();
        
        // Prompt the user to enter the second string
        // This is accepting the number as well, please check
        Console.Write("Enter the second string: ");
        string? str2 = Console.ReadLine();

        // Convert both strings to upper case and compare
        if (str1?.ToUpper() == str2?.ToUpper())
        {
            Console.WriteLine("The strings are equal.");
        }
        else
        {
            Console.WriteLine("The strings are not equal.");
        }
    }
}

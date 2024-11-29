using System;

public class Program
{
    public static void Main()
    {
        int num1, num2;

        // Get the first number with exception handling
        while (true)
        {
            try
            {
                Console.Write("Enter the first number: ");
                string? input1 = Console.ReadLine();
                num1 = int.Parse(input1); // This will throw an exception if input is invalid
                break; // Break out of loop if input is valid
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input for the first number. Please enter a valid integer.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("The number is too large or too small. Please enter a valid integer.");
            }
        }

        // Get the second number with exception handling
        while (true)
        {
            try
            {
                Console.Write("Enter the second number: ");
                string? input2 = Console.ReadLine();
                num2 = int.Parse(input2); 
                break; // Break out of loop if input is valid
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input for the second number. Please enter a valid integer.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("The number is too large or too small. Please enter a valid integer.");
            }
        }

        // Declare and initialize a Func delegate to add two integers
        Func<int, int, int> addNumbers = (x, y) => x + y;

        // Use the delegate to add the two numbers
        int result = addNumbers(num1, num2);

        // Output the result
        Console.WriteLine($"The sum of {num1} and {num2} is: {result}");
    }
}

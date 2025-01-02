using System;

class Program
{
    static void Main()
    {
        // Define a Predicate<int> delegate that checks if a number is positive
        // Number 0 is neither positive nor negative
        Predicate<int> isPositive = number => number > 0;

        while (true)
        {
            // Ask the user for input
            Console.WriteLine("Enter a number (or type 'exit' to stop):");

            // Read the user input
            string? input = Console.ReadLine();

            // If the user types "exit", break the loop
            if (input.ToLower() == "exit")
            {
                break;
            }

            // Try to parse the input as an integer
            if (int.TryParse(input, out int number))
            {
                // Use the Predicate to check if the number is positive
                if (isPositive(number))
                {
                    Console.WriteLine($"{number} is positive.");
                }
                else
                {
                    Console.WriteLine($"{number} is not positive.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
    }
}

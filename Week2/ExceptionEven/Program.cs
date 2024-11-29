using System;

class Even
{
    // Method to validate if the number is even
    static void CheckIfEven(int number)
    {
        // Check if the number is not even
        if (number % 2 != 0)
        {
            // Throwing an exception if the number is not even
            throw new ArgumentException("The number is not even.");
        }
        
        Console.WriteLine($"The number {number} is even.");
    }

    static void Main()
    {
        try
        {
            // Prompt the user for input
            Console.Write("Enter a number: ");
            
            // Read user input
            string? input = Console.ReadLine();
            
            // Check if input is null or empty
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Error: Input cannot be empty.");
                return;
            }

            // Try to parse the input to an integer
            if (int.TryParse(input, out int number))
            {
                // Call the CheckIfEven method to check if the number is even
                CheckIfEven(number);
            }
            else
            {
                // Handle invalid integer input
                Console.WriteLine("Error: Please enter a valid number.");
            }
        }
        catch (ArgumentException ex)
        {
            // Catching the exception and displaying the error message
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

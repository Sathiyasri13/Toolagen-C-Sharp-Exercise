using System;

class Program
{
    // Method to validate the age
    static void ValidateAge(int age)
    {
        // Check if the age is a negative value or unreasonably high
        if (age < 0 || age > 120)
        {
            // Throwing an ArgumentOutOfRangeException if the age is invalid
            throw new ArgumentOutOfRangeException(nameof(age), "Age must be between 0 and 120.");
        }
        
        Console.WriteLine($"Age {age} is valid.");
    }

    static void Main()
    {
        try
        {
            // Prompt the user for input
            Console.Write("Enter your age: ");
            
            // Read user input
            string? input = Console.ReadLine();
            
            // Check if input is null or empty
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Error: Age cannot be empty.");
                return;  // Exit the program if the input is invalid
            }

            // Try to parse the input to an integer
            if (int.TryParse(input, out int age))
            {
                // Call the ValidateAge method
                ValidateAge(age);
            }
            else
            {
                // Handle invalid integer input
                Console.WriteLine("Error: Please enter a valid number for age.");
            }
        }
        catch (ArgumentOutOfRangeException ex)
        {
            // Catching the exception and displaying the error message
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

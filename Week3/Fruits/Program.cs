using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create a list to store the user's favorite fruits
        List<string> favoriteFruits = new List<string>();
        
        // Ask the user how many fruits they want to input
        Console.WriteLine("How many fruits would you like to input?");
        int numOfFruits;

        // Try to parse the user input into an integer (number of fruits)
        try
        {
            numOfFruits = int.Parse(Console.ReadLine());

            // Get the user's favorite fruits
            for (int i = 0; i < numOfFruits; i++)
            {
                Console.WriteLine($"Enter the name of fruit {i + 1}:");
                string fruit = Console.ReadLine();

                // Check if fruit is null or empty before adding
                if (!string.IsNullOrEmpty(fruit))
                {
                    favoriteFruits.Add(fruit);  // Add the fruit to the list
                }
                else
                {
                    Console.WriteLine("Invalid input! The fruit name cannot be null or empty.");
                }
            }

            // Loop through the list and print each fruit
            Console.WriteLine("\nYour favorite fruits are:");
            foreach (var fruit in favoriteFruits)
            {
                Console.WriteLine(fruit);
            }
        }
        catch (FormatException)
        {
            // Catch any input errors, such as non-integer input for number of fruits
            Console.WriteLine("Invalid input! Please enter a valid number.");
        }
        catch (Exception ex)
        {
            // Catch any other exceptions
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}

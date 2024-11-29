using System;

class Program
{
    static void Main()
    {
        // Prompt the user for their name
        Console.Write("Please enter your name: ");
        
        // Read the user's input (name)
        string? UserName = Console.ReadLine();
        
        // Read the time from system
        int hour =  DateTime.Now.Hour;

        string? greeting;
        if (hour >= 5 && hour < 12)
        {
            greeting = "Good Morning";
        }
        else if (hour >= 12 && hour < 17)
        {
            greeting = "Good Afternoon";
        }
        else if (hour >= 17 && hour < 21)
        {
            greeting = "Good Evening";
        }
        else
        {
            greeting = "Good Night";
        }        
        // Greet the user
        Console.WriteLine($"{greeting}, {UserName}! Welcome Have a Good Day!!!.");
    }
}

using System;

public abstract class Shape
{
    // Abstraction: Method to calculate area (to be implemented in derived classes)
    public abstract double CalculateArea();
    public abstract void DisplayInfo();
}

public class Circle : Shape
{
    // Encapsulation: private field for radius
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * Math.Pow(radius, 2);  // Area = π * r^2
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Circle with radius {radius}. Area: {CalculateArea():F2}");
    }
}

public class Rectangle : Shape
{
    // Encapsulation: private fields for length and width
    private double length;
    private double width;

    public Rectangle(double length, double width)
    {
        this.length = length;
        this.width = width;
    }

    public override double CalculateArea()
    {
        return length * width;  // Area = length * width
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Rectangle with length {length} and width {width}. Area: {CalculateArea():F2}");
    }
}

public class Triangle : Shape
{
    // Encapsulation: private fields for base and height
    private double baseLength;
    private double height;

    public Triangle(double baseLength, double height)
    {
        this.baseLength = baseLength;
        this.height = height;
    }

    public override double CalculateArea()
    {
        return 0.5 * baseLength * height;  // Area = 1/2 * base * height
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Triangle with base {baseLength} and height {height}. Area: {CalculateArea():F2}");
    }
}

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Select a shape to calculate its area:");
            Console.WriteLine("1. Circle");
            Console.WriteLine("2. Rectangle");
            Console.WriteLine("3. Triangle");

            // Prompt user to select a shape
            int choice = 0;
            string? inputChoice = Console.ReadLine();

            // Check for null or empty input for the choice
            if (string.IsNullOrEmpty(inputChoice) || !int.TryParse(inputChoice, out choice))
            {
                Console.WriteLine("Invalid selection. Please enter a valid number.");
                return;
            }

            Shape? shape = null;  // To hold the selected shape

            switch (choice)
            {
                case 1: // Circle
                    Console.Write("Enter the radius of the circle: ");
                    string? radiusInput = Console.ReadLine();

                    if (string.IsNullOrEmpty(radiusInput) || !double.TryParse(radiusInput, out double radius) || radius <= 0)
                    {
                        Console.WriteLine("Error: Please enter a valid positive number for the radius.");
                        return;
                    }

                    shape = new Circle(radius);  // Create a Circle object
                    break;

                case 2: // Rectangle
                    Console.Write("Enter the length of the rectangle: ");
                    string? lengthInput = Console.ReadLine();
                    Console.Write("Enter the width of the rectangle: ");
                    string? widthInput = Console.ReadLine();

                    if (string.IsNullOrEmpty(lengthInput) || !double.TryParse(lengthInput, out double length) || length <= 0 ||
                        string.IsNullOrEmpty(widthInput) || !double.TryParse(widthInput, out double width) || width <= 0)
                    {
                        Console.WriteLine("Error: Please enter valid positive numbers for the length and width.");
                        return;
                    }

                    shape = new Rectangle(length, width);  // Create a Rectangle object
                    break;

                case 3: // Triangle
                    Console.Write("Enter the base of the triangle: ");
                    string? baseLengthInput = Console.ReadLine();
                    Console.Write("Enter the height of the triangle: ");
                    string? heightInput = Console.ReadLine();

                    if (string.IsNullOrEmpty(baseLengthInput) || !double.TryParse(baseLengthInput, out double baseLength) || baseLength <= 0 ||
                        string.IsNullOrEmpty(heightInput) || !double.TryParse(heightInput, out double height) || height <= 0)
                    {
                        Console.WriteLine("Error: Please enter valid positive numbers for the base and height.");
                        return;
                    }

                    shape = new Triangle(baseLength, height);  // Create a Triangle object
                    break;

                default:
                    Console.WriteLine("Invalid selection.");
                    return;
            }

            // Display information and area for the selected shape
            shape?.DisplayInfo();  // Polymorphism in action (null-conditional operator)

        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Please enter valid numbers for the dimensions.");
        }
    }
}

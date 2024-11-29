using System;

// Base class: Vehicle
public class Vehicle
{
    // Common properties for all vehicles
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public double Speed { get; set; } // Speed in km/h
    
    // Constructor for Vehicle
    public Vehicle(string make, string model, int year)
    {
        Make = make;
        Model = model;
        Year = year;
        Speed = 0; // Vehicles start at 0 speed
    }

    // A method that can be inherited by derived classes
    public virtual void Accelerate()
    {
        Speed += 10; // Increase speed by 10 km/h
        Console.WriteLine($"The vehicle accelerates. Current speed: {Speed} km/h");
    }

    // A method that can be inherited by derived classes
    public virtual void Stop()
    {
        Speed = 0; // Reset speed to 0
        Console.WriteLine("The vehicle has stopped.");
    }

    // Method to display vehicle details
    public void DisplayInfo()
    {
        Console.WriteLine($"Make: {Make}, Model: {Model}, Year: {Year}, Speed: {Speed} km/h");
    }
}

// Derived class: Car
public class Car : Vehicle
{
    // Specific property for Car
    public int NumberOfDoors { get; set; }

    // Constructor for Car
    public Car(string make, string model, int year, int numberOfDoors)
        : base(make, model, year) // Calling the base class constructor
    {
        NumberOfDoors = numberOfDoors;
    }

    // Overriding the Accelerate method for Car
    public override void Accelerate()
    {
        Speed += 20; // Cars accelerate faster than general vehicles
        Console.WriteLine($"The car accelerates. Current speed: {Speed} km/h");
    }

    // Method to display car details
    public void DisplayCarInfo()
    {
        DisplayInfo();
        Console.WriteLine($"Number of Doors: {NumberOfDoors}");
    }
}

// Derived class: Truck
public class Truck : Vehicle
{
    // Specific property for Truck
    public double LoadCapacity { get; set; } // in kilograms

    // Constructor for Truck
    public Truck(string make, string model, int year, double loadCapacity)
        : base(make, model, year) // Calling the base class constructor
    {
        LoadCapacity = loadCapacity;
    }

    // Overriding the Accelerate method for Truck
    public override void Accelerate()
    {
        Speed += 5; // Trucks accelerate slower than general vehicles
        Console.WriteLine($"The truck accelerates. Current speed: {Speed} km/h");
    }

    // Method to display truck details
    public void DisplayTruckInfo()
    {
        DisplayInfo();
        Console.WriteLine($"Load Capacity: {LoadCapacity} kg");
    }
}

// Main program to test the hierarchy
class Program
{
    static void Main()
    {
        // Create instances of Car and Truck
        Vehicle vehicle = new Vehicle("Generic", "Model X", 2022);
        Car car = new Car("Toyota", "Corolla", 2022, 4);
        Truck truck = new Truck("Ford", "F-150", 2022, 1500);

        // Display info and test methods
        vehicle.DisplayInfo();
        vehicle.Accelerate();
        vehicle.Stop();

        Console.WriteLine();

        car.DisplayCarInfo();
        car.Accelerate();
        car.Stop();

        Console.WriteLine();

        truck.DisplayTruckInfo();
        truck.Accelerate();
        truck.Stop();
    }
}

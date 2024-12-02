using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class Program
{
    private static readonly HttpClient client = new HttpClient();

    // Class to map toy data
    public class Toy
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
    }

    public static async Task FetchAndDisplayToysAsync()
    {
        string url = "http://localhost:5159/api/toys"; // Toy API endpoint
        
        try
        {
            Console.WriteLine("Fetching data from the API...");
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            List<Toy> toys = JsonConvert.DeserializeObject<List<Toy>>(responseBody);

            Console.WriteLine("Fetched Toys:");
            foreach (var toy in toys)
            {
                Console.WriteLine($"Toy ID: {toy.Id}");
                Console.WriteLine($"Name: {toy.Name}");
                Console.WriteLine($"Category: {toy.Category}");
                Console.WriteLine(new string('-', 30));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public static async Task Main(string[] args)
    {
        await FetchAndDisplayToysAsync();
    }
}

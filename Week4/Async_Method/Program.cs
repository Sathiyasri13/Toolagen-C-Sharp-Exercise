using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class Program
{
    private static readonly HttpClient client = new HttpClient();

    public class Product
    {
        public int Id { get; set; }

        [JsonProperty("title")] // Map 'title' to 'Name'
        public string? Name { get; set; }

        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
    }

    public static async Task FetchAndDisplayProductsAsync()
    {
        string url = "https://fakestoreapi.com/products";
        
        try
        {
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(responseBody);

            foreach (var product in products)
            {
                Console.WriteLine($"Product ID: {product.Id}");
                Console.WriteLine($"Name: {product.Name}");
                Console.WriteLine($"Price: ${product.Price}");
                Console.WriteLine($"Description: {product.Description}");
                Console.WriteLine($"Category: {product.Category}");
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
        await FetchAndDisplayProductsAsync();
    }
}

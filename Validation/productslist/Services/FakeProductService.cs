using productslist.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace productslist.Services
{
    public class FakeProductService : IProductService
    {
        private readonly List<ProductDetails> _products;

        public FakeProductService()
        {
            // Initialize the fake product list with sample data
            _products = new List<ProductDetails>
            {
                new ProductDetails { Id = 1, Name = "Product A", Category = "Category 1", Price = 10.50m },
                new ProductDetails { Id = 2, Name = "Product B", Category = "Category 2", Price = 20.00m },
                new ProductDetails { Id = 3, Name = "Product C", Category = "Category 1", Price = 15.75m },
                new ProductDetails { Id = 4, Name = "Product D", Category = "Category 3", Price = 25.30m },
            };
        }

        public Task<List<ProductDetails>> GetProductsAsync(string? category, decimal? minPrice, decimal? maxPrice)
        {
            var query = _products.AsQueryable();

            if (!string.IsNullOrEmpty(category))
                query = query.Where(p => p.Category == category);

            if (minPrice.HasValue)
                query = query.Where(p => p.Price >= minPrice.Value);

            if (maxPrice.HasValue)
                query = query.Where(p => p.Price <= maxPrice.Value);

            return Task.FromResult(query.ToList());
        }

        public Task<ProductDetails?> GetProductByIdAsync(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(product);
        }

        public Task<ProductDetails> AddProductAsync(ProductDetails product)
        {
            product.Id = _products.Any() ? _products.Max(p => p.Id) + 1 : 1;
            _products.Add(product);
            return Task.FromResult(product);
        }

        public Task<bool> UpdateProductAsync(int id, ProductDetails updatedProduct)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
                return Task.FromResult(false);

            existingProduct.Name = updatedProduct.Name;
            existingProduct.Category = updatedProduct.Category;
            existingProduct.Price = updatedProduct.Price;

            return Task.FromResult(true);
        }

        public Task<bool> DeleteProductAsync(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return Task.FromResult(false);

            _products.Remove(product);
            return Task.FromResult(true);
        }
    }
}

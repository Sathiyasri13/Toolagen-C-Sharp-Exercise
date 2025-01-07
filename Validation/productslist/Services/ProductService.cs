using Microsoft.EntityFrameworkCore;
using productslist.Data;
using productslist.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace productslist.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDetails>> GetProductsAsync(string? category, decimal? minPrice, decimal? maxPrice)
        {
            var query = _context.ProductDetails.AsQueryable();

            if (!string.IsNullOrEmpty(category))
                query = query.Where(p => p.Category == category);

            if (minPrice.HasValue)
                query = query.Where(p => p.Price >= minPrice.Value);

            if (maxPrice.HasValue)
                query = query.Where(p => p.Price <= maxPrice.Value);

            return await query.ToListAsync();
        }

        public async Task<ProductDetails?> GetProductByIdAsync(int id)
        {
            return await _context.ProductDetails.FindAsync(id);
        }

        public async Task<ProductDetails> AddProductAsync(ProductDetails product)
        {
            await _context.ProductDetails.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> UpdateProductAsync(int id, ProductDetails updatedProduct)
        {
            var existingProduct = await _context.ProductDetails.FindAsync(id);
            if (existingProduct == null)
                return false;

            existingProduct.Name = updatedProduct.Name;
            existingProduct.Category = updatedProduct.Category;
            existingProduct.Price = updatedProduct.Price;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.ProductDetails.FindAsync(id);
            if (product == null)
                return false;

            _context.ProductDetails.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

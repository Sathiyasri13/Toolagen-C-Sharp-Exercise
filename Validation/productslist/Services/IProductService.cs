using productslist.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace productslist.Services
{
    public interface IProductService
    {
        Task<List<ProductDetails>> GetProductsAsync(string? category, decimal? minPrice, decimal? maxPrice);
        Task<ProductDetails?> GetProductByIdAsync(int id);
        Task<ProductDetails> AddProductAsync(ProductDetails product);
        Task<bool> UpdateProductAsync(int id, ProductDetails updatedProduct);
        Task<bool> DeleteProductAsync(int id);
    }
}

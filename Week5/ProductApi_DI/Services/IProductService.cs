using ProductApi.Models;

namespace ProductApi.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(Product product);
        Task<Product?> UpdateProductAsync(int id, Product updatedProduct);
        Task<bool> DeleteProductAsync(int id);
    }
}

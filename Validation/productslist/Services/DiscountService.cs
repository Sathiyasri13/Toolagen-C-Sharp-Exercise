using System;
using System.Threading.Tasks;
using productslist.Services;

namespace productslist.Services
{
    public class DiscountService : IDiscountService
    {
        
        public async Task<decimal> ApplyDiscountAsync(int productId, decimal discountPercentage)
        {
            // Simulate database or product repository call
            decimal productPrice = await GetProductPriceAsync(productId);

            if (discountPercentage < 0 || discountPercentage > 100)
            {
                throw new ArgumentException("Discount percentage must be between 0 and 100.");
            }

            // Calculate the discounted price
            decimal discountedPrice = productPrice - (productPrice * (discountPercentage / 100));
            return Math.Round(discountedPrice, 2); // Round to 2 decimal places for currency precision
        }

        private Task<decimal> GetProductPriceAsync(int productId)
        {
            // Simulate fetching the product price
            return Task.FromResult(100m); // Mock price for demonstration
        }
    }
}

using System.Threading.Tasks;

namespace productslist.Services
{
    public interface IDiscountService
    {
        
        Task<decimal> ApplyDiscountAsync(int productId, decimal discountPercentage);
    }
}

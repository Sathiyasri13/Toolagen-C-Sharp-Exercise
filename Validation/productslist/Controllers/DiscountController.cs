using Microsoft.AspNetCore.Mvc;
using productslist.Services;
using System.Threading.Tasks;

namespace productslist.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

       
        [HttpGet("apply")]
        public async Task<IActionResult> ApplyDiscount(int productId, decimal discountPercentage)
        {
            if (discountPercentage < 0 || discountPercentage > 100)
            {
                return BadRequest("Discount percentage must be between 0 and 100.");
            }

            try
            {
                var discountedPrice = await _discountService.ApplyDiscountAsync(productId, discountPercentage);
                return Ok(new { ProductId = productId, DiscountedPrice = discountedPrice });
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Product with ID {productId} was not found.");
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

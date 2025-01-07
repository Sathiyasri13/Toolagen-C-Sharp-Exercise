using Microsoft.AspNetCore.Mvc;
using productslist.Models;
using productslist.Services;
using System.Threading.Tasks;

namespace productslist.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // Get all products with optional filters
        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] string? category,
            [FromQuery] decimal? minPrice,
            [FromQuery] decimal? maxPrice)
        {
            try
            {
                var products = await _productService.GetProductsAsync(category, minPrice, maxPrice);

                if (products == null || products.Count == 0)
                    return NotFound("No products found matching the criteria.");

                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Get a single product by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(id);

                if (product == null)
                    return NotFound($"Product with ID {id} not found.");

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("filterByPrice")]
        public async Task<IActionResult> GetProductsByMinPrice(decimal minPrice)
        {
            var allProducts = await _productService.GetProductsAsync(null, null, null);

            // LINQ query to filter products
            var filteredProducts = allProducts
                .Where(product => product.Price > minPrice)
                .ToList();

            return Ok(filteredProducts);
        }

        // Add a new product
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDetails product)
        {
            try
            {
                if (product == null)
                    return BadRequest("Product data is invalid.");

                var createdProduct = await _productService.AddProductAsync(product);
                return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Update an existing product
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductDetails updatedProduct)
        {
            try
            {
                if (id != updatedProduct.Id)
                    return BadRequest("Product ID mismatch.");

                var isUpdated = await _productService.UpdateProductAsync(id, updatedProduct);

                if (!isUpdated)
                    return NotFound($"Product with ID {id} not found.");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        

        // Delete a product
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var isDeleted = await _productService.DeleteProductAsync(id);

                if (!isDeleted)
                    return NotFound($"Product with ID {id} not found.");

                return Ok($"Product with ID {id} has been deleted.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}

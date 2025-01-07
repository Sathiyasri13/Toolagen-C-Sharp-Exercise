using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using productslist.Models;
using productslist.Services;
using productslist.Data;
using System.Linq;
using System.Threading.Tasks;

namespace productslist.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly AppDbContext _context;

        // Constructor with Dependency Injection for ProductService and ProductDbContext
        public ProductsController(IProductService productService, AppDbContext context)
        {
            _productService = productService;
            _context = context;
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
            catch (System.Exception ex)
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
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Get products filtered by minimum price
        //api/products/filterByPrice?minprice=amount
        [HttpGet("filterByPrice")]
        public async Task<IActionResult> GetProductsByMinPrice(decimal minPrice)
        {
            var allProducts = await _productService.GetProductsAsync(null, null, null);

            // LINQ query to filter products by minimum price
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
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Filter and sort products
        //products/filter-sort?category=Electronics&sortBy=price&ascending=true
        [HttpGet("filter-sort")]
        public async Task<IActionResult> FilterAndSort(
            [FromQuery] string? category,
            [FromQuery] decimal? minPrice,
            [FromQuery] decimal? maxPrice,
            [FromQuery] string? sortBy = "price",
            [FromQuery] bool ascending = true)
        {
            var query = _context.ProductDetails.AsQueryable();  // Use injected _context

            // Apply filtering based on query parameters
            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(p => p.Category == category);
            }

            if (minPrice.HasValue)
            {
                query = query.Where(p => p.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= maxPrice.Value);
            }

            // Apply sorting based on query parameters
            query = (sortBy ?? "price").ToLower() switch
            {
                "name" => ascending ? query.OrderBy(p => p.Name) : query.OrderByDescending(p => p.Name),
                "category" => ascending ? query.OrderBy(p => p.Category) : query.OrderByDescending(p => p.Category),
                _ => ascending ? query.OrderBy(p => p.Price) : query.OrderByDescending(p => p.Price), // Default: sort by price
            };

            var filteredProducts = await query.ToListAsync();

            if (!filteredProducts.Any())
            {
                return NotFound("No products match the specified criteria.");
            }

            return Ok(filteredProducts);
        }

        // Bulk add products
        [HttpPost("bulk-add")]
        public async Task<IActionResult> AddProducts([FromBody] List<ProductDetails> products)
        {
            // 401 Unauthorized: Example authentication check
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized(new { error = "Authentication is required to access this resource." });
            }

            // 403 Forbidden: Example authorization check
            if (!User.IsInRole("Admin"))
            {
                return Unauthorized("Authentication is required to access this resource.");
            }

            // 400 Bad Request: Input validation
            if (products == null || products.Count == 0)
            {
                return BadRequest("No products were provided.");
            }

            // 409 Conflict: Check for duplicates
            foreach (var product in products)
            {
                if (_context.ProductDetails.Any(p => p.Name == product.Name && p.Category == product.Category))
                {
                    return Conflict(new { error = $"A product with the name '{product.Name}' already exists in the category '{product.Category}'." });
                }
            }

            try
            {
                await _context.ProductDetails.AddRangeAsync(products);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "An error occurred while saving the products to the database.");
            }

            return Created("", new { message = $"{products.Count} products were added successfully." });
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
            catch (System.Exception ex)
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
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

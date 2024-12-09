using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Models;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        // GET: api/products/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();
            return product;
        }

        // POST: api/products
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            // Check if a product with the same name and price already exists
            var existingProduct = await _context.Products
                .FirstOrDefaultAsync(p => p.Name == product.Name && p.Price == product.Price);

            if (existingProduct != null)
            {
                // Return a conflict response if a duplicate exists
                return Conflict(new { Message = "A product with the same name and price already exists." });
            }

            // Add the new product to the database
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            // Return the created product
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }


        // POST: api/products/update/{id}
        [HttpPost("update/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product updatedProduct)
        {
            // Find the product by ID
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();

            // Update the product fields
            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;
            product.Price = updatedProduct.Price;
            product.Category = updatedProduct.Category;

            // Save changes to the database
            await _context.SaveChangesAsync();

            return Ok(product);
        }


        // DELETE: api/products/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

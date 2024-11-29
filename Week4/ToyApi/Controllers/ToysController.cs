using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToyApi.Data;
using ToyApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToysController : ControllerBase
    {
        private readonly ToyDbContext _context;

        // Constructor to inject the DbContext into the controller
        public ToysController(ToyDbContext context)
        {
            _context = context;
        }

        // GET: api/toys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Toy>>> GetToys()
        {
            var toys = await _context.Toys.ToListAsync();
            return Ok(toys);
        }

        // POST: api/toys
        [HttpPost]
        public async Task<ActionResult<Toy>> CreateToy(Toy toy)
        {
            _context.Toys.Add(toy);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetToys), new { id = toy.Id }, toy);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using ToyApi.Models;

namespace ToyApi.Data
{
    public class ToyDbContext : DbContext
    {
        public ToyDbContext(DbContextOptions<ToyDbContext> options) : base(options) { }

        // DbSet represents the table in the database
        public DbSet<Toy> Toys { get; set; }
    }
}

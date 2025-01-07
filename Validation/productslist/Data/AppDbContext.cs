using Microsoft.EntityFrameworkCore;
using productslist.Models;

namespace productslist.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

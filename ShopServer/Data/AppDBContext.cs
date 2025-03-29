using Microsoft.EntityFrameworkCore;
using ShopShareLibrary.Models;

namespace ShopServer.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; } = default!;
    }
}

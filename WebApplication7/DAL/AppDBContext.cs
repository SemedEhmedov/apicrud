using Microsoft.EntityFrameworkCore;
using WebApplication7.Models;

namespace WebApplication7.DAL
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace Order.API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {

        }

        public DbSet<Order.API.OrderServices.Order> Orders { get; set; }
        public DbSet<Order.API.OrderServices.OrderItem> OrderItems { get; set; }
    }
}

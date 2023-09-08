using BackendAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BackendAPI.DB
{
    public class WebAPIContext : DbContext
    {
        public DbSet<User> UserAccounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public WebAPIContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Order>().HasMany(x => x.OrderedProducts).WithMany(x => x.Orders);
        }
    }
}

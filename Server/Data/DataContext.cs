using BlazorWeb.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorWeb.Server.Data
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        public DbSet<Product> Products { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
                               new Product { Id = 1, Title = "Product 1", Category = "Category 1", Price = 99.99m },
                                              new Product { Id = 2, Title = "Product 2", Category = "Category 2", Price = 9.99m },
                                              new Product { Id = 3, Title = "Product 3", Category = "Category 3", Price = 14.99m },
                                              new Product { Id = 4, Title = "Product 4", Category = "Category 4", Price = 79.90m },
                                              new Product { Id = 5, Title = "Product 5", Category = "Category 5", Price = 499.99m }
                                          );
        }
    }
}

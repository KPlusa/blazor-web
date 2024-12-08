using BlazorWeb.Data;
using BlazorWeb.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorWeb.Services.ProductService
{
    public class ProductService(DataContext context) : IProductService
    {
        public async Task<Product> CreateProduct(Product product)
        {
            context.Add(product);
            await context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            var dbProduct = await context.Products.FindAsync(productId);
            if (dbProduct == null)
            {
                return false;
            }

            context.Remove(dbProduct);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<Product?> GetProductById(int productId)
        {
            var dbProduct = await context.Products.FindAsync(productId);
            return dbProduct;
        }

        public async Task<List<Product>> GetProducts()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<Product?> UpdateProduct(int productId, Product product)
        {
            var dbProduct = await context.Products.FindAsync(productId);
            if (dbProduct == null) return dbProduct;
            dbProduct.Title = product.Title;
            dbProduct.Category = product.Category;
            dbProduct.Price = product.Price;

            await context.SaveChangesAsync();

            return dbProduct;
        }
    }
}
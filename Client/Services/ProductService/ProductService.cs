using BlazorWeb.Shared;

namespace BlazorWeb.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        public Task<List<Product>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task<Product?> GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<Product> CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product?> UpdateProduct(int productId, Product product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }
    }
}

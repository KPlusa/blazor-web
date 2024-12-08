using BlazorWeb.Shared;

namespace BlazorWeb.Client.Services.ProductService
{
    public interface IClientProductService
    {
        List<Product> Products { get; }
        Task GetProducts();
        Task<Product?> GetProductById(int id);
        Task CreateProduct(Product product);
        Task UpdateProduct(int id, Product product);
        Task DeleteProduct(int id);
    }
}

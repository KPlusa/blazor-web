using BlazorWeb.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Net;

namespace BlazorWeb.Client.Services.ProductService
{
    public class ClientProductService(HttpClient http, NavigationManager navigationManger) : IClientProductService
    {
        public List<Product> Products { get; set; } = [];

        public async Task CreateProduct(Product product)
        {
            await http.PostAsJsonAsync("api/product", product);
            navigationManger.NavigateTo("products");
        }

        public async Task DeleteProduct(int id)
        {
            var result = await http.DeleteAsync($"api/product/{id}");
            navigationManger.NavigateTo("products");
        }

        public async Task<Product?> GetProductById(int id)
        {
            var result = await http.GetAsync($"api/product/{id}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<Product>();
            }
            return null;
        }

        public async Task GetProducts()
        {
            var result = await http.GetFromJsonAsync<List<Product>>("api/product");
            if (result is not null)
                Products = result;
        }

        public async Task UpdateProduct(int id, Product product)
        {
            await http.PutAsJsonAsync($"api/product/{id}", product);
            navigationManger.NavigateTo("products");
        }
    }
}

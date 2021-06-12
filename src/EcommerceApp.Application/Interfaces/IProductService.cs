using System.Collections.Generic;
using System.Threading.Tasks;
using EcommerceApp.Application.ViewModels.EmployeePanel;
using EcommerceApp.Application.ViewModels.Home;

namespace EcommerceApp.Application.Interfaces
{
    public interface IProductService
    {
        Task AddProductAsync(ProductVM product);
        Task<ProductVM> GetProductAsync(int id);
        Task<ProductListVM> GetProductsAsync();
        Task<List<ProductForHomeVM>> GetProductsWithImageAsync();
        Task<List<ProductVM>> GetProductsByCategoryNameAsync(string name);
        Task UpdateProductAsync(ProductVM product);
        Task DeleteProductAsync(int id);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using EcommerceApp.Application.ViewModels.EmployeePanel;
using EcommerceApp.Application.ViewModels.Home;
using EcommerceApp.Application.ViewModels.Product;

namespace EcommerceApp.Application.Interfaces
{
    public interface IProductService
    {
        Task AddProductAsync(ProductVM product);
        Task<ProductVM> GetProductAsync(int id);
        Task<ProductDetailsForUserVM> GetProductDetailsForUserAsync(int id);
        Task<ProductListVM> GetPaginatedProductsAsync(int pageSize, int pageNumber);
        Task<HomeVM> GetRandomProductsWithImageAsync(int number);
        Task<ListProductDetailsForUserVM> GetProductsByCategoryIdAsync(int id);
        Task UpdateProductAsync(ProductVM product);
        Task DeleteProductAsync(int id);
    }
}

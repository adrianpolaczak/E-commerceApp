using System.Collections.Generic;
using System.Threading.Tasks;
using EcommerceApp.Application.ViewModels.EmployeePanel;
using EcommerceApp.Application.ViewModels.AdminPanel;

namespace EcommerceApp.Application.Interfaces
{
    public interface ISearchService
    {
        Task<CategoryListVM> CategorySearchAsync(string selectedValue, string searchString);
        Task<ProductListVM> ProductSearchAsync(string selectedValue, string searchString);
        Task<EmployeeListVM> EmployeeSearchAsync(string selectedValue, string searchString);
        Task<CustomerListVM> CustomerSearchAsync(string selectedValue, string searchString);
    }
}

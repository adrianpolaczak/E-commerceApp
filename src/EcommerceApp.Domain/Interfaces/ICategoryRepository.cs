using EcommerceApp.Domain.Models;
using System.Threading.Tasks;
using System.Linq;

namespace EcommerceApp.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task AddCategoryAsync(Category category);

        Task<Category> GetCategoryAsync(int id);

        Task<IQueryable<Category>> GetCategoriesAsync();

        Task UpdateCategoryAsync(Category category);

        Task DeleteCategoryAsync(int id);
    }
}
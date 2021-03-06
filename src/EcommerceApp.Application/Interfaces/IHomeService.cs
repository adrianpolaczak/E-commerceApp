using System.Threading.Tasks;
using EcommerceApp.Application.ViewModels.Home;

namespace EcommerceApp.Application.Interfaces
{
    public interface IHomeService
    {
        Task<HomeVM> GetHomeVMAsync();
    }
}

using System.Collections.Generic;

namespace EcommerceApp.Application.ViewModels.EmployeePanel
{
    public class CategoryListVM
    {
        public List<CategoryForListVM> Categories { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}

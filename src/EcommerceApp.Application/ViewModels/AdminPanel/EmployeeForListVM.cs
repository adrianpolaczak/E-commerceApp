using System.ComponentModel.DataAnnotations;
using AutoMapper;
using EcommerceApp.Application.Mapping;

namespace EcommerceApp.Application.ViewModels.AdminPanel
{
    public class EmployeeForListVM : IMapFrom<Domain.Models.Employee>
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Position { get; set; }

        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Models.Employee, EmployeeForListVM>()
            .ForMember(x => x.Email, y => y.MapFrom(src => src.AppUser.Email));
        }
    }
}

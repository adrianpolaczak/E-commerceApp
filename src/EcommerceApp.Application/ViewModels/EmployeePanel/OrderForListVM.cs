using System.ComponentModel.DataAnnotations;
using AutoMapper;
using EcommerceApp.Application.Mapping;

namespace EcommerceApp.Application.ViewModels.EmployeePanel
{
    public class OrderForListVM : IMapFrom<Domain.Models.Order>
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Price { get; set; }

        [Display(Name = "First name")]
        public string ShipFirstName { get; set; }

        [Display(Name = "Last name")]
        public string ShipLastName { get; set; }

        [Display(Name = "City")]
        public string ShipCity { get; set; }

        [Display(Name = "Postal code")]
        public string ShipPostalCode { get; set; }

        [Display(Name = "Address")]
        public string ShipAddress { get; set; }

        [Display(Name = "Email")]
        public string ContactEmail { get; set; }

        [Display(Name = "Phone number")]
        public string ContactPhoneNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Models.Order, OrderForListVM>().ReverseMap();
        }
    }
}

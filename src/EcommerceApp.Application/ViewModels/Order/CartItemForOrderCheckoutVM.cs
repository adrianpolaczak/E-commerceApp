using System.ComponentModel.DataAnnotations;
using AutoMapper;
using EcommerceApp.Application.Mapping;

namespace EcommerceApp.Application.ViewModels.Order
{
    public class CartItemForOrderCheckoutVM : IMapFrom<Domain.Models.CartItem>
    {
        public int Id { get; set; }

        [Display(Name = "Product Id")]
        public int ProductId { get; set; }

        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Price { get; set; }
        public int ProductsInStock { get; set; }

        public int Quantity { get; set; }

        [Display(Name = "Image")]
        public string ImageToDisplay { get; set; }

        public byte[] ImageByteArray { get; set; }

        [Display(Name = "Total Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal TotalPrice { get { return Price * Quantity; } }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Models.CartItem, CartItemForOrderCheckoutVM>()
            .ForMember(x => x.Name, y => y.MapFrom(src => src.Product.Name))
            .ForMember(x => x.Price, y => y.MapFrom(src => src.Product.UnitPrice))
            .ForMember(x => x.ProductsInStock, y => y.MapFrom(src => src.Product.UnitsInStock))
            .ForMember(x => x.ImageByteArray, y => y.MapFrom(src => src.Product.Image));
        }
    }
}

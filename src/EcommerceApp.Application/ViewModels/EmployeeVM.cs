using System.ComponentModel.DataAnnotations;
using AutoMapper;
using EcommerceApp.Application.Mapping;
using FluentValidation;

namespace EcommerceApp.Application.ViewModels
{
    public class EmployeeVM : IMapFrom<Domain.Model.Employee>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }

        //[Required]
        //[EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Model.Employee, EmployeeVM>().ReverseMap();
        }
    }

    public class EmployeeVMValidator : AbstractValidator<EmployeeVM>
    {
        public EmployeeVMValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.FirstName).NotEmpty().MinimumLength(2).MaximumLength(50).WithMessage("The {FirstName} must be at least {MinLengthAttribute} and at max {MaxLengthAttribute} characters long.");
            RuleFor(x => x.LastName).NotEmpty().MinimumLength(2).MaximumLength(50).WithMessage("The {LastName} must be at least {MinLengthAttribute} and at max {MaxLengthAttribute} characters long.");
            RuleFor(x => x.Position).NotEmpty().MinimumLength(2).MaximumLength(50).WithMessage("The {Position} must be at least {MinLengthAttribute} and at max {MaxLengthAttribute} characters long.");
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }
    }
}
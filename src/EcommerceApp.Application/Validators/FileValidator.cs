using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace EcommerceApp.Application.Validators
{
    public class FileValidator : AbstractValidator<IFormFile>
    {
        public FileValidator()
        {
            RuleFor(x => x.Length).LessThanOrEqualTo(2000000)
                .WithMessage("File size is larger than allowed,max 2MB");
            RuleFor(x => x.ContentType).Must(x =>
                x.Equals("image/jpeg") ||
                x.Equals("image/jpg") ||
                x.Equals("image/png"))
                .WithMessage("File type is different than allowed, must be:.jpeg, .jpg or .png");
        }
    }
}

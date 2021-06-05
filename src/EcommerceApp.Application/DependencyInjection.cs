using System.Reflection;
using EcommerceApp.Application.Interfaces;
using EcommerceApp.Application.Policies;
using EcommerceApp.Application.Services;
using EcommerceApp.Application.ViewModels;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace EcommerceApp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IImageConverterService, ImageConverterService>();
            services.AddMvc().AddFluentValidation();
            services.AddTransient<IValidator<EmployeeVM>, EmployeeVMValidator>();
            services.AddTransient<IValidator<CategoryVM>, CategoryVMValidator>();
            services.AddTransient<IValidator<ProductVM>, ProductVMValidator>();
            services.AddSingleton<IAuthorizationHandler, HasIsAdminClaimHandler>();
            services.AddSingleton<IAuthorizationHandler, HasIsEmployeeClaimHandler>();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanAccessEmployeePanel", policybuilder => policybuilder.Requirements.Add(new CanAccessEmployeePanelRequirement()));
            });
            return services;
        }
    }
}
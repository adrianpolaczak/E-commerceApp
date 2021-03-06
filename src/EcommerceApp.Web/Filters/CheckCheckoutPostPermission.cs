using System;
using System.Security.Claims;
using System.Threading.Tasks;
using EcommerceApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EcommerceApp.Web.Filters
{
    public class CheckCheckoutPostPermission : Attribute, IAsyncAuthorizationFilter
    {
        private readonly ICustomerService _customerService;

        public CheckCheckoutPostPermission(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var appUserId = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var customerId = context.HttpContext.Request.Form["CustomerId"].ToString();

            bool intParse = int.TryParse(customerId, out int parsedCustomerId);
            var getCustomerId = await _customerService.GetCustomerIdByAppUserIdAsync(appUserId);

            if (intParse != true)
            {
                context.Result = new BadRequestResult();
            }

            if (getCustomerId != parsedCustomerId && intParse == true)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}

using System;
using System.Security.Claims;
using System.Threading.Tasks;
using EcommerceApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EcommerceAppApi.Filters
{
    public class CheckCheckoutGetPermission : Attribute, IAsyncAuthorizationFilter
    {
        private readonly ICustomerService _customerService;

        public CheckCheckoutGetPermission(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var appUserId = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var customerId = context.HttpContext.Request.Query["customerId"].ToString();

            bool intParse = int.TryParse(customerId, out int parsedCartId);
            var getCustomerId = await _customerService.GetCustomerIdByAppUserIdAsync(appUserId);

            if (intParse != true)
            {
                context.Result = new BadRequestResult();
            }

            if (getCustomerId != parsedCartId && intParse == true)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}

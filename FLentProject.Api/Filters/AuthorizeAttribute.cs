using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FLentProject.Api.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var userid = context.HttpContext.Items["UserId"];
            if (userid == null)
            {
                context.Result = new JsonResult(new
                {
                    success = false, data = "Unauthorized"
                }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}

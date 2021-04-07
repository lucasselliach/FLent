using FLentProject.Infra.CrossCutting.Auth.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FLentProject.Api.Filters
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        private readonly IUserIdentity _userIdentity;

        public AuthorizationFilter(IUserIdentity userIdentity)
        {
            _userIdentity = userIdentity;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            var userid = context.HttpContext.Items["UserId"];
            var userRole = context.HttpContext.Items["UserRole"];
            if (userid != null && userRole != null)
            {
                _userIdentity.SetUserId(userid.ToString());
                _userIdentity.SetRole(userRole.ToString());
            }
        }
    }

}

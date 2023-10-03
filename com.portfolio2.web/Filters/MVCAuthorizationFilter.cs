using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace com.portfolio2.web.Filters
{
    public class MVCAuthorizationFilter : AuthorizeAttribute, IAuthorizationFilter
    {
        public string[] Roles { get; set; }
        
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string controllerName = context.HttpContext.Request.RouteValues["controller"].ToString();
            string actionName = context.HttpContext.Request.RouteValues["action"].ToString();

            var currentRole = context.HttpContext.User?.FindFirst(ClaimTypes.Role)?.Value;

            return;

            if (Roles.Contains(currentRole))
            {
                //authorized
            }
            else
            {
                //not authorized
            }

            context.HttpContext.Response.Headers.Add("token-Key", "this is my token");

            if (controllerName.ToLower() == "portfolios")
                context.Result = new RedirectToRouteResult(
                                        new RouteValueDictionary
                                        {
                                    {"Area","" },
                                    {"controller", "home"},
                                    {"action", "AccessDenied"}
                                        }
                                    );
            //
        }
    }
}

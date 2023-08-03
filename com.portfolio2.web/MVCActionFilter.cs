using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace com.portfolio2.web
{
    public class MVCActionFilter : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string actionName = context.HttpContext.Request.RouteValues["action"].ToString();
            if (actionName.ToLower() != "accessdenied")
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

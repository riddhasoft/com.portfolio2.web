using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace com.portfolio2.web.Filters
{
    public class MyExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //log your error for future
            //
            context.Result = new RedirectToRouteResult(
                                       new RouteValueDictionary
                                       {
                                    {"Area","" },
                                    {"controller", "home"},
                                    {"action", "SomethingIsWrong"}
                                       }
                                   );
        }
    }
}

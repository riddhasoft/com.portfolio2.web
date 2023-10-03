using Microsoft.AspNetCore.Mvc.Filters;

namespace com.portfolio2.web.Filters
{
    public class MyActionFilter : IActionFilter
    {
        /// <summary>
        /// after action
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            ///throw new NotImplementedException();
        }
        /// <summary>
        /// before action
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnActionExecuting(ActionExecutingContext context)
        {
           /// throw new NotImplementedException();
        }
    }
}

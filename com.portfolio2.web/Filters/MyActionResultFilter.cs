using Microsoft.AspNetCore.Mvc.Filters;

namespace com.portfolio2.web.Filters
{
    public class MyActionResultFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            ///throw new NotImplementedException();
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            ///throw new NotImplementedException();
        }
    }
}

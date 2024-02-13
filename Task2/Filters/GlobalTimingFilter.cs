using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Zellis.HRSauce.Filters
{
    public class GlobalTimingFilter : IActionFilter
    {
        Stopwatch watch = new Stopwatch();

        public void OnActionExecuting(ActionExecutingContext context)
        {
            watch.Restart();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            watch.Stop();
            (context.Controller as Controller).ViewData["ExecutionTime"] = watch.Elapsed.ToString();
        }
    }
}

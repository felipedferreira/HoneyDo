using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HoneyDo.WebApp.Core.Filters;

public class TimingActionFilter : IActionFilter
{
    private Stopwatch? _stopwatch;

    public void OnActionExecuting(ActionExecutingContext context)
    {
        _stopwatch = Stopwatch.StartNew();
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        _stopwatch!.Stop();
        var elapsedMs = _stopwatch.ElapsedMilliseconds;
        context.HttpContext.Response.Headers.Add("X-Elapsed-Time", elapsedMs.ToString());
    }
}
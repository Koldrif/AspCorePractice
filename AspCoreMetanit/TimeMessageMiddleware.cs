using System.ComponentModel;

namespace AspCoreMetanit;

public class TimeMessageMiddleware
{
    private readonly RequestDelegate _next;

    public TimeMessageMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, ITimeService timeService)
    {
        context.Response.ContentType = "text/html; charset=utf-8";
        await context.Response.WriteAsync(
            $"Current time of {TypeDescriptor.GetClassName(timeService)}\n{timeService.GetTime()}");
    }
}
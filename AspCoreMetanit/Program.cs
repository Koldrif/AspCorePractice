using AspCoreMetanit;

var builder = WebApplication.CreateBuilder();
 
var services = builder.Services;

services.AddTransient<ITimeService, ShortTimeService>();
//services.AddTransient<TimeService>();

var app = builder.Build();

app.Use(async (context, next) =>
{
    var path = context.Request.Path;
    if (path == "/timeshort")
    {
        await next(context);
    }
    else 
    {
        var time = app.Services.GetService<TimeService>();
        await context.Response.WriteAsync($"Current time from TimeService\n{time?.GetTime()}");
    }
});

app.Run(async context =>
{
    var timeService = app.Services.GetService<ITimeService>();
    await context.Response.WriteAsync($"Current short time is\n{timeService?.GetTime()}");
});

app.Run();
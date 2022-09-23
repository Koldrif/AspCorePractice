using AspCoreMetanit;

var builder = WebApplication.CreateBuilder();
 
var services = builder.Services;
services.AddTransient<ITimeService, ShortTimeService>();
services.AddTransient<TimeMessage>();

// services.AddTransient<ITimeService, ShortTimeService>();
//services.AddTransient<TimeService>();

var app = builder.Build();

app.Run(async context =>
{
    var timeService = context.RequestServices.GetService<TimeMessage>();
    await context.Response.WriteAsync($"Current short time is\n{timeService?.GetTime()}");
});

app.Run();
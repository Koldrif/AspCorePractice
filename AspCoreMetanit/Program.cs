using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder();
 
var services = builder.Services;
services.AddControllers();
 
var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();


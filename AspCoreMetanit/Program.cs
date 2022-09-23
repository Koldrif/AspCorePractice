// using System.Globalization;
// using System.Text.Json.Serialization;using Microsoft.AspNetCore.Authentication;
//
//
// const string guidReg = @"^/api/users/\w{8}-\w{4}-\w{4}-\w{4}-\w{12}$";
//
// var builder = WebApplication.CreateBuilder();
// var app = builder.Build();
//
// // app.Map("/api/time", ReturnTime);
// //
// // app.Run(async context =>
// // {
// //     await context.Response.WriteAsync("Run component\n");
// // });
//
// //app.UseTokenMiddleware();
//
// app.UseMiddleware<ErrorHandlingMiddleware>();
// app.UseMiddleware<AuthenticationMiddleware>();
// app.UseMiddleware<RoutingMiddleware>();
//
//
// app.Run(async context =>
// {
//     await context.Response.WriteAsync("Hello Metanit");
// });
//
// app.Run();
//
// // void ReturnTime(IApplicationBuilder builder)
// // {
// //     builder.Use(async (context, next) =>
// //     {
// //         await next();
// //         
// //         
// //     });
// //     
// //     builder.Run(async context =>
// //     {
// //         await context.Response.WriteAsync(DateTime.Now.ToLongTimeString());
// //     });
// // }
// //
// // public class TokenMiddleware
// // {
// //     private readonly RequestDelegate next;
// //
// //     public TokenMiddleware(RequestDelegate next)
// //     {
// //         this.next = next;
// //     }
// //
// //     public async Task InvokeAsync(HttpContext context)
// //     {
// //         var token = context.Request.Query["token"];
// //         if (token != "123456")
// //         {
// //             context.Response.StatusCode = 403;
// //             await context.Response.WriteAsync($"Token is invalid\nGiven token is {token}");
// //         }
// //         else
// //         {
// //             await next.Invoke(context);
// //         }
// //     }
// // }  
// //
// // static class TokenExtensions
// // {
// //     public static IApplicationBuilder UseTokenMiddleware(this IApplicationBuilder app)
// //     {
// //         return app.UseMiddleware<TokenMiddleware>();
// //     }
// // }
//
// public class RoutingMiddleware
// {
//     private readonly RequestDelegate next;
//
//     public RoutingMiddleware(RequestDelegate next)
//     {
//         this.next = next;
//     }
//
//     public async Task InvokeAsync(HttpContext context)
//     {
//         var path = context.Request.Path;
//         var response = context.Response;
//         Console.WriteLine(path);
//         if (path == "/index")
//         {
//             await response.WriteAsync("Main page");
//         }
//         else if (path == "/about")
//         {
//             await response.WriteAsync("About page");
//         }
//         else
//         {
//             response.StatusCode = 404;
//         }
//     }
//
// }
//
// public class AuthenticationMiddleware
// {
//     private readonly RequestDelegate next;
//
//     public AuthenticationMiddleware(RequestDelegate next)
//     {
//         this.next = next;
//     }
//
//     public async Task InvokeAsync(HttpContext context)
//     {
//         var token = context.Request.Query["token"];
//         var response = context.Response;
//         if (string.IsNullOrWhiteSpace(token))
//         {
//             response.StatusCode = 403;
//         }
//         else
//         {
//             await next.Invoke(context);
//         }
//     }
// }
//
// public class ErrorHandlingMiddleware
// {
//     private readonly RequestDelegate next;
//
//     public ErrorHandlingMiddleware(RequestDelegate ne)
//     {
//         next = ne;
//     }
//
//     public async Task InvokeAsync(HttpContext context)
//     {
//         await next(context);
//         var contextResponse = context.Response;
//         var code = contextResponse.StatusCode;
//         if (code == 403)
//         {
//             await contextResponse.WriteAsync("Access denied");
//         }
//         else if (code == 404)
//         {
//             await contextResponse.WriteAsync("Page not found");
//         }
//     }
//     
// }

using System.Text;

var builder = WebApplication.CreateBuilder();
 
var services = builder.Services;
 
var app = builder.Build();
 
app.Run(async context =>
{
    var sb = new StringBuilder();
    sb.Append("<h1>Все сервисы</h1>");
    sb.Append("<table>");
    sb.Append("<tr><th>Тип</th><th>Lifetime</th><th>Реализация</th></tr>");
    foreach (var svc in services)
    {
        sb.Append("<tr>");
        sb.Append($"<td>{svc.ServiceType.FullName}</td>");
        sb.Append($"<td>{svc.Lifetime}</td>");
        sb.Append($"<td>{svc.ImplementationType?.FullName}</td>");
        sb.Append("</tr>");
    }
    sb.Append("</table>");
    context.Response.ContentType = "text/html;charset=utf-8";
    await context.Response.WriteAsync(sb.ToString());
});
 
app.Run();
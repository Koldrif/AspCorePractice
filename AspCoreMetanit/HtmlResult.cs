using Microsoft.AspNetCore.Mvc;

namespace AspCoreMetanit;

public class HtmlResult : IActionResult
{
    private readonly string htmlCode;
    public HtmlResult(string htmlData) => htmlCode = htmlData; 
    public async Task ExecuteResultAsync(ActionContext context)
    {
        string fullHtmlCode = @$"<!DOCTYPE html>
            <html>
            <head>
            <title>METANIT.COM</title>
            <meta charset=utf-8 />
            </head>
            <body>{htmlCode}</body>
            </html>";
        await context.HttpContext.Response.WriteAsync(fullHtmlCode);
    }
}
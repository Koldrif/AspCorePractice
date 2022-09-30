using System.Text;

namespace AspCoreMetanit.Controller;
using  Microsoft.AspNetCore.Mvc;
/*
 *  Controller needs to be controller one of these things
 * 1. Inherit from Controller
 * 2. Has "Controller" suffix
 * 3. Has attribute [Controller]
 */
[Controller]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return new HtmlResult("Hello");
    }
    [HttpGet]
    public async Task Name()
    {
        Response.ContentType = "text/html; utf-8";
        await Response.WriteAsync(@$"<form method='post'>
                <label>Name:</label><br />
                <input name='name'/><br />
                <label>Age:</label><br />
                <input type='number' name='age' /><br />
                <input type='submit' value='Send' />
            </form>");
    }

    [HttpPost]
    public async Task Name(string name, int age)
    {
        
        await Response.WriteAsync($"{name} {age}");
    }
    
    [NonAction]
    private string tableShell(string dataWithTableTags)
    {
        StringBuilder builder = new("<table>\n");
        builder.Append(dataWithTableTags);
        builder.Append("</table\n");
        return builder.ToString();
    }
}
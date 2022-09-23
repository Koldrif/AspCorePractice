using Microsoft.AspNetCore.Mvc;

namespace AspCoreMetanit.Controllers;


public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

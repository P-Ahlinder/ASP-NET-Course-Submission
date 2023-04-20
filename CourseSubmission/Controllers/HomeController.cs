using Microsoft.AspNetCore.Mvc;
namespace CourseSubmission.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
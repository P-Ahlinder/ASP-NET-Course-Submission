using Microsoft.AspNetCore.Mvc;
namespace CourseSubmission.Controllers;

public class AdminController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

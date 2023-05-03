using Microsoft.AspNetCore.Mvc;

namespace CourseSubmission.Controllers
{
    public class DeniedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

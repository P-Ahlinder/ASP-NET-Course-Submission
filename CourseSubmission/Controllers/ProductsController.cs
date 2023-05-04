using Microsoft.AspNetCore.Mvc;

namespace CourseSubmission.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

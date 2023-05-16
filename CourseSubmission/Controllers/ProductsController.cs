using CourseSubmission.Contexts;
using CourseSubmission.Helpers.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseSubmission.Controllers
{
    

 
    public class ProductsController : Controller
    {
        private readonly DejjtabejjsContext _dejjtabejjsContext;
        private readonly ProductService _productService;
        public ProductsController(DejjtabejjsContext dejjtabejjsContext, ProductService productService)
        {
            _dejjtabejjsContext = dejjtabejjsContext;
            _productService = productService;   
        }

        public IActionResult Index()
        {
            return View(_dejjtabejjsContext.Products.ToList());
        }




        public async Task<IActionResult> Details(string articleNumber) 
        {
            var item = await _productService.GetAsync(articleNumber);
            return View(item);
        }
    }
}

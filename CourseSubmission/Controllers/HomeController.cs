using CourseSubmission.Helpers.Services;
using CourseSubmission.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace CourseSubmission.Controllers;

public class HomeController : Controller
{

    private readonly ContactService _contactService;
    private readonly ProductService _productService;


    public HomeController(ContactService contactService, ProductService productService)
    {
        _contactService = contactService;
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        var model = new HomeVM
        {
            Featured = new ColletionVM
            {
                Title = "Featured",
                Items = await _productService.GetAllByTagNameAsync("featured")
            },
            Popular = new PopularVM
            {
                Title = "Popular products",
                Items = await _productService.GetAllByTagNameAsync("popular")
            }
        };
        return View(model);
    }



    public IActionResult Contact()
    {
        return View();
    }



    
    [HttpPost]
    public async Task<IActionResult> Contact(ContactFormVM model)
    {


        if (ModelState.IsValid)
        {

            try
            {
                await _contactService.ContactFormAsync(model);
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong, please try again");
            }
        }

        return View(model);
    }








}
using CourseSubmission.Contexts;
using CourseSubmission.Helpers.Services;
using CourseSubmission.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace CourseSubmission.Controllers;

public class HomeController : Controller
{

    private readonly ContactService _contactService;
    private readonly DejjtabejjsContext _dejjtabejjsContext;
    private readonly ProductService _productService;


    public HomeController(ContactService contactService, DejjtabejjsContext dejjtabejjsContext, ProductService productService)
    {
        _contactService = contactService;
        _dejjtabejjsContext = dejjtabejjsContext;
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
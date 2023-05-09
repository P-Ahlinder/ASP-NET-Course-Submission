using CourseSubmission.Contexts;
using CourseSubmission.Helpers.Services;
using CourseSubmission.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace CourseSubmission.Controllers;

public class HomeController : Controller
{

    private readonly ContactService _contactService;
    private readonly DejjtabejjsContext _dejjtabejjsContext;

    public HomeController(ContactService contactService, DejjtabejjsContext dejjtabejjsContext)
    {
        _contactService = contactService;
        _dejjtabejjsContext = dejjtabejjsContext;
    }

    public IActionResult Index()
    {
        return View(_dejjtabejjsContext.Products.ToList());
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
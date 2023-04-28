using CourseSubmission.Helpers.Services;
using CourseSubmission.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace CourseSubmission.Controllers;

public class HomeController : Controller
{

    private readonly ContactService _contactService;

    public HomeController(ContactService contactService)
    {
        _contactService = contactService;
    }

    public IActionResult Index()
    {
        return View();
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
using Microsoft.AspNetCore.Mvc;
using CourseSubmission.ViewModels;
using Microsoft.AspNetCore.Identity;
using CourseSubmission.Models.Identity;

namespace CourseSubmission.Controllers;

public class RegisterController : Controller
{
    private readonly UserManager<AppUser> _userManager;

    public RegisterController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }
    

    [HttpGet]
    public IActionResult Index()
    {

        return View();
    }
    

    [HttpPost]
    public async Task<IActionResult> Index(UserSignUpVM model)
    {
        if (ModelState.IsValid)
        {
            if (await _userManager.FindByNameAsync(model.Email) == null)
            {
                var result = await _userManager.CreateAsync(model, model.Password);
                if (result.Succeeded)
                 return RedirectToAction("Index", "Login"); 
            }
                
            ModelState.AddModelError("", "This email appear to be registred already..");
        }
        return View(model);
    }
}

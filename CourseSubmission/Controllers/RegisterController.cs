using Microsoft.AspNetCore.Mvc;
using CourseSubmission.ViewModels;
using Microsoft.AspNetCore.Identity;
using CourseSubmission.Models.Identity;
using CourseSubmission.Helpers.Services;

namespace CourseSubmission.Controllers;

public class RegisterController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly AuthService _authService;

    public RegisterController(UserManager<AppUser> userManager, AuthService authService)
    {
        _userManager = userManager;
        _authService = authService;
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
            if (await _authService.UserAldredyExistsAsync(model))
                ModelState.AddModelError("", "This email appear to be registred already..");

            if(await _authService.RegisterUserAsync(model))
            return RedirectToAction("Index", "Login"); 
            
                
            ModelState.AddModelError("", "This email appear to be registred already..");
        }
        return View(model);
    }
}

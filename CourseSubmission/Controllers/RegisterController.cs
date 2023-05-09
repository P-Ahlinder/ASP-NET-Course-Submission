using Microsoft.AspNetCore.Mvc;
using CourseSubmission.ViewModels;
using CourseSubmission.Helpers.Services;

namespace CourseSubmission.Controllers;

public class RegisterController : Controller
{
  
    private readonly AuthService _authService;

    public RegisterController( AuthService authService)
    {
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
            
                
            
        }
        return View(model);
    }
}

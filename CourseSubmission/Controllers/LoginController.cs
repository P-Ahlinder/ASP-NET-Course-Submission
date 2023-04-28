using CourseSubmission.Helpers.Services;
using CourseSubmission.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CourseSubmission.Controllers;

public class LoginController : Controller
{
    private readonly AuthService _authService;

    public LoginController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpGet]
    public IActionResult Index(string ReturnUrl = null!)
    {
        var model = new UserLoginVM();
        if (ReturnUrl != null)
            model.ReturnUrl = ReturnUrl;
        
        return View(model);
    }


    [HttpPost]
    public async Task<IActionResult> Index(UserLoginVM model)
    {
        if (ModelState.IsValid)
        {
           if(await _authService.LoginAsync(model))
                return LocalRedirect(model.ReturnUrl);

         ModelState.AddModelError("", "Invalid credentials..please try again");
        }
        
        return View(model);
    }
}

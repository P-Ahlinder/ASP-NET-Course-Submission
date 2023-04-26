using CourseSubmission.Services;
using CourseSubmission.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseSubmission.Controllers;

public class AccountController : Controller
{
    private readonly AuthService _auth;

    public AccountController(AuthService auth)
    {
        _auth = auth;
    }


    [Authorize]
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignUp(UserSignUpVM model)
    {
        if (ModelState.IsValid)
        {
            if (await _auth.SignUpAsync(model))
                return RedirectToAction("Index");

            ModelState.AddModelError("", "This e-mail already registred");
        }
        return View(model);
    }
}

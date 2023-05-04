using CourseSubmission.Models.Identity;
using CourseSubmission.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace CourseSubmission.Controllers;

[Authorize(Roles = "admin")]
public class AdminController : Controller
{
    private readonly UserManager<AppUser> _userManager;

    public AdminController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }


    [HttpGet("admin")]
    public async Task<IActionResult> Index()
    {
       return View();

       
    }
}

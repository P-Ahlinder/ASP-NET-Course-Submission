using CourseSubmission.Contexts;
using CourseSubmission.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace CourseSubmission.Controllers;

[Authorize(Roles = "admin")]
public class AdminController : Controller
{
    private readonly DejjtabejjsContext _dejjtabejjsContext;
    public AdminController(DejjtabejjsContext dejjtabejjsContext)
    {
        _dejjtabejjsContext = dejjtabejjsContext;
    }



    [HttpGet("admin")]
    public IActionResult Index()
    {
       return View(_dejjtabejjsContext.Users.ToList());
       
    }
}

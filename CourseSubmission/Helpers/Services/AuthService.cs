using CourseSubmission.Models.Identity;
using CourseSubmission.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CourseSubmission.Helpers.Services;

public class AuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly AddressService _addressService;
    private readonly SignInManager<AppUser> _signInManager;
    public AuthService(UserManager <AppUser> userManager, AddressService addressService, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _addressService = addressService;
        _signInManager = signInManager;
    }

    public async Task <bool> UserAldredyExistsAsync(Expression<Func<AppUser, bool>> expression)
    {
        return await _userManager.Users.AnyAsync(expression);
    }

    public async Task<bool>RegisterUserAsync(UserSignUpVM model)
    {
        AppUser appUser = model;

        var result = await _userManager.CreateAsync(appUser, model.Password);
        if (result.Succeeded)
        {
            var addressEntity = await _addressService.GetOrCreateAsync(model);
            if (addressEntity != null)
            {
                await _addressService.AddAddressAsync(appUser, addressEntity);
                return true;
            }
            
        }

        return false;
    }

    public async Task<bool>LoginAsync(UserLoginVM model)
    {
        var appUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == model.Email);
        if (appUser != null)
        {
            var result = await _signInManager.PasswordSignInAsync(appUser, model.Password, false, false);
            return result.Succeeded;
        }
        return false;
    }
}

using CourseSubmission.Models.Identity;
using CourseSubmission.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace CourseSubmission.Helpers.Services;

public class AuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly AddressService _addressService;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly SeedService _seedService;

    public AuthService(UserManager <AppUser> userManager,SeedService seedService, RoleManager<IdentityRole> roleManager, AddressService addressService, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _addressService = addressService;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _seedService = seedService;

    }

    public async Task <bool> UserAldredyExistsAsync(UserSignUpVM model)
    {
        return await _userManager.Users.AnyAsync(x => x.Email == model.Email);
    }



    public async Task<bool>RegisterUserAsync(UserSignUpVM model)
    {
            await _seedService.SeedRoles();
            var roleName = "user";

            if (!await _userManager.Users.AnyAsync())
            roleName = "admin";
            

        AppUser appUser = model;

            var result = await _userManager.CreateAsync(appUser, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(appUser, roleName);

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

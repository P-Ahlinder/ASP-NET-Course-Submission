using CourseSubmission.ViewModels;
using Microsoft.AspNetCore.Identity;
using CourseSubmission.Contexts;
using CourseSubmission.Models.Entities;

namespace CourseSubmission.Services;

public class AuthService
{

    private readonly UserManager<IdentityUser> _userManager;
    private readonly AppDbContext _identityContext;

    public AuthService(UserManager<IdentityUser> userManager, AppDbContext identityContext)
    {
        _userManager = userManager;
        _identityContext = identityContext;
    }


    public async Task<bool> SignUpAsync(UserSignUpVM model)
    {
        try
        {
            IdentityUser identityUser = model;
            await _userManager.CreateAsync(identityUser, model.Password);

            UserProfileEntity userProfileEntity = model;
            userProfileEntity.UserId = identityUser.Id;

            _identityContext.UserProfiles.Add(userProfileEntity);
            await _identityContext.SaveChangesAsync();
        
            return true;
        }

        catch {return false;}
       
    }
}

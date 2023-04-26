using CourseSubmission.Contexts;
using CourseSubmission.Models.Entities;
using CourseSubmission.ViewModels;
using Microsoft.AspNetCore.Identity;
namespace CourseSubmission.Services;

public class ContactService
{
    private readonly DataDbContext _contactContext;

    public ContactService(DataDbContext contactContext)
    {
        _contactContext = contactContext;
    }


    public async Task<bool> ContactFormAsync(ContactFormVM model)
    {
        try
        {
            ContactFormEntity contactFormEntity = model;
           
            _contactContext.ContactForms.Add(contactFormEntity);
            await _contactContext.SaveChangesAsync();

            return true;
        }

        catch { return false; }

    }
}

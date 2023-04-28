using CourseSubmission.Contexts;
using CourseSubmission.Models.Entities;
using CourseSubmission.ViewModels;
namespace CourseSubmission.Helpers.Services;

public class ContactService
{
    private readonly DejjtabejjsContext _contactContext;

    public ContactService(DejjtabejjsContext contactContext)
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

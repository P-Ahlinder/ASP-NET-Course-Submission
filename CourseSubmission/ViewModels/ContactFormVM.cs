using CourseSubmission.Models.Entities;
namespace CourseSubmission.ViewModels;

public class ContactFormVM
{
    public string FirstName { get; set; } = null!;
    public string LastName  { get; set; } = null!;
    public string Email     { get; set; } = null!;
    public string Message   { get; set; } = null!;


    public static implicit operator ContactFormEntity(ContactFormVM model)
    {
        return new ContactFormEntity
        {
            FirstName = model.FirstName,
            LastName  = model.LastName,
            Email     = model.Email,
            Message   = model.Message
        };
    }
}


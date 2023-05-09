using System.ComponentModel.DataAnnotations;

namespace CourseSubmission.ViewModels;

public class UserLoginVM
{
    [Required(ErrorMessage = "This field is requierd.")]
    [DataType(DataType.EmailAddress)]
    public string Email     { get; set; } = null!;

    [Required(ErrorMessage = "This field is requierd.")]
    [DataType(DataType.Password)]
    public string Password  { get; set; } = null!;

    public string ReturnUrl { get; set; } = "/";
}

using CourseSubmission.Models.Entities;
using CourseSubmission.Models.Identity;
using System.ComponentModel.DataAnnotations;

namespace CourseSubmission.ViewModels;

public class UserSignUpVM
{
    [Required(ErrorMessage = "This field is requierd.")]
    public string FirstName { get; set; } = null!;


    [Required(ErrorMessage = "This field is requierd.")]
    public string LastName { get; set; } = null!;


    [Required(ErrorMessage = "This field is requierd.")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;


    [Required(ErrorMessage = "This field is requierd.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;


    [Required(ErrorMessage ="This field is requierd.")]
    [DataType(DataType.Password)]
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; } = null!;


    [Required(ErrorMessage = "This field is requierd.")]
    public string StreetName  { get; set; } = null!;
    [Required(ErrorMessage = "This field is requierd.")]
    public string PostalCode  { get; set; } = null!;
    [Required(ErrorMessage = "This field is requierd.")]
    public string City        { get; set; } = null!;
    [Required(ErrorMessage = "This field is requierd.")]
    public string Country { get; set; } = null!;



    public static implicit operator AppUser(UserSignUpVM model)
    {

        return new AppUser
        {
           UserName    = model.Email,
           FirstName   = model.FirstName,
           LastName    = model.LastName,
           Email       = model.Email,
        };
    }

    public static implicit operator AddressEntity(UserSignUpVM model)
    {
        return new AddressEntity
        {
            StreetName = model.StreetName,
            PostalCode = model.PostalCode,
            City       = model.City,
            Country    = model.Country,
        };
    }

}

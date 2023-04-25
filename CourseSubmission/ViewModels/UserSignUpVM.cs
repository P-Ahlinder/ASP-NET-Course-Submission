using CourseSubmission.Models.Entities;
using Microsoft.AspNetCore.Identity;
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




    [Required(ErrorMessage = "This field is requierd.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;




    [Required(ErrorMessage ="This field is requierd.")]
    [DataType(DataType.Password)]
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; } = null!;


    
    public string? PhoneNumber { get; set; } 
    public string? StreetName  { get; set; }
    public string? PostalCode  { get; set; }
    public string? City        { get; set; }



    public static implicit operator IdentityUser(UserSignUpVM model)
    {
        return new IdentityUser
        {
            UserName    = model.Email,
            Email       = model.Email,
            PhoneNumber = model.PhoneNumber
        };
    }

    public static implicit operator UserProfileEntity(UserSignUpVM model)
    {
        return new UserProfileEntity
        {
            FirstName   = model.FirstName,
            LastName    = model.LastName,
            StreetName  = model.StreetName,
            PostalCode  = model.PostalCode,
            City        = model.City
        };
    }

}

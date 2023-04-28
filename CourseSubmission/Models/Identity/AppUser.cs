using CourseSubmission.Models.Entities;
using Microsoft.AspNetCore.Identity;
namespace CourseSubmission.Models.Identity;

public class AppUser : IdentityUser
{
    public string  FirstName    { get; set; } = null!;
    public string  LastName     { get; set; } = null!;
    public string? CompanyName  { get; set; }
    public string? ImgURL       { get; set; }
    public ICollection<UserAddressEntity> Addresses { get; set; } = new HashSet<UserAddressEntity>();
}

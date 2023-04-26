using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CourseSubmission.Models.Entities;
using CourseSubmission.Models.Identity;

namespace CourseSubmission.Contexts;

public class DataDbContext : IdentityDbContext <CustomIdentityUser>
{

    public DataDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
    {

    }

    public DbSet<UserProfileEntity> UserProfiles { get; set; }
    public DbSet<ContactFormEntity> ContactForms { get; set; }

}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CourseSubmission.Models.Entities;

namespace CourseSubmission.Contexts;

public class IdentityContext : IdentityDbContext
{

    public IdentityContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<UserProfileEntity> UserProfiles { get; set; }
    public DbSet<ContactFormEntity>  ContacForms  { get; set; }

}

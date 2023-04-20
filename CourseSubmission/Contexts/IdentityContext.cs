using CourseSubmission.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CourseSubmission.Contexts;

public class IdentityContext : IdentityDbContext
{

    public IdentityContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<UserProfileEntity> UserProfiles { get; set; }


}

 using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CourseSubmission.Models.Entities;
using CourseSubmission.Models.Identity;


namespace CourseSubmission.Contexts;

public class DejjtabejjsContext : IdentityDbContext<AppUser>
{
    public DejjtabejjsContext(DbContextOptions<DejjtabejjsContext> options) : base(options)
    {
    }

    public DbSet<ContactFormEntity> ContactForms { get; set; }
    public DbSet<AddressEntity> AspNetAddress { get; set; }
    public DbSet<UserAddressEntity> AspNetUserAddresses { get; set; }

}

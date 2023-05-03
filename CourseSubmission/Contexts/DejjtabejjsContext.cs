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
    public DbSet<AddressEntity> AspNetAddresses { get; set; }
    public DbSet<UserAddressEntity> AspNetUsersAddresses { get; set; }

}

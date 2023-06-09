﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<TagEntity> Tags { get; set; }
    public DbSet <ProductTagEntity> ProductTags { get; set; } 

}

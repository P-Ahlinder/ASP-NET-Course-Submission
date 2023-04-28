using CourseSubmission.Contexts;
using CourseSubmission.Helpers.Repos;
using CourseSubmission.Helpers.Services;
using CourseSubmission.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<DejjtabejjsContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("IdentityDatabase")));
builder.Services.AddScoped<ContactService>();
builder.Services.AddScoped<AddressRepo>();
builder.Services.AddScoped<UserAddressRepo>();
builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<AuthService>();

builder.Services.AddIdentity<AppUser, IdentityRole>(x => 
{
    x.SignIn.RequireConfirmedAccount = false;
    x.User.RequireUniqueEmail = true;
    x.Password.RequiredUniqueChars = 0;
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequiredLength = 1;
    x.Password.RequireDigit = false;
    x.Password.RequireUppercase = false;
    
}).AddEntityFrameworkStores<DejjtabejjsContext>();




var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();

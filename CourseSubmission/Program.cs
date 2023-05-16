using CourseSubmission.Contexts;
using CourseSubmission.Helpers.Repos;
using CourseSubmission.Helpers.Services;
using CourseSubmission.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

//DB Connection
builder.Services.AddDbContext<DejjtabejjsContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("IdentityDatabase")));


//Services
builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<SeedService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ContactService>();


//Repos
builder.Services.AddScoped<ProductsRepository>();
builder.Services.AddScoped<UserAddressRepo>();
builder.Services.AddScoped<AddressRepository>();


//Identity
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


builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/login";
    x.LogoutPath = "/";
    x.AccessDeniedPath = "/denied";
});





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

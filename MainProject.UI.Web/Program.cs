using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MainProject.BL.Extentions;
using Microsoft.AspNetCore.Authentication.Cookies;
using MainProject.DAL.Repositories.DbRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EducationPortalContext>(options => options.UseSqlServer(connection));
builder.Services.AddServices();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

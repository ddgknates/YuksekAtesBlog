using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YuksekAtesBlog.Business.Managers;
using YuksekAtesBlog.Business.Services;
using YuksekAtesBlog.Data.Context;
using YuksekAtesBlog.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<YuksekAtesBlogContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped(typeof(IRepository<>), typeof(SqlRepository<>));

builder.Services.AddScoped<IAdminService, AdminManager>();

builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddScoped<IPostService, PostManager>();



builder.Services.AddDataProtection();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = new PathString("/");
    options.LogoutPath = new PathString("/");
    options.AccessDeniedPath = new PathString("/");
});


var app = builder.Build();

app.UseAuthentication();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{Controller=Dashboard}/{Action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: ("{Controller=Home}/{Action=Index}/{id?}")
    );

app.Run();

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using pustoktemplate.DAL;
using pustoktemplate.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(builder.Configuration["ConnectionStrings:Default"]));
builder.Services.AddControllersWithViews();
builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
{
    opt.Password.RequireNonAlphanumeric = false;
    
}).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
    );
});
app.MapDefaultControllerRoute();
app.UseStaticFiles();

app.Run();

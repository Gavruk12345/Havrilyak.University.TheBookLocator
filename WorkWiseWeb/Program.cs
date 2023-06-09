using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WorkWiseWeb.Areas.Identity.Data;
using WorkWiseWeb.Data;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("WorkWiseWebDbContextConnection") ?? throw new InvalidOperationException("Connection string 'WorkWiseWebDbContextConnection' not found.");

builder.Services.AddDbContext<WorkWiseWebDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<WorkWiseWebDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();

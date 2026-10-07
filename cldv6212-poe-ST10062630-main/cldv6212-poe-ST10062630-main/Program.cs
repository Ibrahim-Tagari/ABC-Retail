
using Microsoft.EntityFrameworkCore;
using ST10062630_CLDV6212_POE.Data;
using System.Runtime.Intrinsics.X86;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure DbContext with connection string
builder.Services.AddDbContext<ABCRetailContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ABCRetailDatabase")));

var app = builder.Build();

// Use routing middleware to map requests
app.UseRouting();

// Ensure static files can be served
app.UseStaticFiles();

// Use authentication/authorization (if needed)
app.UseAuthorization();

// Set up the default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
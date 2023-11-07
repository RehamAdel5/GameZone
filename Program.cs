
using GameZone.Data;
using GameZone.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                                ?? throw new InvalidOperationException("No connection string was found");

builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddRazorPages();
builder.Services.AddMvc(x => x.EnableEndpointRouting = false);

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddScoped<IGamesService, GamesService>();
builder.Services.AddScoped<IDevicesService, DevicesService>();
builder.Services.AddScoped<ICategoriesService, CategoriesService>();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();
app.UseMvcWithDefaultRoute();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

using Microsoft.EntityFrameworkCore;
using Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<RepositoryContext>(opt => 
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), b=> b.MigrationsAssembly("StoreApp"));
});

var app = builder.Build();

app.UseStaticFiles(); // Using wwwroot folder for static files

app.UseHttpsRedirection(); 

app.UseRouting(); 

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();

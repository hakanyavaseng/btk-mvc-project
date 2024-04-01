using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Concretes;
using Repositories.Contracts;
using Services.Concretes;
using Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<RepositoryContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("StoreApp"));
});

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddSingleton<Cart>();

builder.Services.AddAutoMapper(typeof(Program));


var app = builder.Build();

app.UseStaticFiles(); // Using wwwroot folder for static files

app.UseHttpsRedirection();

app.UseRouting();




app.UseEndpoints(endpoint =>
{

   endpoint.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
    );
    endpoint.MapControllerRoute(
         name: "default",
         pattern: "{controller=Home}/{action=Index}/{id?}"
    );

    endpoint.MapRazorPages();

});

app.Run();

using StoreApp.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureIdentity();

builder.Services.ConfigureSession();

builder.Services.ConfigureRepositoryRegistration();
builder.Services.ConfigureServiceRegistration();

builder.Services.ConfigureRouting();


builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.UseStaticFiles(); // Using wwwroot folder for static files
app.UseSession();
app.UseHttpsRedirection();

app.UseRouting();
//These middlewares must be in this order and before UseEndpoints after UseRouting
app.UseAuthentication();
app.UseAuthorization();

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

app.ConfigureLocalization();
app.ConfigureDefaultAdminUser();

app.Run();
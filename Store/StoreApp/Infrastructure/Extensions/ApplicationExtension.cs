using Microsoft.AspNetCore.Identity;

namespace StoreApp.Infrastructure.Extensions
{
    public static class ApplicationExtension
    {
        public static void ConfigureLocalization(this WebApplication app)
        {
            app.UseRequestLocalization(options =>
            {
                options.AddSupportedCultures("tr-TR")
                       .AddSupportedUICultures("tr-TR")
                       .SetDefaultCulture("tr-TR");
            });
        }
        public static async void ConfigureDefaultAdminUser(this IApplicationBuilder app)
        {
            const string adminUser = "Admin";
            const string adminPassword = "Admin123";

            //UserManager
            UserManager<IdentityUser> userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            //RoleManager
            RoleManager<IdentityRole> roleManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            


            IdentityUser user = await userManager.FindByNameAsync(adminUser);
            if (user is null)
            {
                user = new IdentityUser(adminUser)
                {
                    Email = "admin@gmail.com",
                    PhoneNumber = "1234567890"
                };

                IdentityResult result = await userManager.CreateAsync(user, adminPassword);
                if (result.Succeeded)
                {
                    if(!await roleManager.RoleExistsAsync("Admin"))
                    {
                        await roleManager.CreateAsync(new IdentityRole("Admin"));
                    }
                    await userManager.AddToRoleAsync(user, "Admin");
                }
                else
                    throw new Exception("Admin user could not be created.");
            }
        }
    }
}

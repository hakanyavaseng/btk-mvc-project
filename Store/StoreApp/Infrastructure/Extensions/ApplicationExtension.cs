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
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WorkWise.Database.Service; // Додайте директиву using для простору імен, який містить UserService
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;


namespace WorkWise
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Інші налаштування

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "login",
                    pattern: "login",
                    defaults: new { controller = "YourController", action = "Login" });

                // Додаткові маршрути

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            

            // Додайте решту налаштувань сервісів, які ви використовуєте

            services.AddScoped<UserService>(); // Додайте залежність UserService з методом AddScoped або AddSingleton, залежно від потреб

            // ...
        }






    }
}
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;
using WorkWise.Databases.Model;


namespace WorkWise
{
    public class Startup 
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Додайте налаштування підключення до бази даних
            services.AddDbContext<WorkWise.StoreDbContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("StoreDbContext")));

            // Додайте налаштування роботи з Identity
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<WorkWise.StoreDbContext>()
                .AddDefaultTokenProviders();

            // Додайте сервіси, необхідні для роботи з MVC
            services.AddMvc();

            // Додайте інші сервіси за потребою
        }
    }


}


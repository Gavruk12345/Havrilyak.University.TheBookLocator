using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorkWise.Model.Databases;
using WorkWise.Database;
using WorkWise.Databases;
using WorkWise.Database.Interfaces;
using System.Data.Entity;
using WorkWise.Databases.Services;

namespace WorkWise.Database
{
    /*
    public static class DIConfiguration
    {
        public static void RegisterDatabaseDependencies(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddDbContext<StoreDbContext>((x) => x.UseSqlServer(configuration.GetConnectionString("StoreDbContext")));

            services.AddScoped(typeof(IDbEntityService<>), typeof(MyService<>));
            services.AddScoped<CustomerService, CustomerService>();
        }
    }*/
    public class DependencyRegistration
    {
        public static void Register(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<StoreDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<CustomerService, CustomerService>();
        }
    }

}

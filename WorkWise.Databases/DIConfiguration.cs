using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorkWise.Model.Databases;
using WorkWise.Database;
using WorkWise.Databases;
using WorkWise.Database.Interfaces;
using WorkWise.Database.Service;

namespace WorkWise.Database
{
    public static class DIConfiguration
    {
        public static void RegisterDatabaseDependencies(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddDbContext<StoreDbContext>((x) => x.UseSqlServer(configuration.GetConnectionString("StoreDbContext")));

            services.AddScoped(typeof(IDbEntityService<>), typeof(MyService<>));
            //services.AddScoped<IDbEnityService<>>
        }
    }
}

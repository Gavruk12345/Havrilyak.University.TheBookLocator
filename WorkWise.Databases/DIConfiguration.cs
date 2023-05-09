using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorkWise.Database.Interfaces;
using WorkWise.Database.Service;
using WorkWise.Model.Database.Tables;
using WorkWise.Database;

namespace WorkWise.Database
{
    public static class DIConfiguration
    {
        public static void RegisterDatabaseDependencies(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddDbContext<StoreDbContext>((x) => x.UseSqlServer(configuration.GetConnectionString("StoreDatabase")));
            services.AddScoped(typeof(IDbEntityService<>), typeof(DbEntityService<>));
            services.AddScoped<UserService, UserService>();
        }
    }
}
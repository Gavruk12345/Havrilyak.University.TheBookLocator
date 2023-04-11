using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;
using System;

namespace WorkWise
{
    public class Startup 
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("StoreDbContext");
            services.AddDbContext<AppDBContext>(c => c.UseSqlServer(connectionString));

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDBContext>();
            services.AddControllersWithViews();

        }
    }


}


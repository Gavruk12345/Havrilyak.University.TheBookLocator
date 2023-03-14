﻿/*
using Microsoft.Extensions.Configuration;



using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WorkWise.Test;

namespace WorkWise.Test;

public class TestBase
{
    public IServiceProvider ServiceProvider { get; private set; }

    public ILogger Logger { get; private set; }

    protected TestBase()
    {
        IConfigurationBuilder builder = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", false)
                    .AddJsonFile("appsettings.Development.json", true)
                    .AddUserSecrets<TestBase>();

        IConfigurationRoot configuration = builder.Build();

        var services = new ServiceCollection();

        services.AddLogging((config) => config.AddDebug());
        services.RegisterCoreDependencies();
        services.RegisterCoreConfiguration(configuration);

        ServiceProvider = services.BuildServiceProvider();
        Logger = ServiceProvider.GetRequiredService<ILogger<TestBase>>();
    }

    protected T ResolveService<T>() where T : class
    {
        return ServiceProvider.GetRequiredService<T>();
    }
}
*/
using WorkWise.Database.Service;
using WorkWise.Database;
using WorkWise.Model.Databases;
using WorkWise.Database.Interfaces;

namespace WorkWise.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Створення контексту бази даних
            using (var dbContext = new StoreDb ontext())
            {
                // Створення нового клієнта
                var newCustomer = new Customer
                {
                    
                  Name = "dima"
                    Email = "johndoe@example.com"
                };

                // Створення сервісу для роботи з клієнтами і додавання нового клієнта
                var customerService = new CustomerService(dbContext);
                customerService.AddCustomer(newCustomer);
            }
        }
    }
}

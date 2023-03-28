/*
using Microsoft.Extensions.Configuration;
using WorkWise;
using Microsoft.Extensions.Configuration.Json;
using WorkWise.Database;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WorkWise.Test;
using Microsoft.Extensions.Logging.Debug;
using Microsoft.Extensions.Configuration.UserSecrets;
using WorkWise.Database.Service;
using WorkWise.Model.Configuration;
using WorkWise.Core;


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
       // services.RegisterCoreDependencies(configuration);
        services.RegisterCoreConfiguration(configuration);

        ServiceProvider = services.BuildServiceProvider();
        Logger = ServiceProvider.GetRequiredService<ILogger<TestBase>>();
    }

    protected T ResolveService<T>() where T : class
    {
        return ServiceProvider.GetRequiredService<T>();
    }
}*/


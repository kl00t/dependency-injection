using DependencyInjection.Services.Contracts;
using DependencyInjection.Services;

namespace DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddServicesExample(this IServiceCollection services)
    {
        services.AddSingleton<IExternalApi, HoroscopeApi>(); // Red

        services.AddScoped<IRepository, SqlRepository>(); // Blue
        services.AddScoped<IRepository, MongoRepository>(); // Blue

        services.AddTransient<IPersonService, PersonService>(); // Green
        services.AddTransient<ICalculator, Calculator>(); // Green
        services.AddTransient<IGreeting, HelloGreeting>(); // Green
        services.AddTransient<IGreeting, HolaGreeting>(); // Greed
    }

    public static void AddKeyedServicesExample(this IServiceCollection services)
    {
        services.AddSingleton<IExternalApi, HoroscopeApi>();

        services.AddKeyedScoped<IRepository, SqlRepository>("sql");
        services.AddKeyedScoped<IRepository, MongoRepository>("mongo");

        services.AddTransient<IPersonService, PersonService>();
        services.AddTransient<ICalculator, Calculator>();
        services.AddKeyedTransient<IGreeting, HelloGreeting>("hello");
        services.AddKeyedTransient<IGreeting, HolaGreeting>("hola");
    }
}

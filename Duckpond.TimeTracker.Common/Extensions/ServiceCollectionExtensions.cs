using System.Reflection;
using Duckpond.TimeTracker.Common.Attributes;

namespace Duckpond.TimeTracker.Common.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAttributedServiesFromAssembly(this IServiceCollection services, Assembly? assembly = null)
    {
        assembly ??= Assembly.GetEntryAssembly();

        assembly?.GetTypes().Where(type => type is { IsClass: true, IsAbstract: false, IsGenericType: false, IsInterface: false }
                                           && type.GetCustomAttributes<ServiceAttribute>().Any())
            .ForEach(t =>
            {
                var serviceAttribute = t.GetCustomAttribute<ServiceAttribute>();
                if (serviceAttribute is null) return;

                if (serviceAttribute.ServiceKey is not null)
                {
                    switch (serviceAttribute.ServiceLifetime)
                    {
                        case ServiceLifetime.Transient:
                            services.AddKeyedTransient(t, serviceAttribute.ServiceKey);
                            break;
                        case ServiceLifetime.Scoped:
                            services.AddKeyedScoped(t, serviceAttribute.ServiceKey);
                            break;
                        case ServiceLifetime.Singleton:
                            services.AddKeyedSingleton(t, serviceAttribute.ServiceKey);
                            break;
                    }
                }
                else
                {
                    switch (serviceAttribute.ServiceLifetime)
                    {
                        case ServiceLifetime.Transient:
                            services.AddTransient(t);
                            break;
                        case ServiceLifetime.Scoped:
                            services.AddScoped(t);
                            break;
                        case ServiceLifetime.Singleton:
                            services.AddSingleton(t);
                            break;
                    }
                }
            });

        return services;
    }
}
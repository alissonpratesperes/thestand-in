using Microsoft.Extensions.DependencyInjection;

using Domain.Shared.Data;
using Infrastructure.Shared.Data;

    namespace Infrastructure.Extensions {
        public static class WorkUnit {
            public static IServiceCollection AddUnityOfWork(this IServiceCollection services) {
                AddWorkUnits(services);

                    return services;
            }

                private static void AddWorkUnits(IServiceCollection services) {
                    services.AddScoped<IUnityOfWork, UnityOfWork>();
                }
        }
    }
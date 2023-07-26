using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Domain.Shared.Data;
using Infrastructure.Shared.Data;

    namespace Infrastructure.Extensions {
        public static class Extension {
            public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) {

                services.AddScoped<IUnityOfWork, UnityOfWork>();

                    AddRepositories(services);

                        return services;
            }

                private static void AddRepositories(IServiceCollection services) {

                }
        }
    }
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Domain.Shared.Data;
using Infrastructure.Contexts;
using Infrastructure.Shared.Data;
using Domain.Requested.Repositories;
using Infrastructure.Repositories.Requested;



    namespace Infrastructure.Extensions {
        public static class Extension {
            public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) {
                services.AddSqlite<Context>(configuration["Database:Connection"]);
                services.AddScoped<IUnityOfWork, UnityOfWork>();

                    AddRepositories(services);

                        return services;
            }

                private static void AddRepositories(IServiceCollection services) {
                    services.AddTransient<IProspectRepository, ProspectRepository>();

                }
        }
    }
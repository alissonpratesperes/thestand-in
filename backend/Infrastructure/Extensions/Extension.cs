using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Infrastructure.Contexts;
using Domain.Requested.Repositories;
using Domain.Requester.Repositories;
using Infrastructure.Repositories.Requested;
using Infrastructure.Repositories.Requester;

    namespace Infrastructure.Extensions {
        public static class Extension {
            public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) {
                services.AddSqlite<Context>(configuration["Database:Connection"]);

                    AddRepositories(services);

                        return services;
            }

                private static void AddRepositories(IServiceCollection services) {
                    services.AddTransient<IProspectRepository, ProspectRepository>();
                    services.AddTransient<IDateRepository, DateRepository>();
                }
        }
    }
using Microsoft.Extensions.DependencyInjection;

using Domain.Requested.Repositories;
using Domain.Requester.Repositories;
using Infrastructure.Repositories.Requested;
using Infrastructure.Repositories.Requester;

    namespace Infrastructure.Extensions {
        public static class Repository {
            public static IServiceCollection AddRepository(this IServiceCollection services) {
                AddRepositories(services);

                    return services;
            }

                private static void AddRepositories(IServiceCollection services) {
                    services.AddTransient<IProspectRepository, ProspectRepository>();
                    services.AddTransient<IDateRepository, DateRepository>();
                }
        }
    }
using Microsoft.Extensions.DependencyInjection;

using Domain.Requested.QueryRepositories;
using Infrastructure.QueryRepositories.Requested;

    namespace Infrastructure.Extensions {
        public static class QueryRepository {
            public static IServiceCollection AddQueryRepository(this IServiceCollection services) {
                AddQueryableRepositories(services);

                    return services;
            }

                private static void AddQueryableRepositories(IServiceCollection services) {
                    services.AddTransient<IProspectQueryRepository, ProspectQueryRepository>();
                }
        }
    }
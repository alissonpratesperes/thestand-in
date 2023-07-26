using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

    namespace Infrastructure.Extensions {
        public static class Extension {
            public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) {



                    AddRepositories(services);

                        return services;
            }

                private static void AddRepositories(IServiceCollection services) {

                }
        }
    }
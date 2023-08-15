using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Infrastructure.Contexts;

    namespace Infrastructure.Extensions {
        public static class Extension {
            public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) {
                services.AddSqlite<Context>(configuration["Database:Connection"]);

                    return services;
            } 
        }
    }
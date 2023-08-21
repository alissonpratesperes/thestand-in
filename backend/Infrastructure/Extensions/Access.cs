using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Infrastructure.Sessions;

    namespace Infrastructure.Extensions {
        public static class Access {
            public static IServiceCollection AddSession(this IServiceCollection services, IConfiguration configuration) {
                services.AddScoped<Session>();

                    return services;
            }
        }
    }
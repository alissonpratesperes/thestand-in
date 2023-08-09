using Microsoft.Extensions.DependencyInjection;

using Domain.Shared.Results;
using Infrastructure.Shared.Results;

    namespace Infrastructure.Extensions {
        public static class Result {
            public static IServiceCollection AddResults<T>(this IServiceCollection services) {
                AddCommandResults<T>(services);

                    return services;
            }

                private static void AddCommandResults<T>(IServiceCollection services) {
                    services.AddScoped<ICommandResult<T>, CommandResult<T>>();
                }
        }
    }
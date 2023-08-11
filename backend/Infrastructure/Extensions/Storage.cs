using Microsoft.Extensions.DependencyInjection;

using Domain.Shared.Services;
using Infrastructure.Shared.Services;

    namespace Infrastructure.Extensions {
        public static class Storage {
            public static IServiceCollection AddStorage(this IServiceCollection services) {
                AddPictures(services);

                    return services;
            }

                private static void AddPictures(IServiceCollection services) {
                    services.AddTransient<IPictureStorage, PictureStorage>();
                }
        }
    }
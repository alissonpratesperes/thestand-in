using MediatR;
using Microsoft.OpenApi.Models;

using Domain.Shared.Entities;
using Infrastructure.Contexts;
using Infrastructure.Migrators;
using Infrastructure.Extensions;

    var builder = WebApplication.CreateBuilder(args);

        ConfigureServices(builder.Services);

    var app = builder.Build();
    var context = builder.Services.BuildServiceProvider().GetRequiredService<Context>();

        Configure(context);

            if (app.Environment.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

                app.UseStaticFiles();
                app.MapControllers();
                app.Run();

                    void ConfigureServices(IServiceCollection services) {
                        IConfiguration configuration = builder.Configuration;

                            services.AddControllers();
                            services.AddEndpointsApiExplorer();
                            services.AddSwaggerGen();
                            services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(typeof(Entity).Assembly); });
                            services.AddAuthorization();
                            services.AddDatabase(configuration);
                            services.AddRepository();
                            services.AddStorage();
                            services.AddUnityOfWork();
                            services.AddResults<Unit>();
                            services.AddSession(configuration);
                            services.AddQueryRepository();
                            services.AddMemoryCache();

                                ConfigureSwagger(services);
                    }

                    void ConfigureSwagger(IServiceCollection services) {
                        services.AddSwaggerGen(configs => {
                            configs.SwaggerDoc("v1", new OpenApiInfo {
                                Title = "The Stand-in",
                                Version = "v1",
                                Description = "The Stand-in: Find your perfect date."
                            });
                        });
                    }

                    void Configure(Context context) {
                        Migrator.MigrateDatabase(context);
                    }
using Microsoft.OpenApi.Models;

    var builder = WebApplication.CreateBuilder(args);

        ConfigureServices(builder.Services);

    var app = builder.Build();




            if (app.Environment.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

                app.UseAuthorization();
                app.MapControllers();
                app.Run();

                    void ConfigureServices(IServiceCollection services) {


                            services.AddControllers();
                            services.AddEndpointsApiExplorer();
                            services.AddSwaggerGen();

                            services.AddAuthorization();


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
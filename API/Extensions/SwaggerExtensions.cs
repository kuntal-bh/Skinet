using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API.Extensions
{
    public  static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerDocumentServices(this IServiceCollection services){
              services.AddSwaggerGen(c=> 
            {
                c.SwaggerDoc("v1", new OpenApiInfo {
                    Title = "Skinet API",
                    Version = "v1"
                });
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDoc(this IApplicationBuilder app) {
            app.UseSwagger();
            app.UseSwaggerUI(c=> {
                c.SwaggerEndpoint("/swagger/v1/swagger.json","Skinet API");
            });

            return app;
        }
    }
     
}
using System.Linq;
using API.Errors;
using core.Interfaces;
using infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
             services.Configure<ApiBehaviorOptions>(options=>
            {
                options.InvalidModelStateResponseFactory = action=>{
                    var errors = action.ModelState.Where(x=>x.Value.Errors.Count>0)
                                                  .SelectMany(e=>e.Value.Errors)
                                                  .Select(v=>v.ErrorMessage).ToArray();

                    var validationErrors = new ApiValidationError(400) {
                        ValidationErrors = errors
                    };

                    return new BadRequestObjectResult(validationErrors);
                };
            }
            );

            return services;
        }
    }
}
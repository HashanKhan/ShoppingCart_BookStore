using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;


namespace ShoppingCartApp.Extensions
{
    public static class ServiceExtensions
    {
        //Service extension for ConfigureCors. This wil resolve the CORS issue.

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }
    }
}

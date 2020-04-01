using EventsPortal.API.ActionFilter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace EventsPortal.API.Configuration
{
    public static class MVC
    {
        public static IServiceCollection AddApiMvc(this IServiceCollection services)
        {
            services.AddScoped<JWTActionFilter>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddMvc().AddMvcOptions(options =>
            {
                options.Filters.AddService(typeof(JWTActionFilter));
            });

            return services;
        }
    }
}

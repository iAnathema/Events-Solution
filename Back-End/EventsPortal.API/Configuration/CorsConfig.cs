using EventsPortal.AppSettings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace EventsPortal.API.Configuration
{
    public static class Cors
    {
        public static IServiceCollection AddCorsPolicy(this IServiceCollection services, string AllowOrigins)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(AllowOrigins,
                builder =>
                {
                    builder
                       .WithOrigins(Settings.Cors.Hubs)
                       .AllowAnyMethod()
                       .WithHeaders(Settings.Cors.Headers);
                });
            });
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory(AllowOrigins));
            });

            return services;
        }
    }
}

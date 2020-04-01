using EventsPortal.AppSettings;
using EventsPortal.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EventsPortal.API.Configuration
{
    public static class AddDbContextConfig
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services)
        {

            switch(Settings.ConnectionSettings.DBConnectionType)
            {
                case ConnectionType.SqlServer:
                       services.AddDbContext<EventsPortalDbContext>(item =>
                            item.UseSqlServer(Settings.ConnectionSettings.DBConnectionString,
                            assembly => assembly.MigrationsAssembly(typeof(EventsPortalDbContext).Assembly.FullName))
                            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
                break;


                case ConnectionType.SqlLite:
                      services.AddDbContext<EventsPortalDbContext>(item =>
                            item.UseSqlite(Settings.ConnectionSettings.DBConnectionString,
                            assembly => assembly.MigrationsAssembly(typeof(EventsPortalDbContext).Assembly.FullName))
                           .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
                break;
            }

            return services;





        }
    }
}

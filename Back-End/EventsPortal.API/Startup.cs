using EventsPortal.API.Configuration;
using EventsPortal.AppSettings;
using EventsPortal.DAL.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;

namespace EventsPortal.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string AllowOrigins = "EventsPortalPolicy";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            IdentityModelEventSource.ShowPII = true;
            //Read appsetting.json
            var appSettingsSection = Configuration.GetSection("Settings");
            services.Configure<Settings>(appSettingsSection);
            appSettingsSection.Get<Settings>();

            //Load DB Context
            services.AddDbContext();

            //Cors policy copnfiguration
            services.AddCorsPolicy(AllowOrigins);

            services.AddApiMvc();

            //Manage different Versions of API. A client can add the header "x-api-version" in the request Headers and set the value. By default the value is Api version 1
            services.AddVersioning();

            //Add oAuth2 Configuration
            services.AddOAuth2();

            //Add the Middleware Swagger, this component add an Self-Write HTML page with API Specification. Add /swagger to URL
            services.AddSwaggerConfig();

            services.AddMappingAndScoped();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<EventsPortalDbContext>();
                context.Database.Migrate();
            }

            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

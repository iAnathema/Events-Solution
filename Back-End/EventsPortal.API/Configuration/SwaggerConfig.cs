using EventsPortal.AppSettings;
using Microsoft.Extensions.DependencyInjection;
using NSwag;
using NSwag.Generation.Processors.Security;
using System.Collections.Generic;
using System.Reflection;

namespace EventsPortal.API.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {

            services.AddSwaggerDocument(document =>
            {

                document.PostProcess = config =>
                {
                    config.Info.Version = Assembly.GetEntryAssembly().GetName().Version.ToString();
                    config.Info.Title = "EventsPortal API";
                    config.Info.Description = "RESTful API for LSNJ Events";
                    config.Info.TermsOfService = "None";

                    config.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "Legal Services of New Jersey",
                        Email = string.Empty,
                        Url = "https://www.lsnj.org"
                    };
                    //config.Info.License = new NSwag.OpenApiLicense
                    //{
                    //    Name = "Use under LICX",
                    //    Url = "https://example.com/license"
                    //};
                };

                document.AddSecurity("oauth2", new OpenApiSecurityScheme()
                {
                    Flows = new OpenApiOAuthFlows()
                    {
                        Implicit = new OpenApiOAuthFlow()
                        {
                            AuthorizationUrl = $"{Settings.Authentication.Authority}/connect/authorize",
                            Scopes = new Dictionary<string, string>
                            {
                                {"EventPortal", "EventPortal Management API - full access"},
                            },
                        }
                    }
                });

                document.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("bearer"));

            });

            return services;
        }
    }
}

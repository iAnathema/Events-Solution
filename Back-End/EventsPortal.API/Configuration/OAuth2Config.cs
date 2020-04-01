using EventsPortal.AppSettings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EventsPortal.API.Configuration
{
    public static class OAuth2
    {
        public static IServiceCollection AddOAuth2(this IServiceCollection services)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); //asp.net core auth services tend to map to more formal/longer type of claim names

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = "name",
                    RoleClaimType = "role",
                };
                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = async ctx =>
                    {
                        try
                        {
                            await BearerTokenAuthorizationEventHelper.OnTokenValidated(ctx);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                };
                options.Authority = Settings.Authentication.Authority;
                options.Audience = Settings.Authentication.Audience;
                options.RequireHttpsMetadata = Settings.Authentication.RequireHttpsMetadata;
            });



            services.AddAuthorization(options =>
            {
                options.AddPolicy("Administrator", policy => policy.RequireClaim("role", "Administrator"));
            });


            return services;
        }
    }

    public static class BearerTokenAuthorizationEventHelper
    {
        public static async Task OnTokenValidated(TokenValidatedContext ctx)
        {
            try
            {
                //Set data in request
                WebRequest request = WebRequest.Create(Settings.Authentication.Authority + "connect/userinfo");
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers.Add("Authorization:" + ctx.Request.Headers["Authorization"]);
                Stream dataStream = await request.GetRequestStreamAsync();

                //Get the response
                WebResponse wr = await request.GetResponseAsync();
                var receiveStream = wr.GetResponseStream();
                StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
                string identityClaimString = reader.ReadToEnd();
                var identityClaims = JObject.Parse(identityClaimString);
                //ctx.Principal.AddIdentity(lsnjIdentity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

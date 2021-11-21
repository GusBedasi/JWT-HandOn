using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Shop.Services;
using Shop.Services.Contracts;

namespace Shop.Infrastruture.IoC
{
    public static class DependencyInjection
    {
        public static void AddJwtConfiguration(this IServiceCollection services, IConfigurationSection configuration)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddCors();

            var key = configuration.GetValue<string>("Secret");
            var keyBytes = Encoding.ASCII.GetBytes(key);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
    }
}
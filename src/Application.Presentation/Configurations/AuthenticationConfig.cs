using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors;
using Microsoft.IdentityModel.Tokens;

namespace Conecta.Doa.Application.Presentation.Configurations;

public static class AuthenticationConfig
{
    public static WebApplicationBuilder AddAuthenticationConfiguration(this WebApplicationBuilder builder, IConfiguration configuration)
    {
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt =>
            {
                opt.Authority = configuration["Keycloack:AuthorizationUrl"];
                opt.MetadataAddress = configuration["Keycloak:Metadata"];
                opt.RequireHttpsMetadata = false;

                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["Keycloack:AuthorizationUrl"],
                    ValidateAudience = false
                };

                opt.MapInboundClaims = false;
            });

        builder.Services.AddAuthorization();

        return builder;
    }
}

using Conecta.Doa.Application.Presentation.Interfaces;
using Conecta.Doa.Application.Presentation.Services;

namespace Conecta.Doa.Application.Presentation.Configurations;

public static class DependencyInjectionConfig
{
    public static WebApplicationBuilder AddDependencyInjectionConfiguration(this WebApplicationBuilder builder)
    {
        // builder.Services.AddScoped<IAuthService, AuthService>();

        builder.Services.AddScoped<IDonatorAppService, DonatorAppService>();

        return builder;
    }
}

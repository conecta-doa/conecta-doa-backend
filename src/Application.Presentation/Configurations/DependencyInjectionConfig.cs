namespace Conecta.Doa.Application.Presentation.Configurations;

public static class DependencyInjectionConfig
{
    public static WebApplicationBuilder AddDependencyInjectionConfiguration(this WebApplicationBuilder builder)
    {
        // builder.Services.AddScoped<IAuthService, AuthService>();

        return builder;
    }
}

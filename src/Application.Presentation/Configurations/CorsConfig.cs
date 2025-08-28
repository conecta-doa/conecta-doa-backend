namespace Conecta.Doa.Application.Presentation.Configurations;

public static class CorsConfig
{
    public static WebApplicationBuilder AddCorsConfiguration(this WebApplicationBuilder builder, IConfiguration configuration)
    {
        builder.Services.AddCors(o => o.AddDefaultPolicy(p =>
            p.WithOrigins(configuration.GetSection("AllowedOrigins").Get<string[]>()!)
             .AllowAnyHeader().AllowAnyMethod().AllowCredentials()
        ));
        return builder;
    }
}

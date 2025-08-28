using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Conecta.Doa.Application.Presentation.Configurations;

public static class SwaggerConfig
{
    //TODO melhorar esse codigo
    public static WebApplicationBuilder AddSwaggerConfiguration(this WebApplicationBuilder builder, IConfiguration configuration)
    {
        builder.Services.AddApiVersioning(options =>
        {
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.ReportApiVersions = true;
        }).AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = false;
        });

        builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerConfigOptions>();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(s =>
        {
            s.AddSecurityDefinition("Keycloack", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows
                {
                    AuthorizationCode = new OpenApiOAuthFlow
                    {
                        AuthorizationUrl = new Uri(configuration["Keycloack:AuthenticationUrl"]!),
                        TokenUrl = new Uri(configuration["Keycloack:TokenUrl"]!),
                        Scopes = new Dictionary<string, string>
                        {
                            ["openid"] = "OIDC",
                            ["profile"] = "Perfil",
                            ["email"] = "E-mail"
                        }
                    }
                }
            });

            s.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Keycloack"
                        }
                    },
                    new[] { "openid", "profile", "email"}
                }
            });
        });

        return builder;
    }

    public static WebApplication UseSwaggerConfiguration(this WebApplication app, IConfiguration configuration)
    {
        var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.OAuthUsePkce();
            options.OAuthClientId(configuration["Keycloack:SwaggerClientId"]);
            options.OAuthScopes("openid", "profile", "email");
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", $"ConectaDoa API {description.GroupName}");
            }
        });

        return app;
    }
}

public class SwaggerConfigOptions : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;

    public SwaggerConfigOptions(IApiVersionDescriptionProvider provider)
    {
        _provider = provider;
    }

    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
        }

        options.OperationFilter<ApiVersionFilter>();
    }

    private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
    {
        return new OpenApiInfo
        {
            Title = "ConectaDoa API",
            Version = description.ApiVersion.ToString(),
            Description = "This API belogns to ConectaDoa",
            Contact = new OpenApiContact
            {
                Name = "ConectaDoa Support",
                Email = "conecta.doa.dev@gmail.com",
            }

        };
    }

    private class ApiVersionFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var parametersToRemove = operation.Parameters.Where(x => x.Name == "api-version").ToList();
            foreach (var parameter in parametersToRemove)
                operation.Parameters.Remove(parameter);
        }
    }
}
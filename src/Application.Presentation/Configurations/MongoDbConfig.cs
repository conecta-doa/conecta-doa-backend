using Conecta.Doa.Application.Presentation.Domain.Interfaces;
using Conecta.Doa.Application.Presentation.Infra.Data.Configs;
using Conecta.Doa.Application.Presentation.Infra.Data.Context;
using Conecta.Doa.Application.Presentation.Infra.Data.Interfaces;
using Conecta.Doa.Application.Presentation.Infra.Data.Repositories;

namespace Conecta.Doa.Application.Presentation.Configurations;

public static class MongoDbConfig
{
    public static WebApplicationBuilder AddMongoDbConfiguration(this WebApplicationBuilder builder)
    {
        var mongoDbConfigs = GetMongoDbConfig(builder.Configuration);

        builder.Services.AddSingleton(mongoDbConfigs)
                        .AddSingleton<IMongoContext, MongoContext>();

        // Donator
        builder.Services.AddScoped<IDonatorRepository, DonatorRepository>();

        return builder;
    }

    public static MongoDbConfigs GetMongoDbConfig(IConfiguration configuration)
    {
        return new MongoDbConfigs(configuration.GetSection("ConnectionString").Value,
                                  configuration.GetSection("DatabaseName").Value);
    }
}

using Conecta.Doa.Application.Presentation.Data.Configs;
using Conecta.Doa.Application.Presentation.Data.Context;
using Conecta.Doa.Application.Presentation.Data.Interfaces;
using Conecta.Doa.Application.Presentation.Data.Repositories;
using Conecta.Doa.Application.Presentation.Domain.Interfaces;

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

        // User
        builder.Services.AddScoped<IUserRepository, UserRepository>();

        return builder;
    }

    public static MongoDbConfigs GetMongoDbConfig(IConfiguration configuration)
    {
        return new MongoDbConfigs(configuration.GetSection("ConnectionString").Value,
                                  configuration.GetSection("DatabaseName").Value);
    }
}

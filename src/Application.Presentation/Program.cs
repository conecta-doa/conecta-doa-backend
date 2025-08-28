using Conecta.Doa.Application.Presentation.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.AddMongoDbConfiguration()
    .AddCorsConfiguration(builder.Configuration)
    .AddSwaggerConfiguration(builder.Configuration)
    .AddDependencyInjectionConfiguration()
    .AddAuthenticationConfiguration(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

app.UseCors();
app.UseSwaggerConfiguration(builder.Configuration);

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

using System;
using Conecta.Doa.Application.Presentation.Configurations;
using Application.Presentation.Interfaces;    // ajusta para o seu namespace real
using Application.Presentation.Services;      // ajusta para o seu namespace real

var builder = WebApplication.CreateBuilder(args);

builder.AddMongoDbConfiguration()
    .AddCorsConfiguration(builder.Configuration)
    .AddSwaggerConfiguration(builder.Configuration)
    .AddDependencyInjectionConfiguration()
    .AddAuthenticationConfiguration(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

// *** REGISTRO DO SERVIÇO DA BRASILAPI COM HttpClientFactory ***
// Isso injeta IIBrasilAPI e cria um HttpClient configurado.
// Se você já registra IIBrasilAPI dentro de AddDependencyInjectionConfiguration(),
// remova a duplicata ou garanta que não haja conflito.
builder.Services.AddHttpClient<IIBrasilAPI, CnpjService>(client =>
{
    client.BaseAddress = new Uri("https://brasilapi.com.br/"); // base da API
    client.Timeout = TimeSpan.FromSeconds(30);
});

var app = builder.Build();

app.UseCors(); // ok, desde que sua AddCorsConfiguration defina política padrão

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

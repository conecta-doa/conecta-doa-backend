using System;
using Conecta.Doa.Application.Presentation.Configurations;
using Application.Presentation.Interfaces;    
using Application.Presentation.Services;     

var builder = WebApplication.CreateBuilder(args);

builder.AddMongoDbConfiguration()
    .AddCorsConfiguration(builder.Configuration)
    .AddSwaggerConfiguration(builder.Configuration)
    .AddDependencyInjectionConfiguration()
    .AddAuthenticationConfiguration(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddOpenApi();


builder.Services.AddHttpClient<ICorporation_information, CnpjService>(client =>
{
    client.BaseAddress = new Uri("https://brasilapi.com.br/"); 
    client.Timeout = TimeSpan.FromSeconds(30);
});

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

using Conecta.Doa.Application.Presentation.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.AddSwaggerConfiguration();

builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

app.UseSwaggerConfiguration();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

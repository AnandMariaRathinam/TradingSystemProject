//using Microsoft.OpenApi.Models;
using TradingCompany.Api.Application.Interfaces;
using TradingCompany.Api.Application.Services;
using TradingCompany.Api.Infrastructure.Data;
using TradingCompany.Api.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ProductService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Trading Company API v1");
    });
}

app.UseAuthorization();
app.MapControllers();
app.Run();

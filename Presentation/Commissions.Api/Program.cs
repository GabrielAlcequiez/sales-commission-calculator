using Commissions.Domain.Entities;
using Commissions.Domain.Interfaces;
using Commissions.Business.Services;
using Commissions.Business.Validators;
using Commissions.Data;
using Commissions.Data.Repository;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<ISalesRepository, SalesRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();

builder.Services.AddScoped<IValidator<Sales>, SalesValidator>();
builder.Services.AddScoped<IValidator<Country>, CountryValidator>();

builder.Services.AddScoped<ISalesService, SalesService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Commissions API V1");
        c.RoutePrefix = string.Empty; 
    });
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
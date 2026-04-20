using Commissions.Business.Entities;
using Commissions.Business.Interfaces;
using Commissions.Business.Services;
using Commissions.Business.Validators;
using Commissions.Data;
using Commissions.Data.Repository;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

DotNetEnv.Env.Load();

var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL")
    ?? builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<ISalesRepository, SalesRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();

builder.Services.AddScoped<IValidator<Sales>, SalesValidator>();
builder.Services.AddScoped<IValidator<Country>, CountryValidator>();

builder.Services.AddScoped<ISalesService, SalesService>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
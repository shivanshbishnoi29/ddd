using Application.Countries;
using Application.States;
using Infrastructure;
using Infrastructure.Repositories.Countries;
using Infrastructure.Repositories.States;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DataContext>(options=>options.UseSqlServer(connectionString));

builder.Services.AddTransient<ICountryRepository, CountryRepository>();
builder.Services.AddTransient<ICountryApplication, CountryApplication>();
builder.Services.AddTransient<IStateRepository,StateRepository>();
builder.Services.AddTransient<IStateApplication,StateApplication>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

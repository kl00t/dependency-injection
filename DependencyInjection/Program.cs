using DependencyInjection.Services;
using DependencyInjection.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// NOTE: Show example of services not being registered.
builder.Services.AddSingleton<IExternalApi, HoroscopeApi>(); // Red

builder.Services.AddScoped<IPersonService, PersonService>(); // Blue
builder.Services.AddScoped<IRepository, SqlRepository>(); // Blue
builder.Services.AddScoped<IRepository, MongoRepository>(); // Blue

// NOTE: Show example of precedence.
builder.Services.AddTransient<ICalculator, Calculator>(); // Green
builder.Services.AddTransient<IGreeting, HelloGreeting>(); // Green
builder.Services.AddTransient<IGreeting, HolaGreeting>(); // Greed

// NOTE: show example of DI keyed services.
//builder.Services.AddKeyedTransient<IGreeting, HelloGreeting>("hello"); // Green
//builder.Services.AddKeyedTransient<IGreeting, HolaGreeting>("hola"); // Greed

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

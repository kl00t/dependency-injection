using DependencyInjection.Services;
using DependencyInjection.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IExternalApi, HoroscopeApi>(); // Red

builder.Services.AddScoped<IPersonService, PersonService>(); // Blue
builder.Services.AddScoped<IRepository, SqlRepository>(); // Blue
builder.Services.AddScoped<IRepository, MongoRepository>(); // Blue

builder.Services.AddTransient<ICalculator, Calculator>(); // Green
builder.Services.AddTransient<IGreeting, HelloGreeting>(); // Green
builder.Services.AddTransient<IGreeting, HolaGreeting>(); // Greed


// NOTE: Show example of services not being registered.
// NOTE: Show example of precedence. This can be override by using name parameters


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

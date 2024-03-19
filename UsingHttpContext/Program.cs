using Microsoft.AspNetCore.Mvc;
using UsingHttpContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<Service>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/weatherforecast", (Service service, [FromQuery] string city) =>
{
    WeatherForecast[] weatherForecasts = service.GetWeatherForecast();
    return weatherForecasts;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();



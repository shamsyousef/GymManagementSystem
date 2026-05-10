using Gym.API.Middleware;
using Gym.Application;
using Gym.Application.Interfaces.UnitOfWork;
using Gym.Infrastructure.Data;
using Gym.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers()
    .AddJsonOptions(o =>
    {
        o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
{
    o.UseInlineDefinitionsForEnums();
});

// DbContext
builder.Services.AddDbContext<GymDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GymDB")));

// Application services
builder.Services.AddApplication();

// Unit of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Middleware
builder.Services.AddTransient<GlobalExceptionMiddleware>();

var app = builder.Build();

// Configure Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gym API V1");
        c.RoutePrefix = string.Empty; // Swagger على root
    });
}

app.UseHttpsRedirection();


app.UseMiddleware<GlobalExceptionMiddleware>();

app.MapControllers();

app.Run();



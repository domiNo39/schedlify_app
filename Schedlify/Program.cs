using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Schedlify.Data;

var builder = WebApplication.CreateBuilder(args);

// Load environment variables from .env.local
DotNetEnv.Env.Load(".env.local");

// Configure Entity Framework to use PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var host = Environment.GetEnvironmentVariable("DB_HOST");
    var port = Environment.GetEnvironmentVariable("DB_PORT");
    var database = Environment.GetEnvironmentVariable("DB_NAME");
    var username = Environment.GetEnvironmentVariable("DB_USER");
    var password = Environment.GetEnvironmentVariable("DB_PASSWORD");

    var connectionString = $"Host={host};Port={port};Database={database};Username={username};Password={password}";

    options.UseNpgsql(connectionString);
});

// Add other services here
// builder.Services.AddControllers(); // Example

var app = builder.Build();

// Configure middleware, etc.
app.Run();
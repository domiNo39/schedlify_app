// Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;


namespace Schedlify.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            // Ensure that the .env file is loaded during DbContext construction
            DotNetEnv.Env.Load(".env.local");
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var host = Environment.GetEnvironmentVariable("DB_HOST");
                var port = Environment.GetEnvironmentVariable("DB_PORT");
                var database = Environment.GetEnvironmentVariable("DB_NAME");
                var username = Environment.GetEnvironmentVariable("DB_USER");
                var password = Environment.GetEnvironmentVariable("DB_PASSWORD");

                var connectionString = $"Host={host};Port={port};Database={database};Username={username};Password={password}";

                optionsBuilder.UseNpgsql(connectionString);
            }
        }
    }
}
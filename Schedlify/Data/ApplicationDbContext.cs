// Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using Schedlify.Models;

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

        
        public DbSet<User> Users { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<TemplateSlot> TemplateSlots { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Class> Classes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User configuration
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Login).IsUnique();
                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
            });

            // University configuration
            modelBuilder.Entity<University>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
            });

            // Department configuration
            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
                entity.HasOne(d => d.University)
                      .WithMany(u => u.Departments)
                      .HasForeignKey(d => d.UniversityId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Group configuration
            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
                entity.HasOne(g => g.Department)
                      .WithMany(d => d.Groups)
                      .HasForeignKey(g => g.DepartmentId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(g => g.Administrator)
                      .WithMany(u => u.AdministratedGroups)
                      .HasForeignKey(g => g.AdministratorId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // TemplateSlot configuration
            modelBuilder.Entity<TemplateSlot>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
                entity.HasOne(ts => ts.Department)
                      .WithMany(d => d.TemplateSlots)
                      .HasForeignKey(ts => ts.DepartmentId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Assignment configuration
            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
                entity.Property(e => e.Type).HasColumnName("Type");
                entity.Property(e => e.Date).HasColumnName("Date");

                entity.HasOne(a => a.Group)
                      .WithMany(g => g.Assignments)
                      .HasForeignKey(a => a.GroupId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(a => a.Class)
                      .WithMany(c => c.Assignments)
                      .HasForeignKey(a => a.ClassId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Class configuration
            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
                entity.HasOne(c => c.Group)
                      .WithMany(g => g.Classes)
                      .HasForeignKey(c => c.GroupId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
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
    
    public static class DbContextFactory
    {
        public static ApplicationDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var host = Environment.GetEnvironmentVariable("DB_HOST");
            var port = Environment.GetEnvironmentVariable("DB_PORT");
            var database = Environment.GetEnvironmentVariable("DB_NAME");
            var username = Environment.GetEnvironmentVariable("DB_USER");
            var password = Environment.GetEnvironmentVariable("DB_PASSWORD");

            var connectionString = $"Host={host};Port={port};Database={database};Username={username};Password={password}";

            optionsBuilder.UseNpgsql(connectionString);
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
    
}
// Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using Schedlify.Models;


namespace Schedlify.Data
{
    public class ApplicationDbContext : DbContext
    {

        // DbSets for all models
        public DbSet<User> Users { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<TemplateSlot> TemplateSlots { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<ScheduleAssignment> ScheduleAssignments { get; set; }
        public DbSet<UserSchedule> UserSchedules { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            // Ensure that the .env file is loaded during DbContext construction
            DotNetEnv.Env.Load(".env.local");
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Many-to-Many: ScheduleAssignments
            modelBuilder.Entity<ScheduleAssignment>()
                .HasKey(sa => new { sa.AssignmentId, sa.ScheduleId });

            modelBuilder.Entity<ScheduleAssignment>()
                .HasOne(sa => sa.Assignment)
                .WithMany(a => a.ScheduleAssignments)
                .HasForeignKey(sa => sa.AssignmentId);

            modelBuilder.Entity<ScheduleAssignment>()
                .HasOne(sa => sa.Schedule)
                .WithMany(s => s.ScheduleAssignments)
                .HasForeignKey(sa => sa.ScheduleId);

            // Many-to-Many: UserSchedules
            modelBuilder.Entity<UserSchedule>()
                .HasKey(us => new { us.UserId, us.ScheduleId });

            modelBuilder.Entity<UserSchedule>()
                .HasOne(us => us.User)
                .WithMany(u => u.UserSchedules)
                .HasForeignKey(us => us.UserId);

            modelBuilder.Entity<UserSchedule>()
                .HasOne(us => us.Schedule)
                .WithMany(s => s.UserSchedules)
                .HasForeignKey(us => us.ScheduleId);

            // Relationships and additional configurations for other models
            modelBuilder.Entity<Department>()
                .HasOne(d => d.University)
                .WithMany(u => u.Departments)
                .HasForeignKey(d => d.UniversityId);

            modelBuilder.Entity<Group>()
                .HasOne(g => g.University)
                .WithMany(u => u.Groups)
                .HasForeignKey(g => g.UniversityId);

            modelBuilder.Entity<Group>()
                .HasOne(g => g.Department)
                .WithMany(d => d.Groups)
                .HasForeignKey(g => g.DepartmentId);

            modelBuilder.Entity<Group>()
                .HasOne(g => g.Administrator)
                .WithMany(u => u.AdminGroups)
                .HasForeignKey(g => g.AdministratorId);

            modelBuilder.Entity<TemplateSlot>()
                .HasOne(ts => ts.User)
                .WithMany(u => u.TemplateSlots)
                .HasForeignKey(ts => ts.UserId);

            modelBuilder.Entity<TemplateSlot>()
                .HasOne(ts => ts.Department)
                .WithMany(d => d.TemplateSlots)
                .HasForeignKey(ts => ts.DepartmentId);

            modelBuilder.Entity<Class>()
                .HasOne(c => c.Group)
                .WithMany(g => g.Classes)
                .HasForeignKey(c => c.GroupId);

            modelBuilder.Entity<Class>()
                .HasOne(c => c.User)
                .WithMany(u => u.Classes)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.ForkSchedule)
                .WithMany()
                .HasForeignKey(s => s.ForkScheduleId)
                .OnDelete(DeleteBehavior.Restrict);  // Avoid circular delete cascade

            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Group)
                .WithMany(g => g.Schedules)
                .HasForeignKey(s => s.GroupId);

            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.User)
                .WithMany(u => u.Schedules)
                .HasForeignKey(s => s.UserId);
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
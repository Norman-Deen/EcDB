using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using EcDB.Entities;
using EcDB.Data.Config;
using System.Reflection.Emit;

namespace EcDB.Data
{
    public class AppSettings : DbContext
    {

        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<CoursePlan> CoursePlans { get; set; }
        public DbSet<Student> Students { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("AppSettings.json")
                .Build();

            var ConnectionString = configuration.GetSection("constr").Value;

            optionsBuilder.UseSqlServer(ConnectionString)
              .EnableSensitiveDataLogging();

        }


  protected override void OnModelCreating(ModelBuilder modelBuilder)
{
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppSettings).Assembly);

            modelBuilder.Entity<School>()
                .Property(s => s.SchoolId)
                .ValueGeneratedOnAdd();

            // In your School entity configuration
            modelBuilder.Entity<School>()
                .HasMany(s => s.Courses)
                .WithOne(c => c.School)
                .HasForeignKey(c => c.SchoolId)
                .IsRequired()
                .OnDelete(DeleteBehavior.SetNull); // Cascade deletion of associated courses

            modelBuilder.Entity<Instructor>()
                .Property(i => i.InstructorId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.Course)
                .WithMany(c => c.Instructors)
                .HasForeignKey(i => i.CourseId)
                .IsRequired(false)  // Allows CourseId to be nullable
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.School)
                .WithMany(s => s.Instructors)
                .HasForeignKey(i => i.SchoolId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull); // SetNull instead of the default DeleteBehavior.Restrict

            modelBuilder.Entity<Student>()
                .Property(s => s.StudentId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Course)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.CourseId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.School)
                .WithMany(sc => sc.Students)
                .HasForeignKey(s => s.SchoolId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);


            modelBuilder.Entity<Course>()
                .HasOne(c => c.School)
                .WithMany(s => s.Courses)
                .HasForeignKey(c => c.SchoolId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull); // or specify ON DELETE NO ACTION based on your requirements

            modelBuilder.Entity<CoursePlan>()
                .Property(cP => cP.CoursePlanId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<CoursePlan>()
                .HasOne(cp => cp.Course)
                .WithMany(c => c.CoursePlans)
                .HasForeignKey(cp => cp.CourseId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

        }

    }
}




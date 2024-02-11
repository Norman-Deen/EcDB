using EcDB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace EcDB.Data.Config
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(x => x.InstructorId);
            builder.Property(x => x.InstructorId).ValueGeneratedNever();

            builder.Property(x => x.Name).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.Email).HasColumnType("VARCHAR").HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.Phone).HasColumnType("VARCHAR").HasMaxLength(20).IsRequired(false);
            builder.Property(x => x.Address).HasColumnType("VARCHAR").HasMaxLength(100).IsRequired(false);



            builder.HasData(LoadInstructors());
        }

        private static List<Instructor> LoadInstructors()
        {
            return new List<Instructor>
            {
                new Instructor { InstructorId = 1, Name = "Hans Mattin-Lassei", Email = "hans@example.com", Phone = "123-456-7890", Address = "123 Main St", SchoolId = 1, CourseId = 1 },
                new Instructor { InstructorId = 2, Name = "Tommy Mattin-Lassei", Email = "tommy@example.com", Phone = "987-654-3210", Address = "456 Oak Ave", SchoolId = 2, CourseId = 2 },
                new Instructor { InstructorId = 3, Name = "Joakim Lindh", Email = "joakim@example.com", Phone = "555-123-4567", Address = "789 Elm Blvd", SchoolId = 3, CourseId = 3 },
                new Instructor { InstructorId = 4, Name = "Robert Tublén", Email = "robert@example.com", Phone = "777-888-9999", Address = "101 Pine St", SchoolId = 4, CourseId = 4 },
                new Instructor { InstructorId = 5, Name = "Therese Lidbom", Email = "therese@example.com", Phone = "111-222-3333", Address = "202 Cedar Ave", SchoolId = 5, CourseId = 5 },
                new Instructor { InstructorId = 6, Name = "Adam Olaso", Email = "adam@example.com", Phone = "444-555-6666", Address = "303 Birch Blvd", SchoolId = 1, CourseId = 1 },
                new Instructor { InstructorId = 7, Name = "Morgan Kostav", Email = "morgan@example.com", Phone = "999-888-7777", Address = "404 Maple St", SchoolId = 2, CourseId = 2 },
                new Instructor { InstructorId = 8, Name = "Burim Fatit", Email = "burim@example.com", Phone = "333-222-1111", Address = "505 Oak Ave", SchoolId = 3, CourseId = 3 },
                new Instructor { InstructorId = 9, Name = "Jorjan Moland", Email = "jorjan@example.com", Phone = "666-777-8888", Address = "606 Pine St", SchoolId = 4, CourseId = 4 },
                new Instructor { InstructorId = 10, Name = "Balushi Jeto", Email = "balushi@example.com", Phone = "123-456-7890", Address = "707 Elm Blvd", SchoolId = 5, CourseId = 5 }

            };
        }
    }
}

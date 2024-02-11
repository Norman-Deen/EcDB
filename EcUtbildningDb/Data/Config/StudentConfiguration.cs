// StudentConfiguration.cs
using System.Collections.Generic;
using EcDB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcDB.Data.Config
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.StudentId);


            builder.Property(x => x.Name).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.Email).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.Phone).HasColumnType("VARCHAR").HasMaxLength(15); // Adjust the length as needed
            builder.Property(x => x.Address).HasColumnType("VARCHAR").HasMaxLength(255).IsRequired(false); // Adjust the length as needed

         

            // INSERT DATA  
            builder.HasData(LoadStudents());
        }



        private static List<Student> LoadStudents()
        {
            return new List<Student>
            {
                new Student { StudentId = 1, Name = "Nour Altinawi", Email = "nour.altinawi@example.com", Phone = "123456789", Address = "Address 1", SchoolId = 1, Grade = 90, CourseId = 3 },
                new Student { StudentId = 2, Name = "Liam Berg", Email = "liam.berg@example.com", Phone = "987654321", Address = "Address 2", SchoolId = 2, Grade = 80, CourseId = 2 },
                new Student { StudentId = 3, Name = "Olivia Carlsson", Email = "olivia.carlsson@example.com", Phone = "555555555", Address = "Address 3", SchoolId = 3, Grade = 49, CourseId = 4 },
                new Student { StudentId = 4, Name = "Hugo Dahl", Email = "hugo.dahl@example.com", Phone = "123123123", Address = "Address 4", SchoolId = 4, Grade = 85, CourseId = 1 },
                new Student { StudentId = 5, Name = "Amelia Eriksson", Email = "amelia.eriksson@example.com", Phone = "987987987", Address = "Address 5", SchoolId = 5, Grade = 92, CourseId = 5 },
                new Student { StudentId = 6, Name = "Zara Forsberg", Email = "zara.forsberg@example.com", Phone = "777777777", Address = "Address 6", SchoolId = 3, Grade = 45, CourseId = 3 }
            };
        }
    }
}

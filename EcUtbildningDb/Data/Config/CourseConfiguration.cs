using EcDB.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(x => x.CourseId);
        builder.Property(x => x.CourseId).ValueGeneratedOnAdd();

        builder.Property(x => x.CourseName).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();
        builder.Property(x => x.Description).HasColumnType("TEXT");
        builder.Property(x => x.Duration).IsRequired();

        // Add SchoolId property configuration
        builder.Property(x => x.SchoolId);

        builder.HasData(LoadCourses());
    }

    private static List<Course> LoadCourses()
    {
        // Add SchoolId for each course
        return new List<Course>
        {
           new Course { CourseId = 1, CourseName = "Front End", Duration = "1 yr", Description = "HTML, CSS, JS for UI. React, Vue.js exploration.", SchoolId = 1 },
            new Course { CourseId = 2, CourseName = "Data Scientist", Duration = "2 yrs", Description = "Node.js, Django, SQL, NoSQL, API design.", SchoolId = 2 },
            new Course { CourseId = 3, CourseName = "Full Stack", Duration = "3 yrs", Description = "Front-end and back-end mastery. Web app development.", SchoolId = 3 },
            new Course { CourseId = 4, CourseName = "BIM", Duration = "1 yr", Description = "Building Information Modeling basics.", SchoolId = 4 },
            new Course { CourseId = 5, CourseName = "IT", Duration = "1 yr", Description = "IT essentials, network admin, cybersecurity.", SchoolId = 5 }

        };
    }
}

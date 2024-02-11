using EcDB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace EcDB.Data.Config
{
    public class CoursePlanConfiguration : IEntityTypeConfiguration<CoursePlan>
    {
        public void Configure(EntityTypeBuilder<CoursePlan> builder)
        {
            builder.HasKey(x => x.CoursePlanId);
            builder.Property(x => x.CoursePlanId).ValueGeneratedNever();

            builder.Property(x => x.CoursePlanDetails)
                   .HasColumnType("VARCHAR").HasMaxLength(2000)
                   .IsRequired();

            builder.Property(x => x.CourseId).IsRequired();

            // Set the relationship to the Course object
            builder.HasOne(x => x.Course)
                   .WithMany()  // WithMany call has been removed here
                   .HasForeignKey(x => x.CourseId)
                   .IsRequired();

            // Add data
            builder.HasData(LoadCoursePlans());
        }

        private static List<CoursePlan> LoadCoursePlans()
        {
            return new List<CoursePlan>
            {

              new CoursePlan { CoursePlanId = 1, CoursePlanDetails =
                    "Frontend Dev 1, Frontend Dev 2, Exam Project, HTML/CSS, JS 1, JS 2, JS 3, LIA Frontend Dev, Agile Methods, UX Design", CourseId = 1 },

              new CoursePlan { CoursePlanId = 2, CoursePlanDetails =
                    "Prep Math; Stats and AI, Python Programming and Stats Analysis, SQL, Business Intelligence, Machine Learning, R Programming, Deep Learning, Python Programming Advanced, Data Science Project, LIA Internship, Thesis", CourseId = 2 },

              new CoursePlan { CoursePlanId = 3, CoursePlanDetails =
                    "Full Stack: 3 years of front-end and back-end mastery, focusing on web app development.", CourseId = 3 },

              new CoursePlan { CoursePlanId = 4, CoursePlanDetails =
                    "BIM Basics: Learn the fundamentals of Building Information Modeling in a year-long course.", CourseId = 4 },

              new CoursePlan { CoursePlanId = 5, CoursePlanDetails =
                    "IT Essentials: Essentials of Information Technology in a one-year course, covering network admin and cybersecurity.", CourseId = 5 },

            };
        }
    }
}

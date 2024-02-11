using EcDB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace EcDB.Data.Config
{
    public class SchoolConfiguration : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.HasKey(x => x.SchoolId);
            builder.Property(x => x.SchoolId).ValueGeneratedNever();

            builder.Property(x => x.SchoolName).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Address).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();
            builder.Property(x => x.PhoneNumber).HasColumnType("VARCHAR").HasMaxLength(15).IsRequired();
            builder.Property(x => x.Website).HasColumnType("VARCHAR").HasMaxLength(255).IsRequired();

            builder.ToTable("Schools");

            // Add data
            builder.HasData(LoadSchool());
        }

        private static List<School> LoadSchool()
        {
            return new List<School>
            {
                new School { SchoolId = 1, SchoolName = "EC Utbildning-HA", Address = "Halmstad", PhoneNumber = "123-456-7890", Website = "http://www.ecutbildning-ha.com" },
                new School { SchoolId = 2, SchoolName = "EC Utbildning-MA", Address = "Malmö", PhoneNumber = "987-654-3210", Website = "http://www.ecutbildning-ma.com" },
                new School { SchoolId = 3, SchoolName = "EC Utbildning-GO", Address = "Göteborg", PhoneNumber = "555-123-4567", Website = "http://www.ecutbildning-go.com" },
                new School { SchoolId = 4, SchoolName = "EC Utbildning-OR", Address = "Örebro", PhoneNumber = "777-888-9999", Website = "http://www.ecutbildning-or.com" },
                new School { SchoolId = 5, SchoolName = "EC Utbildning-ST", Address = "Stockholm", PhoneNumber = "111-222-3333", Website = "http://www.ecutbildning-st.com" }
            };
        }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcDB.Entities
{
    public class School
    {
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();

        public ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();


        // Add this navigation property for Students
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}

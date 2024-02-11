namespace EcDB.Entities
{
    public class Instructor
    {
        public int InstructorId { get; set; } 
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }

        // Navigation properties to other objects
        public int? SchoolId { get; set; } // A property that indicates the school to which the teacher belongs

        public int? CourseId { get; set; } // A property that indicates the course taught by the instructor

        public Course Course { get; set; } // Represents the course taught by the teacher
        public School School { get; set; } //Represents the school to which the teacher belongs


    }
}

namespace EcDB.Entities
{
    public class Student
    {
        public int? StudentId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; } 
        public int? Grade { get; set; }

        public int? CourseId { get; set; } // A property that indicates the course the student is taking
        public int? SchoolId { get; set; } // A property indicating which school the student belongs to (now allows null)

        // Navigation properties to other objects
        public Course Course { get; set; } // Represents the course the student is pursuing
        public School School { get; set; } // Represents the school to which the student belongs

        public ICollection<CoursePlan> StudentGrades { get; set; } = new List<CoursePlan>();
    }
}



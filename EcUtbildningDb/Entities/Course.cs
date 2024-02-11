namespace EcDB.Entities;

public class Course
{
    public int CourseId { get; set; }
    public string? CourseName { get; set; }
    public string? Duration { get; set; }
    public string? Description { get; set; }

    public int? SchoolId { get; set; } 
    public School School { get; set; } 


    // Add this navigation property
    public List<CoursePlan> CoursePlans { get; set; }


    public ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
    public ICollection<Student> Students { get; set; } = new List<Student>();
}


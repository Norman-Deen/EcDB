namespace EcDB.Entities
{
    public class CoursePlan
    {
        public int CoursePlanId { get; set; } 
        public string CoursePlanDetails { get; set; } 
        public int? CourseId { get; set; }

        // Navigation property
        public Course Course { get; set; }
    }
}

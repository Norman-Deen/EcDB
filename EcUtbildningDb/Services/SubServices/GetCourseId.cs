using EcDB.Data;
using EcDB.Repository;
using System;

namespace EcDB.Services.SubServices
{
    public class GetCourseId
    {
        private readonly AppSettings _context;
        private readonly CourseRepository _courseRepository;

        public GetCourseId(AppSettings context, CourseRepository CourseRepository)
        {
            // _context = context;
            _courseRepository = CourseRepository;
        }

        public bool TryGetCourseId(out int CourseId)
        {
            try
            {
                // Display the list of Courses
                Console.WriteLine();
                Console.WriteLine("Select Courses:");
                _courseRepository.GetAllmini();
                Console.WriteLine();
                Console.Write("Enter Course Id: ");
                int.TryParse(Console.ReadLine(), out CourseId);

                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred while fetching course details.");
                CourseId = 0;
                return false;
            }
        }
    }
}

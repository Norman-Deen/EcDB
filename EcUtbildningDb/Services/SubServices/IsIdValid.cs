using EcDB.Data;
using System.Linq;

namespace EcDB.Services.SubServices
{
    internal class IsIdValid
    {
        private readonly AppSettings _context;

        public IsIdValid(AppSettings context)
        {
            _context = context;
        }

        public bool isIdValid(int schoolId, string searchType)
        {
            switch (searchType)
            {
                case "School":
                    // Retrieve available school IDs from the database or another source
                    var availableSchoolIds = _context.Schools.Select(s => s.SchoolId).ToList();
                    

                    // Check if the entered school ID is in the list of available IDs
                    return availableSchoolIds.Contains(schoolId);

                case "Course":
                    // Retrieve available school IDs from the database or another source
                    var IsCourseIdValid = _context.Courses.Select(s => s.CourseId).ToList();

                    // Check if the entered school ID is in the list of available IDs
                    return IsCourseIdValid.Contains(schoolId);
                    

                default:
                    return false;
            }
        }
    }
}

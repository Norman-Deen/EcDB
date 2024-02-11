using EcDB.Data;
using EcDB.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EcDB.Services
{
    public class ValidationService
    {
        private readonly AppSettings _context;

        public ValidationService(AppSettings context)
        {
            _context = context; // Initialize the _context field with the provided AppSettings object
        }

        public bool CheckIfExists<T>(T searchMe, string searchType)
        {
            string _searchMe = searchMe?.ToString();

            if (!string.IsNullOrEmpty(_searchMe))
            {
                switch (searchType)
                {
                    case "Student":
                        return _context.Students.Any(s => s.Email == _searchMe);

                    case "Course":

                        if (int.TryParse(searchMe?.ToString(), out int CourseId))
                        {
                            return _context.Courses.Any(c => c.CourseId == CourseId);
                        }
                        return false;

                    case "Instructor":
                        return _context.Instructors.Any(i => i.Email == _searchMe);

                    case "School":
                        // Assuming SchoolId is an integer

                        if (int.TryParse(searchMe?.ToString(), out int schoolId))
                        {
                            return _context.Schools.Any(s => s.SchoolId == schoolId);
                        }

                        return false;
                }
            }

            return false;
        }
    }
}

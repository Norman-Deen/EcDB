using EcDB.Data;
using EcDB.IRepository;
using EcDB.Repository;
using System;

namespace EcDB.Services.SubServices
{
    internal class GetSchoolId
    {
        private readonly AppSettings _context;
        private readonly SchoolRepository _schoolRepository;
        private readonly IStudentRepository _studentRepository;

        public GetSchoolId(AppSettings context, SchoolRepository schoolRepository)
        {
            _context = context;
            _schoolRepository = schoolRepository;
        }

        public bool TryGetSchoolId(out int schoolId)
        {
            try
            {
                // Display the list of schools
                Console.WriteLine();
                ConsoleColors.PrintColoredLine("Select Schools:", ConsoleColor.DarkGray);
                _schoolRepository.GetAllmini();  // Ensure _schoolRepository is not null here
                Console.WriteLine();
                ConsoleColors.PrintColoredLine("Enter School Id: ", ConsoleColor.DarkGray);
                int.TryParse(Console.ReadLine(), out schoolId);

                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred while fetching school details.");
                schoolId = 0;
                return false;
            }
        }
    }
}

using EcDB.Data;
using EcDB.IRepository;
using EcDB.Repository;
using System;

namespace EcDB.Services.SubServices
{
    internal class GetInstructorEmail
    {
        private readonly AppSettings _context;
        private readonly InstructorRepository _instructorRepository;

        internal GetInstructorEmail(AppSettings context, InstructorRepository instructorRepository)
        {
            _context = context;
            _instructorRepository = instructorRepository;
        }

        internal bool TryGetInstructorEmail(out string instructorEmail)
        {
            try
            {
                // Display the list of instructors
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Select Instructors:\n");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                _instructorRepository.GetAllmini();
                Console.WriteLine();
                Console.ResetColor();
                Console.Write("Enter Instructor Email: ");
                instructorEmail = Console.ReadLine();
               

                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred while fetching instructor details.");
                instructorEmail = string.Empty;
                return false;
            }
        }
    }
}

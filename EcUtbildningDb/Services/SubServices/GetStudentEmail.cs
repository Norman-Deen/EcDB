using EcDB.Data;
using System;
using System.Linq;

namespace EcDB.Services.SubServices
{
    internal class GetStudentEmail
    {
        private readonly AppSettings _context;
        private readonly StudentService _studentService;

        internal GetStudentEmail(AppSettings context, StudentService studentService)
        {
            _context = context;
            _studentService = studentService;
        }

        internal bool TryGetStudentEmail(out string studentEmail)
        {
            try
            {
                // Display the list of students
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Select Students:");
                _studentService.GetAllmini();
                Console.WriteLine();
                Console.Write("Enter Student Email: ");
                studentEmail = Console.ReadLine();

                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred while fetching student details.");
                studentEmail = string.Empty;
                return false;
            }
        }
    }
}

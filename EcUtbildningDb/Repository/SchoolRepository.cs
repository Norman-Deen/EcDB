using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using EcDB.Data;
using EcDB.IRepository;
using EcDB.Entities;
using EcDB.Services.SubServices;
using EcDB.Services;

namespace EcDB.Repository;

internal class SchoolRepository : ISchoolRepository
{
    private readonly AppSettings _context;
    private readonly ValidationService _validationService;
    private readonly GetSchoolId _getSchoolId;
    public SchoolRepository(AppSettings context)
    {
        _context = context;
        // Initialize ValidationService using the provided context
        _validationService = new ValidationService(_context);
        // Pass an instance of SchoolRepository as the second parameter
        _getSchoolId = new GetSchoolId(_context, this);

    }


    public bool GetAll()
    {
        try
        {
            Console.Clear();
            ConsoleColors.PrintColoredLine("--------All Schools--------\n", ConsoleColor.DarkGray);
            var schools = _context.Schools.ToList();

            foreach (var school in schools)
            {
                Console.WriteLine($"ID:{school.SchoolId}\nName: \"{school.SchoolName}\"");
                Console.WriteLine();
            }
            Console.WriteLine();
            ConsoleColors.PrintColoredLine("Press space to return to main menu.", ConsoleColor.DarkGray);
            Console.ReadKey();
            Console.Clear();

            // Return true to indicate success
            return true;

        }
        catch (Exception)
        {
            Console.WriteLine("An error occurred while fetching schools.\n");
            // Return false to indicate failure
            return false;
        }
    }


    public bool GetAllmini()
    {
        try
        {
            var schools = _context.Schools.ToList();

            foreach (var school in schools)
            {
                Console.WriteLine($"ID:\"{school.SchoolId}\" \"{school.SchoolName}\"");
            }
            return true;
        }
        catch (Exception)
        {
            return false; // Indicate failure
        }
    }


    public bool GetBy()
    {
        try
        {
            int schoolId;

            do
            {
                Console.Clear();
                GetSchoolId getSchoolIdInstance = new GetSchoolId(_context, this);
                bool success = getSchoolIdInstance.TryGetSchoolId(out schoolId);

                if (!success || !_validationService.CheckIfExists(schoolId, "School"))
                {
                    Console.WriteLine();
                    ConsoleColors.PrintColoredLine("Invalid input or school not found. Please try again.\n", ConsoleColor.Red);
                    Console.ReadKey();
                    continue; // Continue to the next iteration of the loop
                }
                else
                {
                    break; // Break the loop if a valid school ID is obtained
                }

            } while (true);

            // At this point, 'schoolId' contains a valid school ID
            int xId = schoolId;


            // Find the existing school by SchoolId and include related entities separately
            School existingSchool = _context.Schools
                .Include(s => s.Instructors)
                .Include(s => s.Courses)
                .FirstOrDefault(s => s.SchoolId == xId);

            if (existingSchool != null)
            {
                // Display school details
                Console.Clear();
                ConsoleColors.PrintColoredLine("School Details:\n", ConsoleColor.DarkGray);
                Console.WriteLine($"ID: {existingSchool.SchoolId}");
                Console.WriteLine($"School Name: \"{existingSchool.SchoolName}\"");
                Console.WriteLine($"Address: {existingSchool.Address}");
                Console.WriteLine($"Phone: {existingSchool.PhoneNumber}");
                Console.WriteLine($"Website: {existingSchool.Website}\n\n");

                // Display associated Instructors
                if (existingSchool.Instructors != null && existingSchool.Instructors.Any())
                {
                    Console.WriteLine("Instructors:\n");
                    foreach (var instructor in existingSchool.Instructors)
                    {
                        Console.WriteLine($" - {instructor.Name ?? "N/A"}");
                    }
                }
                else
                {
                    Console.WriteLine("Instructors: N/A\n");
                }
                Console.WriteLine();

                // Display associated Courses
                if (existingSchool.Courses != null && existingSchool.Courses.Any())
                {
                    Console.WriteLine("Courses:\n");
                    foreach (var course in existingSchool.Courses)
                    {
                        Console.WriteLine($" - {course.CourseName ?? "N/A"}");
                    }
                }
                else
                {
                    Console.WriteLine("Courses: N/A\n");
                }
                Console.WriteLine();
                ConsoleColors.PrintColoredLine("Press any key to return to the main menu.", ConsoleColor.DarkGray);
                Console.ReadKey();

                return true; // School details displayed
            }
            else
            {
                Console.WriteLine("School not found.");
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while fetching school details: {ex.Message}\n");
            // Return false to indicate failure
            return false;
        }
    }


    public bool Create()
    {

        try
        {
            InputRead(out string SchoolName, out string Address, out string PhoneNumber, out string Website);

            School newSchool = new School()
            {
                SchoolName = SchoolName,
                Address = Address,
                PhoneNumber = PhoneNumber,
                Website = Website,
            };

            _context.Schools.Add(newSchool);
            _context.SaveChanges();

            Console.Clear();
            Console.WriteLine($"School '{newSchool.SchoolName}' created successfully.\n");
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
            Console.Clear();

            return true;
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine("An error occurred while creating the new school:\n" + ex.Message);

            if (ex.InnerException != null)
            {
                Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
            }

            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
            Console.Clear();
            return false;
        }
    }


    public bool Update()
    {
        try
        {
            int schoolId;

            do
            {
                Console.Clear();
                GetSchoolId getSchoolIdInstance = new GetSchoolId(_context, this);
                bool success = getSchoolIdInstance.TryGetSchoolId(out schoolId);

                if (!success || !_validationService.CheckIfExists(schoolId, "School"))
                {
                    Console.WriteLine();
                    ConsoleColors.PrintColoredLine("Invalid input or school not found. Please try again.\n", ConsoleColor.Red);
                    Console.ReadKey();
                    continue; // Continue to the next iteration of the loop
                }
                else
                {
                    break; // Break the loop if a valid school ID is obtained
                }

            } while (true);

        


            // Find the existing school by SchoolId
            School existingSchool = _context.Schools.FirstOrDefault(s => s.SchoolId == schoolId);

            // Use the InputRead method to update other variables
            InputRead(out string SchoolName, out string Address, out string PhoneNumber, out string Website);

            // Update the properties with the new values
            existingSchool.SchoolName = SchoolName;
            existingSchool.PhoneNumber = PhoneNumber;
            existingSchool.Address = Address;
            existingSchool.Website = Website;

            // Save changes to the database
            _context.SaveChanges();

            Console.Clear();
            Console.WriteLine($"School with ID: '{schoolId}' Updated successful\n");
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
            Console.Clear();

            return true; // Update successful
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return false; // Error occurred
        }
    }



    public bool Delete()
    {


        try
        {
            int schoolId;
            do
            {
                Console.Clear();
                GetSchoolId getSchoolIdInstance = new GetSchoolId(_context, this);
                bool success = getSchoolIdInstance.TryGetSchoolId(out schoolId);

                if (!success || !_validationService.CheckIfExists(schoolId, "School"))
                {
                    Console.WriteLine();
                    ConsoleColors.PrintColoredLine("Invalid input or school not found. Please try again.\n", ConsoleColor.Red);
                    Console.ReadKey();
                    continue; // Continue to the next iteration of the loop
                }
                else
                {
                    break; // Break the loop if a valid school ID is obtained
                }

            } while (true);

            // At this point, 'schoolId' contains a valid school ID

            // Find the existing school by SchoolId
            School existingSchool = _context.Schools.FirstOrDefault(s => s.SchoolId == schoolId);

            // Update the SchoolId for associated instructors to null or another default value
            var associatedInstructors = _context.Instructors.Where(i => i.SchoolId == schoolId);
            foreach (var instructor in associatedInstructors)
            {
                instructor.SchoolId = null; // or another default value
            }

            // Update the SchoolId for associated students to null
            var associatedStudents = _context.Students.Where(st => st.SchoolId == schoolId);
            foreach (var student in associatedStudents)
            {
                student.SchoolId = null; // or another default value
            }

            // Update the SchoolId for associated courses to null
            var associatedCourses = _context.Courses.Where(c => c.SchoolId == schoolId);
            foreach (var course in associatedCourses)
            {
                course.SchoolId = null; // or another default value
            }

            // Perform the deletion without confirmation
            _context.Schools.Remove(existingSchool);

            _context.SaveChanges();

            Console.Clear();
            Console.WriteLine($"School with ID: '{schoolId}' deleted successfully.\n");
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
            Console.Clear();

            return true; // Deletion successful
        }
        catch (DbUpdateException ex)
        {
            Console.Clear();
            Console.WriteLine($"Database update error: {ex.Message}");

            if (ex.InnerException is SqlException sqlException)
            {
                Console.WriteLine($"SQL Server error code: {sqlException.Number}");
                Console.WriteLine($"SQL Server error message: {sqlException.Message}");
            }

            Console.WriteLine("\nPress any key to return to the main menu.");
            Console.ReadKey();
            Console.Clear();
            return false; // Error occurred during database update
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Error: {ex.Message}\n");
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
            Console.Clear();
            throw; // Optionally, rethrow the exception for further analysis
        }
    }



    public bool InputRead(out string SchoolName, out string Address, out string PhoneNumber, out string Website)
    {
        try
        {
            Console.Clear();

            Console.Write("Enter school name: ");
            SchoolName = Console.ReadLine();
            Console.Write("Enter school address: ");
            Address = Console.ReadLine();
            Console.Write("Enter school phone number: ");
            PhoneNumber = Console.ReadLine();
            Console.Write("Enter school website: ");
            Website = Console.ReadLine();

            return true;
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine("An error occurred while reading input:\n" + ex.Message);
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
            Console.Clear();

            SchoolName = Address = PhoneNumber = Website = string.Empty;
            return false;
        }
    }


}

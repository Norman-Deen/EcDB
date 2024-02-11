using EcDB.Entities;
using EcDB.IRepository;
using EcDB.Services.SubServices;
using EcDB.Services;
using Microsoft.EntityFrameworkCore;
using EcDB.Data;

namespace EcDB.Repository;

internal class InstructorRepository : IInstructorRepository
{
    private readonly AppSettings _context;
    private readonly ValidationService _validationService;
    private readonly CourseService _courseService;
    private readonly SchoolRepository _schoolRepository;
    private readonly CourseRepository _courseRepository;
    public InstructorRepository(AppSettings context)
    {
        _context = context;
        _validationService = new ValidationService(context);
        _schoolRepository = new SchoolRepository(context);
        _courseRepository = new CourseRepository(context);  // Initialize _courseRepository
    }


    public bool GetAll()
    {
        try
        {
            var instructors = _context.Instructors
                .Include(i => i.School)
                .Include(i => i.Course)
                .ToList();

            Console.Clear();
            Console.WriteLine("------Instructors------\n");

            if (instructors.Any())
            {
                foreach (var instructor in instructors)
                {
                    Console.WriteLine($"Name: {instructor.Name}");
                    Console.WriteLine($"Email: {instructor.Email ?? "N/A"}");
                    // Uncomment and customize additional details if needed
                    // Console.WriteLine($"Phone: {instructor.Phone ?? "N/A"}");
                    // Console.WriteLine($"School: {instructor.School?.SchoolName ?? "N/A"}");
                    // Console.WriteLine($"Course: {instructor.Course?.CourseName ?? "N/A"}");
                    Console.WriteLine();
                }

                Console.WriteLine("Press any key to return to the main menu.");
                Console.ReadKey();
                Console.Clear();

                return true; // Instructors found
            }
            else
            {
                Console.WriteLine("No instructors found.\n");
                Console.WriteLine("Press any key to return to the main menu.");
                Console.ReadKey();
                Console.Clear();

                return false; // No instructors found
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return false; // Error occurred
        }
    }



    public bool GetAllmini()
    {
        try
        {
            var instructors = _context.Instructors.ToList();

            foreach (var instructor in instructors)
            {
                Console.WriteLine($"[Email]: '{instructor.Email}'   [Name]: '{instructor.Name}'\n");
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
            string instructorEmail;

            do
            {
                Console.Clear();
                InstructorRepository instructorRepository = new InstructorRepository(_context);
                GetInstructorEmail getInstructorEmailInstance = new GetInstructorEmail(_context, instructorRepository);
                bool success = getInstructorEmailInstance.TryGetInstructorEmail(out instructorEmail);

                if (!success || !_validationService.CheckIfExists(instructorEmail, "Instructor"))
                {
                    Console.WriteLine();
                    ConsoleColors.PrintColoredLine("Invalid input or Instructor email not found. Please try again.\n", ConsoleColor.Red);
                    Console.ReadKey();
                    continue; // Continue to the next iteration of the loop
                }
                else
                {
                    break; // Break the loop if a valid instructor email is obtained
                }

            } while (true);

            var instructor = _context.Instructors
                .Include(i => i.School)
                .Include(i => i.Course)
                .FirstOrDefault(i => i.Email == instructorEmail);

            if (instructor != null)
            {
                Console.Clear();
                ConsoleColors.PrintColoredLine("---Instructor info---\n\n\n", ConsoleColor.DarkGray);
                Console.WriteLine($"Name: {instructor.Name}");
                Console.WriteLine($"Email: {instructor.Email ?? "N/A"}");
                Console.WriteLine($"Phone: {instructor.Phone ?? "N/A"}");
                Console.WriteLine($"Address: {instructor.Address ?? "N/A"}\n");
                Console.WriteLine($"School: {instructor.School?.SchoolName ?? "N/A"}");
                Console.WriteLine($"Course: {instructor.Course?.CourseName ?? "N/A"}\n\n");
                ConsoleColors.PrintColoredLine("Press any key to return to the main menu.", ConsoleColor.DarkGray);
                Console.ReadKey();
                Console.Clear();

                return true; // Instructor found
            }
            else
            {
                Console.WriteLine("Instructor not found.");
                Console.WriteLine("Press any key to return to the main menu.");
                Console.ReadKey();
                Console.Clear();

                return false; // Instructor not found
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return false; // Error occurred
        }
    }



    public bool Create()
    {
        try
        {
            InputRead(out string Name, out string Email, out string Phone, out string Address, out int SchoolId, out int CourseId);

            // Create an instance of IsIdValid
            IsIdValid isIdValidInstance = new IsIdValid(_context);

            // Check if the instructor with the given Email already exists
            if (_validationService.CheckIfExists(Email, "Instructor"))
            {
                Console.Clear();
                Console.WriteLine($"Error: An instructor with the Email '{Email}' already exists.\n");
                Console.WriteLine("Press any key to return to the main menu.");
                Console.ReadKey();
                Console.Clear();

                return true; // Instructor found
            }
            else
            {
                // Proceed with creating a new instructor
                Instructor newInstructor = new Instructor()
                {
                    Name = Name,
                    Email = Email,
                    Phone = Phone,
                    Address = Address,
                    SchoolId = SchoolId,
                    CourseId = CourseId
                };

                _context.Instructors.Add(newInstructor);
                _context.SaveChanges();

                Console.Clear();
                Console.WriteLine($"Instructor '{newInstructor.Name}' created successfully.\n");
                Console.WriteLine("Press any key to return to the main menu.");
                Console.ReadKey();
                Console.Clear();

                return false; // Instructor not found
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return false; // Error occurred
        }
    }



    public bool Update()
    {
        try
        {
            string instructorEmail;

            do
            {
                // Pass _instructorRepository as a parameter to the GetInstructorEmail constructor
                InstructorRepository instructorRepository = new InstructorRepository(_context);
                GetInstructorEmail getInstructorEmailInstance = new GetInstructorEmail(_context, instructorRepository);
                bool success = getInstructorEmailInstance.TryGetInstructorEmail(out instructorEmail);
                string newEmail = instructorEmail;

                if (!success || !_validationService.CheckIfExists(instructorEmail, "Instructor"))
                {
                    Console.WriteLine();
                    ConsoleColors.PrintColoredLine("Invalid input or Instructor email not found. Please try again.\n", ConsoleColor.Red);
                    Console.ReadKey();
                    continue; // Continue to the next iteration of the loop
                }
                else
                {
                    break; // Break the loop if a valid school ID is obtained
                }

            } while (true);


            // Find the existing instructor by InstructorEmail
            Instructor existingInstructor = _context.Instructors.FirstOrDefault(i => i.Email == instructorEmail);

            // Use the InputRead method to update other variables
            InputRead(out string Name, out string Email, out string Phone, out string Address, out int SchoolId, out int CourseId);

            // Check if the instructor with the given Email already exists
            if (_validationService.CheckIfExists(Email, "Instructor"))
            {
                Console.Clear();
                Console.WriteLine($"Error: An instructor with the Email '{Email}' already exists.\n");
                Console.WriteLine("Press any key to return to the main menu.");
                Console.ReadKey();
                Console.Clear();

                return true; // Instructor found
            }
            else
            {
                // Update the properties with the new values
                existingInstructor.Name = Name;
                existingInstructor.Email = Email;
                existingInstructor.Phone = Phone;
                existingInstructor.Address = Address;
                existingInstructor.SchoolId = SchoolId;
                existingInstructor.CourseId = CourseId;

                // Save changes to the database
                _context.SaveChanges();
                Console.Clear();
                Console.WriteLine($"Instructor with oldEmail: {instructorEmail} Updated successfully\n");
                Console.WriteLine("Press any key to return to the main menu.");
                Console.ReadKey();
                Console.Clear();

                return true; // Update successful

            }
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Error updating instructor: {ex.Message}\n");

            // Print inner exception details
            if (ex.InnerException != null)
            {
                Console.WriteLine($"Inner Exception: {ex.InnerException.Message}\n");
            }

            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
            Console.Clear();

            return false; // Update failed
        }

    }



    public bool Delete()
    {
        try
        {
            string instructorEmail;

            do
            {
                InstructorRepository instructorRepository = new InstructorRepository(_context);
                GetInstructorEmail getInstructorEmailInstance = new GetInstructorEmail(_context, instructorRepository);
                bool success = getInstructorEmailInstance.TryGetInstructorEmail(out instructorEmail);

                if (!success || !_validationService.CheckIfExists(instructorEmail, "Instructor"))
                {
                    Console.WriteLine();
                    ConsoleColors.PrintColoredLine("Invalid input or Instructor email not found. Please try again.\n", ConsoleColor.Red);
                    Console.ReadKey();
                    continue; // Continue to the next iteration of the loop
                }
                else
                {
                    break; // Break the loop if a valid instructor email is obtained
                }

            } while (true);

            var existingInstructor = _context.Instructors.FirstOrDefault(i => i.Email == instructorEmail);

            if (existingInstructor != null)
            {
                _context.Instructors.Remove(existingInstructor);
                _context.SaveChanges();
                Console.Clear();
                Console.WriteLine($"Instructor with Email '{instructorEmail}' deleted successfully.\n");
                Console.WriteLine("Press any key to return to the main menu.");
                Console.ReadKey();
                Console.Clear();

                return true; // Deletion successful
            }
            else
            {
                Console.WriteLine($"Instructor with Email '{instructorEmail}' not found.");
                Console.WriteLine("Press any key to return to the main menu.");
                Console.ReadKey();
                Console.Clear();

                return false; // Instructor not found
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return false; // Error occurred
        }
    }



    public bool InputRead(out string Name, out string Email, out string Phone, out string Address, out int SchoolId, out int CourseId)
    {
        try
        {
            Console.Clear();
            Console.Write("Enter instructor name: ");
            Name = Console.ReadLine();
            Console.Write("Enter instructor Email: ");
            Email = Console.ReadLine();
            Console.Write("Enter instructor phone: ");
            Phone = Console.ReadLine();
            Console.Write("Enter instructor address: ");
            Address = Console.ReadLine();


            int schoolId;

            do
            {
                // Pass the correct repository type to the GetSchoolId constructor
                GetSchoolId getSchoolIdInstance = new GetSchoolId(_context, new SchoolRepository(_context));
                bool success = getSchoolIdInstance.TryGetSchoolId(out schoolId);

                if (!success || !_validationService.CheckIfExists(schoolId, "School"))
                {
                    Console.WriteLine();
                    ConsoleColors.PrintColoredLine("Invalid input or school not found. Please try again.\n", ConsoleColor.Red);
                    Console.ReadKey();
                    Console.Clear();
                    continue; // Continue to the next iteration of the loop
                }
                else
                {
                    break; // Break the loop if a valid school ID is obtained
                }

            } while (true);



            SchoolId = schoolId;

            int courseId;

            do
            {
                // Pass the correct repository type to the GetCourseId constructor
                GetCourseId getCourseIdInstance = new GetCourseId(_context, new CourseRepository(_context));
                bool success = getCourseIdInstance.TryGetCourseId(out courseId);

                if (!success || !_validationService.CheckIfExists(courseId, "Course"))
                {
                    Console.WriteLine();
                    ConsoleColors.PrintColoredLine("Invalid input or course not found. Please try again.\n", ConsoleColor.Red);
                    Console.ReadKey();
                    Console.Clear();
                    continue; // Continue to the next iteration of the loop
                }
                else
                {
                    break; // Break the loop if a valid course ID is obtained
                }

            } while (true);


            CourseId = courseId;

            return true;
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine("An error occurred while reading input:\n" + ex.Message);
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
            Console.Clear();
            Name = Email = Phone = Address = String.Empty;
            CourseId = SchoolId = 0;

            return false;
        }
    }


}

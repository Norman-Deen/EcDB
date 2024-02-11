using EcDB.Entities;
using EcDB.Services.SubServices;
using EcDB.Services;
using Microsoft.EntityFrameworkCore;
using EcDB.IRepository;
using EcDB.Data;


namespace EcDB.Repository;

public class StudentRepository : IStudentRepository
{
    private readonly AppSettings _context;
    private readonly ValidationService _validationService;
    private readonly SchoolRepository _schoolRepository;
    private readonly CourseRepository _courseRepository;

    // Create an instance of ValidationService
    public StudentRepository(AppSettings context)
    {
        _context = context;
        _validationService = new ValidationService(context); // Ensure _validationService is initialized
        _schoolRepository = new SchoolRepository(context);
        _courseRepository = new CourseRepository(context);  // Initialize _courseRepository
    }


    public bool Delete()
    {
        try
        {
            string studentEmail;

            do
            {
                Console.Clear();
                IStudentRepository studentRepository = new StudentRepository(_context);
                GetStudentEmail getStudentEmailInstance = new GetStudentEmail(_context, new StudentService(studentRepository, _context));
                bool success = getStudentEmailInstance.TryGetStudentEmail(out studentEmail);

                if (!success || !_validationService.CheckIfExists(studentEmail, "Student"))
                {
                    Console.WriteLine();
                    ConsoleColors.PrintColoredLine("Invalid input or Student not found. Please try again.\n", ConsoleColor.Red);
                    Console.ReadKey();
                    continue; // Continue to the next iteration of the loop
                }
                else
                {
                    break; // Break the loop if a valid school ID is obtained
                }

            } while (true);


            var existingStudent = _context.Students.FirstOrDefault(s => s.Email == studentEmail);
            if (existingStudent != null)
            {
                // Remove the student from the database
                _context.Students.Remove(existingStudent);
                _context.SaveChanges();
                Console.Clear();
                Console.WriteLine("Student deleted successfully.\n");
                Console.WriteLine("Press any key to return to the main menu.");
                Console.ReadKey();
                Console.Clear();
                return true;
            }
            else
            {
                Console.WriteLine("Student not found.");
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return false;
        }
    }




    public bool GetAll()
    {
        try
        {
            var students = _context.Students
                .Include(s => s.School)
                .Include(s => s.Course)
                .ToList();

            Console.Clear();
            Console.WriteLine("-------Students------\n");

            if (students.Any())
            {
                foreach (var student in students)
                {
                    Console.WriteLine($"Email: {student.Email ?? "N/A"}\nName: \"{student.Name}\"");
                    // Console.WriteLine($"Email: {student.Email ?? "N/A"}");
                    // Console.WriteLine($"Phone: {student.Phone ?? "N/A"}");
                    // Console.WriteLine($"School: {student.School?.SchoolName ?? "N/A"}");
                    // Console.WriteLine($"Course: {student.Course?.CourseName ?? "N/A"}");
                    Console.WriteLine();
                }

                Console.WriteLine("Press any key to return to the main menu.");
                Console.ReadKey();
                Console.Clear();

                return true; // Students found
            }
            else
            {
                Console.WriteLine("No students found.\n");
                Console.WriteLine("Press any key to return to the main menu.");
                Console.ReadKey();
                Console.Clear();
                return false; // No students found
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return false; // Error occurred
        }
    }




    public bool GetBy()
    {
        try
        {
            string studentEmail;

            do
            {
                Console.Clear();
                IStudentRepository studentRepository = new StudentRepository(_context);
                GetStudentEmail getStudentEmailInstance = new GetStudentEmail(_context, new StudentService(studentRepository, _context));
                bool success = getStudentEmailInstance.TryGetStudentEmail(out studentEmail);

                if (!success || !_validationService.CheckIfExists(studentEmail, "Student"))
                {
                    Console.WriteLine();
                    ConsoleColors.PrintColoredLine("Invalid input or Student not found. Please try again.\n", ConsoleColor.Red);
                    Console.ReadKey();
                    continue; // Continue to the next iteration of the loop
                }
                else
                {
                    break; // Break the loop if a valid school ID is obtained
                }

            } while (true);

            var student = _context.Students
                    .Include(s => s.School)
                    .Include(s => s.Course)
                    .FirstOrDefault(s => s.Email == studentEmail);

            if (student != null)
            {
                Console.Clear();
                Console.WriteLine($"Name: {student.Name}");
                Console.WriteLine($"Email: {student.Email ?? "N/A"}");
                Console.WriteLine($"Phone: {student.Phone ?? "N/A"}\n");
                Console.WriteLine($"School: {student.School?.SchoolName ?? "N/A"}");
                Console.WriteLine($"Course: {student.Course?.CourseName ?? "N/A"}");

                // Access the Instructor's name through the associated Instructors table
                if (student.Course != null)
                {
                    var instructor = _context.Instructors
                        .FirstOrDefault(i => i.CourseId == student.Course.CourseId);

                    Console.WriteLine($"Instructor: {instructor?.Name ?? "N/A"}");
                }
                else
                {
                    Console.WriteLine("Instructor: N/A");
                }

                Console.WriteLine($"Grade: {student.Grade}\n");
                Console.WriteLine("Press any key to return to the main menu.");
                Console.ReadKey();
                Console.Clear();
                return true; // Student found
            }
            else
            {
                Console.WriteLine("Student not found.");
                Console.WriteLine("Press any key to return to the main menu.");
                Console.ReadKey();
                Console.Clear();
                return false; // Student not found
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
            var students = _context.Students.ToList();

            foreach (var student in students)
            {
                Console.WriteLine($"Name: '{student.Name}' Email: '{student.Email}' ");
            }
            return true;
        }
        catch (Exception)
        {
            return false; // Indicate failure
        }
    }



    public bool Update()
    {

        try
        {
            string studentEmail;

            do
            {
                Console.Clear();
                IStudentRepository studentRepository = new StudentRepository(_context);
                GetStudentEmail getStudentEmailInstance = new GetStudentEmail(_context, new StudentService(studentRepository, _context));
                bool success = getStudentEmailInstance.TryGetStudentEmail(out studentEmail);

                if (!success || !_validationService.CheckIfExists(studentEmail, "Student"))
                {
                    Console.WriteLine();
                    ConsoleColors.PrintColoredLine("Invalid input or Student not found. Please try again.\n", ConsoleColor.Red);
                    Console.ReadKey();
                    continue; // Continue to the next iteration of the loop
                }
                else
                {
                    break; // Break the loop if a valid school ID is obtained
                }

            } while (true);


            // Find the existing student by Email
            Student existingStudent = _context.Students.FirstOrDefault(s => s.Email == studentEmail);

            // Use the InputRead method to get the values
            InputRead(out string Name, out studentEmail, out string Phone, out string Address, out int Grade, out int SchoolId, out int CourseId);

            // Create an instance of IsIdValid
            //  IsIdValid isIdValidInstance = new IsIdValid(_context);

            // Assuming you have an instance of AppSettings named appSettings
            //   AppSettings appSettings = new AppSettings(); // You may need to provide appropriate initialization






            // Update the properties with the new values
            existingStudent.Name = Name;
            existingStudent.Email = studentEmail;
            existingStudent.Phone = Phone;
            existingStudent.Address = Address;
            existingStudent.Grade = Grade;
            existingStudent.SchoolId = SchoolId;
            existingStudent.CourseId = CourseId;

            // Save changes to the database
            _context.SaveChanges();

            Console.Clear();
            Console.WriteLine($"Student with Email: {studentEmail} updated successfully.\n");
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
            Console.Clear();

            return true; // Update successful
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Error updating student: {ex.Message}\n");

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



    public bool Create()
    {
        try
        {
            InputRead(out string Name, out string Email, out string Phone, out string Address, out int Grade, out int SchoolId, out int CourseId);
            Console.Clear();

            if (_validationService.CheckIfExists(Email, "Student"))
            {
                Console.WriteLine();
                ConsoleColors.PrintColoredLine($"An account with the email address {Email} already exists!!. Please use a different email.\n", ConsoleColor.Red);
                Console.ReadKey();
                return true;
            }
            else
            {

                Student newStudent = new Student()
                {
                    Name = Name,
                    Email = Email,
                    Phone = Phone,
                    Address = Address,
                    Grade = Grade,
                };

                newStudent.SchoolId = SchoolId;
                newStudent.CourseId = CourseId;

                _context.Students.Add(newStudent);
                _context.SaveChanges();
                Console.Clear();
                Console.WriteLine($"Student '{newStudent.Name}' created successfully.\n");
                Console.WriteLine("Press any key to return to the main menu.");
                Console.ReadKey();
                Console.Clear();

                return false; // Break the loop if a valid school ID is obtained
            }

        
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine("An error occurred while creating the new student:\n" + ex.Message);
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
            Console.Clear();
            return false;
        }
    }



    public bool InputRead(out string Name, out string Email, out string Phone, out string Address, out int Grade, out int SchoolId, out int CourseId)
    {
        try
        {
            Console.Clear();
            Console.Write("Enter Student name: ");
            Name = Console.ReadLine();
            Console.Write("Enter Student Email: ");
            Email = Console.ReadLine();
            Console.Write("Enter Student phone: ");
            Phone = Console.ReadLine();
            Console.Write("Enter Student address: ");
            Address = Console.ReadLine();
            Console.Write("Enter Student grade: ");
            int.TryParse(Console.ReadLine(), out Grade);



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
            Name = Email = Phone = Address = string.Empty;
            CourseId = SchoolId = Grade = 0;
            return false;
        }
    }



}

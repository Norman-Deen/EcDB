using EcDB.Entities;
using EcDB.Services.SubServices;
using EcDB.Services;
using Microsoft.EntityFrameworkCore;
using EcDB.Data;

namespace EcDB.Repository;

public class CourseRepository : ICourseRepository
{
    private readonly AppSettings _context;
    private readonly ValidationService _validationService;
    private readonly SchoolRepository _schoolRepository;
    public CourseRepository(AppSettings context)
    {
        _context = context;
        _validationService = new ValidationService(context); // Initialize _validationService in the constructor
        _schoolRepository = new SchoolRepository(context);
    }

    public bool GetAll()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("--------All Courses--------\n");

            var courses = _context.Courses.Include(c => c.CoursePlans).ToList();

            if (courses.Any())
            {
                foreach (var course in courses)
                {
                    Console.WriteLine($"ID: \"{course.CourseId}\"");
                    Console.WriteLine($"Name: \"{course.CourseName}\"\n");
                }

                Console.WriteLine();
                Console.WriteLine("Press any key to return to the main menu.");
                Console.ReadKey();
                Console.Clear();

                return true; // Courses found
            }
            else
            {
                Console.WriteLine("No courses found.\n");
                Console.WriteLine("Press any key to return to the main menu.");
                Console.ReadKey();
                Console.Clear();

                return false; // No courses found
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
            int courseId;

            do
            {
                Console.Clear();
                // Display the list of Courses
                CourseRepository courseRepository = new CourseRepository(_context);
                GetCourseId getCourseIdInstance = new GetCourseId(_context, courseRepository);
                bool success = getCourseIdInstance.TryGetCourseId(out courseId); // Call the TryGetCourseId method
                courseId = courseId;

                if (!success || !_validationService.CheckIfExists(courseId, "Course"))
                {
                    Console.WriteLine();
                    ConsoleColors.PrintColoredLine("Invalid input or Course id not found. Please try again.\n", ConsoleColor.Red);
                    Console.ReadKey();
                    Console.Clear();
                    continue; // Continue to the next iteration of the loop
                }
                else
                {
                    break; // Break the loop if a valid school ID is obtained
                }

            } while (true);


            // Retrieve the existing course from the database, including the related school and instructors
            var existingCourse = _context.Courses
                .Include(c => c.School)       // Include the related school
                .Include(c => c.Instructors)  // Include the related instructors
                .Include(c => c.CoursePlans)  // Include the related course plans
                .FirstOrDefault(c => c.CourseId == courseId);

            // Display course details
            Console.Clear();
            Console.WriteLine($"Course Details:\n");
            Console.WriteLine($"ID: {existingCourse.CourseId}");
            Console.WriteLine($"Course Name: \"{existingCourse.CourseName}\"");
            Console.WriteLine($"Duration: {existingCourse.Duration}");
            Console.WriteLine($"Description:\n {existingCourse.Description}\n");
            // Display the related course plans for the selected course
            Console.WriteLine("Course Plans:");
            if (existingCourse.CoursePlans != null && existingCourse.CoursePlans.Any())
            {
                foreach (var coursePlan in existingCourse.CoursePlans)
                {
                    Console.WriteLine($" - {coursePlan.CoursePlanDetails}");
                }
            }
            else
            {
                Console.WriteLine("No Course Plans available.");
            }
            Console.WriteLine();

            // Display the related school name
            Console.WriteLine($"School:\n  -{existingCourse.School?.SchoolName ?? "N/A"}\n");




            // Display the instructor names if available
            if (existingCourse.Instructors != null && existingCourse.Instructors.Any())
            {
                Console.WriteLine("Instructor Names:");
                foreach (var instructor in existingCourse.Instructors)
                {
                    Console.WriteLine($" - {instructor.Name}");
                }
            }
            else
            {
                Console.WriteLine("Instructors: N/A");
            }

            Console.WriteLine("\nPress any key to return to the main menu.");
            Console.ReadKey();

            return true;
        }
        catch (Exception)
        {
            Console.Clear();
            Console.WriteLine("An error occurred while fetching course details.\n");
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
            Console.Clear();
            return false;
        }
    }


    public bool GetAllmini()
    {
        try
        {
            var courses = _context.Courses.ToList();

            foreach (var course in courses)
            {
                Console.WriteLine($"ID: {course.CourseId} \"{course.CourseName}\"");
            }
            return true;
        }
        catch (Exception)
        {


            return false; // Indicate failure
        }
    }


    public bool Create()
    {
        try
        {

            InputRead(out string courseName, out string duration, out string description, out string coursePlan, out int schoolId);

            // Create a new course instance with the extracted values
            var newCourse = new Course
            {
                CourseName = courseName,
                Duration = duration,
                Description = description
            };

            // Add the new course to your data context
            _context.Courses.Add(newCourse);


            newCourse.SchoolId = schoolId;


            // Save changes to the database
            _context.SaveChanges();


            // Now, you have the CourseId generated by the database
            var courseId = newCourse.CourseId;

            // Create a new course plan instance with the extracted values and the generated courseId
            var newCoursePlan = new CoursePlan
            {
                CoursePlanDetails = coursePlan,
                CourseId = courseId // Set the CourseId to the generated CourseId
            };

            // Add the new course plan to your data context
            _context.CoursePlans.Add(newCoursePlan);

            // Save changes to the database
            _context.SaveChanges();

            Console.Clear();
            Console.WriteLine($"Course: \"{courseName}\" created successfully.\n");
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
            Console.Clear();

            return true;
        }
        catch (Exception)
        {
            Console.Clear();
            Console.WriteLine("An error occurred while creating the course.\n");
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
            int courseId;

            do
            {
                Console.Clear();
                // Display the list of Courses
                CourseRepository courseRepository = new CourseRepository(_context);
                GetCourseId getCourseIdInstance = new GetCourseId(_context, courseRepository);
                bool success = getCourseIdInstance.TryGetCourseId(out courseId); // Call the TryGetCourseId method
                courseId = courseId;

                if (!success || !_validationService.CheckIfExists(courseId, "Course"))
                {
                    Console.WriteLine();
                    ConsoleColors.PrintColoredLine("Invalid input or Course id not found. Please try again.\n", ConsoleColor.Red);
                    Console.ReadKey();
                    Console.Clear();
                    continue; // Continue to the next iteration of the loop
                }
                else
                {
                    break; // Break the loop if a valid school ID is obtained
                }

            } while (true);


            InputRead(out string courseName, out string duration, out string description, out string coursePlanDetails, out int schoolId);
            // Retrieve the existing course from the database
            var existingCourse = _context.Courses.Include(c => c.CoursePlans).FirstOrDefault(c => c.CourseId == courseId);

            // Update the properties of the existing course
            existingCourse.CourseName = courseName;
            existingCourse.Duration = duration;
            existingCourse.Description = description;
            existingCourse.SchoolId = schoolId; // Add this line to update SchoolId

            // Update the properties of the associated CoursePlan (assuming there is only one associated CoursePlan)
            var coursePlan = existingCourse.CoursePlans?.FirstOrDefault();

            coursePlan.CoursePlanDetails = coursePlanDetails;

            // Save changes to the database
            _context.SaveChanges();

            Console.Clear();
            Console.WriteLine($"Course with ID: {courseId} updated successfully.\n");
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
            Console.Clear();

            return true;
        }
        catch (Exception)
        {
            Console.Clear();
            Console.WriteLine("An error occurred while updating the course.\n");
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
            Console.Clear();
            return false;
        }
    }


    public bool Delete()
    {
        try
        {
            int courseId;

            do
            {
                Console.Clear();
                // Display the list of Courses
                CourseRepository courseRepository = new CourseRepository(_context);
                GetCourseId getCourseIdInstance = new GetCourseId(_context, courseRepository);
                bool success = getCourseIdInstance.TryGetCourseId(out courseId); // Call the TryGetCourseId method
                courseId = courseId;

                if (!success || !_validationService.CheckIfExists(courseId, "Course"))
                {
                    Console.WriteLine();
                    ConsoleColors.PrintColoredLine("Invalid input or Course id not found. Please try again.\n", ConsoleColor.Red);
                    Console.ReadKey();
                    Console.Clear();
                    continue; // Continue to the next iteration of the loop
                }
                else
                {
                    break; // Break the loop if a valid course ID is obtained
                }

            } while (true);

            var courseToRemove = _context.Courses.Find(courseId);

            if (courseToRemove != null)
            {
                _context.Courses.Remove(courseToRemove);
                _context.SaveChanges();

                Console.Clear();
                Console.WriteLine($"Course with ID {courseId} deleted successfully.\n");
                Console.WriteLine("Press any key to return to the main menu.");
                Console.ReadKey();
                Console.Clear();
                return true; // Deletion successful
            }
            else
            {
                Console.WriteLine($"Course with ID {courseId} not found.");
                Console.WriteLine("Press any key to return to the main menu.");
                Console.ReadKey();
                Console.Clear();
                return false; // Course not found
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return false; // Error occurred
        }
    }



    public bool InputRead(out string courseName, out string duration, out string description, out string coursePlan, out int schoolId)
    {

        try
        {
            Console.Clear();
            Console.Write("Enter Course name: ");
            courseName = Console.ReadLine();
            Console.Write("Enter Course Duration: ");
            duration = Console.ReadLine();
            Console.Write("Enter Course Description: ");
            description = Console.ReadLine();
            Console.Write("Enter Course Plan: ");
            coursePlan = Console.ReadLine();


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



            int SchoolId = schoolId;

            return true;
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine("An error occurred while reading input:\n" + ex.Message);
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
            Console.Clear();
            courseName = duration = description = coursePlan = "";
            schoolId = 0;

            return false;
        }
    }



}

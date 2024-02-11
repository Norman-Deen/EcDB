using EcDB.Data;
using EcDB.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EcDB.Services.SubServices
{
    internal class Querying
    {
        private readonly AppSettings dbContext;
        private readonly int passingGrade = 60; // Set your passing grade here

        private int CourseId; // Define CourseId here
        public Querying(AppSettings dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        }
        static void PrintColoredLine(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }



        public void TotalQueries()
        {
            try
            {
                // Ensure database is created and seeded with data
                dbContext.Database.EnsureCreated();

                // Query for the counts
                int schoolCount = dbContext.Schools.Count();
                int instructorCount = dbContext.Instructors.Count();
                int studentCount = dbContext.Students.Count();
                int courseCount = dbContext.Courses.Count();

                // Output the counts
                Console.Clear();
                Console.WriteLine($"    ---Total---\n");
                Console.WriteLine($"Number of Schools: {schoolCount}");
                Console.WriteLine($"Number of Instructors: {instructorCount}");
                Console.WriteLine($"Number of Students: {studentCount}");
                Console.WriteLine($"Number of Courses: {courseCount}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Press any key to return to the main menu.");
                Console.ReadKey();
            }
        }


        public void StudentsGradeQueries()
        {
            try
            {
                // Successful students
                var studentsPassed = dbContext.Students
                    .Where(student => student.Grade >= passingGrade)
                    .Select(student => student.Name)
                    .ToList();
                // Failing students
                var studentsFailed = dbContext.Students
                    .Where(student => student.Grade < passingGrade)
                    .Select(student => student.Name)
                    .ToList();

                // Display the names of successful students
                Console.Clear();
                PrintColoredLine("Successful students (over 60):\n", ConsoleColor.DarkGray);
                foreach (var studentName in studentsPassed)
                {
                    Console.WriteLine(studentName);
                }
                Console.WriteLine();
                // Display the names of failed students
                PrintColoredLine("Failed students (under 60):\n", ConsoleColor.DarkGray);
                foreach (var studentName in studentsFailed)
                {
                    Console.WriteLine(studentName);
                }
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                PrintColoredLine("Press any key to return to the main menu.", ConsoleColor.DarkGray);
                Console.ReadKey();
            }
        }



        public void StudentCountPerCourseQuery()
        {
            try
            {
                // Ensure the database is created and seeded with data
                dbContext.Database.EnsureCreated();

                // Query for student count per course with course names
                var studentCountPerCourse = dbContext.Students
                    .GroupBy(s => s.CourseId)
                    .Select(g => new
                    {
                        CourseId = g.Key,
                        CourseName = dbContext.Courses.FirstOrDefault(c => c.CourseId == g.Key) != null
                            ? dbContext.Courses.First(c => c.CourseId == g.Key).CourseName
                            : null,
                        StudentCount = g.Count()
                    })
                    .ToList();

                // Display the results
                Console.Clear();
                PrintColoredLine("Student Count per Course:\n", ConsoleColor.DarkGray);
                foreach (var entry in studentCountPerCourse)
                {
                    Console.WriteLine($"CourseId:'{entry.CourseId}'\nCourseName:'{entry.CourseName}'\nStudent Count:'{entry.StudentCount}'\n");
                }
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                PrintColoredLine("Press any key to return to the main menu.", ConsoleColor.DarkGray);
                Console.ReadKey();
            }
        }




    }
}

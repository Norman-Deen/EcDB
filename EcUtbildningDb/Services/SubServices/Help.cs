using System;

namespace EcDB.Services.SubServices
{
    public class Help
    {
        public void DisplayHelpInfo()
        {
            Console.Clear();
            Console.WriteLine("**Program Overview:**\n");
            Console.WriteLine("1. **Querying:**");
            Console.WriteLine("   - Access various querying options to retrieve information from the database.");
            Console.WriteLine("2. **Editor:**");
            Console.WriteLine("   - Modify database entries for schools, instructors, courses, and students.");
            Console.WriteLine("3. **Exit:**");
            Console.WriteLine("   - Terminate the application.\n");

            Console.WriteLine("**Usage Tips:**");
            Console.WriteLine("- Navigate through the menus using numeric keys.");
            Console.WriteLine("- Use querying options to retrieve specific data from the database.");
            Console.WriteLine("- Take advantage of editor options to add, update, or delete database entries.\n");

            Console.WriteLine("**Note:** You can return to the main menu at any time by pressing '0'.\n\n");

            // Display database schema
            DisplayDatabaseSchema();

            Console.WriteLine();
            ConsoleColors.PrintColoredLine("Press space to return to the main menu.", ConsoleColor.DarkGray);
            Console.ReadKey();
            Console.Clear();
        }

        private void DisplayDatabaseSchema()
        {
            Console.WriteLine("+-------------------+       +---------------------+");
            Console.WriteLine("|      Schools      |       |    CoursePlans      |");
            Console.WriteLine("+-------------------+       +---------------------+");
            Console.WriteLine("| SchoolId (PK)     |       | CoursePlanId (PK)   |");
            Console.WriteLine("| SchoolName        |       | CoursePlanDetails   |");
            Console.WriteLine("| Address           |       | CourseId (FK) --->  |");
            Console.WriteLine("| PhoneNumber       |       +---------------------+");
            Console.WriteLine("| Website           |                |");
            Console.WriteLine("|                   |                |");
            Console.WriteLine("|                   V                |");
            Console.WriteLine("+-------------------+                |");
            Console.WriteLine("        |                            |");
            Console.WriteLine("        |                            |");
            Console.WriteLine("        V                            V");
            Console.WriteLine("+-------------------+       +---------------------+");
            Console.WriteLine("|      Courses      |       |     Instructors     |");
            Console.WriteLine("+-------------------+       +---------------------+");
            Console.WriteLine("| CourseId (PK)     |       | InstructorId (PK)   |");
            Console.WriteLine("| CourseName        |       | Name                |");
            Console.WriteLine("| Duration          |       | Email               |");
            Console.WriteLine("| Description       |       | Phone               |");
            Console.WriteLine("| SchoolId (FK) --->|       | Address             |");
            Console.WriteLine("+-------------------+       | CourseId (FK) --->  |");
            Console.WriteLine("        |                   | SchoolId (FK) --->  |");
            Console.WriteLine("        |                   |                     |");
            Console.WriteLine("        V                   |                     |");
            Console.WriteLine("+-------------------+       +---------------------+");
            Console.WriteLine("|      Students     |");
            Console.WriteLine("+-------------------+");
            Console.WriteLine("| StudentId (PK)    |");
            Console.WriteLine("| Name              |");
            Console.WriteLine("| Email             |");
            Console.WriteLine("| Phone             |");
            Console.WriteLine("| Address           |");
            Console.WriteLine("| Grade             |");
            Console.WriteLine("| CourseId (FK) --->|");
            Console.WriteLine("| SchoolId (FK) --->|");
            Console.WriteLine("+-------------------+");
        }
    }
}

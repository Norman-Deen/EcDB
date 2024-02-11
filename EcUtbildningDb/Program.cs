using EcDB.Services;
using EcDB.Data;
using EcDB.Services.UI;
using EcDB.Services.SubServices;
using EcDB.IRepository;
using EcDB.Repository;

namespace EcDB;

class Program
{
    private static readonly AppSettings context = new AppSettings();
    static void Main()
    {
        Console.Title = "EcUtbildning Db V1.0"; // Console name
        char UserChoice;
        MenuService menus = new MenuService();

        ICourseRepository courseRepository = new CourseRepository(context);
        CourseService CourseManager = new CourseService(courseRepository);

        ISchoolRepository schoolRepository = new SchoolRepository(context);
        SchoolService schoolManager = new SchoolService(schoolRepository);

        Help helpInstance = new Help();

        IInstructorRepository instructorRepository = new InstructorRepository(context);
        InstructorService InstructorManager = new InstructorService(instructorRepository, context);

        IStudentRepository StudentRepository = new StudentRepository(context);
        StudentService StudentManager = new StudentService(StudentRepository, context);

        // Assuming you have an instance of AppSettings, replace this with your actual instance
        AppSettings yourDbContextInstance = new AppSettings();

        // Create an instance of Querying
        Querying queryingInstance = new Querying(yourDbContextInstance);

        //loop to keep the application running continuously
        while (true)
        {
            // display main menu start
            menus.mainMenu();
            ConsoleKeyInfo key = Console.ReadKey(intercept: true);

            //read user input
            switch (key.KeyChar)
            {
                // display Querying menu
                case '1':
                    menus.Querying();
                    string userInput = Console.ReadLine(); // Read the user's choice for student operations

                    if (int.TryParse(userInput, out int UserSelect))
                    {
                        // Call the ExecuteQueries method
                        switch (UserSelect)
                        {
                            // Display all schools
                            case 1:
                                bool schoolGetAll = schoolManager.GetAll();
                                break;

                            // Get school by ID
                            case 2:
                                bool schoolGetById = schoolManager.GetBy();
                                break;

                            // Display all Instructors
                            case 3:
                                bool instructorGetAll = InstructorManager.GetAll();
                                break;

                            // Get Instructor info by Email
                            case 4:
                                bool instructorGetBy = InstructorManager.GetBy();
                                break;

                            // Display All Courses
                            case 5:
                                bool CoursesGetAll = CourseManager.GetAll();
                                break;

                            // Get Course info by id
                            case 6:
                                bool CourseGetById = CourseManager.GetBy();
                                break;

                            // Display All Students
                            case 7:
                                bool StudentGetAll = StudentManager.GetAll();
                                break;

                            // Get Student info By Email
                            case 8:
                                bool StudentGetBy = StudentManager.GetBy();
                                break;

                            // Display number of schools, trainers, and courses
                            case 9:
                                queryingInstance.TotalQueries();
                                break;

                            // Display number of schools, trainers, and courses
                            case 10:
                                queryingInstance.StudentsGradeQueries();
                                break;

                            // Display number of schools, trainers, and courses
                            case 11:
                                queryingInstance.StudentCountPerCourseQuery();
                                break;

                            case 0:
                                break;

                            default:
                                break; // Add a default case to handle unexpected input
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid numeric option.");
                        // Handle invalid input accordingly
                    }

                    // Add this break statement to exit the 'case '1':' block
                    break;

                // editor Menu
                case '2':
                    menus.editorMenu();
                    key = Console.ReadKey(intercept: true);

                    //read and handle user input
                    switch (key.KeyChar)
                    {
                        // display schools menu
                        case '1':
                            menus.SchoolsMenu();
                            UserChoice = Console.ReadKey().KeyChar; // Read the user's choice for student operations

                            // Get all schools
                            switch (UserChoice)
                            {
                                // Display all schools
                                case '1':
                                    bool schoolGetAll = schoolManager.GetAll();
                                    break;

                                // Get school by ID
                                case '2':
                                    bool schoolGetById = schoolManager.GetBy();
                                    break;

                                // Add new school
                                case '3':
                                    bool schoolCreate = schoolManager.Create();
                                    break;

                                // Update school info
                                case '4':
                                    bool schoolUpdated = schoolManager.Update();
                                    break;

                                // Delete School
                                case '5':
                                    bool schoolDelete = schoolManager.Delete();
                                    break;

                                // Return to main menu
                                case ' ':
                                    break;
                            }
                            break;

                        // Instructors
                        case '2':
                            menus.InstructorsMenu();
                            key = Console.ReadKey(intercept: true);

                            //read and handle user input
                            switch (key.KeyChar)
                            {
                                // Get all Instructors
                                case '1':
                                    bool instructorGetAll = InstructorManager.GetAll();
                                    break;

                                // Get Instructor info by Email
                                case '2':
                                    bool instructorGetBy = InstructorManager.GetBy();
                                    break;

                                // Add new instructor
                                case '3':
                                    bool instructorCreate = InstructorManager.Create();
                                    break;

                                // Update Instructor 
                                case '4':
                                    bool instructorUpdated = InstructorManager.Update();
                                    break;

                                case '5': // Delete Instructor
                                    bool instructorDelete = InstructorManager.Delete();
                                    break;
                            }
                            break;

                        // Courses
                        case '3':
                            menus.CoursesMenu();
                            UserChoice = Console.ReadKey().KeyChar; // Read the user's choice for student operations

                            switch (UserChoice)
                            {
                                // Display All Courses
                                case '1':
                                    bool CoursesGetAll = CourseManager.GetAll();
                                    break;

                                // Get Course info by id
                                case '2':
                                    bool CourseGetById = CourseManager.GetBy();
                                    break;

                                // Add New Courses
                                case '3':
                                    bool CourseCreate = CourseManager.Create();
                                    break;

                                // Update Courses
                                case '4':
                                    bool CourseUpdate = CourseManager.Update();
                                    break;

                                // Delete Courses
                                case '5':
                                    bool CourseDelete = CourseManager.Delete();
                                    break;

                                // Return to main menu
                                case '6':
                                    Console.Clear();
                                    break;
                            }
                            break;

                        // Student 
                        case '4':
                            menus.StudentMenu();
                            char x = Console.ReadKey().KeyChar; // Read the user's choice for student operations

                            switch (x)
                            {
                                // Display All Students
                                case '1':
                                    bool StudentGetAll = StudentManager.GetAll();
                                    break;

                                // Get Student info By Email
                                case '2':
                                    bool StudentGetBy = StudentManager.GetBy();
                                    break;

                                // Add New Student
                                case '3':
                                    bool StudentCreat = StudentManager.Create();
                                    break;

                                // Update Student Info
                                case '4':
                                    bool StudentUpdate = StudentManager.Update();
                                    break;

                                // Delete Student
                                case '5':
                                    bool StudentDelete = StudentManager.Delete();
                                    break;

                                // return to main menu
                                case '6':
                                    break;

                                default:
                                    break;
                            }
                            break;
                    }
                    break;

                // Exit
                case '3':
                    Console.Clear();
                    ConsoleColors.PrintColoredLine("Exiting the application. Goodbye!", ConsoleColor.DarkBlue);
                    Thread.Sleep(2000); // Sleep for 2000 milliseconds (2 seconds)
                    Environment.Exit(0);
                    break;

                case '0':
                    helpInstance.DisplayHelpInfo();
                    break;
            }
        }
    }
}

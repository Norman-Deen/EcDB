using EcDB.IRepository;
using EcDB.Services.SubServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcDB.Services.UI
{
    public class MenuService : IMenuRepository
    {
       
        public void mainMenu()
        {
            Console.Clear();
            ConsoleColors.PrintColoredLine("Ec Utbildning Db V1.0\n", ConsoleColor.DarkGray);
            ConsoleColors.PrintColoredLine("1 Querying", ConsoleColor.Gray);
            ConsoleColors.PrintColoredLine("2 Editor\n", ConsoleColor.Gray);

            ConsoleColors.PrintColoredLine("3 Exit\n\n\n\n", ConsoleColor.DarkGray);
            ConsoleColors.PrintColoredLine("0 Help\n\n\n\n", ConsoleColor.DarkGray);
        }



        public void Querying()
        {
            Console.Clear();
            ConsoleColors.PrintColoredLine("----Select Option----\n", ConsoleColor.DarkGray);
            ConsoleColors.PrintColoredLine("1 Display All Schools", ConsoleColor.Gray);
            ConsoleColors.PrintColoredLine("2 Get School info by id\n", ConsoleColor.Gray);
            ConsoleColors.PrintColoredLine("3 Display All Instructors", ConsoleColor.Gray);
            ConsoleColors.PrintColoredLine("4 Get Instructor info by Email\n", ConsoleColor.Gray);
            ConsoleColors.PrintColoredLine("5 Display All Courses", ConsoleColor.Gray);
            ConsoleColors.PrintColoredLine("6 Get Course info by id\n", ConsoleColor.Gray);
            ConsoleColors.PrintColoredLine("7 Display All Student", ConsoleColor.Gray);
            ConsoleColors.PrintColoredLine("8 Get Student info by Email\n", ConsoleColor.Gray);
            ConsoleColors.PrintColoredLine("9 Display number of schools, Instructors and courses", ConsoleColor.Gray);
            ConsoleColors.PrintColoredLine("10 Display StudentsGrade", ConsoleColor.Gray);
            ConsoleColors.PrintColoredLine("11 Display Student CountPer Course Query\n", ConsoleColor.Gray);
            //ConsoleColors.PrintColoredLine("3 Display Courses Count", ConsoleColor.Gray);
            //ConsoleColors.PrintColoredLine("4 Display Courses Count", ConsoleColor.Gray);
            //ConsoleColors.PrintColoredLine("5 Display Student Count\n", ConsoleColor.Gray);
            ConsoleColors.PrintColoredLine("\n0 to return to main menu.", ConsoleColor.DarkGray);
            Console.Write("\nYour Input: ");
        }


     

        public void editorMenu()
        {
            Console.Clear();
            ConsoleColors.PrintColoredLine("----Select Editor----\n", ConsoleColor.DarkGray);
            ConsoleColors.PrintColoredLine("1 Schools", ConsoleColor.Gray);
            ConsoleColors.PrintColoredLine("2 Instructors", ConsoleColor.Gray);
            ConsoleColors.PrintColoredLine("3 Courses", ConsoleColor.Gray);
            ConsoleColors.PrintColoredLine("4 Student\n", ConsoleColor.Gray);

            ConsoleColors.PrintColoredLine("Press space to return to main menu.", ConsoleColor.DarkGray);
        }



        public void SchoolsMenu()
        {
            Console.Clear();
            ConsoleColors.PrintColoredLine("----Select Option----\n", ConsoleColor.DarkGray);
            ConsoleColors.PrintColoredLine("1 Display All Schools", ConsoleColor.Gray);
            ConsoleColors.PrintColoredLine("2 Get School info by id", ConsoleColor.Gray);
            ConsoleColors.PrintColoredLine("3 Add New School", ConsoleColor.Gray);
            ConsoleColors.PrintColoredLine("4 Update School Info", ConsoleColor.Gray);
            ConsoleColors.PrintColoredLine("5 Delete School\n", ConsoleColor.Gray);
            ConsoleColors.PrintColoredLine("Press space to return to the main menu.", ConsoleColor.DarkGray);

        }

        public void InstructorsMenu()
        {
            Console.Clear();
            ConsoleColors.PrintColoredLine("----Select Option----\n", ConsoleColor.DarkGray);
            ConsoleColors.PrintColoredLine("1 Display All Instructors", ConsoleColor.Gray);
            ConsoleColors.PrintColoredLine("2 Get Instructor info by Email", ConsoleColor.Gray);
            ConsoleColors.PrintColoredLine("3 Add New Instructor", ConsoleColor.Gray);
            ConsoleColors.PrintColoredLine("4 Update Instructor Info", ConsoleColor.Gray);
            ConsoleColors.PrintColoredLine("5 Delete Instructor\n", ConsoleColor.Gray);
            ConsoleColors.PrintColoredLine("Press space to return to main menu.", ConsoleColor.DarkGray);

        }

        public void CoursesMenu()
        {
            Console.Clear();
            ConsoleColors.PrintColoredLine("----Select Option----\n", ConsoleColor.DarkGray);
            ConsoleColors.PrintColoredLine("1 Display All Courses", ConsoleColor.Gray);
            ConsoleColors.PrintColoredLine("2 Get Course info by id", ConsoleColor.Gray);
            ConsoleColors.PrintColoredLine("3 Add New Courses", ConsoleColor.Gray);
            ConsoleColors.PrintColoredLine("4 Update Courses Info", ConsoleColor.Gray);
            ConsoleColors.PrintColoredLine("5 Delete Courses\n", ConsoleColor.Gray);
            ConsoleColors.PrintColoredLine("Press space to return to main menu.", ConsoleColor.DarkGray);

        }

        public void StudentMenu()
        {
            Console.Clear();
            ConsoleColors.PrintColoredLine("----Select Option----\n", ConsoleColor.DarkGray);
            ConsoleColors.PrintColoredLine("1 Display All Student", ConsoleColor.Gray);
            ConsoleColors.PrintColoredLine("2 Get Student info by Email", ConsoleColor.Gray);
            ConsoleColors.PrintColoredLine("3 Add New Student", ConsoleColor.Gray);
            ConsoleColors.PrintColoredLine("4 Update Student Info", ConsoleColor.Gray);
            ConsoleColors.PrintColoredLine("5 Delete Student\n", ConsoleColor.Gray);
            ConsoleColors.PrintColoredLine("Press space to return to main menu.", ConsoleColor.DarkGray);

        }


     

    }
}

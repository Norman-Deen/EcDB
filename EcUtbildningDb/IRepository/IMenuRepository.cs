using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcDB.IRepository
{
    internal interface IMenuRepository
    {


        /// <summary>
        /// Displays the main menu.
        /// Ec Utbildning Db V1.0
        /// 1 Schools
        /// 2 Instructors
        /// 3 Courses
        /// 4 Student
        /// 5 Exit
        /// </summary>
        public void mainMenu();

        /// <summary>
        /// Displays a menu for school-related operations.
        /// Options include:
        /// 1. Display All Schools
        /// 2. Add New School
        /// 3. Update School Info
        /// 4. Delete School
        /// Users can press the space key to return to the main menu.
        /// </summary>
        public void SchoolsMenu();

        /// <summary>
        /// Displays a menu for instructor-related operations.
        /// Options include:
        /// 1. Display All Instructors
        /// 2. Get Instructor Info by Email
        /// 3. Add New Instructor
        /// 4. Update Instructor Info
        /// 5. Delete Instructor
        /// Users can press 6 to return to the main menu.
        /// </summary>
        public void InstructorsMenu();

        /// <summary>
        /// Displays a menu for course-related operations.
        /// Options include:
        /// 1. Display All Courses
        /// 2. Add New Courses
        /// 3. Update Courses Info
        /// 4. Delete Courses
        /// Users can press 5 to return to the main menu.
        /// </summary>
        public void CoursesMenu();

        /// <summary>
        /// Displays a menu for student-related operations.
        /// Options include:
        /// 1. Display All Students
        /// 2. Get Student Info by Email
        /// 3. Add New Student
        /// 4. Update Student Info
        /// 5. Delete Student
        /// Users can press the space key to return to the main menu.
        /// </summary>
        public void StudentMenu();

        public void Querying();

    }
}

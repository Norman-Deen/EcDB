using System;

namespace EcDB.IRepository
{
    /// <summary>
    /// Interface representing operations for interacting with student-related data in the database.
    /// </summary>
    internal interface IStudentRepository
    {
        /// <summary>
        /// Retrieves all students from the database.
        /// </summary>
        bool GetAll();

        /// <summary>
        /// Retrieves a summary of all students from the database.
        /// </summary>
        bool GetAllmini();

        /// <summary>
        /// Retrieves a specific student from the database based on input criteria.
        /// </summary>
        bool GetBy();

        /// <summary>
        /// Creates a new student entry in the database.
        /// </summary>
        bool Create();

        /// <summary>
        /// Updates an existing student entry in the database.
        /// </summary>
        bool Update();

        /// <summary>
        /// Deletes a student entry from the database.
        /// </summary>
        bool Delete();

        /// <summary>
        /// Reads input data to create or update a student entry.
        /// </summary>
        /// <param name="Name">The name of the student.</param>
        /// <param name="Email">The email of the student.</param>
        /// <param name="Phone">The phone number of the student.</param>
        /// <param name="Address">The address of the student.</param>
        /// <param name="Grade">The grade of the student.</param>
        /// <param name="SchoolId">The ID of the school associated with the student.</param>
        /// <param name="CourseId">The ID of the course associated with the student.</param>
        bool InputRead(out string Name, out string Email, out string Phone, out string Address, out int Grade, out int SchoolId, out int CourseId);
    }
}

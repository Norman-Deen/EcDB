using System;

namespace EcDB.IRepository
{
    /// <summary>
    /// Interface representing operations for interacting with instructor-related data in the database.
    /// </summary>
    internal interface IInstructorRepository
    {
        /// <summary>
        /// Retrieves all instructors from the database.
        /// </summary>
        bool GetAll();

        /// <summary>
        /// Retrieves a summary of all instructors from the database.
        /// </summary>
        bool GetAllmini();

        /// <summary>
        /// Retrieves a specific instructor from the database based on input criteria.
        /// </summary>
        bool GetBy();

        /// <summary>
        /// Creates a new instructor entry in the database.
        /// </summary>
        bool Create();

        /// <summary>
        /// Updates an existing instructor entry in the database.
        /// </summary>
        bool Update();

        /// <summary>
        /// Deletes an instructor entry from the database.
        /// </summary>
        bool Delete();

        /// <summary>
        /// Reads input data to create or update an instructor entry.
        /// </summary>
        /// <param name="Name">The name of the instructor.</param>
        /// <param name="Email">The email of the instructor.</param>
        /// <param name="Phone">The phone number of the instructor.</param>
        /// <param name="Address">The address of the instructor.</param>
        /// <param name="SchoolId">The ID of the school associated with the instructor.</param>
        /// <param name="CourseId">The ID of the course associated with the instructor.</param>
        bool InputRead(out string Name, out string Email, out string Phone, out string Address, out int SchoolId, out int CourseId);
    }
}

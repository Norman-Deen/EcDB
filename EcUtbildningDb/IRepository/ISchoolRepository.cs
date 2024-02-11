namespace EcDB.IRepository
{
 
    internal interface ISchoolRepository
    {
        /// <summary>
        /// Retrieves all schools from the database.
        /// </summary>
        bool GetAll();

        /// <summary>
        /// Retrieves basic information of all schools from the database.
        /// </summary>
        bool GetAllmini();

        /// <summary>
        /// Retrieves a specific school from the database based on input criteria.
        /// </summary>
        bool GetBy();

        /// <summary>
        /// Creates a new school entry in the database.
        /// </summary>
        bool Create();

        /// <summary>
        /// Updates an existing school entry in the database.
        /// </summary>
        bool Update();

        /// <summary>
        /// Deletes a school entry from the database.
        /// </summary>
        bool Delete();

        /// <summary>
        /// Reads input data to create or update a school entry.
        /// </summary>
        /// <param name="courseName">The name of the course associated with the school.</param>
        /// <param name="duration">The duration of the course associated with the school.</param>
        /// <param name="description">The description of the course associated with the school.</param>
        /// <param name="coursePlan">The plan or schedule of the course associated with the school.</param>
        bool InputRead(out string courseName, out string duration, out string description, out string coursePlan);
    }
}

public interface ICourseRepository
{
    /// <summary>
    /// Retrieves all courses from the database.
    /// </summary>
    bool GetAll();

    /// <summary>
    /// Retrieves a summary of all courses from the database.
    /// </summary>
    bool GetAllmini();

    /// <summary>
    /// Retrieves a specific course from the database based on input criteria.
    /// </summary>
    bool GetBy();

    /// <summary>
    /// Creates a new course entry in the database.
    /// </summary>
    bool Create();

    /// <summary>
    /// Updates an existing course entry in the database.
    /// </summary>
    bool Update();

    /// <summary>
    /// Deletes a course entry from the database.
    /// </summary>
    bool Delete();

    /// <summary>
    /// Reads input data to create or update a course entry.
    /// </summary>
    /// <param name="courseName">The name of the course.</param>
    /// <param name="duration">The duration of the course.</param>
    /// <param name="description">The description of the course.</param>
    /// <param name="coursePlan">The plan associated with the course.</param>
    /// <param name="schoolId">The ID of the school associated with the course.</param>
    bool InputRead(out string courseName, out string duration, out string description, out string coursePlan, out int schoolId);
}

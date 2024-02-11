internal interface ICoursePlanRepository
{
    /// <summary>
    /// Retrieves all course plans from the database.
    /// </summary>
    bool GetAll();

    /// <summary>
    /// Retrieves a specific course plan from the database based on input criteria.
    /// </summary>
    bool GetBy();

    /// <summary>
    /// Creates a new course plan entry in the database.
    /// </summary>
    bool Create();

    /// <summary>
    /// Updates an existing course plan entry in the database.
    /// </summary>
    bool Update();

    /// <summary>
    /// Deletes a course plan entry from the database.
    /// </summary>
    bool Delete();

    /// <summary>
    /// Reads input data to create or update a course plan entry.
    /// </summary>
    /// <param name="Name">The name of the course plan.</param>
    /// <param name="Email">The email of the course plan.</param>
    /// <param name="Phone">The phone number of the course plan.</param>
    /// <param name="Address">The address of the course plan.</param>
    /// <param name="Grade">The grade or level of the course plan.</param>
    /// <param name="SchoolId">The ID of the school associated with the course plan.</param>
    /// <param name="CourseId">The ID of the course associated with the course plan.</param>
    bool InputRead(out string Name, out string Email, out string Phone, out string Address, out int Grade, out int SchoolId, out int CourseId);
}

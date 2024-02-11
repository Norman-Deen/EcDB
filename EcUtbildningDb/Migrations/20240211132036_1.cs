using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcDB.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    SchoolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: false),
                    Website = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.SchoolId);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    SchoolId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Courses_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    InstructorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true),
                    SchoolId = table.Column<int>(type: "int", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.InstructorId);
                    table.ForeignKey(
                        name: "FK_Instructors_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Instructors_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: true),
                    Address = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),
                    Grade = table.Column<int>(type: "int", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: true),
                    SchoolId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Students_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CoursePlans",
                columns: table => new
                {
                    CoursePlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoursePlanDetails = table.Column<string>(type: "VARCHAR(2000)", maxLength: 2000, nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursePlans", x => x.CoursePlanId);
                    table.ForeignKey(
                        name: "FK_CoursePlans_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursePlans_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId");
                });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "SchoolId", "Address", "PhoneNumber", "SchoolName", "Website" },
                values: new object[,]
                {
                    { 1, "Halmstad", "123-456-7890", "EC Utbildning-HA", "http://www.ecutbildning-ha.com" },
                    { 2, "Malmö", "987-654-3210", "EC Utbildning-MA", "http://www.ecutbildning-ma.com" },
                    { 3, "Göteborg", "555-123-4567", "EC Utbildning-GO", "http://www.ecutbildning-go.com" },
                    { 4, "Örebro", "777-888-9999", "EC Utbildning-OR", "http://www.ecutbildning-or.com" },
                    { 5, "Stockholm", "111-222-3333", "EC Utbildning-ST", "http://www.ecutbildning-st.com" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseName", "Description", "Duration", "SchoolId" },
                values: new object[,]
                {
                    { 1, "Front End", "HTML, CSS, JS for UI. React, Vue.js exploration.", "1 yr", 1 },
                    { 2, "Data Scientist", "Node.js, Django, SQL, NoSQL, API design.", "2 yrs", 2 },
                    { 3, "Full Stack", "Front-end and back-end mastery. Web app development.", "3 yrs", 3 },
                    { 4, "BIM", "Building Information Modeling basics.", "1 yr", 4 },
                    { 5, "IT", "IT essentials, network admin, cybersecurity.", "1 yr", 5 }
                });

            migrationBuilder.InsertData(
                table: "CoursePlans",
                columns: new[] { "CoursePlanId", "CourseId", "CoursePlanDetails", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, "Frontend Dev 1, Frontend Dev 2, Exam Project, HTML/CSS, JS 1, JS 2, JS 3, LIA Frontend Dev, Agile Methods, UX Design", null },
                    { 2, 2, "Prep Math; Stats and AI, Python Programming and Stats Analysis, SQL, Business Intelligence, Machine Learning, R Programming, Deep Learning, Python Programming Advanced, Data Science Project, LIA Internship, Thesis", null },
                    { 3, 3, "Full Stack: 3 years of front-end and back-end mastery, focusing on web app development.", null },
                    { 4, 4, "BIM Basics: Learn the fundamentals of Building Information Modeling in a year-long course.", null },
                    { 5, 5, "IT Essentials: Essentials of Information Technology in a one-year course, covering network admin and cybersecurity.", null }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "InstructorId", "Address", "CourseId", "Email", "Name", "Phone", "SchoolId" },
                values: new object[,]
                {
                    { 1, "123 Main St", 1, "hans@example.com", "Hans Mattin-Lassei", "123-456-7890", 1 },
                    { 2, "456 Oak Ave", 2, "tommy@example.com", "Tommy Mattin-Lassei", "987-654-3210", 2 },
                    { 3, "789 Elm Blvd", 3, "joakim@example.com", "Joakim Lindh", "555-123-4567", 3 },
                    { 4, "101 Pine St", 4, "robert@example.com", "Robert Tublén", "777-888-9999", 4 },
                    { 5, "202 Cedar Ave", 5, "therese@example.com", "Therese Lidbom", "111-222-3333", 5 },
                    { 6, "303 Birch Blvd", 1, "adam@example.com", "Adam Olaso", "444-555-6666", 1 },
                    { 7, "404 Maple St", 2, "morgan@example.com", "Morgan Kostav", "999-888-7777", 2 },
                    { 8, "505 Oak Ave", 3, "burim@example.com", "Burim Fatit", "333-222-1111", 3 },
                    { 9, "606 Pine St", 4, "jorjan@example.com", "Jorjan Moland", "666-777-8888", 4 },
                    { 10, "707 Elm Blvd", 5, "balushi@example.com", "Balushi Jeto", "123-456-7890", 5 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Address", "CourseId", "Email", "Grade", "Name", "Phone", "SchoolId" },
                values: new object[,]
                {
                    { 1, "Address 1", 3, "nour.altinawi@example.com", 90, "Nour Altinawi", "123456789", 1 },
                    { 2, "Address 2", 2, "liam.berg@example.com", 80, "Liam Berg", "987654321", 2 },
                    { 3, "Address 3", 4, "olivia.carlsson@example.com", 49, "Olivia Carlsson", "555555555", 3 },
                    { 4, "Address 4", 1, "hugo.dahl@example.com", 85, "Hugo Dahl", "123123123", 4 },
                    { 5, "Address 5", 5, "amelia.eriksson@example.com", 92, "Amelia Eriksson", "987987987", 5 },
                    { 6, "Address 6", 3, "zara.forsberg@example.com", 45, "Zara Forsberg", "777777777", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoursePlans_CourseId",
                table: "CoursePlans",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePlans_StudentId",
                table: "CoursePlans",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_SchoolId",
                table: "Courses",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_CourseId",
                table: "Instructors",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_SchoolId",
                table: "Instructors",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CourseId",
                table: "Students",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SchoolId",
                table: "Students",
                column: "SchoolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoursePlans");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Schools");
        }
    }
}

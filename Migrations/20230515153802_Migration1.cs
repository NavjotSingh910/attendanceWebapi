using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace attendaceAppWebApi.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "College",
                columns: table => new
                {
                    CollegeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollegeName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Location = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__College__29409519F8AD7213", x => x.CollegeID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Role__8AFACE3ADE9A3C8A", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Location = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    HeadOfDepartment = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CollegeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Departme__B2079BCD24611304", x => x.DepartmentID);
                    table.ForeignKey(
                        name: "FK__Departmen__Colle__398D8EEE",
                        column: x => x.CollegeID,
                        principalTable: "College",
                        principalColumn: "CollegeID");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    PasswordHash = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    PasswordSalt = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    RefreshTokenHash = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__User__1788CCACD1EBFD70", x => x.UserID);
                    table.ForeignKey(
                        name: "FK__User__RoleID__52593CB8",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "RoleID");
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Location = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    DepartmentID = table.Column<int>(type: "int", nullable: true),
                    CourseDuration = table.Column<int>(type: "int", nullable: true),
                    NumberOfSemesters = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Course__C92D7187E0F21400", x => x.CourseID);
                    table.ForeignKey(
                        name: "FK__Course__Departme__3C69FB99",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "DepartmentID");
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    LastName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    HireDate = table.Column<DateTime>(type: "date", nullable: true),
                    DepartmentID = table.Column<int>(type: "int", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Staff__96D4AAF766FE5B99", x => x.StaffID);
                    table.ForeignKey(
                        name: "FK__Staff__Departmen__5BE2A6F2",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "DepartmentID");
                    table.ForeignKey(
                        name: "FK__Staff__UserID__5CD6CB2B",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    LastName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: true),
                    Address = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    City = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    State = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ZipCode = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    EnrollmentDate = table.Column<DateTime>(type: "date", nullable: true),
                    GraduationDate = table.Column<DateTime>(type: "date", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    RollNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Student__32C52A79D40DED86", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK__Student__UserID__5535A963",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    TeacherID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    LastName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    HireDate = table.Column<DateTime>(type: "date", nullable: true),
                    DepartmentID = table.Column<int>(type: "int", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Teacher__EDF259443ACA13A1", x => x.TeacherID);
                    table.ForeignKey(
                        name: "FK__Teacher__Departm__5812160E",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "DepartmentID");
                    table.ForeignKey(
                        name: "FK__Teacher__UserID__59063A47",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "CourseSession",
                columns: table => new
                {
                    SessionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    StartYear = table.Column<int>(type: "int", nullable: true),
                    EndYear = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CourseSe__C9F49270B5F2E967", x => x.SessionID);
                    table.ForeignKey(
                        name: "FK__CourseSes__Cours__3F466844",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                });

            migrationBuilder.CreateTable(
                name: "Semester",
                columns: table => new
                {
                    SemesterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionID = table.Column<int>(type: "int", nullable: true),
                    SemesterNumber = table.Column<int>(type: "int", nullable: true),
                    SemesterLengthInMonth = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Semester__043301BD6BB80B4B", x => x.SemesterID);
                    table.ForeignKey(
                        name: "FK__Semester__Sessio__4222D4EF",
                        column: x => x.SessionID,
                        principalTable: "CourseSession",
                        principalColumn: "SessionID");
                });

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    SectionID = table.Column<int>(type: "int", nullable: false),
                    SectionName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    SemesterID = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    RoomNumber = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Section__80EF08920E8588A0", x => x.SectionID);
                    table.ForeignKey(
                        name: "FK__Section__CourseI__5FB337D6",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "FK__Section__Departm__60A75C0F",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "DepartmentID");
                    table.ForeignKey(
                        name: "FK__Section__Semeste__619B8048",
                        column: x => x.SemesterID,
                        principalTable: "Semester",
                        principalColumn: "SemesterID");
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    SubjectCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    CreditHours = table.Column<int>(type: "int", nullable: true),
                    SemesterID = table.Column<int>(type: "int", nullable: true),
                    SubjectType = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Subject__AC1BA388C5F473A7", x => x.SubjectID);
                    table.ForeignKey(
                        name: "FK__Subject__Semeste__44FF419A",
                        column: x => x.SemesterID,
                        principalTable: "Semester",
                        principalColumn: "SemesterID");
                });

            migrationBuilder.CreateTable(
                name: "SectionStudent",
                columns: table => new
                {
                    SectionStudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionID = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SectionS__807A9EC7C4E16663", x => x.SectionStudentID);
                    table.ForeignKey(
                        name: "FK__SectionSt__Secti__6477ECF3",
                        column: x => x.SectionID,
                        principalTable: "Section",
                        principalColumn: "SectionID");
                    table.ForeignKey(
                        name: "FK__SectionSt__Stude__656C112C",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID");
                });

            migrationBuilder.CreateTable(
                name: "Attendance",
                columns: table => new
                {
                    AttendanceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false),
                    SectionID = table.Column<int>(type: "int", nullable: false),
                    TeacherID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    IsWorkingDay = table.Column<bool>(type: "bit", nullable: false),
                    IsPresent = table.Column<bool>(type: "bit", nullable: false),
                    IsOnLeave = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Attendan__8B69263C63C8674A", x => x.AttendanceID);
                    table.ForeignKey(
                        name: "FK__Attendanc__Secti__6EF57B66",
                        column: x => x.SectionID,
                        principalTable: "Section",
                        principalColumn: "SectionID");
                    table.ForeignKey(
                        name: "FK__Attendanc__Stude__6D0D32F4",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID");
                    table.ForeignKey(
                        name: "FK__Attendanc__Subje__6E01572D",
                        column: x => x.SubjectID,
                        principalTable: "Subject",
                        principalColumn: "SubjectID");
                    table.ForeignKey(
                        name: "FK__Attendanc__Teach__6FE99F9F",
                        column: x => x.TeacherID,
                        principalTable: "Teacher",
                        principalColumn: "TeacherID");
                });

            migrationBuilder.CreateTable(
                name: "SectionSubject",
                columns: table => new
                {
                    SectionSubjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionID = table.Column<int>(type: "int", nullable: true),
                    SubjectID = table.Column<int>(type: "int", nullable: true),
                    TeacherID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SectionS__5BEE0FE3DBBF5966", x => x.SectionSubjectID);
                    table.ForeignKey(
                        name: "FK__SectionSu__Secti__68487DD7",
                        column: x => x.SectionID,
                        principalTable: "Section",
                        principalColumn: "SectionID");
                    table.ForeignKey(
                        name: "FK__SectionSu__Subje__693CA210",
                        column: x => x.SubjectID,
                        principalTable: "Subject",
                        principalColumn: "SubjectID");
                    table.ForeignKey(
                        name: "FK__SectionSu__Teach__6A30C649",
                        column: x => x.TeacherID,
                        principalTable: "Teacher",
                        principalColumn: "TeacherID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_SectionID",
                table: "Attendance",
                column: "SectionID");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_StudentID",
                table: "Attendance",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_SubjectID",
                table: "Attendance",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_TeacherID",
                table: "Attendance",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_DepartmentID",
                table: "Course",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSession_CourseID",
                table: "CourseSession",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Department_CollegeID",
                table: "Department",
                column: "CollegeID");

            migrationBuilder.CreateIndex(
                name: "IX_Section_CourseID",
                table: "Section",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Section_DepartmentID",
                table: "Section",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Section_SemesterID",
                table: "Section",
                column: "SemesterID");

            migrationBuilder.CreateIndex(
                name: "IX_SectionStudent_SectionID",
                table: "SectionStudent",
                column: "SectionID");

            migrationBuilder.CreateIndex(
                name: "IX_SectionStudent_StudentID",
                table: "SectionStudent",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_SectionSubject_SectionID",
                table: "SectionSubject",
                column: "SectionID");

            migrationBuilder.CreateIndex(
                name: "IX_SectionSubject_SubjectID",
                table: "SectionSubject",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_SectionSubject_TeacherID",
                table: "SectionSubject",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Semester_SessionID",
                table: "Semester",
                column: "SessionID");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_DepartmentID",
                table: "Staff",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_UserID",
                table: "Staff",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_UserID",
                table: "Student",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_SemesterID",
                table: "Subject",
                column: "SemesterID");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_DepartmentID",
                table: "Teacher",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_UserID",
                table: "Teacher",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleID",
                table: "User",
                column: "RoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendance");

            migrationBuilder.DropTable(
                name: "SectionStudent");

            migrationBuilder.DropTable(
                name: "SectionSubject");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Semester");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "CourseSession");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "College");
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace attendaceAppWebApi.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<College> Colleges { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseSession> CourseSessions { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<SectionStudent> SectionStudents { get; set; }

    public virtual DbSet<SectionSubject> SectionSubjects { get; set; }

    public virtual DbSet<Semester> Semesters { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=hp\\MSSQLSERVER_2022;Initial Catalog=attendaceDatabase-Dev; User ID=sa;Password=admin@123;Connect Timeout=30; Encrypt=False; TrustServerCertificate=False; ApplicationIntent=ReadWrite; MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.AttendanceId).HasName("PK__Attendan__8B69263C63C8674A");

            entity.ToTable("Attendance");

            entity.Property(e => e.AttendanceId).HasColumnName("AttendanceID");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.SectionId).HasColumnName("SectionID");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.SubjectId).HasColumnName("SubjectID");
            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

            entity.HasOne(d => d.Section).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.SectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Attendanc__Secti__6EF57B66");

            entity.HasOne(d => d.Student).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Attendanc__Stude__6D0D32F4");

            entity.HasOne(d => d.Subject).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Attendanc__Subje__6E01572D");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Attendanc__Teach__6FE99F9F");
        });

        modelBuilder.Entity<College>(entity =>
        {
            entity.HasKey(e => e.CollegeId).HasName("PK__College__29409519F8AD7213");

            entity.ToTable("College");

            entity.Property(e => e.CollegeId).HasColumnName("CollegeID");
            entity.Property(e => e.CollegeName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Course__C92D7187E0F21400");

            entity.ToTable("Course");

            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.CourseName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Department).WithMany(p => p.Courses)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Course__Departme__3C69FB99");
        });

        modelBuilder.Entity<CourseSession>(entity =>
        {
            entity.HasKey(e => e.SessionId).HasName("PK__CourseSe__C9F49270B5F2E967");

            entity.ToTable("CourseSession");

            entity.Property(e => e.SessionId).HasColumnName("SessionID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");

            entity.HasOne(d => d.Course).WithMany(p => p.CourseSessions)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__CourseSes__Cours__3F466844");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BCD24611304");

            entity.ToTable("Department");

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.CollegeId).HasColumnName("CollegeID");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.HeadOfDepartment)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.College).WithMany(p => p.Departments)
                .HasForeignKey(d => d.CollegeId)
                .HasConstraintName("FK__Departmen__Colle__398D8EEE");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE3ADE9A3C8A");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => e.SectionId).HasName("PK__Section__80EF08920E8588A0");

            entity.ToTable("Section");

            entity.Property(e => e.SectionId)
                .ValueGeneratedNever()
                .HasColumnName("SectionID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.RoomNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SectionName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SemesterId).HasColumnName("SemesterID");

            entity.HasOne(d => d.Course).WithMany(p => p.Sections)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Section__CourseI__5FB337D6");

            entity.HasOne(d => d.Department).WithMany(p => p.Sections)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Section__Departm__60A75C0F");

            entity.HasOne(d => d.Semester).WithMany(p => p.Sections)
                .HasForeignKey(d => d.SemesterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Section__Semeste__619B8048");
        });

        modelBuilder.Entity<SectionStudent>(entity =>
        {
            entity.HasKey(e => e.SectionStudentId).HasName("PK__SectionS__807A9EC7C4E16663");

            entity.ToTable("SectionStudent");

            entity.Property(e => e.SectionStudentId).HasColumnName("SectionStudentID");
            entity.Property(e => e.SectionId).HasColumnName("SectionID");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Section).WithMany(p => p.SectionStudents)
                .HasForeignKey(d => d.SectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SectionSt__Secti__6477ECF3");

            entity.HasOne(d => d.Student).WithMany(p => p.SectionStudents)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SectionSt__Stude__656C112C");
        });

        modelBuilder.Entity<SectionSubject>(entity =>
        {
            entity.HasKey(e => e.SectionSubjectId).HasName("PK__SectionS__5BEE0FE3DBBF5966");

            entity.ToTable("SectionSubject");

            entity.Property(e => e.SectionSubjectId).HasColumnName("SectionSubjectID");
            entity.Property(e => e.SectionId).HasColumnName("SectionID");
            entity.Property(e => e.SubjectId).HasColumnName("SubjectID");
            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

            entity.HasOne(d => d.Section).WithMany(p => p.SectionSubjects)
                .HasForeignKey(d => d.SectionId)
                .HasConstraintName("FK__SectionSu__Secti__68487DD7");

            entity.HasOne(d => d.Subject).WithMany(p => p.SectionSubjects)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__SectionSu__Subje__693CA210");

            entity.HasOne(d => d.Teacher).WithMany(p => p.SectionSubjects)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__SectionSu__Teach__6A30C649");
        });

        modelBuilder.Entity<Semester>(entity =>
        {
            entity.HasKey(e => e.SemesterId).HasName("PK__Semester__043301BD6BB80B4B");

            entity.ToTable("Semester");

            entity.Property(e => e.SemesterId).HasColumnName("SemesterID");
            entity.Property(e => e.SessionId).HasColumnName("SessionID");

            entity.HasOne(d => d.Session).WithMany(p => p.Semesters)
                .HasForeignKey(d => d.SessionId)
                .HasConstraintName("FK__Semester__Sessio__4222D4EF");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staff__96D4AAF766FE5B99");

            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.HireDate).HasColumnType("date");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Department).WithMany(p => p.Staff)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Staff__Departmen__5BE2A6F2");

            entity.HasOne(d => d.User).WithMany(p => p.Staff)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Staff__UserID__5CD6CB2B");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52A79D40DED86");

            entity.ToTable("Student");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EnrollmentDate).HasColumnType("date");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.GraduationDate).HasColumnType("date");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Students)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Student__UserID__5535A963");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK__Subject__AC1BA388C5F473A7");

            entity.ToTable("Subject");

            entity.Property(e => e.SubjectId).HasColumnName("SubjectID");
            entity.Property(e => e.SemesterId).HasColumnName("SemesterID");
            entity.Property(e => e.SubjectCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.SubjectName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SubjectType)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Semester).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.SemesterId)
                .HasConstraintName("FK__Subject__Semeste__44FF419A");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK__Teacher__EDF259443ACA13A1");

            entity.ToTable("Teacher");

            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.HireDate).HasColumnType("date");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Department).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Teacher__Departm__5812160E");

            entity.HasOne(d => d.User).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Teacher__UserID__59063A47");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CCACD1EBFD70");

            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PasswordSalt)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RefreshTokenHash)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__User__RoleID__52593CB8");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

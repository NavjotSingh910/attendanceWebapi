using System;
using System.Collections.Generic;

namespace attendaceAppWebApi.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? ZipCode { get; set; }

    public DateTime? EnrollmentDate { get; set; }

    public DateTime? GraduationDate { get; set; }

    public int? UserId { get; set; }
    public int? RollNumber { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual ICollection<SectionStudent> SectionStudents { get; set; } = new List<SectionStudent>();

    public virtual User? User { get; set; }
}

using System;
using System.Collections.Generic;

namespace attendaceAppWebApi.Models;

public partial class Section
{
    public int SectionId { get; set; }

    public string SectionName { get; set; } = null!;

    public int CourseId { get; set; }

    public int DepartmentId { get; set; }

    public int SemesterId { get; set; }

    public int Capacity { get; set; }

    public string RoomNumber { get; set; } = null!;

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual Course Course { get; set; } = null!;

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<SectionStudent> SectionStudents { get; set; } = new List<SectionStudent>();

    public virtual ICollection<SectionSubject> SectionSubjects { get; set; } = new List<SectionSubject>();

    public virtual Semester Semester { get; set; } = null!;
}

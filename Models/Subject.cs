using System;
using System.Collections.Generic;

namespace attendaceAppWebApi.Models;

public partial class Subject
{
    public int SubjectId { get; set; }

    public string? SubjectName { get; set; }

    public string? SubjectCode { get; set; }

    public int? CreditHours { get; set; }

    public int? SemesterId { get; set; }

    public string? SubjectType { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual ICollection<SectionSubject> SectionSubjects { get; set; } = new List<SectionSubject>();

    public virtual Semester? Semester { get; set; }
}

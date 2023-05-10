using System;
using System.Collections.Generic;

namespace attendaceAppWebApi.Models;

public partial class Semester
{
    public int SemesterId { get; set; }

    public int? SessionId { get; set; }

    public int? SemesterNumber { get; set; }

    public int? SemesterLengthInMonth { get; set; }

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();

    public virtual CourseSession? Session { get; set; }

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}

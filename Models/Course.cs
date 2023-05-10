using System;
using System.Collections.Generic;

namespace attendaceAppWebApi.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string? CourseName { get; set; }

    public string? Location { get; set; }

    public string? PhoneNumber { get; set; }

    public int? DepartmentId { get; set; }

    public int? CourseDuration { get; set; }

    public int? NumberOfSemesters { get; set; }

    public virtual ICollection<CourseSession> CourseSessions { get; set; } = new List<CourseSession>();

    public virtual Department? Department { get; set; }

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
}

using System;
using System.Collections.Generic;

namespace attendaceAppWebApi.Models;

public partial class CourseSession
{
    public int SessionId { get; set; }

    public int? CourseId { get; set; }

    public int? StartYear { get; set; }

    public int? EndYear { get; set; }

    public virtual Course? Course { get; set; }

    public virtual ICollection<Semester> Semesters { get; set; } = new List<Semester>();
}

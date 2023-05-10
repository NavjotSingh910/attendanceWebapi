using System;
using System.Collections.Generic;

namespace attendaceAppWebApi.Models;

public partial class SectionStudent
{
    public int SectionStudentId { get; set; }

    public int SectionId { get; set; }

    public int StudentId { get; set; }

    public virtual Section Section { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace attendaceAppWebApi.Models;

public partial class SectionSubject
{
    public int SectionSubjectId { get; set; }

    public int? SectionId { get; set; }

    public int? SubjectId { get; set; }

    public int? TeacherId { get; set; }

    public virtual Section? Section { get; set; }

    public virtual Subject? Subject { get; set; }

    public virtual Teacher? Teacher { get; set; }
}

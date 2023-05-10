using System;
using System.Collections.Generic;

namespace attendaceAppWebApi.Models;

public partial class Attendance
{
    public int AttendanceId { get; set; }

    public int StudentId { get; set; }

    public int SubjectId { get; set; }

    public int SectionId { get; set; }

    public int TeacherId { get; set; }

    public DateTime Date { get; set; }

    public bool IsWorkingDay { get; set; }

    public bool IsPresent { get; set; }

    public bool IsOnLeave { get; set; }

    public virtual Section Section { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}

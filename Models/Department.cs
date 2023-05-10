using System;
using System.Collections.Generic;

namespace attendaceAppWebApi.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string? DepartmentName { get; set; }

    public string? Location { get; set; }

    public string? PhoneNumber { get; set; }

    public string? HeadOfDepartment { get; set; }

    public int? CollegeId { get; set; }

    public virtual College? College { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}

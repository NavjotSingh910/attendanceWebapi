using System;
using System.Collections.Generic;

namespace attendaceAppWebApi.Models;

public partial class College
{
    public int CollegeId { get; set; }

    public string? CollegeName { get; set; }

    public string? Location { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
}

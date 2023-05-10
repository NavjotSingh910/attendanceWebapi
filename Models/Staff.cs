using System;
using System.Collections.Generic;

namespace attendaceAppWebApi.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public DateTime? HireDate { get; set; }

    public int? DepartmentId { get; set; }

    public int? UserId { get; set; }

    public virtual Department? Department { get; set; }

    public virtual User? User { get; set; }
}

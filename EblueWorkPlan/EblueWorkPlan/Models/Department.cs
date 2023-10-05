using System;
using System.Collections.Generic;

namespace EblueWorkPlan.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; }

    public string DepartmentCode { get; set; }

    public int? DepartmentOf { get; set; }

    public int? DepartmentOldId { get; set; }

    public int? RosterDepartmentDirectorId { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}

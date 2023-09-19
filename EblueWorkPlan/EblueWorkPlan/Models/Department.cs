﻿namespace EblueWorkPlan.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public string DepartmentCode { get; set; } = null!;

    public int? DepartmentOf { get; set; }

    public int? DepartmentOldId { get; set; }

    public int? RosterDepartmentDirectorId { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}

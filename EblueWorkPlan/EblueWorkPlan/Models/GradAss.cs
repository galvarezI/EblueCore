using System;
using System.Collections.Generic;

namespace EblueWorkPlan.Models;

public partial class GradAss
{
    public int Gaid { get; set; }

    public string Gname { get; set; }

    public string Thesis { get; set; }

    public int? ProjectId { get; set; }

    public int? StudentId { get; set; }

    public decimal? Amount { get; set; }

    public int? RoleId { get; set; }

    public string StudentName { get; set; }

    public bool? IsGraduated { get; set; }

    public bool? IsUndergraduated { get; set; }

    public int? ThesisProjectId { get; set; }

    public int? GradoptionId { get; set; }

    public virtual GradOption Gradoption { get; set; }

    public virtual Project Project { get; set; }

    public virtual ThesisProject ThesisProject { get; set; }
}

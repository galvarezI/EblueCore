using System;
using System.Collections.Generic;

namespace EblueWorkPlan.Models;

public partial class FundType
{
    public int FundTypeId { get; set; }

    public string? FundTypeName { get; set; }

    public bool? IsFederal { get; set; }

    public bool? IsState { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}

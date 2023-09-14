using System;
using System.Collections.Generic;

namespace EblueWorkPlan.Models;

public partial class Porganization
{
    public int PorganizationId { get; set; }

    public string PorganizationName { get; set; } = null!;

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}

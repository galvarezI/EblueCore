using System;
using System.Collections.Generic;

namespace EblueWorkPlan.Models;

public partial class Commodity
{
    public int CommId { get; set; }

    public string CommName { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}

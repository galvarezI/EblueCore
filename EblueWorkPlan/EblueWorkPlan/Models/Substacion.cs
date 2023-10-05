using System;
using System.Collections.Generic;

namespace EblueWorkPlan.Models;

public partial class Substacion
{
    public int SubstationId { get; set; }

    public string SubStationName { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}

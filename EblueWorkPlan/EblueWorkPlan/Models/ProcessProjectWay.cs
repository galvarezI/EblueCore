using System;
using System.Collections.Generic;

namespace EblueWorkPlan.Models;

public partial class ProcessProjectWay
{
    public int ProcessProjectWayId { get; set; }

    public int ProjectId { get; set; }

    public int ProcessId { get; set; }

    public int EstatusId { get; set; }

    public virtual Project Project { get; set; }
}

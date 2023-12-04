using System;
using System.Collections.Generic;

namespace EblueWorkPlan.Models;

public partial class ProjectStatus
{
    public int ProjectstatusId { get; set; }

    public int? StatusNumber { get; set; }

    public string StatusName { get; set; }
}

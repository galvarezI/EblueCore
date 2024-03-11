using System;
using System.Collections.Generic;

namespace EblueWorkPlan.Models;

public partial class Analytical
{
    public int AnalyticalId { get; set; }

    public string AnalysisRequired { get; set; }

    public string NumSamples { get; set; }

    public DateTime? ProbableDate { get; set; }

    public int? ProjectId { get; set; }

    public virtual Project Project { get; set; }
}

using System;
using System.Collections.Generic;

namespace EblueWorkPlan.Models;

public partial class Laboratory
{
    public int LabId { get; set; }

    public string Areq { get; set; }

    public string NoSamples { get; set; }

    public DateTime? SamplesDate { get; set; }

    public int? ProjectId { get; set; }

    public virtual Project Project { get; set; }
}

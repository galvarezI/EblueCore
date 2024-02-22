using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EblueWorkPlan.Models;

public partial class Laboratory
{
    public int LabId { get; set; }

    public string Areq { get; set; }

    public string NoSamples { get; set; }


    [DataType(DataType.Date)]
    public DateTime? SamplesDate { get; set; }

    public int? ProjectId { get; set; }

    public string WorkPlanned { get; set; }

    public string Descriptions { get; set; }

    public string EstimatedTime { get; set; }

    public string FacilitiesNeeded { get; set; }

    [DataType(DataType.Date)]
    public DateTime? TimeEstimated { get; set; }

    public virtual Project Project { get; set; }
}

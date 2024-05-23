using System;
using System.Collections.Generic;

namespace EblueWorkPlan.Models;

public partial class FieldWork
{
    public int FieldWorkId { get; set; }

    public int ProjectId { get; set; }

    public int LocationId { get; set; }

    public DateTime? DateStarted { get; set; }

    public DateTime? DateEnded { get; set; }

    public bool InProgress { get; set; }

    public bool ToBeInitiated { get; set; }

    public string Wfieldwork { get; set; }

    public string Area { get; set; }

    public int? FieldoptionId { get; set; }

    public virtual FieldOption Fieldoption { get; set; }

    public virtual Locationn Location { get; set; }

    public virtual Project Project { get; set; }
}

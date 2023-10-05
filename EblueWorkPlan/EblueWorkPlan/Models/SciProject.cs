using System;
using System.Collections.Generic;

namespace EblueWorkPlan.Models;

public partial class SciProject
{
    public int SciId { get; set; }

    public int RosterId { get; set; }

    public int Roles { get; set; }

    public int? Credits { get; set; }

    public decimal? Tr { get; set; }

    public decimal? Ca { get; set; }

    public decimal? Ah { get; set; }

    public bool? AdHonorem { get; set; }

    public int? ProjectId { get; set; }

    public virtual Roster Project { get; set; }

    public virtual Roster Roster { get; set; }
}

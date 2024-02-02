using System;
using System.Collections.Generic;

namespace EblueWorkPlan.Models;

public partial class OtherPersonel
{
    public int Opid { get; set; }

    public string Name { get; set; }

    public decimal? PerTime { get; set; }

    public int? ProjectId { get; set; }

    public int? LocationId { get; set; }

    public int? RosterId { get; set; }

    public string PersonnelManAdded { get; set; }

    public string RoleManAdded { get; set; }

    public virtual Locationn Location { get; set; }

    public virtual Project Project { get; set; }

    public virtual Roster Roster { get; set; }
}

using System;
using System.Collections.Generic;

namespace EblueWorkPlan.Models;

public partial class Role
{
    public int RolesId { get; set; }

    public string? Rname { get; set; }

    public bool? IsResearchDirector { get; set; }

    public bool? IsExecutiveOfficer { get; set; }

    public bool? IsAdministrativeOfficer { get; set; }

    public bool? IsExternalResources { get; set; }

    public int? RosterId { get; set; }

    public virtual Roster? Roster { get; set; }
}

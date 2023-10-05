using System;
using System.Collections.Generic;

namespace EblueWorkPlan.Models;

public partial class ProgramArea
{
    public int ProgramAreaId { get; set; }

    public string ProgramAreaName { get; set; }

    public int? ProgramAreaOldId { get; set; }

    public int? RosterProgragmaticCoordinatorId { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}

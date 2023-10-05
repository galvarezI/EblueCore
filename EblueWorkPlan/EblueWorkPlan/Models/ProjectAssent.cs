using System;
using System.Collections.Generic;

namespace EblueWorkPlan.Models;

public partial class ProjectAssent
{
    public int PassentsId { get; set; }

    public int? ProjectId { get; set; }

    public int? RosterId { get; set; }

    public int? RoleId { get; set; }

    public string SignData { get; set; }

    public DateTime SignDate { get; set; }

    public string RosterData { get; set; }
}

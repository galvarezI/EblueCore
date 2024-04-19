using System;
using System.Collections.Generic;

namespace EblueWorkPlan.Models;

public partial class SciRole
{
    public int SciRolesId { get; set; }

    public string SciRoleName { get; set; }

    public virtual ICollection<SciProject> SciProjects { get; set; } = new List<SciProject>();
}

using System;
using System.Collections.Generic;

namespace EblueWorkPlan.Models;

public partial class GradOption
{
    public int GradoptionId { get; set; }

    public string GradOptionName { get; set; }

    public virtual ICollection<GradAss> GradAsses { get; set; } = new List<GradAss>();
}

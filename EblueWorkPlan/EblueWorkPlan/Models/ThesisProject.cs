﻿using System;
using System.Collections.Generic;

namespace EblueWorkPlan.Models;

public partial class ThesisProject
{
    public int ThesisProjectId { get; set; }

    public string OptionName { get; set; }

    public virtual ICollection<GradAss> GradAsses { get; set; } = new List<GradAss>();

    public virtual ICollection<SciProject> SciProjects { get; set; } = new List<SciProject>();
}

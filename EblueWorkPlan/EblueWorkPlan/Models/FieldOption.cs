using System;
using System.Collections.Generic;

namespace EblueWorkPlan.Models;

public partial class FieldOption
{
    public int FieldoptionId { get; set; }

    public string OptionName { get; set; }

    public virtual ICollection<FieldWork> FieldWorks { get; set; } = new List<FieldWork>();
}

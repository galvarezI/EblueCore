using System;
using System.Collections.Generic;

namespace EblueWorkPlan.Models;

public partial class Locationn
{
    public int LocationId { get; set; }

    public string LocationName { get; set; } = null!;

    public int? LocationOldId { get; set; }

    public string? FundsVar { get; set; }

    public virtual ICollection<FieldWork> FieldWorks { get; set; } = new List<FieldWork>();

    public virtual ICollection<Fund> Funds { get; set; } = new List<Fund>();

    public virtual ICollection<OtherPersonel> OtherPersonels { get; set; } = new List<OtherPersonel>();
}

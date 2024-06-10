using System;
using System.Collections.Generic;

namespace EblueWorkPlan.Models;

public partial class Fund
{
    public int FundId { get; set; }

    public int LocationId { get; set; }

    public decimal? Salaries { get; set; }

    public decimal? Wages { get; set; }

    public decimal? Benefits { get; set; }

    public decimal? Assistant { get; set; }

    public decimal? Materials { get; set; }

    public decimal? Equipment { get; set; }

    public decimal? Travel { get; set; }

    public decimal? Abroad { get; set; }

    public decimal? Subcontracts { get; set; }

    public decimal? Others { get; set; }

    public int ProjectId { get; set; }

    public string Ufisaccount { get; set; }

    public decimal? IndirectCosts { get; set; }

    public decimal? TotalAmount { get; set; }

    public virtual Locationn Location { get; set; }

    public virtual Project Project { get; set; }
}

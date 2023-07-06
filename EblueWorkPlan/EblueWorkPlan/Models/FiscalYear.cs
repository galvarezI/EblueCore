using System;
using System.Collections.Generic;

namespace EblueWorkPlan.Models;

public partial class FiscalYear
{
    public int FiscalYearId { get; set; }

    public string FiscalYearName { get; set; } = null!;

    public string FiscalYearNumber { get; set; } = null!;

    public DateTime LastUpdate { get; set; }

    public int FiscalYearStatusId { get; set; }

    public virtual FiscalYearStatus FiscalYearStatus { get; set; } = null!;

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}

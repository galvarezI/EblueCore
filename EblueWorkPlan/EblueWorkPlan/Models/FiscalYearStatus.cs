using System;
using System.Collections.Generic;

namespace EblueWorkPlan.Models;

public partial class FiscalYearStatus
{
    public int FiscalYearStatusId { get; set; }

    public string FiscalYearStatusName { get; set; }

    public virtual ICollection<FiscalYear> FiscalYears { get; set; } = new List<FiscalYear>();
}

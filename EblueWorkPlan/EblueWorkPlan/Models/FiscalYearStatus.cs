namespace EblueWorkPlan.Models;

public partial class FiscalYearStatus
{
    public int FiscalYearStatusId { get; set; }

    public string FiscalYearStatusName { get; set; } = null!;

    public virtual ICollection<FiscalYear> FiscalYears { get; set; } = new List<FiscalYear>();
}

namespace EblueWorkPlan.Models;

public partial class Commodity
{
    public int CommId { get; set; }

    public string CommName { get; set; } = null!;

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}

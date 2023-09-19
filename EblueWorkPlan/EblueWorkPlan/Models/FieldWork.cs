namespace EblueWorkPlan.Models;

public partial class FieldWork
{
    public int FieldWorkId { get; set; }

    public int ProjectId { get; set; }

    public int LocationId { get; set; }

    public DateTime DateStarted { get; set; }

    public DateTime DateEnded { get; set; }

    public bool InProgress { get; set; }

    public bool ToBeInitiated { get; set; }

    public string? FieldWork1 { get; set; }

    public string? Area { get; set; }

    public virtual Locationn Location { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;
}

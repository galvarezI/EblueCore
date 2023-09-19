namespace EblueWorkPlan.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public int? RosterId { get; set; }

    public bool? IsEnabled { get; set; }

    public virtual Roster? Roster { get; set; }
}

namespace EblueWorkPlan.Models.ViewModels
{
    public class RosterVM: Roster
    {

        public virtual Department Departments { get; set; }
        public virtual Locationn Locationns { get; set; }
        public virtual Role Roles { get; set; }

    }
}

namespace EblueWorkPlan.Models.ViewModels
{
    public class SciProjectVM
    {

        public int sciPId { get; set; }

        public int rosterId { get; set; }

        //public int Roles { get; set; }

        public decimal? credit { get; set; }

        public decimal? tr { get; set; }

        public decimal? ca { get; set; }

        public decimal? ah { get; set; }

        //public bool? AdHonorem { get; set; }

        public int? projectId { get; set; }

        public virtual Project Project { get; set; }

        public virtual Roster Roster { get; set; }
    }
}

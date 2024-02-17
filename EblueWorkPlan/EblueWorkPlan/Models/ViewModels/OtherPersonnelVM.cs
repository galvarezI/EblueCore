namespace EblueWorkPlan.Models.ViewModels
{
    public class OtherPersonnelVM
    {

        public int Opid { get; set; }

        public string perName { get; set; }

        public decimal? pertime { get; set; }

        public int? projectId { get; set; }

        public int? locationid { get; set; }

        public int? rosterid { get; set; }

        public string personnelman { get; set; }

        public string roleman { get; set; }

        public virtual Locationn Location { get; set; }

        public virtual Project Project { get; set; }

        public virtual Roster Roster { get; set; }


    }
}

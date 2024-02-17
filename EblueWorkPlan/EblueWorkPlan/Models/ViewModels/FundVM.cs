namespace EblueWorkPlan.Models.ViewModels
{
    public class FundVM
    {


        public int fundId { get; set; }

        public int locationId { get; set; }

        public decimal? salaries { get; set; }

        public decimal? wages { get; set; }

        public decimal? benefit { get; set; }

        public decimal? assistant { get; set; }

        public decimal? materials { get; set; }

        public decimal? equipment { get; set; }

        public decimal? travel { get; set; }

        public decimal? abroad { get; set; }

        public decimal? subcontract { get; set; }

        public decimal? others { get; set; }

        public int projectId { get; set; }

        public string ufisaccount { get; set; }

        public decimal? indirectcosts { get; set; }

        public virtual Locationn Location { get; set; }

        public virtual Project Project { get; set; }
    }
}

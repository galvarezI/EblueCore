namespace EblueWorkPlan.Models.ViewModels
{
    public class AnalyticalVM
    {
        public int analitycalId { get; set; }

        public string analysis { get; set; }

        public string numSamples { get; set; }

        public string pblDate { get; set; }

        public int? ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}

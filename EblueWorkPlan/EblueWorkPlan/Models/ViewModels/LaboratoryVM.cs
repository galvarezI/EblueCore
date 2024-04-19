using System.ComponentModel.DataAnnotations;

namespace EblueWorkPlan.Models.ViewModels
{
    public class LaboratoryVM
    {


        public int LabId { get; set; }

        public string Areq { get; set; }

        public string NoSamples { get; set; }

        [DataType(DataType.Date)]
        public DateTime? SamplesDate { get; set; }

        public int? ProjectId { get; set; }

        public string WorkPlanned { get; set; }

        public string Descriptions { get; set; }

        [DataType(DataType.Date)]
        public DateTime? TimeEstimated { get; set; }


        public string CentralLaboratory { get; set; }

        public string FacilitiesNeeded { get; set; }

        public virtual Project Project { get; set; }
    }
}

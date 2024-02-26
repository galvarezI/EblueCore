namespace EblueWorkPlan.Models.ViewModels
{
    public class GradassVM
    {
        public int gradId { get; set; }

        public string gname { get; set; }

        public string thesis { get; set; }

        public int? projectId { get; set; }

        public int? student { get; set; }

        public decimal? amount { get; set; }

        public int? RoleId { get; set; }

        public string studentName { get; set; }

        public int? gradoption { get; set; }

        public int? thesisid { get; set; }

        public bool? isGraduated { get; set; }

        public bool? isUndergraduated { get; set; }

        public virtual Project Project { get; set; }
    }
}

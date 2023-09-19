using System.ComponentModel.DataAnnotations;



namespace EblueWorkPlan.Models.ViewModels
{
    public class FiscalYearViewModel
    {
        public int FiscalYearId { get; set; }

        [Display(Name = "Fiscal Year Name")]
        public string FiscalYearName { get; set; }

        [Display(Name = "Fiscal Year Number")]
        public string FiscalYearNumber { get; set; }




        [Display(Name = "Fiscal Year Status")]
        public int FiscalYearStatusId { get; set; }


    }
}

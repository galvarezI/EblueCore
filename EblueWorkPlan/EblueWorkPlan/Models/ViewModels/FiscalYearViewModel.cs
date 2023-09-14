using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using EblueWorkPlan.Models;



namespace EblueWorkPlan.Models.ViewModels
{
    public class FiscalYearViewModel
    {
        public int FiscalYearId { get; set; }

        [Display(Name ="Fiscal Year Name")]
        public string FiscalYearName { get; set; }

        [Display(Name ="Fiscal Year Number")]
        public string FiscalYearNumber { get; set; }

        [Display(Name = "Last Update")]
        public DateTime LastUpdate { get; set; }


        [Display(Name ="Fiscal Year Status")]
        public int FiscalYearStatusId { get; set; }


    }
}

using System.ComponentModel.DataAnnotations;

namespace EblueWorkPlan.Models.ViewModels
{
    public class FundVM
    {


        public int fundId { get; set; }

        public string LocationId { get; set; }

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

       

        public decimal? indirectcosts { get; set; }

        

        //public virtual Project Project { get; set; }





        //[DisplayFormat(DataFormatString = "{0:N2}")]
        //public decimal? Salaries { get; set; }

        //[DisplayFormat(DataFormatString = "{0:N2}")]
        //public decimal? Wages { get; set; }

        //[DisplayFormat(DataFormatString = "{0:N2}")]
        //public decimal? Benefits { get; set; }

        //[DisplayFormat(DataFormatString = "{0:N2}")]
        //public decimal? Assistant { get; set; }

        //[DisplayFormat(DataFormatString = "{0:N2}")]
        //public decimal? Materials { get; set; }

        //[DisplayFormat(DataFormatString = "{0:N2}")]
        //public decimal? Equipment { get; set; }

        //[DisplayFormat(DataFormatString = "{0:N2}")]
        //public decimal? Travel { get; set; }

        //[DisplayFormat(DataFormatString = "{0:N2}")]
        //public decimal? Abroad { get; set; }

        //[DisplayFormat(DataFormatString = "{0:N2}")]
        //public decimal? Subcontracts { get; set; }

        //[DisplayFormat(DataFormatString = "{0:N2}")]
        //public decimal? Others { get; set; }


        //public int ProjectId { get; set; }

        //[DisplayFormat(DataFormatString = "{0:N2}")]
        //public string Ufisaccount { get; set; }

        //[DisplayFormat(DataFormatString = "{0:N2}")]
        //public decimal? IndirectCosts { get; set; }

        //[DisplayFormat(DataFormatString = "{0:N2}")]
        //public decimal? TotalAmount { get; set; }




    }
}

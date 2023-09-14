using Microsoft.Build.Framework;
using Microsoft.CodeAnalysis.CSharp;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EblueWorkPlan.Models.ViewModels
{
    public class ProjectViewModel
    {
        public int ProjectId { get; set; }



        [Display(Name = "Project Number")]
        public int ProjectNumber { get; set; }

        [Display(Name = "Project Short Title")]
        public string? ProjectTitle { get; set; }

        [Display(Name = "Department")]

        public int? DepartmentId { get; set; }

        [Display(Name = "Commodity")]

        public int? CommId { get; set; }

        [Display(Name = "Programatic Area")]

        public int? ProgramAreaId { get; set; }

        [Display(Name = "Substation or Region")]

        public int? SubStationId { get; set; }

        [Display(Name = "Type of Funds")]

        public int? FundTypeId { get; set; }

        [Display(Name = "Award/Accession/Contract Number")]

        public string? ContractNumber { get; set; }

        [Display(Name = "Account Number")]

        public string? Orcid { get; set; }

        [Display(Name = "Performing Organizations")]

        public int? PorganizationsId { get; set; }

        [Display(Name = "Location")]

        public int? LocationId { get; set; }


        public string? ProjectPi { get; set; }

        [Display(Name = "Principal Investigator")]

        public int? RosterId { get; set; }

        [Display(Name = "Fiscal Year")]

        public int? FiscalYearId { get; set; }


        public Roster roster { get; set; }
        public Department department { get; set; }
        public Locationn locationn { get; set; }
        public Porganization porganization { get; set; }
        public FiscalYear fiscalYear { get; set; } 
        public FundType fundType { get; set; }
        public Commodity Commodity { get; set; }
        public ProgramArea programArea { get; set;}
        public Substacion substacion { get; set; } 
        

    }
   

    


    
}

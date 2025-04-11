using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EblueWorkPlan.Models.ViewModels
{
    public class ProjectViewModel
    {
        //public int ProjectId { get; set; }

        public Project oProject { get; set; }
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Project Number")]
        public string ProjectNumber { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Project Short Title")]
        public string? ProjectTitle { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Department")]

        public int? DepartmentId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Commodity")]

        public int? CommId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Programatic Area")]

        public int? ProgramAreaId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Substation or Region")]

        public int? SubStationId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [NotMapped]
        public int[] SubStationSelectedArray { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Type of Funds")]

        public int? FundTypeId { get; set; }

        [Display(Name = "Award/Accession/Contract Number")]

        public string? ContractNumber { get; set; }

        [Display(Name = "Account Number")]

        public string? Orcid { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Performing Organizations")]

        public int? PorganizationsId { get; set; }


        public string? OtherFundtype { get; set; }


        public string? ProjectPi { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Principal Investigator")]

        public int? RosterId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Fiscal Year")]

        public int? FiscalYearId { get; set; }



        public string Facilities { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Project Impact")]
        public string Impact { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Salaries { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Materials { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Equipment { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Travel { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Abroad { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Others { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Wages { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Benefits { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Assistant { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Subcontracts { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string IndirectCosts { get; set; }


        public virtual Project Projects { get; set; }
        public virtual Roster Rosters { get; set; }
        public virtual FieldWork Fieldworks { get; set; }

        public virtual Fund Funds { get; set; }

        public virtual GradAss GradAss { get; set; }

        public virtual Laboratory Laboratorys { get; set; }

        public virtual Analytical Analyticals { get; set; }

        public virtual OtherPersonel OtherPersonels { get; set; }

        public virtual SciProject SciProjects { get; set; }



    }






}

using System.ComponentModel.DataAnnotations;

namespace EblueWorkPlan.Models.ViewModels
{
    public class ProjectFormView
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

        [Display(Name = "Performing Organization")]

        public int? PorganizationsId { get; set; }

        [Display(Name = "Location")]

        public int? LocationId { get; set; }

        [Display(Name = "Principal Investigator")]
        public string? ProjectPi { get; set; }

        [Display(Name = "Pricipal Investigator")]

        public int? RosterId { get; set; }

        [Display(Name = "Fiscal Year")]

        public int? FiscalYearId { get; set; }


        [Display(Name = "Project Objective(s)")]
        public string? Objectives { get; set; }


        [Display(Name = "Objective of Work Planned for the Year")]
        public string? ObjWorkPlan { get; set; }

        [Display(Name = "Work Accomplished and Present Outlook")]
        public string? PresentOutlook { get; set; }


        [Display(Name = " Work Planned (Field Work)")]
        public string? FieldWork1 { get; set; }


        [Display(Name = " Area(Acres)")]
        public string? Area { get; set; }


    }
}

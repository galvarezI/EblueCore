using System.ComponentModel.DataAnnotations;

namespace EblueWorkPlan.Models.ViewModels
{
    public class ProjectFormView
    {
        public Project oProject { get; set; }
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



        public int FieldWorkId { get; set; }





        public DateTime DateStarted { get; set; }

        public DateTime DateEnded { get; set; }

        public bool InProgress { get; set; }

        public bool ToBeInitiated { get; set; }


        //from Model Laboratory:


        public int LabId { get; set; }

        public string Areq { get; set; }

        public string NoSamples { get; set; }

        public DateTime? SamplesDate { get; set; }



        //From Analytical:

        public int AnalyticalId { get; set; }

        public string AnalysisRequired { get; set; }

        public string NumSamples { get; set; }

        public DateTime? ProbableDate { get; set; }




        //From SciProjects

        public int SciId { get; set; }

      

        public int Roles { get; set; }

        public int? Credits { get; set; }

        public decimal? Tr { get; set; }

        public decimal? Ca { get; set; }

        public decimal? Ah { get; set; }

        public bool? AdHonorem { get; set; }





        // From Other Personnel


        public int Opid { get; set; }

        public string Name { get; set; }

        public int? PerTime { get; set; }

       

        public string PersonnelManAdded { get; set; }

        public string RoleManAdded { get; set; }




        // For Gradass:

        public int Gaid { get; set; }

        public string Gname { get; set; }

        public string Thesis { get; set; }

        

        public int? StudentId { get; set; }

        public decimal? Amount { get; set; }

        public int? RoleId { get; set; }

        public string StudentName { get; set; }

        public bool? IsGraduated { get; set; }

        public bool? IsUndergraduated { get; set; }




        //For Funds:


        public int FundId { get; set; }


        public string Facilities { get; set; }

        public string Impact { get; set; }

      

        public string Materials { get; set; }

        public string Equipment { get; set; }

        public string Travel { get; set; }

        public string Abroad { get; set; }

        public string Others { get; set; }

        public int? Wfsid { get; set; }

        public DateTime? Wfupdate { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? TerminationDate { get; set; }

    

        public string WorkPlan2 { get; set; }

        public string Wages { get; set; }


        public decimal? Salaries { get; set; }

      

        public decimal? Benefits { get; set; }

        public decimal? Assistant { get; set; }

      

        public decimal? Subcontracts { get; set; }

 

      

        public string Ufisaccount { get; set; }

        public decimal? IndirectCosts { get; set; }

    }
}

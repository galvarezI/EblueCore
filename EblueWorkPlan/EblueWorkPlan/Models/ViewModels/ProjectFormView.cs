using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EblueWorkPlan.Models.ViewModels
{
    public class ProjectFormView
    {
        public Project oProject { get; set; }
        public int ProjectId { get; set; }
        public int idParameter { get; set; }


        [Display(Name = "Project Number")]
        public string ProjectNumber { get; set; }

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

        [NotMapped]
        public int[] SubStationSelectedArray { get; set; }

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


        public string Substation { get; set; }

        [Display(Name = "Project Objective(s)")]
        public string? Objectives { get; set; }

        [Display(Name = "Project Objective(s)")]
        public string Objectives2 { get; set; }

        [Display(Name = "Project Objective(s)")]
        public string Objectives3 { get; set; }


        [Display(Name = "Project Objective(s)")]
        public string Objectives4 { get; set; }

        [Display(Name = "Project Objective(s)")]

        public string Objectives5 { get; set; }


        [Display(Name = "Project Objective(s)")]
        public string Objectives6 { get; set; }




        [Display(Name = "Objective of Work Planned for the Year")]
        public string? ObjWorkPlan { get; set; }

        [Display(Name = "Work Accomplished and Present Outlook")]
        public string? PresentOutlook { get; set; }


        [Display(Name = " Work Planned (1) (Field Work)")]
        public string Wfieldwork { get; set; }


        [Display(Name = " Area(Acres)")]
        public string Area { get; set; }



        public int FieldWorkId { get; set; }




        
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateStarted { get; set; }

        public string DateStartedStr { get; set; }

        
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateEnded { get; set; }

        public string DateEndedStr { get; set; }

        [Display(Name = "Status")]
        public int? FieldoptionId { get; set; }

        public bool InProgress { get; set; }

        public bool ToBeInitiated { get; set; }


        //from Model Laboratory:


        public int LabId { get; set; }

        public string Areq { get; set; }

        public string NoSamples { get; set; }



        public DateTime? SamplesDate { get; set; }

        [Display(Name = " Work Planned (2) ")]
        public string WorkPlanned { get; set; }

        [Display(Name = " \tEstimated Time in Which Results\r\nwill be Available.")]
        public DateTime? TimeEstimated { get; set; }

        public string TimeEstimatedStr { get; set; }

        [Display]
        public string Descriptions { get; set; }

        public string EstimatedTime { get; set; }

        public string FacilitiesNeeded { get; set; }

        [Display(Name = " Services of Central Analytical Laboratory")]
        public string CentralLaboratory { get; set; }


        //From Analytical:

        public int AnalyticalId { get; set; }

        [Display(Name = " Analysis ")]
        public string AnalysisRequired { get; set; }

        [Display(Name = " # of Samples")]
        public string NumSamples { get; set; }


        public DateTime? ProbableDate { get; set; }

        public string ProbableDateStr { get; set; }



        //From SciProjects

        public int SciId { get; set; }



        public int Roles { get; set; }

        public Double? Credits { get; set; }

        [Display(Name = "TR")]
        public decimal? Tr { get; set; }
        [Display(Name = "CA")]
        public decimal? Ca { get; set; }
        [Display(Name = "AH")]
        public decimal? Ah { get; set; }

        public bool? AdHonorem { get; set; }

        [Display(Name = "Role")]
        public int? SciRolesId { get; set; }



        // From Other Personnel


        public int Opid { get; set; }

        public string Name { get; set; }
        [Display(Name = "% of Time")]
        public decimal? PerTime { get; set; }


        [Display(Name = "Personnel  Added ")]
        public string PersonnelManAdded { get; set; }

        [Display(Name = "Role Added")]
        public string RoleManAdded { get; set; }




        // For Gradass:

        public int Gaid { get; set; }

        [Display(Name = "Name")]
        public string Gname { get; set; }

        [Display(Name = "Thesis title")]
        public string Thesis { get; set; }

        [Display(Name = "Thesis or Project")]
        public int? ThesisProjectId { get; set; }


        [Display(Name = "Graduate or Undergraduate")]
        public int? GradoptionId { get; set; }


        public int? StudentId { get; set; }

        [Display(Name = "Student ID")]
        public decimal? Amount { get; set; }

        public int? RoleId { get; set; }

        public string StudentName { get; set; }

        [Display(Name = "Graduated")]
        public bool IsGraduated { get; set; }

        [Display(Name = "Undergraduated")]
        public bool IsUndergraduated { get; set; }




        //For Funds:


        public int FundId { get; set; }


        public string Facilities { get; set; }

        [Display(Name = "Project Impact")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public string Impact { get; set; }


        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? Materials { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? Equipment { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? Travel { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? Abroad { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? Others { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal TotalAmount { get; set; }

        public int? Wfsid { get; set; }

        public DateTime? Wfupdate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}",ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? TerminationDate { get; set; }



        public string WorkPlan2 { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? Wages { get; set; }


        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? Salaries { get; set; }


        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? Benefits { get; set; }


        [DisplayFormat(DataFormatString = "{0:N2}")]
        [Display(Name = "Assistanships")]
        public decimal? Assistant { get; set; }


        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? Subcontracts { get; set; }





        public string Ufisaccount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? IndirectCosts { get; set; }



        #region totalfunds

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? TSalaries { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? TWages { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? TBenefits { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? TAssistant { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? TMaterials { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? TEquipment { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? TTravel { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? TAbroad { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? TSubcontracts { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? TOthers { get; set; }

        
      


        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? TIndirectCosts { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? TTotalAmount { get; set; }



        #endregion





        //from Project Status

        public int ProjectstatusId { get; set; }

        public int? StatusNumber { get; set; }

        public string StatusName { get; set; }



        //From Project Notes

        public int ProjectNotesId { get; set; }

        [Display (Name="Leave your Comment Here!")]
        public string Comment { get; set; }

        [Display(Name =" last Update")]
        public DateTime? LastUpdate { get; set; }

        public int? UserId { get; set; }


        [Display(Name = " Role")]
        public string userRole { get; set; }

        public string Username { get; set; }


        [Display(Name = " Department Director Comments")]
        public string DepartmentDirectorComments { get; set; }


        [Display(Name = " Representative of the\r\nAssociate Dean")]
        public string DeanComments { get; set; }



        //Admin Comments...
        public int AdminOfficerCommentsId { get; set; }


        [Display(Name = "  Comments")]
        public string AdComments { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]

        [Display(Name = " Start Date")]
        public DateTime? ProjectVigency { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]

        [Display(Name = " End Date")]
        public DateTime? ReviewDate { get; set; }

        [Display(Name = "  Budget Distribution")]
        public string WorkplanQuantity { get; set; }

        [Display(Name = " Total Funding of the Project")]
        public string FundsComments { get; set; }

        public string UserRole { get; set; }


        public virtual AdminOfficerComment AdminOfficerComment { get; set; }

        public virtual User User { get; set; }


        public virtual Project Projects { get; set; }
        public virtual Roster Rosters { get; set; }
        public virtual FieldWork Fieldworks { get; set; }

        public virtual Fund Funds { get; set; }

        public virtual GradAss GradAss { get; set; }

        public virtual Laboratory Laboratorys { get; set; }

        public virtual Analytical Analyticals { get; set; }

        public virtual OtherPersonel OtherPersonels { get; set; }

        public virtual SciProject SciProjects { get; set; }
        public virtual Project Project { get; set; }
        public virtual Roster Roster { get; set; }
        public virtual FieldWork Fieldwork { get; set; }

        public virtual Fund Fund { get; set; }

        public virtual GradAss GradAs { get; set; }

        public virtual Laboratory Laboratory { get; set; }

        public virtual Analytical Analytical { get; set; }

        public virtual OtherPersonel OtherPersonel { get; set; }

        public virtual SciProject SciProject { get; set; }

        public virtual Locationn Location { get; set; }

        public virtual GradOption Gradoption { get; set; }

        public virtual ThesisProject ThesisProject { get; set; }

        

        //Lista de Proyectos Custom

        public IEnumerable<AdminOfficerComment> AdminOfficerComments { get; set; }
        public IEnumerable<Fund>Fundss { get; set; }
        public IEnumerable<Laboratory> laboratories { get; set; }
        public IEnumerable<Analytical> analyticals { get; set; }
        public IEnumerable<SciProject>sciProjects { get; set; }
        public IEnumerable<OtherPersonel> otherPersonels { get; set; }
        public IEnumerable<GradAss> gradAsses { get; set; }
        public IEnumerable<FieldWork> fieldsWork { get; set; }
        public IEnumerable<Project> projects { get; set; }
        public IEnumerable<ProjectNote> projectNotes { get; set; }
        public IList<ProjectFormView> ProjectItem {get; set;}


    }
}

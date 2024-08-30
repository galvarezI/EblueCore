using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EblueWorkPlan.Models;

public partial class Project
{
    public int ProjectId { get; set; }

    [Display(Name = "Project Number")]
    public string ProjectNumber { get; set; }

    [Display(Name = "Project Short Title")]
    public string ProjectTitle { get; set; }

    [Display(Name = "Department")]
    public int? DepartmentId { get; set; }

    [Display(Name = "Commodity")]
    public int? CommId { get; set; }

    [Display(Name = "Program Area")]
    public int? ProgramAreaId { get; set; }

    [Display(Name = "Substation")]
    public int? SubStationId { get; set; }

    public DateTime? DateRegister { get; set; }

    public DateTime? LastUpdate { get; set; }

    [Display(Name = "Fiscal Year")]
    public int? FiscalYearId { get; set; }

    public string Objectives { get; set; }

    public string ObjWorkPlan { get; set; }

    public string PresentOutlook { get; set; }

    public string Wp1fieldWork { get; set; }

    public int? Wp2id { get; set; }

    public string Workplan2Desc { get; set; }

    public string ResultsAvailable { get; set; }

    public string Facilities { get; set; }

    public string Impact { get; set; }

    public string Salaries { get; set; }

    public string Materials { get; set; }

    public string Equipment { get; set; }

    public string Travel { get; set; }

    public string Abroad { get; set; }

    public string Others { get; set; }

    public int? Wfsid { get; set; }

    public DateTime? Wfupdate { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? TerminationDate { get; set; }

    public int? FundTypeId { get; set; }

    public string WorkPlan2 { get; set; }

    public string Wages { get; set; }

    public string Benefits { get; set; }

    public string Assistant { get; set; }

    public string Subcontracts { get; set; }

    public string IndirectCosts { get; set; }

    public string ContractNumber { get; set; }

    [Display(Name = "Account Number")]
    public string Orcid { get; set; }

    public int? ProcessProjectWayId { get; set; }

    public int? PorganizationsId { get; set; }

    public int? LocationId { get; set; }

    public string ProjectPi { get; set; }

    public int? RosterId { get; set; }

    public string Objectives2 { get; set; }

    public string Objectives3 { get; set; }

    public string Objectives4 { get; set; }

    public string Objectives5 { get; set; }

    public string Objectives6 { get; set; }

    public string Substation { get; set; }

    public int? ProjectStatusId { get; set; }

    public virtual ICollection<AdminOfficerComment> AdminOfficerComments { get; set; } = new List<AdminOfficerComment>();

    public virtual ICollection<Analytical> Analyticals { get; set; } = new List<Analytical>();

    public virtual Commodity Comm { get; set; }

    public virtual Department Department { get; set; }

    public virtual ICollection<FieldWork> FieldWorks { get; set; } = new List<FieldWork>();

    public virtual FiscalYear FiscalYear { get; set; }

    public virtual FundType FundType { get; set; }

    public virtual ICollection<Fund> Funds { get; set; } = new List<Fund>();

    public virtual ICollection<GradAss> GradAsses { get; set; } = new List<GradAss>();

    public virtual ICollection<Laboratory> Laboratories { get; set; } = new List<Laboratory>();

    public virtual Locationn Location { get; set; }

    public virtual ICollection<OtherPersonel> OtherPersonels { get; set; } = new List<OtherPersonel>();

    public virtual Porganization Porganizations { get; set; }

    public virtual ProgramArea ProgramArea { get; set; }

    public virtual ICollection<ProjectNote> ProjectNotes { get; set; } = new List<ProjectNote>();

    public virtual ProjectStatus ProjectStatus { get; set; }

    public virtual Roster Roster { get; set; }

    public virtual ICollection<SciProject> SciProjects { get; set; } = new List<SciProject>();

    public virtual Substacion SubStation { get; set; }
}

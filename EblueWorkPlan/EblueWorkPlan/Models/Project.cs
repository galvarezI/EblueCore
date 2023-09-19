namespace EblueWorkPlan.Models;

public partial class Project
{
    public int ProjectId { get; set; }

    public int ProjectNumber { get; set; }

    public string? ProjectTitle { get; set; }

    public int? DepartmentId { get; set; }

    public int? CommId { get; set; }

    public int? ProgramAreaId { get; set; }

    public int? SubStationId { get; set; }

    public DateTime? DateRegister { get; set; }

    public DateTime? LastUpdate { get; set; }

    public int ProjectStatusId { get; set; }

    public int? FiscalYearId { get; set; }

    public string? Objectives { get; set; }

    public string? ObjWorkPlan { get; set; }

    public string? PresentOutlook { get; set; }

    public string? Wp1fieldWork { get; set; }

    public int? Wp2id { get; set; }

    public string? Workplan2Desc { get; set; }

    public string? ResultsAvailable { get; set; }

    public string? Facilities { get; set; }

    public string? Impact { get; set; }

    public string? Salaries { get; set; }

    public string? Materials { get; set; }

    public string? Equipment { get; set; }

    public string? Travel { get; set; }

    public string? Abroad { get; set; }

    public string? Others { get; set; }

    public int? Wfsid { get; set; }

    public DateTime? Wfupdate { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? TerminationDate { get; set; }

    public int? FundTypeId { get; set; }

    public string? WorkPlan2 { get; set; }

    public string? Wages { get; set; }

    public string? Benefits { get; set; }

    public string? Assistant { get; set; }

    public string? Subcontracts { get; set; }

    public string? IndirectCosts { get; set; }

    public string? ContractNumber { get; set; }

    public string? Orcid { get; set; }

    public int? ProcessProjectWayId { get; set; }

    public int? PorganizationsId { get; set; }

    public int? LocationId { get; set; }

    public string? ProjectPi { get; set; }

    public int? RosterId { get; set; }

    public virtual ICollection<Analytical> Analyticals { get; set; } = new List<Analytical>();

    public virtual Commodity? Comm { get; set; }

    public virtual Department? Department { get; set; }

    public virtual ICollection<FieldWork> FieldWorks { get; set; } = new List<FieldWork>();

    public virtual FiscalYear? FiscalYear { get; set; }

    public virtual FundType? FundType { get; set; }

    public virtual ICollection<Fund> Funds { get; set; } = new List<Fund>();

    public virtual ICollection<GradAss> GradAsses { get; set; } = new List<GradAss>();

    public virtual ICollection<Laboratory> Laboratories { get; set; } = new List<Laboratory>();

    public virtual Locationn? Location { get; set; }

    public virtual ICollection<OtherPersonel> OtherPersonels { get; set; } = new List<OtherPersonel>();

    public virtual Porganization? Porganizations { get; set; }

    public virtual ProgramArea? ProgramArea { get; set; }

    public virtual Roster? Roster { get; set; }

    public virtual Substacion? SubStation { get; set; }
}

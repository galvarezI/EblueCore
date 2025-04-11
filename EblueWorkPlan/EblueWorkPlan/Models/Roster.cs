using System;
using System.Collections.Generic;

namespace EblueWorkPlan.Models;

public partial class Roster
{
    public int RosterId { get; set; }

    public string RosterSegSoc { get; set; }

    public string RosterName { get; set; }

    public int DepartmentId { get; set; }

    public int LocationId { get; set; }

    public bool CanBePi { get; set; }

    public int? RoleId { get; set; }

    public string Email { get; set; }

    public virtual ICollection<OtherPersonel> OtherPersonels { get; set; } = new List<OtherPersonel>();

    public virtual ICollection<ProjectNote> ProjectNotes { get; set; } = new List<ProjectNote>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();

    public virtual ICollection<SciProject> SciProjects { get; set; } = new List<SciProject>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}

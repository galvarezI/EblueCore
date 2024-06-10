using System;
using System.Collections.Generic;

namespace EblueWorkPlan.Models;

public partial class AdminOfficerComment
{
    public int AdminOfficerCommentsId { get; set; }

    public string AdComments { get; set; }

    public DateTime? ProjectVigency { get; set; }

    public DateTime? ReviewDate { get; set; }

    public string WorkplanQuantity { get; set; }

    public string FundsComments { get; set; }

    public int? ProjectId { get; set; }

    public string Username { get; set; }

    public string UserRole { get; set; }

    public virtual Project Project { get; set; }
}

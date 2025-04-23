using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EblueWorkPlan.Models;

public partial class AdminOfficerComment
{
    public int AdminOfficerCommentsId { get; set; }

    public string AdComments { get; set; }

    [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? ProjectVigency { get; set; }

    [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? ReviewDate { get; set; }

    public string WorkplanQuantity { get; set; }

    public string FundsComments { get; set; }

    public int? ProjectId { get; set; }

    public string Username { get; set; }

    public string UserRole { get; set; }

    public virtual Project Project { get; set; }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EblueWorkPlan.Models;

public partial class FieldWork
{
    public int FieldWorkId { get; set; }

    public int ProjectId { get; set; }

    [Display(Name ="Location")]
    public int LocationId { get; set; }
    [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]

    public DateTime? DateStarted { get; set; }
    [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? DateEnded { get; set; }

    public bool InProgress { get; set; }

    public bool ToBeInitiated { get; set; }


    [Display(Name = "Fieldwork")]
    public string Wfieldwork { get; set; }

    public string Area { get; set; }

    [Display(Name = "To be Initiated or In Progress")]
    public int? FieldoptionId { get; set; }

    public virtual FieldOption Fieldoption { get; set; }

    public virtual Locationn Location { get; set; }

    public virtual Project Project { get; set; }
}

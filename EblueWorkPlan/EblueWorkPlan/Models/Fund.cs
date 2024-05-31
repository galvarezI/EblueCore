using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EblueWorkPlan.Models;

public partial class Fund
{
    public int FundId { get; set; }

    public int LocationId { get; set; }

    [DisplayFormat(DataFormatString = "{0:N2}")]
    public decimal? Salaries { get; set; }
    [DisplayFormat(DataFormatString = "{0:N2}")]
    public decimal? Wages { get; set; }
    [DisplayFormat(DataFormatString = "{0:N2}")]
    public decimal? Benefits { get; set; }
    [DisplayFormat(DataFormatString = "{0:N2}")]
    public decimal? Assistant { get; set; }
    [DisplayFormat(DataFormatString = "{0:N2}")]
    public decimal? Materials { get; set; }
    [DisplayFormat(DataFormatString = "{0:N2}")]
    public decimal? Equipment { get; set; }
    [DisplayFormat(DataFormatString = "{0:N2}")]
    public decimal? Travel { get; set; }
    [DisplayFormat(DataFormatString = "{0:N2}")]
    public decimal? Abroad { get; set; }
    [DisplayFormat(DataFormatString = "{0:N2}")]
    public decimal? Subcontracts { get; set; }
    [DisplayFormat(DataFormatString = "{0:N2}")]
    public decimal? Others { get; set; }
    [DisplayFormat(DataFormatString = "{0:N2}")]
    public int ProjectId { get; set; }
 
    public string Ufisaccount { get; set; }
    [DisplayFormat(DataFormatString = "{0:N2}")]
    public decimal? IndirectCosts { get; set; }
    [DisplayFormat(DataFormatString = "{0:N2}")]
    public decimal? TotalAmount { get; set; }

    public virtual Locationn Location { get; set; }

    public virtual Project Project { get; set; }
}

﻿using System;
using System.Collections.Generic;

namespace EblueWorkPlan.Models;

public partial class AspNetUserClaim
{
    public int Id { get; set; }

    public string UserId { get; set; }

    public string ClaimType { get; set; }

    public string ClaimValue { get; set; }

    public virtual AspNetUser User { get; set; }
}

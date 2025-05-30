﻿using System;
using System.Collections.Generic;

namespace EblueWorkPlan.Models;

public partial class AspNetUserToken
{
    public string UserId { get; set; }

    public string LoginProvider { get; set; }

    public string Name { get; set; }

    public string Value { get; set; }

    public virtual AspNetUser User { get; set; }
}

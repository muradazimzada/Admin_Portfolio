﻿using System;
using System.Collections.Generic;

namespace Admin_Portfolio.Data.Models;

public partial class Skill
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Percent { get; set; }
}

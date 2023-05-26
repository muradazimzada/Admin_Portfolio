using System;
using System.Collections.Generic;

namespace Admin_Portfolio.Data.Models;

public partial class Counter
{
    public int Id { get; set; }

    public int? Count { get; set; }

    public string? Subtitle { get; set; }

    public string? Icon { get; set; }
}

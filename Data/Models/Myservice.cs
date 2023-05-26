using System;
using System.Collections.Generic;

namespace Admin_Portfolio.Data.Models;

public partial class Myservice
{
    public int Id { get; set; }

    public string Header { get; set; } = null!;

    public string Subtitle { get; set; } = null!;

    public string Icon { get; set; } = null!;
}

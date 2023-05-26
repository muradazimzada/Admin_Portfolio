using System;
using System.Collections.Generic;

namespace Admin_Portfolio.Data.Models;

public partial class Language
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Percent { get; set; }
}

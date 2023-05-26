using System;
using System.Collections.Generic;

namespace Admin_Portfolio.Data.Models;

public partial class About
{
    public int Id { get; set; }

    public string? Fullname { get; set; }

    public string? Work { get; set; }

    public string? Header { get; set; }

    public string? Subtitle { get; set; }

    public string? Birthdate { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Skype { get; set; }

    public string? Address { get; set; }
}

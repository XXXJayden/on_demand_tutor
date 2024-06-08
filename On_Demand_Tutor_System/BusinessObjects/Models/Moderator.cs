using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Moderator
{
    public int ModId { get; set; }

    public string Fullname { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;
}

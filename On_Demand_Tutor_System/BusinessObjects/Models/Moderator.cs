using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Moderator
{
    public int ModId { get; set; }

    public int TutorId { get; set; }

    public decimal Price { get; set; }

    public virtual Tutor Tutor { get; set; } = null!;
}

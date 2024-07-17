using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class TutorService
{
    public int Id { get; set; }

    public int ServiceId { get; set; }

    public int TutorId { get; set; }

    public decimal Price { get; set; }

    public virtual Service Service { get; set; } = null!;

    public virtual Tutor Tutor { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Report
{
    public int Id { get; set; }

    public string Detail { get; set; } = null!;

    public string Date { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string Image { get; set; } = null!;

    public int StudentId { get; set; }

    public int TutorId { get; set; }

    public int ServiceId { get; set; }

    public virtual Service Service { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;

    public virtual Tutor Tutor { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Feedback
{
    public int FbId { get; set; }

    public int TutorId { get; set; }

    public int StudentId { get; set; }

    public int Rating { get; set; }

    public string Detail { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;

    public virtual Tutor Tutor { get; set; } = null!;
}

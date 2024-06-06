using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Achievement
{
    public int AchievementId { get; set; }

    public int TutorId { get; set; }

    public string Certificate { get; set; } = null!;

    public virtual Tutor Tutor { get; set; } = null!;
}

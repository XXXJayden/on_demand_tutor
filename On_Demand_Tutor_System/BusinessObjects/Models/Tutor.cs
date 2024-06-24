using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Tutor
{
    public int TutorId { get; set; }

    public string Fullname { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string? Description { get; set; }

    public string Major { get; set; } = null!;

    public string Grade { get; set; } = null!;

    public string Avatar { get; set; } = null!;

    public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<TutorService> TutorServices { get; set; } = new List<TutorService>();
}

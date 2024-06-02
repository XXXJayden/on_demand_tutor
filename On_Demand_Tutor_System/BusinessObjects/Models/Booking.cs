using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Booking
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int TutorId { get; set; }

    public int ServiceId { get; set; }

    public int StatusId { get; set; }

    public virtual ICollection<BookingSchedule> BookingSchedules { get; set; } = new List<BookingSchedule>();

    public virtual Service Service { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;

    public virtual Tutor Tutor { get; set; } = null!;
}

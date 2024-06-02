using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Schedule
{
    public int Id { get; set; }

    public string Date { get; set; } = null!;

    public string Slot { get; set; } = null!;

    public virtual ICollection<BookingSchedule> BookingSchedules { get; set; } = new List<BookingSchedule>();
}

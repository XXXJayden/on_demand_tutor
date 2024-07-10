using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class BookingSchedule
{
    public int Id { get; set; }

    public int BookingId { get; set; }

    public int ScId { get; set; }

    public string Date { get; set; } = null!;

    public virtual Booking Booking { get; set; } = null!;

    public virtual Schedule Sc { get; set; } = null!;
}

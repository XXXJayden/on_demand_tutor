using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Status
{
    public int StatusId { get; set; }

    public string Status1 { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}

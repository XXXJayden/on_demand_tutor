using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Service
{
    public int Id { get; set; }

    public string Service1 { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<TutorService> TutorServices { get; set; } = new List<TutorService>();
}

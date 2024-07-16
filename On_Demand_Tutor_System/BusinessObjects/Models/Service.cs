using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Models;

public partial class Service
{
    public int Id { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "Service name can't be longer than 100 characters.")]
    public string Service1 { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual ICollection<TutorService> TutorServices { get; set; } = new List<TutorService>();
}

namespace BusinessObjects.Models;

public partial class Booking
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int TutorId { get; set; }

    public int ServiceId { get; set; }

    public string Status { get; set; } = null!;

    public DateOnly? DateStart { get; set; }

    public DateOnly? DateEnd { get; set; }

    public virtual ICollection<BookingSchedule> BookingSchedules { get; set; } = new List<BookingSchedule>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual Service Service { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;

    public virtual Tutor Tutor { get; set; } = null!;
}

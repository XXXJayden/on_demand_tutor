using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.DTO.Booking
{
    public class BookingTutorResponse
    {
        public int Id { get; set; }
        [Display(Name = "Student Name")]
        public string StudentName { get; set; }

        public int TutorId { get; set; }

        [Display(Name = "Service Name")]
        public string ServiceName { get; set; }

        public string Status { get; set; } = null!;

        public DateOnly? DateStart { get; set; }

        public DateOnly? DateEnd { get; set; }
        public string PaymentMethods { get; set; }
        [Display(Name = "Payment Method")]

        public List<string> Schedules { get; set; } = new List<string>();

    }
}

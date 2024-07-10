using BusinessObjects.Enums.Booking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO.Booking
{
    public class ProcessingLearning
    {
        public int Id { get; set; }
        [Display(Name = "Tutor Name")]
        public string TutorName { get; set; }
        public int TutorId { get; set; }
        public string Email { get; set; }
        public int StudentId { get; set; }

        [Display(Name = "Service Name")]
        public string ServiceName { get; set; }

        public string Status { get; set; } = BookingStatus.Approve;

        public DateOnly? DateStart { get; set; }

        public DateOnly? DateEnd { get; set; }
        public string PaymentMethods { get; set; }

        public List<string> Schedules { get; set; } = new List<string>();
    }
}

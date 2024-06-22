using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO.Booking
{
    public class BookingRequest
    {
        public string ServiceName { get; set; }
        public int TutorId { get; set; }
        public string Date { get; set; }
        public string Slot { get; set; }
    }
}

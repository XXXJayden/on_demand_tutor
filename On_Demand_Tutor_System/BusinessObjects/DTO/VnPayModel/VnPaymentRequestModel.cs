using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO.VnPayModel
{
    public class VnPaymentRequestModel
    {
        public int ServiceId { get; set; }
        public int TutorId { get; set; }
        public int StudentId { get; set; }
        public decimal Amount { get; set; }
        public int BookingId { get; set; }
    }
}

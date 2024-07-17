using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Enums.Booking
{
    public class BookingStatus
    {
        public static readonly string Complete = "Complete";
        public static readonly string Pending = "Pending";
        public static readonly string Approve = "Approve";
        public static readonly string Cancel = "Cancel";
        public static readonly string Proccessing = "Proccessing";
    }

    public class PaymentStatus
    {
        public static readonly string Paid = "Paid";
        public static readonly string Unpaid = "UnPaid";
    }
}

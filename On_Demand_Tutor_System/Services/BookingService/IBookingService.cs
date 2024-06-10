using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BookingService
{
    public interface IBookingService
    {
        List<Booking> GetAllBooking();
        Booking GetBookingById(int id);
        void AddBooking(Booking booking);
        void UpdateBooking(Booking booking);

        void DeleteBooking(Booking booking);
    }
}

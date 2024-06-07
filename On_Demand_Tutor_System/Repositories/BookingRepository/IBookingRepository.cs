using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessObjects.Models;

namespace Repositories.BookingRepository
{
    public interface IBookingRepository
    {
        List<Booking> GetAllBooking();
        Booking GetBookingById(int id);
        void AddBooking(Booking booking);
        void UpdateBooking(Booking booking);

        void DeleteBooking(Booking booking);
        //Booking GetBookingByName(string name);
    }
}

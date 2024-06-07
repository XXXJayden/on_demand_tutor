using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.BookingScheduleRepository
{
    public interface IBookingScheduleRepository
    {
        List<BookingSchedule> GetAllBookingSchedule();
        BookingSchedule GetBookingScheduleById(int id);
        void AddBookingSchedule(BookingSchedule bookingSchedule);
        void UpdateBookingSchedule(BookingSchedule bookingSchedule);

        void DeleteBookingSchedule(BookingSchedule bookingSchedule);
    }
}

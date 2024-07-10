using BusinessObjects.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.BookingScheduleRepository
{
    public class BookingScheduleRepository : IBookingScheduleRepository
    {
        public void AddBookingSchedule(BookingSchedule bookingSchedule)
        => BookingScheduleDAO.AddBookingSchedule(bookingSchedule);

        public void DeleteBookingSchedule(BookingSchedule bookingSchedule)
            => BookingScheduleDAO.DeleteBookingSchedule(bookingSchedule);

        public List<BookingSchedule> GetAllBookingSchedule()
            => BookingScheduleDAO.GetAllBookingSchedule();

        public BookingSchedule GetBookingScheduleById(int id)
            => BookingScheduleDAO.GetBookingScheduleById(id);

        public void UpdateBookingSchedule(BookingSchedule bookingSchedule)
            => BookingScheduleDAO.UpdateBookingSchedule(bookingSchedule);

    }
}

using BusinessObjects.Models;
using Repositories.BookingScheduleRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BookingScheduleService
{
    public class BookingScheduleService : IBookingScheduleService
    {
        private readonly IBookingScheduleRepository bookingScheduleRepository;

        public BookingScheduleService()
        {
            bookingScheduleRepository = new BookingScheduleRepository();
        }

        public void AddBookingSchedule(BookingSchedule bookingSchedule)
        {
            bookingScheduleRepository.AddBookingSchedule(bookingSchedule);
        }

        public void DeleteBookingSchedule(BookingSchedule bookingSchedule)
        {
            bookingScheduleRepository.DeleteBookingSchedule(bookingSchedule);
        }

        public List<BookingSchedule> GetAllBookingSchedule()
        {
            return bookingScheduleRepository.GetAllBookingSchedule();
        }

        public BookingSchedule GetBookingScheduleById(int id)
        {
            return bookingScheduleRepository.GetBookingScheduleById(id);
        }


        public void UpdateBookingSchedule(BookingSchedule bookingSchedule)
        {
            bookingScheduleRepository.UpdateBookingSchedule(bookingSchedule);
        }
    }
}

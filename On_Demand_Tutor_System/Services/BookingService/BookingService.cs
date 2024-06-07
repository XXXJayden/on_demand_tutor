using BusinessObjects.Models;
using Repositories.BookingRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BookingService
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository bookingRepository;

        public BookingService()
        {
            bookingRepository = new BookingRepository();
        }
        public void AddBooking(Booking booking)
        {
            bookingRepository.AddBooking(booking);
        }

        public void DeleteBooking(Booking booking)
        {
            bookingRepository.DeleteBooking(booking);
        }

        public List<Booking> GetAllBooking()
        {
            return bookingRepository.GetAllBooking();   
        }

        public Booking GetBookingById(int id)
        {
            return bookingRepository.GetBookingById(id);
        }

        public void UpdateBooking(Booking booking)
        {
            bookingRepository.UpdateBooking(booking);   
        }
    }
}

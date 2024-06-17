using BusinessObjects.Models;
using Repositories.BookingRepository;

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

        public List<Booking> GetAllBookingTutor()
        {
            return bookingRepository.GetAllBookingTutor();
        }

        public Booking GetBookingById(int id)
        {
            return bookingRepository.GetBookingById(id);
        }

        public Booking GetDetailsBookingById(int id)
        {
            return bookingRepository.GetDetailsBookingById(id);
        }

        public void UpdateBooking(Booking booking)
        {
            bookingRepository.UpdateBooking(booking);
        }
    }
}

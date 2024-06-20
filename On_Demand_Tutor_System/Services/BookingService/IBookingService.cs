using BusinessObjects.Models;

namespace Services.BookingService
{
    public interface IBookingService
    {
        List<Booking> GetAllBooking();
        Booking GetBookingById(int id);
        void AddBooking(Booking booking);
        void UpdateBooking(Booking booking);
        List<Booking> GetAllBookingTutor();
        void DeleteBooking(Booking booking);

        Booking GetDetailsBookingById(int id);
    }
}

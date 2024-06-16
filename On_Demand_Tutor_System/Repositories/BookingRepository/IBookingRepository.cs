using BusinessObjects.Models;

namespace Repositories.BookingRepository
{
    public interface IBookingRepository
    {
        List<Booking> GetAllBooking();
        Booking GetBookingById(int id);
        void AddBooking(Booking booking);
        void UpdateBooking(Booking booking);
        List<Booking> GetAllBookingTutor();
        void DeleteBooking(Booking booking);
        //Booking GetBookingByName(string name);
    }
}

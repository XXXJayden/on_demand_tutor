using BusinessObjects.Models;
using DataAccessLayer;

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

        Booking GetDetailsBookingById(int id);
        void UpdateBookingStatusToPaid(int bookingId);
        Task<List<Booking>> GetStudentBookingById(int id);
        Task<List<Booking>> GetTutorBookingById(int id);
    }
}

using BusinessObjects.Models;
using DataAccessLayer;

namespace Repositories.BookingRepository
{
    public class BookingRepository : IBookingRepository
    {
        public void AddBooking(Booking booking) => BookingDAO.AddBooking(booking);

        public void DeleteBooking(Booking booking) => BookingDAO.DeleteCategory(booking);

        public List<Booking> GetAllBooking() => BookingDAO.GetAllBooking();

        public List<Booking> GetAllBookingTutor() => BookingDAO.GetAllBookingTutor();

        public Booking GetBookingById(int id) => BookingDAO.GetBookingById(id);

        public void UpdateBooking(Booking booking) => BookingDAO.UpdateBooking(booking);
    }
}

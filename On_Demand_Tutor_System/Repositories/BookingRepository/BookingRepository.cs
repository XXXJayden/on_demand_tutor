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

        public Booking GetDetailsBookingById(int id) => BookingDAO.GetDetailsBookingById(id);

        public void UpdateBooking(Booking booking) => BookingDAO.UpdateBooking(booking);

        public void UpdateBookingStatusToPaid(int bookingId) => BookingDAO.UpdateBookingStatusToPaid(bookingId);

        public async Task<List<Booking>> GetStudentBookingById(int id)
        {
            BookingDAO dao = new BookingDAO();
            return await dao.GetStudentBookingById(id);
        }
        public async Task<List<Booking>> GetTutorBookingById(int id)
        {
            BookingDAO dao = new BookingDAO();
            return await dao.GetTutorBookingById(id);
        }
    }
}

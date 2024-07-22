using BusinessObjects.Enums.Booking;
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

        public (int Complete, int Pending, int Approve, int Cancel, int Processing) GetBookingStatusCounts()
        {
            try
            {
                var bookings = bookingRepository.GetAllBooking();
                return (
                    Complete: bookings.Count(b => b.Status == BookingStatus.Complete),
                    Pending: bookings.Count(b => b.Status == BookingStatus.Pending),
                    Approve: bookings.Count(b => b.Status == BookingStatus.Approve),
                    Cancel: bookings.Count(b => b.Status == BookingStatus.Cancel),
                    Processing: bookings.Count(b => b.Status == BookingStatus.Proccessing)
                );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateBookingStatusToPaid(int bookId)
        {
            bookingRepository.UpdateBookingStatusToPaid(bookId);
        }

        public async Task<List<Booking>> GetStudentBookingById(int id)
        {
            return await bookingRepository.GetStudentBookingById(id);
        }
        public async Task<List<Booking>> GetTutorBookingById(int id)
        {
            return await bookingRepository.GetTutorBookingById(id);
        }

    }
}

using BusinessObjects.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.BookingRepository
{
    public class BookingRepository : IBookingRepository
    {
        public void AddBooking(Booking booking) => BookingDAO.AddBooking(booking);  

        public void DeleteBooking(Booking booking) => BookingDAO.DeleteCategory(booking);   

        public List<Booking> GetAllBooking() => BookingDAO.GetAllBooking();


        public Booking GetBookingById(int id) => BookingDAO.GetBookingById(id); 

        public void UpdateBooking(Booking booking) => BookingDAO.UpdateBooking(booking);    
    }
}

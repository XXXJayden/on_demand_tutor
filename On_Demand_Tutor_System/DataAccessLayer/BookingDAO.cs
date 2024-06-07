using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BookingDAO
    {
        public static List<Booking> GetAllBooking()
        {
            var listBookings = new List<Booking>();
            try
            {
                using var context = new OnDemandTutorDbContext();
                listBookings = context.Bookings.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listBookings;
        }

        public static Booking GetBookingById(int id)
        {
            using var context = new OnDemandTutorDbContext();
            return context.Bookings.FirstOrDefault(c => c.Id == id);
        }
        

        public static void AddBooking(Booking b)
        {
            try
            {
                using var context = new OnDemandTutorDbContext();
                context.Bookings.Add(b);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void UpdateBooking(Booking b)
        {
            try
            {
                using var context = new OnDemandTutorDbContext();
                context.Entry<Booking>(b).State
                    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteCategory(Booking b)
        {
            try
            {
                using var context = new OnDemandTutorDbContext();
                var p1 = context.Bookings.SingleOrDefault(c => c.Id == b.Id);
                context.Bookings.Remove(p1);

                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BookingScheduleDAO
    {
        public static List<BookingSchedule> GetAllBookingSchedule()
        {
            var listBookingSchedules = new List<BookingSchedule>();
            try
            {
                using var context = new OnDemandTutorDbContext();
                listBookingSchedules = context.BookingSchedules.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listBookingSchedules;
        }

        public static BookingSchedule GetBookingScheduleById(int id)
        {
            using var context = new OnDemandTutorDbContext();
            return context.BookingSchedules.FirstOrDefault(c => c.Id == id);
        }


        public static void AddBookingSchedule(BookingSchedule bs)
        {
            try
            {
                using var context = new OnDemandTutorDbContext();
                context.BookingSchedules.Add(bs);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void UpdateBookingSchedule(BookingSchedule bs)
        {
            try
            {
                using var context = new OnDemandTutorDbContext();
                context.Entry<BookingSchedule>(bs).State
                    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteBookingSchedule(BookingSchedule bs)
        {
            try
            {
                using var context = new OnDemandTutorDbContext();
                var p1 = context.BookingSchedules.SingleOrDefault(c => c.Id == bs.Id);
                context.BookingSchedules.Remove(p1);

                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

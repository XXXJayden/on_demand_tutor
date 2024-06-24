using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class ScheduleDAO
    {
        public static async Task<List<string>> GetAvailableSlotsAsync(int tutorId)
        {
            using var context = new OnDemandTutorDbContext();

            var bookedSlots = await context.BookingSchedules
                .Where(bs => bs.Booking.TutorId == tutorId)
                .Select(bs => bs.Sc.Slot)
                .ToListAsync();

            var allSlots = new List<string> { "Slot 1", "Slot 2", "Slot 3", "Slot 4", "Slot 5", "Slot 6" };

            var availableSlots = allSlots.Except(bookedSlots).ToList();

            return availableSlots;
        }

        public static List<Schedule> GetAllSchedule()
        {
            var listSchedules = new List<Schedule>();
            try
            {
                using var context = new OnDemandTutorDbContext();
                listSchedules = context.Schedules.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listSchedules;
        }

        public static Schedule GetScheduleById(int id)
        {
            using var context = new OnDemandTutorDbContext();
            return context.Schedules.FirstOrDefault(c => c.Id == id);
        }


        public static void AddSchedule(Schedule s)
        {
            try
            {
                using var context = new OnDemandTutorDbContext();
                context.Schedules.Add(s);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void UpdateSchedule(Schedule s)
        {
            try
            {
                using var context = new OnDemandTutorDbContext();
                context.Entry<Schedule>(s).State
                    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteSchedule(Schedule s)
        {
            try
            {
                using var context = new OnDemandTutorDbContext();
                var p1 = context.Bookings.SingleOrDefault(c => c.Id == s.Id);
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

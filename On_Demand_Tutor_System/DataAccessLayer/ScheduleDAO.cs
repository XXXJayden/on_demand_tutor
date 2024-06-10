using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ScheduleDAO
    {
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

using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class TutorServiceDAO
    {
        public static List<TutorService> GetAllTutorServices()
        {
            using var db = new OnDemandTutorDbContext();
            return db.TutorServices.Include(ts => ts.Tutor).Include(ts => ts.Service).ToList();
        }

        public static TutorService GetTutorServiceByServiceId(int id)
        {
            using var db = new OnDemandTutorDbContext();
            return db.TutorServices.FirstOrDefault(sr => sr.ServiceId == id);
        }

        public static void UpdateTutorService(TutorService tutorService)
        {
            using var db = new OnDemandTutorDbContext();
            db.TutorServices.Update(tutorService);
            db.SaveChanges();
        }

        public static void AddTutorService(TutorService newTutorService)
        {
            using var db = new OnDemandTutorDbContext();
            db.TutorServices.Add(newTutorService);
            db.SaveChanges();
        }

        public static void DeleteTutorService(int id)
        {
            using var db = new OnDemandTutorDbContext();
            var tutorService = db.TutorServices.Find(id);
            if (tutorService != null)
            {
                db.TutorServices.Remove(tutorService);
                db.SaveChanges();
            }
        }

        public static decimal GetTutorServicePrice(int tutorId, int serviceId)
        {
            using var db = new OnDemandTutorDbContext();
            var tutorService = db.TutorServices.FirstOrDefault(ts => ts.TutorId == tutorId && ts.ServiceId == serviceId);
            return tutorService?.Price ?? 0;
        }
    }
}

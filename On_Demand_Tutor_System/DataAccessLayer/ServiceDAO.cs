using BusinessObjects.Models;

namespace DataAccessLayer
{
    public class ServiceDAO
    {
        public static List<Service> GetAllServices()
        {
            using var db = new OnDemandTutorDbContext();
            return db.Services.ToList();
        }

        public static Service GetServiceById(int id)
        {
            using var db = new OnDemandTutorDbContext();
            return db.Services.Find(id);
        }

        public static void UpdateService(Service service)
        {
            using var db = new OnDemandTutorDbContext();
            db.Services.Update(service);
            db.SaveChanges();
        }

        public static void AddService(Service newService)
        {
            using var db = new OnDemandTutorDbContext();
            db.Services.Add(newService);
            db.SaveChanges();
        }

        public static void DeleteService(int id)
        {
            using var db = new OnDemandTutorDbContext();
            var service = db.Services.Find(id);
            if (service != null)
            {
                db.Services.Remove(service);
                db.SaveChanges();
            }
        }
    }
}

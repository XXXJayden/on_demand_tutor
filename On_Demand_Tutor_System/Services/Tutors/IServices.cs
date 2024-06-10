using BusinessObjects.Models;

namespace Services.Tutors
{
    public interface IServices
    {
        List<Service> GetServices();
        void AddService(Service service);
        void DeleteService(int id);
        void UpdateService(Service service);
    }
}

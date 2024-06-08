using BusinessObjects.Models;

namespace Repositories.Tutors
{
    public interface IServiceRepository
    {
        List<Service> GetServices();
        void AddService(Service service);
        void DeleteService(int id);
        void UpdateService(Service service);
    }
}

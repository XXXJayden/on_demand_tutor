using BusinessObjects.Models;
using DataAccessLayer;

namespace Repositories.Tutors
{
    public class ServiceRepository : IServiceRepository
    {
        public List<Service> GetServices() => ServiceDAO.GetAllServices();
        public void DeleteService(int id) => ServiceDAO.DeleteService(id);
        public void AddService(Service service) => ServiceDAO.AddService(service);
        public void UpdateService(Service service) => ServiceDAO.UpdateService(service);
    }
}

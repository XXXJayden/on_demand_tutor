using BusinessObjects.Models;
using DataAccessLayer;

namespace Repositories.ServiceRepository
{
    public class ServiceRepository : IServiceRepository
    {
        public List<Service> GetAllService() => ServiceDAO.GetAllServices();
        public Service GetServiceIdByName(string Name) => ServiceDAO.GetServiceByName(Name);
        public Service GetServiceById(int id) => ServiceDAO.GetServiceById(id);
        public void SaveService(Service ser) => ServiceDAO.AddService(ser);

        public void UpdateService(Service ser) => ServiceDAO.UpdateService(ser);

        public void DeleteService(int serId) => ServiceDAO.DeleteService(serId);

    }
}

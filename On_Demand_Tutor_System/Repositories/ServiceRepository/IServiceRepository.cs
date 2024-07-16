using BusinessObjects.Models;

namespace Repositories.ServiceRepository
{
    public interface IServiceRepository
    {
        List<Service> GetAllService();
        Service GetServiceIdByName(string Name);
        Service GetServiceById(int id);
        void SaveService(Service ser);
        void UpdateService(Service ser);
        void DeleteService(int serId);

    }
}

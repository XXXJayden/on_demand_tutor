using BusinessObjects.Models;

namespace Services.ServiceServices
{
    public interface IServiceServices
    {
        List<Service> GetAllServices();
        Service GetServiceIdByName(string Name);
        Service GetServiceById(int Id);
        void SaveService(Service ser);
        void UpdateService(Service ser);
        void DeleteService(int serId);
    }
}

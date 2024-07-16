using BusinessObjects.Models;
using Repositories.ServiceRepository;

namespace Services.ServiceServices
{
    public class ServiceService : IServiceServices
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public List<Service> GetAllServices()
        {
            return _serviceRepository.GetAllService();
        }
        public Service GetServiceIdByName(string Name)
        {
            return _serviceRepository.GetServiceIdByName(Name);
        }
        public Service GetServiceById(int serviceId)
        {
            return _serviceRepository.GetServiceById(serviceId);
        }
        public void SaveService(Service ser)
        {
            _serviceRepository.SaveService(ser);
        }

        public void UpdateService(Service ser)
        {
            _serviceRepository.UpdateService(ser);
        }

        public void DeleteService(int serId)
        {
            _serviceRepository.DeleteService(serId);
        }
    }
}

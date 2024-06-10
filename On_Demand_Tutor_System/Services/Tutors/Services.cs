using BusinessObjects.Models;
using Repositories.Tutors;

namespace Services.Tutors
{
    public class Services : IServices
    {
        private readonly ServiceRepository _iserviceRepository;
        public Services()
        {
            _iserviceRepository = new ServiceRepository();
        }

        public void AddService(Service service)
        {
            _iserviceRepository.AddService(service);
        }

        public void DeleteService(int id)
        {
            _iserviceRepository.DeleteService(id);
        }

        public List<Service> GetServices()
        {
            return _iserviceRepository.GetServices();
        }

        public void UpdateService(Service service)
        {
            _iserviceRepository.UpdateService(service);
        }
    }
}

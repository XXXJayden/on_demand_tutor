using BusinessObjects.Models;
using Repositories.ServiceRepository;
using Repositories.StudentRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}

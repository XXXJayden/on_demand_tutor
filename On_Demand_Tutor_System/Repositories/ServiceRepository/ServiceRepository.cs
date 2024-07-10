using BusinessObjects.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.ServiceRepository
{
    public class ServiceRepository : IServiceRepository
    {
        public List<Service> GetAllService() => ServiceDAO.GetAllServices();
        public Service GetServiceIdByName(string Name) => ServiceDAO.GetServiceByName(Name);

    }
}

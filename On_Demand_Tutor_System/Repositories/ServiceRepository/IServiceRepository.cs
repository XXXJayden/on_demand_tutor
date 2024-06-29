using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.ServiceRepository
{
    public interface IServiceRepository
    {
        List<Service> GetAllService();
        Service GetServiceIdByName(string Name);
    }
}

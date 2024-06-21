using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServiceServices
{
    public interface IServiceServices
    {
        List<Service> GetAllServices();
    }
}

using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.ServiceServices;

namespace On_Demand_Tutor_UI.Pages.Admin.ServicePrice
{
    public class IndexModel : PageModel
    {
        private IServiceServices _serviceService;

        public IndexModel(IServiceServices serviceServices)
        {
            _serviceService = serviceServices;
        }

        public IList<Service> Service { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Service = _serviceService.GetAllServices();
        }
    }
}
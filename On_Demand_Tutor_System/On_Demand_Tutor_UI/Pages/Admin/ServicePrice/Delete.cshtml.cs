using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.ServiceServices;
using Services.Tutors;

namespace On_Demand_Tutor_UI.Pages.Admin.ServicePrice
{
    public class DeleteModel : PageModel
    {
        private readonly IServiceServices _serviceService;
        private readonly ITutorService _tutorService;

        public DeleteModel(IServiceServices serviceServices, ITutorService tutorService)
        {
            _serviceService = serviceServices;
            _tutorService = tutorService;
        }

        [BindProperty]
        public Service Service { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = _serviceService.GetServiceById(id);

            if (service == null)
            {
                return NotFound();
            }
            else
            {
                Service = service;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var service = _serviceService.GetServiceById(id);
            var tutorService = _tutorService.GetTutorServiceByServiceId(id);

            if (service == null)
            {
                return NotFound();
            }

            if (tutorService != null)
            {
                ModelState.AddModelError(string.Empty, "Cannot delete this service as it is associated with a tutor.");
                return Page();
            }

            _serviceService.DeleteService(id);
            return RedirectToPage("./Index");
        }
    }
}
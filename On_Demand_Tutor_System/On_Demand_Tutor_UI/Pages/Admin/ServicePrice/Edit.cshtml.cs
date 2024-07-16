using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Services.ServiceServices;

namespace On_Demand_Tutor_UI.Pages.Admin.ServicePrice
{
    public class EditModel : PageModel
    {
        private readonly IServiceServices _serviceService;

        public EditModel(IServiceServices serviceServices)
        {
            _serviceService = serviceServices;
        }

        [BindProperty]
        public Service Service { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var service = _serviceService.GetServiceById(id);
            if (service == null)
            {
                return NotFound();
            }
            Service = service;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _serviceService.UpdateService(Service);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ServiceExists(Service.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private async Task<bool> ServiceExists(int id)
        {
            var service = _serviceService.GetServiceById(id);
            return service != null;
        }
    }
}

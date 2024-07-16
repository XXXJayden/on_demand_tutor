using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.ServiceServices;

namespace On_Demand_Tutor_UI.Pages.Admin.ServicePrice
{
    public class CreateModel : PageModel
    {
        private readonly IServiceServices _serviceService;

        public CreateModel(IServiceServices services)
        {
            _serviceService = services;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Service Service { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _serviceService.SaveService(Service);

            return RedirectToPage("./Index");
        }
    }
}
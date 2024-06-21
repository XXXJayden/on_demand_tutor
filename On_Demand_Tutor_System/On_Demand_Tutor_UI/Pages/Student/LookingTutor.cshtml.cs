using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Services.ServiceServices;

namespace On_Demand_Tutor_UI.Pages.Student
{
    public class LookingTutorModel : PageModel
    {
        private readonly IServiceServices _serviceServices;

        public LookingTutorModel(IServiceServices serviceServices)
        {
            _serviceServices = serviceServices;
        }

        public IList<Service> Services { get; set; } = new List<Service>();

        [BindProperty]
        public int Grade { get; set; } = default!;
        [BindProperty]
        public string Subject { get; set; } = default!;
        [BindProperty]
        public Service Service { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync(string Grade, string subject, Service servive)
        {
            if (Service == null) 
            {
                ModelState.AddModelError(string.Empty, "Wrong email or password!");
                return Page();
            }
            Services = _serviceServices.GetAllServices();
            return Page();
        }
    }
}

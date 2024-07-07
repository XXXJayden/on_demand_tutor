using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using Services.Tutors;
using Services.TutorServices;
using Services.ServiceServices;

namespace On_Demand_Tutor_UI.Pages.Tutor
{
    public class CreateServiceModel : PageModel
    {
        private readonly ITutorService _tutorService;
        private readonly IServiceServices _serviceServices;
        private readonly ITutorAccountService _tutorAccountService;

        public CreateServiceModel(ITutorService tutorService, IServiceServices serviceServices, ITutorAccountService tutorAccountService)
        {
            _tutorService = tutorService;
            _serviceServices = serviceServices;
            _tutorAccountService = tutorAccountService;
        }

        public List<TutorService> TutorServices { get; set; } = new List<TutorService>();

        public async Task<IActionResult> OnGetAsync()
        {
            var accTutor = HttpContext.Session.GetString("UserEmail");
            var tutorAll = _tutorAccountService.GetTutorByEmail(accTutor);

            var tutorServices = _tutorService.GetTutorServices().Where(ts => ts.TutorId == tutorAll.TutorId).ToList();
            TutorServices = tutorServices;

            var availableServices = _serviceServices.GetAllServices().Where(s => !tutorServices.Select(ts => ts.ServiceId).Contains(s.Id)).ToList();

            if (!availableServices.Any())
            {
                ModelState.AddModelError("", "No services available");
                return Page();
            }

            ViewData["Service"] = new SelectList(availableServices, "Id", "Service1");
            return Page();
        }

        [BindProperty]
        public TutorService TutorService { get; set; } = new TutorService();

        [BindProperty]
        public Service Service { get; set; } = new Service();

        public async Task<IActionResult> OnPostAsync()
        {
            var accTutor = HttpContext.Session.GetString("UserEmail");
            var tutorAll = _tutorAccountService.GetTutorByEmail(accTutor);

            var tutorServices = _tutorService.GetTutorServices().Where(ts => ts.TutorId == tutorAll.TutorId).ToList();
            TutorServices = tutorServices;

            var availableServices = _serviceServices.GetAllServices().Where(s => !tutorServices.Select(ts => ts.ServiceId).Contains(s.Id)).ToList();

            if (TutorService.Price == null)
            {
                ViewData["Service"] = new SelectList(availableServices, "Id", "Service1");
                return Page();
            }

            TutorService.TutorId = tutorAll.TutorId;
            TutorService.ServiceId = Service.Id;

            _tutorService.AddTutorService(TutorService);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int Id)
        {
            var accTutor = HttpContext.Session.GetString("UserEmail");
            var tutorAll = _tutorAccountService.GetTutorByEmail(accTutor);

            var tutorService = _tutorService.GetTutorServices().FirstOrDefault(ts => ts.TutorId == tutorAll.TutorId && ts.Id == Id);

            if (tutorService != null)
            {
                _tutorService.DeleteTutorService(Id);
            }

            return RedirectToPage();
        }
    }
}

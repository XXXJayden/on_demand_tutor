using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using On_Demand_Tutor_UI.Pages.AccountPages;
using Services.ServiceServices;
using Services.Tutors;
using Services.TutorServices;
using Services.ServiceServices;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Enums.User;

namespace On_Demand_Tutor_UI.Pages.Tutor
{
    public class CreateServiceModel : AuthenPageModel
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
            if (TutorService.Price < 100000 || TutorService.Price > 200000)
            {
                ModelState.AddModelError("TutorService.Price", "Price must be between 100,000 and 200,000 Vnđ.");

                var tutorServices = _tutorService.GetTutorServices().Where(ts => ts.TutorId == tutorAll.TutorId).ToList();
                TutorServices = tutorServices;

                var availableServices = _serviceServices.GetAllServices().Where(s => !tutorServices.Select(ts => ts.ServiceId).Contains(s.Id)).ToList();
                ViewData["Service"] = new SelectList(availableServices, "Id", "Service1");

                return Page();
            }

            TutorService.TutorId = tutorAll.TutorId;
            TutorService.ServiceId = Service.Id;

            try
            {
                tutorAll.Status = UserStatus.Pending;
                _tutorAccountService.UpdateTutor(tutorAll);
                _tutorService.AddTutorService(TutorService);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while saving the service. Please ensure the price is within the valid range.");

                var tutorServices = _tutorService.GetTutorServices().Where(ts => ts.TutorId == tutorAll.TutorId).ToList();
                TutorServices = tutorServices;

                var availableServices = _serviceServices.GetAllServices().Where(s => !tutorServices.Select(ts => ts.ServiceId).Contains(s.Id)).ToList();
                ViewData["Service"] = new SelectList(availableServices, "Id", "Service1");

                return Page();
            }

            return RedirectToPage();
        }


        public async Task<IActionResult> OnPostDeleteAsync(int Id)
        {
            var accTutor = HttpContext.Session.GetString("UserEmail");
            var tutorAll = _tutorAccountService.GetTutorByEmail(accTutor);

            var tutorService = _tutorService.GetTutorServices().FirstOrDefault(ts => ts.TutorId == tutorAll.TutorId && ts.Id == Id);

            if (tutorService != null)
            {
                tutorAll.Status = UserStatus.Pending;
                _tutorAccountService.UpdateTutor(tutorAll);
                _tutorService.DeleteTutorService(Id);
            }

            return RedirectToPage();
        }
    }
}

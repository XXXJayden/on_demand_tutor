using BusinessObjects.DTO.Tutor;
using BusinessObjects.Enums.User;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using On_Demand_Tutor_UI.Pages.AccountPages;
using Services.ServiceServices;
using Services.TutorServices;

namespace On_Demand_Tutor_UI.Pages.Student
{
    public class LookingTutorModel : AuthenPageModel
    {
        private readonly IServiceServices _serviceServices;
        private readonly ITutorAccountService _tutorAccountService;

        public LookingTutorModel(IServiceServices serviceServices, ITutorAccountService tutorAccountService)
        {
            _serviceServices = serviceServices;
            _tutorAccountService = tutorAccountService;
        }

        public IList<Service> Services { get; set; } = new List<Service>();

        [BindProperty]
        public SearchTutorDTO SearchTutor { get; set; } = new SearchTutorDTO();

        public IList<TutorServiceResponse> TutorServiceResponses { get; set; } = new List<TutorServiceResponse>();

        private void LoadTutor(SearchTutorDTO searchTutor)
        {
            var listTutor = _tutorAccountService.GetAllTutor().Where(x => x.Status.Equals(UserStatus.Active));
            var listTutorService = listTutor.Select(x => new TutorServiceResponse
            {
                TutorId = x.TutorId,
                Fullname = x.Fullname,
                Email = x.Email,
                Description = x.Description,
                Major = x.Major,
                Grade = x.Grade,
                Services = x.TutorServices.Select(sv => sv.Service.Service1).ToList()
            }).ToList();

            var searchGrade = searchTutor.grade;
            var searchSubject = searchTutor.subject;
            var searchService = searchTutor.serviceId;

            TutorServiceResponses = listTutorService.Where(x =>
                (string.IsNullOrEmpty(searchGrade) || x.Grade.ToLower().Contains(searchGrade.ToLower())) &&
                (string.IsNullOrEmpty(searchSubject) || x.Major.ToLower().Contains(searchSubject.ToLower())) &&
                (string.IsNullOrEmpty(searchService) || x.Services.Any(sv => sv.ToLower().Contains(searchService.ToLower())))
            ).ToList();
        }

        public async Task<IActionResult> OnGetAsync(SearchTutorDTO searchTutorDTO)
        {
            if (searchTutorDTO != null)
            {
                SearchTutor = searchTutorDTO;
                LoadTutor(searchTutorDTO);
            }

            Services = _serviceServices.GetAllServices();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            LoadTutor(SearchTutor);
            Services = _serviceServices.GetAllServices();
            return Page();
        }
    }

}

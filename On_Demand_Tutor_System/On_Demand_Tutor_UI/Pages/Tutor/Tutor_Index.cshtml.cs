using On_Demand_Tutor_UI.Pages.AccountPages;
using Services.TutorServices;

namespace On_Demand_Tutor_UI.Pages.Tutor
{
    public class Tutor_IndexModel : AuthenPageModel
    {
        private readonly ITutorAccountService _tutorAccountService;

        public Tutor_IndexModel(ITutorAccountService tutorAccountService) { 
        _tutorAccountService = tutorAccountService;
        }
        public string TutorStatus { get; set; }
        public void OnGet()
        {
            var accountTutor = HttpContext.Session.GetString("UserEmail");
            var tutor = _tutorAccountService.GetTutorByEmail(accountTutor);
            TutorStatus =  tutor.Status;
        }
    }
}

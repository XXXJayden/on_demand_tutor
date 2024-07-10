using BusinessObjects.DTO.Tutor;
using On_Demand_Tutor_UI.Pages.AccountPages;
using Services.TutorServices;

namespace On_Demand_Tutor_UI.Pages.Moderator.IncompleteTutor
{
    public class IncompleteIndex : AuthenPageModel
    {
        private readonly ITutorAccountService _tutorAccountService;

        public IncompleteIndex(ITutorAccountService tutorAccountService)
        {
            _tutorAccountService = tutorAccountService;
        }

        public IList<TutorViewDTO> IncompleteTutors { get; set; } = default!;

        public async Task OnGetAsync()
        {
            IncompleteTutors = await _tutorAccountService.GetTutorByIncompleteStatus();
        }
    }
}

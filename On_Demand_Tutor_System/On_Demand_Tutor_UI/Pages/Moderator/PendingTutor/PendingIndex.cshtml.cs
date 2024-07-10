using BusinessObjects.DTO.Tutor;
using On_Demand_Tutor_UI.Pages.AccountPages;
using Services.TutorServices;

namespace On_Demand_Tutor_UI.Pages.Moderator.PendingTutor
{
    public class PendingIndexModel : AuthenPageModel
    {
        private readonly ITutorAccountService _tutorAccountService;
        public IList<TutorViewDTO> PendingTutors { get; set; } = default!;

        public PendingIndexModel(ITutorAccountService tutorAccountService)
        {
            _tutorAccountService = tutorAccountService;
        }

        public async Task OnGetAsync()
        {
            PendingTutors = await _tutorAccountService.GetTutorByPendingStatus();
        }
    }
}

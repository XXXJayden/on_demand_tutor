using BusinessObjects.DTO.Tutor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.TutorServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace On_Demand_Tutor_UI.Pages.Moderator.PendingTutor
{
    public class PendingIndexModel : PageModel
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

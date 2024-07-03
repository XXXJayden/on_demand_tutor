using BusinessObjects.DTO.Tutor;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Services.TutorServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_Demand_Tutor_UI.Pages.Moderator.IncompleteTutor
{
    public class IncompleteIndex : PageModel
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

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
    public class IncompleteDetails : PageModel
    {
        private readonly ITutorAccountService _tutorAccountService;

        public IncompleteDetails(ITutorAccountService tutorAccountService)
        {
            _tutorAccountService = tutorAccountService;
        }

        public BusinessObjects.Models.Tutor Tutor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(short id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tutor = _tutorAccountService.GetTutorById(id);
            if (tutor == null)
            {
                return NotFound();
            }
            else
            {
                Tutor = tutor;
            }
            return Page();
        }
    }
}

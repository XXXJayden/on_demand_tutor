using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Services.TutorServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_Demand_Tutor_UI.Pages.Moderator.PendingTutor
{
    public class PendingDetails : PageModel
    {
        private readonly ITutorAccountService _tutorAccountService;

        public PendingDetails(ITutorAccountService tutorAccountService)
        {
            _tutorAccountService = tutorAccountService;
        }

        [BindProperty]
        public BusinessObjects.Models.Tutor Tutor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(short id)
        {
            var tutor = await _tutorAccountService.GetTutorById(id);

            if (id == null)
            {
                return NotFound();
            }

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

        public async Task<IActionResult> OnPostApproveAsync(short id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            await _tutorAccountService.ChangeStatusToActive(id);
            TempData["SuccessMessage"] = "This tutor has been approved";

            return RedirectToPage(new { id });
        }

        public async Task<IActionResult> OnPostDenyAsync(short id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            await _tutorAccountService.ChangeStatusToIncomplete(id);
            TempData["SuccessMessage"] = "This tutor has been denied";

            return RedirectToPage(new { id });
        }


    }
}

﻿using Microsoft.AspNetCore.Mvc;
using On_Demand_Tutor_UI.Pages.AccountPages;
using Services.TutorServices;

namespace On_Demand_Tutor_UI.Pages.Moderator.PendingTutor
{
    public class PendingDetails : AuthenPageModel
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
            var tutor = _tutorAccountService.GetTutorById(id);

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

            return RedirectToPage("/Moderator/PendingTutor/PendingIndex");
        }

        public async Task<IActionResult> OnPostDenyAsync(short id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            await _tutorAccountService.ChangeStatusToIncomplete(id);
            TempData["SuccessMessage"] = "This tutor has been denied";

            return RedirectToPage("/Moderator/PendingTutor/PendingIndex");
        }


    }
}

using BusinessObjects.DTO.Tutor;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.AccountService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_Demand_Tutor_UI.Pages.AccountPages
{
    public class TutorRegisterModel : PageModel
    {
        private readonly IAccountService accountService;

        public TutorRegisterModel(IAccountService accountservice)
        {
            this.accountService = accountservice;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TutorRegisterDTO Tutor { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (await accountService.EmailExistsAsync(Tutor.Email) == true)
            {
                ModelState.AddModelError("Tutor.Email", "An account with this email already exists.");
                return Page();
            }

            await accountService.RegisterTutorAsync(Tutor);

            return RedirectToPage("/Index");
        }
    }
}

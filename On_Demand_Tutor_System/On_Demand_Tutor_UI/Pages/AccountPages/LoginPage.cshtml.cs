using BusinessObjects.Models;
using DataAccessLayer;
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
    public class LoginPageModel : PageModel
    {
        private readonly IAccountService accountService;

        public LoginPageModel(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var (account, type) = await accountService.GetAccount(Email, Password);

            if (account != null)
            {
                HttpContext.Session.SetString("UserType", type);
                HttpContext.Session.SetString("UserEmail", Email);
                if (type == "Student")
                {
                    return RedirectToPage("/Index");
                }
                else if (type == "Tutor")
                {
                    return RedirectToPage("./TutorDashboard");
                }
            }

            return RedirectToPage("/Error");
        }
    }
}

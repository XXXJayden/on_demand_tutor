using BusinessObjects.DTO.Tutor;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using On_Demand_Tutor_UI.Validator;
using Services.AccountService;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace On_Demand_Tutor_UI.Pages.AccountPages
{
    public class TutorRegisterModel : TrimmedPageModel
    {
        private readonly IAccountService accountService;
        private readonly IConfiguration configuration;

        public TutorRegisterModel(IAccountService accountservice)
        {
            this.accountService = accountservice;
            this.configuration = configuration;
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
            TrimModelStrings(Tutor);
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (await accountService.TutorEmailExistsAsync(Tutor.Email) == true)
            {
                ModelState.AddModelError("Tutor.Email", "An account with this email already exists");
                return Page();
            }
            if (await accountService.StudentEmailExistsAsync(Tutor.Email) == true)
            {
                ModelState.AddModelError("Tutor.Email", "An account with this email already registerd for Student");
                return Page();
            }

            await accountService.RegisterTutorAsync(Tutor);
            TempData["SuccessMessage"] = "You have registered successfully. Please login!";

            return RedirectToPage("/AccountPages/LoginPage");
        }
        public static string GetDisplayName(Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()?
                            .GetName() ?? enumValue.ToString();
        }
    }
}
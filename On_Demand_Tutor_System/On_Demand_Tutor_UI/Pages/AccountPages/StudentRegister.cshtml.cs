using BusinessObjects.DTO.Student;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using On_Demand_Tutor_UI.Validator;
using Services.AccountService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace On_Demand_Tutor_UI.Pages.AccountPages
{
    public class StudentRegisterModel : TrimmedPageModel
    {
        private readonly IAccountService accountService;

        public StudentRegisterModel(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public StudentRegisterDTO Student { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            TrimModelStrings(Student);
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (await accountService.EmailExistsAsync(Student.Email) == true)
            {
                ModelState.AddModelError("Student.Email", "An account with this email already exists.");
                return Page();
            }
            if (await accountService.PhoneNumberExistsAsync(Student.Phone) == true)
            {
                ModelState.AddModelError("Student.Phone", "An account with this phone number already exists.");
                return Page();
            }

            await accountService.RegisterStudentAsync(Student);
            TempData["SuccessMessage"] = "You have registered successfully! Please login!";

            return RedirectToPage("/AccountPages/LoginPage");
        }
    }
}

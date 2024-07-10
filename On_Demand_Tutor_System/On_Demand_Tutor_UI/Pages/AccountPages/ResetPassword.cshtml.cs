using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.AccountService;
using System.ComponentModel.DataAnnotations;

namespace On_Demand_Tutor_UI.Pages.AccountPages
{
    public class ResetPasswordModel : PageModel
    {
        private readonly IAccountService _accountService;

        public ResetPasswordModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty(SupportsGet = true)]
        public string? Token { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please enter your new Password")]
        public string? NewPassword { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please confirm the new Password")]
        public string? ConfirmPassword { get; set; }

        public void OnGet(string token)
        {
            Token = System.Net.WebUtility.UrlDecode(token);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (string.IsNullOrEmpty(Token))
            {
                ModelState.AddModelError(string.Empty, "Invalid request.");
                return Page();
            }

            if (NewPassword != ConfirmPassword)
            {
                ModelState.AddModelError(string.Empty, "Passwords do not match.");
                return Page();
            }

            var userType = await _accountService.GetUserTypeByTokenAsync(Token);
            if (userType == null)
            {
                ModelState.AddModelError(string.Empty, "You don't have permission");
                return Page();
            }

            var resetSuccessful = await _accountService.ResetPasswordAsync(Token, userType, NewPassword);

            if (!resetSuccessful)
            {
                ModelState.AddModelError(string.Empty, "Invalid or expired token.");
                return Page();
            }

            TempData["SuccessMessage"] = "Password has been successfully reseted.";
            return RedirectToPage("/AccountPages/LoginPage");
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using Services.AccountService;
using Services.EmailService;
using System.ComponentModel.DataAnnotations;

namespace On_Demand_Tutor_UI.Pages.AccountPages
{
    public class ForgotPasswordRequestModel : PageModel
    {
        private readonly IAccountService _accountService;
        private readonly IEmailService _emailService;

        public ForgotPasswordRequestModel(IAccountService accountService, IEmailService emailService)
        {
            _accountService = accountService;
            _emailService = emailService;
        }

        [BindProperty, EmailAddress, Required, Display(Name = "Email Address")]
        public string Email { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var userType = await _accountService.GetUserTypeByEmailAsync(Email);
                if (userType == null)
                {
                    TempData["Message"] = "Please choose Forgot Password again to reset your password";
                    return Page();
                    //return RedirectToPage("/Index");
                }

                var token = await GeneratePasswordResetTokenAsync(Email,
                    userType);
                if (token != null)
                {
                    var resetLink = Url.Page(
                        "/AccountPages/ResetPassword",
                        pageHandler: null,
                        values: new { token },
                        protocol: Request.Scheme);

                    await _emailService.SendEmailAsync(Email, "Reset Your Password",
                        $"Please reset your password by clicking {resetLink} .'" +
                        $"This link will expire in 24 hours.");
                }

                TempData["ErrorMessage"] = "If an account exists for the email address, a reset link has been sent.";
                return RedirectToPage("/AccountPages/LoginPage");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send email: {ex.Message}");

            }

            TempData["ErrorMessage"] = "If an account exists for the email address, a reset link has been sent.";
            return RedirectToPage("/Index");
        }

        private async Task<string?> GeneratePasswordResetTokenAsync(string email, string userType)
        {
            var token = Guid.NewGuid().ToString();
            var tokenStoredSuccessfully = await _accountService.GenerateAndStoreTokenAsync(email, userType, token);

            if (!tokenStoredSuccessfully)
            {
                return null;
            }

            return token;
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using On_Demand_Tutor_UI.Validator;
using Services.AccountService;

namespace On_Demand_Tutor_UI.Pages.AccountPages
{
    public class LoginPageModel : TrimmedPageModel
    {
        private readonly IAccountService accountService;
        private readonly IConfiguration _configuration;


        public LoginPageModel(IAccountService accountService, IConfiguration configuration)
        {
            this.accountService = accountService;
            _configuration = configuration;
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

            var adminEmail = _configuration["AdminAccount:Email"];
            var adminPassword = _configuration["AdminAccount:Password"];
            if (Email == adminEmail && Password == adminPassword)
            {
                HttpContext.Session.SetString("UserRole", "Admin");
                HttpContext.Session.SetString("UserEmail", Email);
                return RedirectToPage("/Admin/Admin_Index");
            }

            var (account, type, status) = await accountService.GetAccount(Email, Password);

            if (account == null || status == "Inactive")
            {
                return RedirectToPage("/Error");
            }

            HttpContext.Session.SetString("UserType", type);
            HttpContext.Session.SetString("UserEmail", Email);

            if (type == "Student")
            {
                return RedirectToPage("/Index");
            }
            else if (type == "Tutor")
            {
                return RedirectToPage("/Tutor/Tutor_Index");
            }

            return RedirectToPage("/Error");
        }

    }
}

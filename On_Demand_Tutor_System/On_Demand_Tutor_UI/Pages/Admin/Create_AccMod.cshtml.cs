using BusinessObjects.DTO.Mod;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.ModService;
using Services.Sercurity;

namespace On_Demand_Tutor_UI.Pages.Admin
{
    public class Create_AccModModel : PageModel
    {
        private readonly IModService _modService;
        private readonly PasswordHasher _hasher;

        public Create_AccModModel(IModService modService, PasswordHasher haser)
        {
            _modService = modService;
            _hasher = haser;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CreateModAcc Moderator { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var existingModerator = _modService.GetModByEmail(Moderator.Email);
            if (existingModerator != null)
            {
                ModelState.AddModelError(string.Empty, "An account with this email already exists");
                return Page();
            }

            var moderator = new BusinessObjects.Models.Moderator
            {
                Email = Moderator.Email,
                Password = _hasher.HashPassword(Moderator.Password),
                Fullname = Moderator.FullName,
                Status = Moderator.Status
            };

            _modService.SaveMod(moderator);

            return RedirectToPage("./GetAccount");
        }
    }
}

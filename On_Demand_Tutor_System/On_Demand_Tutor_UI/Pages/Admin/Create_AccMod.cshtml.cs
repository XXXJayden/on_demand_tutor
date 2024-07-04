using BusinessObjects.DTO.Mod;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.ModService;

namespace On_Demand_Tutor_UI.Pages.Admin
{
    public class Create_AccModModel : PageModel
    {
        private readonly IModService _modService;

        public Create_AccModModel(IModService modService)
        {
            _modService = modService;
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

            // Check if the email already exists
            var existingModerator = _modService.GetModByEmail(Moderator.Email);
            if (existingModerator != null)
            {
                ModelState.AddModelError(string.Empty, "An account with this email already exists");
                return Page();
            }

            var moderator = new BusinessObjects.Models.Moderator
            {
                Email = Moderator.Email,
                Password = Moderator.Password,
                Fullname = Moderator.FullName,
                Status = Moderator.Status
            };

            _modService.SaveMod(moderator);

            return RedirectToPage("./GetAccount");
        }
    }
}

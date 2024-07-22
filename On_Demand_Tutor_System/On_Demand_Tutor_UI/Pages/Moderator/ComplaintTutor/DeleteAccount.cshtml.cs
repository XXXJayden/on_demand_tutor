using BusinessObjects.DTO.Admin;
using BusinessObjects.Enums.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using On_Demand_Tutor_UI.Pages.AccountPages;
using Services.ModService;
using Services.StudentServices;
using Services.TutorServices;
using System.Data;

namespace On_Demand_Tutor_UI.Pages.Moderator
{
    public class DeleteAccountModel : PageModel
    {
        private readonly ITutorAccountService _tutorService;
        private readonly IStudentService _studentService;
        private readonly IModService _modService;

        public DeleteAccountModel(ITutorAccountService tutorAccountService, IStudentService studentService, IModService modService)
        {
            _tutorService = tutorAccountService;
            _studentService = studentService;
            _modService = modService;
        }

        [BindProperty]
        public GetAccountDTO AccountToDelete { get; set; }

        public async Task<IActionResult> OnGetAsync(short id)
        {
           
                    var tutor = _tutorService.GetTutorById(id);
                    if (tutor != null)
                    {
                        AccountToDelete = new GetAccountDTO
                        {
                            Id = tutor.TutorId,
                            FullName = tutor.Fullname,
                            Email = tutor.Email,
                            Status = tutor.Status,
                            Role = UserRole.Tutor,
                        };
                    }

            if (AccountToDelete == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(short id)
        {
            var accTutor = _tutorService.GetTutorById(id);
            if (accTutor.Status == UserStatus.InActive)
            {
                OnGetAsync(id);
                ModelState.Clear();
                ModelState.AddModelError(string.Empty, "This account have been banned.");
                return Page();
            }else
            {
                _tutorService.ChangeStatusToActive(id);
            }

            return RedirectToPage("./ViewReport");
        }
    }
}

using BusinessObjects.DTO.Admin;
using BusinessObjects.Enums.User;
using Microsoft.AspNetCore.Mvc;
using On_Demand_Tutor_UI.Pages.AccountPages;
using Services.ModService;
using Services.StudentServices;
using Services.TutorServices;

namespace On_Demand_Tutor_UI.Pages.Admin
{
    public class DeleteAccountModel : AuthenPageModel
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

        public async Task<IActionResult> OnGetAsync(short id, string Role)
        {
            switch (Role)
            {
                case "Tutor":
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
                    break;
                case "Student":
                    var student = await _studentService.GetStudentByIdAsync(id);
                    if (student != null)
                    {
                        AccountToDelete = new GetAccountDTO
                        {
                            Id = student.StudentId,
                            FullName = student.Fullname,
                            Email = student.Email,
                            Status = student.Status,
                            Role = UserRole.Student,
                        };
                    }
                    break;
                case "Moderator":
                    var mod = _modService.GetModById(id);
                    if (mod != null)
                    {
                        AccountToDelete = new GetAccountDTO
                        {
                            Id = mod.ModId,
                            FullName = mod.Fullname,
                            Email = mod.Email,
                            Role = UserRole.Moderator,
                        };
                    }
                    break;
                default:
                    return NotFound();
            }

            if (AccountToDelete == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(short id, string Role)
        {
            switch (Role)
            {
                case "Tutor":
                    _tutorService.ChangeStatusToActive(id);
                    break;
                case "Student":
                    _studentService.DeleteStudent(id);
                    break;
                case "Moderator":
                    _modService.DeleteMod(id);
                    break;
                default:
                    return NotFound();
            }

            return RedirectToPage("/Admin/GetAccount");
        }
    }
}

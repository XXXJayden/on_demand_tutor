using BusinessObjects.DTO.Admin;
using BusinessObjects.Enums.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.ModService;
using Services.StudentServices;
using Services.TutorServices;

namespace On_Demand_Tutor_UI.Pages.Admin
{
    public class GetAccountModel : PageModel
    {
        private readonly ITutorAccountService _tutorService;
        private readonly IStudentService _studentService;
        private readonly IModService _modService;

        public GetAccountModel(ITutorAccountService tutorAccountService, IStudentService studentService, IModService modService)
        {
            _tutorService = tutorAccountService;
            _studentService = studentService;
            _modService = modService;
        }

        public List<GetAccountDTO> GetAccountDTO { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string InputRole { get; set; }
        [BindProperty(SupportsGet = true)]
        public string InputStatus { get; set; }


        public async Task OnGetAsync()
        {
            switch (InputStatus)
            {
                case "1":
                    switch (InputRole)
                    {
                        case "1":
                            var getTutors = _tutorService.GetAllTutor().Where(x => x.Status.Equals(UserStatus.Active)).Select(x => new GetAccountDTO
                            {
                                Id = x.TutorId,
                                FullName = x.Fullname,
                                Email = x.Email,
                                Status = x.Status,
                                Description = x.Description,
                                Major = x.Major,
                                Grade = x.Grade,
                                Role = UserRole.Tutor
                            });
                            GetAccountDTO = getTutors.ToList();
                            break;
                        case "2":
                            var getMods = _modService.GetAllMods().Where(x => x.Status.Equals(UserStatus.Active)).Select(x => new GetAccountDTO
                            {
                                Id = x.ModId,
                                FullName = x.Fullname,
                                Email = x.Email,
                                Role = UserRole.Moderator,
                                Status = x.Status,
                            });
                            GetAccountDTO = getMods.ToList();
                            break;
                        case "3":
                            var getStudents = _studentService.GetAllStudent().Where(x => x.Status.Equals(UserStatus.Active)).Select(x => new GetAccountDTO
                            {
                                Id = x.StudentId,
                                FullName = x.Fullname,
                                Email = x.Email,
                                Status = x.Status,
                                Address = x.Address,
                                Grade = x.Grade,
                                Phone = x.Phone,
                                Role = UserRole.Student
                            });
                            GetAccountDTO = getStudents.ToList();
                            break;
                        default:
                            GetAccountDTO = new List<GetAccountDTO>();
                            break;
                    }
                    break;
                case "2":
                    switch (InputRole)
                    {
                        case "1":
                            var getTutors = _tutorService.GetAllTutor().Where(x => x.Status.Equals(UserStatus.InActive)).Select(x => new GetAccountDTO
                            {
                                Id = x.TutorId,
                                FullName = x.Fullname,
                                Email = x.Email,
                                Status = x.Status,
                                Description = x.Description,
                                Major = x.Major,
                                Grade = x.Grade,
                                Role = UserRole.Tutor
                            });
                            GetAccountDTO = getTutors.ToList();
                            break;
                        case "2":
                            var getMods = _modService.GetAllMods().Where(x => x.Status.Equals(UserStatus.InActive)).Select(x => new GetAccountDTO
                            {
                                Id = x.ModId,
                                FullName = x.Fullname,
                                Email = x.Email,
                                Role = UserRole.Moderator,
                                Status = x.Status,
                            });
                            GetAccountDTO = getMods.ToList();
                            break;
                        case "3":
                            var getStudents = _studentService.GetAllStudent().Where(x => x.Status.Equals(UserStatus.InActive)).Select(x => new GetAccountDTO
                            {
                                Id = x.StudentId,
                                FullName = x.Fullname,
                                Email = x.Email,
                                Status = x.Status,
                                Address = x.Address,
                                Grade = x.Grade,
                                Phone = x.Phone,
                                Role = UserRole.Student
                            });
                            GetAccountDTO = getStudents.ToList();
                            break;
                        default:
                            GetAccountDTO = new List<GetAccountDTO>();
                            break;
                    }
                    break;
            }
        }
    }
}
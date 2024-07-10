using BusinessObjects.Enums.User;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using On_Demand_Tutor_UI.Pages.AccountPages;
using Services.AchievementServices;
using Services.TutorServices;

namespace On_Demand_Tutor_UI.Pages.Tutor
{
    public class UploadAchievementModel : AuthenPageModel
    {
        private readonly FireBaseStorage _fireBaseStorage;
        private readonly IAchievementService _achievementService;
        private readonly ITutorAccountService _tutorService;

        public UploadAchievementModel(FireBaseStorage fireBaseStorage,
            IAchievementService achievementService,
            ITutorAccountService tutorAccountService)
        {
            _fireBaseStorage = fireBaseStorage;
            _achievementService = achievementService;
            _tutorService = tutorAccountService;
        }

        [BindProperty]
        public short TutorId { get; set; }

        [BindProperty]
        public IFormFile Certificate { get; set; }

        public string Message { get; set; }

        public IList<Achievement> Achievements { get; set; } = new List<Achievement>();

        public async Task OnGetAsync()
        {
            var accountTutor = HttpContext.Session.GetString("UserEmail");
            var tutor = _tutorService.GetTutorByEmail(accountTutor);

            if (tutor != null)
            {
                Achievements = _achievementService.GetAllAchievement()
                    .Where(x => x.TutorId == tutor.TutorId)
                    .ToList();
            }
        }

        public async Task<IActionResult> OnPostUploadAsync()
        {
            var accountTutor = HttpContext.Session.GetString("UserEmail");
            var tutor = _tutorService.GetTutorByEmail(accountTutor);

            if (Certificate != null)
            {
                var fileName = Path.GetFileName(Certificate.FileName);
                string uploadedFileUrl;
                using (var stream = Certificate.OpenReadStream())
                {
                    uploadedFileUrl = await _fireBaseStorage.UploadFileAsync(stream, fileName);
                }

                var achievement = new Achievement
                {
                    TutorId = tutor.TutorId,
                    Certificate = uploadedFileUrl
                };

                try
                {
                    _achievementService.SaveAchievement(achievement);
                    tutor.Status = UserStatus.Pending;
                    _tutorService.UpdateTutor(tutor);
                    Message = "Achievement uploaded successfully!";
                }
                catch (Exception ex)
                {
                    Message = $"Error: {ex.Message}";
                }
            }
            else
            {
                Message = "Please upload a certificate.";
            }

            await OnGetAsync(); // Refresh the achievements list
            return Page();
        }


        public async Task<IActionResult> OnPostDeleteAsync(List<int> selectedCertificates)
        {
            if (selectedCertificates == null || !selectedCertificates.Any())
            {
                Message = "No certificates selected.";
                return Page();
            }

            foreach (short id in selectedCertificates)
            {
                var achievement = _achievementService.GetAchievementById(id);
                if (achievement != null)
                {
                    await _fireBaseStorage.DeleteFileAsync(achievement.Certificate);
                    _achievementService.DeleteAchievement(id);
                }
            }

            Message = "Selected certificates deleted successfully.";

            await OnGetAsync(); // Refresh the achievements list
            return Page();
        }
    }
}

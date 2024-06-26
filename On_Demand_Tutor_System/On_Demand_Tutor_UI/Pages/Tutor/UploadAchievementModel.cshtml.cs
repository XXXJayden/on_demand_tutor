using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.AchievementServices;
using Services.TutorServices;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace On_Demand_Tutor_UI.Pages.Tutor
{
    public class UploadAchievementModel : PageModel
    {
        private readonly FireBaseStorage _fireBaseStorage;
        private readonly IAchievementService _achievementService;
        private readonly ITutorAccountService _tutorService;

        public UploadAchievementModel(FireBaseStorage fireBaseStorage,
            IAchievementService achievementService,
            ITutorAccountService tutorAccountService
            )
        {
            _fireBaseStorage = fireBaseStorage;
            _achievementService = achievementService;
            _tutorService = tutorAccountService;
        }

        [BindProperty]
        public int TutorId { get; set; }

        [BindProperty]
        public IFormFile Certificate { get; set; }

        public string Message { get; set; }

        public IList<Achievement> Achievement { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var accountTutor = HttpContext.Session.GetString("UserEmail");
            var allTutor = _tutorService.GetTutorByEmail(accountTutor);
            var certificate = _achievementService.GetAllAchievement()
                .Where(x => x.TutorId == allTutor.TutorId)
                .Select(x => new Achievement
                {
                    AchievementId = x.AchievementId,
                    Certificate = x.Certificate,
                });
            Achievement = certificate.ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var accountTutor = HttpContext.Session.GetString("UserEmail");
            var allTutor = _tutorService.GetTutorByEmail(accountTutor);

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
                    TutorId = allTutor.TutorId,
                    Certificate = uploadedFileUrl
                };

                try
                {
                    _achievementService.SaveAchievement(achievement);
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

        //public async Task<IActionResult> OnPostDeleteAsync(List<int> selectedCertificates)
        //{
        //    if (selectedCertificates == null || !selectedCertificates.Any())
        //    {
        //        Message = "No certificates selected.";
        //        return Page();
        //    }

        //    foreach (var id in selectedCertificates)
        //    {
        //        var achievement = _achievementService.GetAchievementById(id);
        //        if (achievement != null)
        //        {
        //            await _fireBaseStorage.DeleteFileAsync(achievement.Certificate);
        //            _achievementService.DeleteAchievement(achievement);
        //        }
        //    }

        //    Message = "Selected certificates deleted successfully.";

        //    await OnGetAsync(); // Refresh the achievements list
        //    return Page();
        //}
    }
}

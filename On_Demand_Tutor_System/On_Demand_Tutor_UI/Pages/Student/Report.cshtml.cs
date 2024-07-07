using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Services.ReportServices;
using BusinessObjects.Enums.Report;

namespace On_Demand_Tutor_UI.Pages.Student
{
    public class ReportModel : PageModel
    {
        private readonly IReportService _reportService;
        private readonly FireBaseStorage _fireBaseStorage;

        public ReportModel(IReportService reportService, FireBaseStorage fireBaseStorage)
        {
            _reportService = reportService;
            _fireBaseStorage = fireBaseStorage;
        }

        [BindProperty]
        public Report Report { get; set; } = new Report();

        [BindProperty]
        public IFormFile ImageFile { get; set; }

        public string Message { get; set; }

        public IActionResult OnGet(int StudentId, int TutorId, int ServiceId)
        {
            Report.StudentId = StudentId;
            Report.TutorId = TutorId;
            Report.ServiceId = ServiceId;
            Report.Date = DateTime.Now.ToString("yyyy-MM-dd");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int StudentId, int TutorId, int ServiceId)
        {
            if (ImageFile != null)
            {
                var fileName = Path.GetFileName(ImageFile.FileName);
                string uploadedFileUrl;
                using (var stream = ImageFile.OpenReadStream())
                {
                    uploadedFileUrl = await _fireBaseStorage.UploadFileAsync(stream, fileName);
                }
                Report.Image = uploadedFileUrl;
            }

            if (string.IsNullOrEmpty(Report.Date))
            {
                Report.Date = DateTime.Now.ToString("yyyy-MM-dd");
            }

            try
            {
                Report.StudentId = StudentId;
                Report.TutorId = TutorId;
                Report.ServiceId = ServiceId;
                Report.Status = ReportStatus.Pending;
                _reportService.SaveReport(Report);
                Message = "Report submitted successfully!";
            }
            catch (Exception ex)
            {
                Message = $"Error: {ex.Message}";
            }

            return RedirectToPage("/Student/ViewProcessingLearning");
        }

    }
}

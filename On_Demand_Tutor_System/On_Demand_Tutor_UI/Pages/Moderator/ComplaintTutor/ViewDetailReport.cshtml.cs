using BusinessObjects.DTO.Report;
using Microsoft.AspNetCore.Mvc;
using On_Demand_Tutor_UI.Pages.AccountPages;
using Services.ReportServices;
using Services.TutorServices;

namespace On_Demand_Tutor_UI.Pages.Moderator.ComplaintTutor
{
    public class ViewDetailReportModel : AuthenPageModel
    {
        private readonly IReportService _reportService;
        private readonly ITutorAccountService _tutorAccountService;

        public ViewDetailReportModel(IReportService reportService, ITutorAccountService tutorAccountService)
        {
            _reportService = reportService;
            _tutorAccountService = tutorAccountService;
        }

        public ReportListDTO Report { get; set; } = new ReportListDTO();

        public IActionResult OnGet(int id)
        {
            var report = _reportService.GetReportById(id);
            if (report == null)
            {
                return NotFound();
            }

            Report = new ReportListDTO
            {
                Id = report.Id,
                Date = report.Date,
                Detail = report.Detail,
                ServiceName = report.Service.Service1,
                TutorId = report.TutorId,
                TutorName = report.Tutor.Fullname,
                StudentName = report.Student.Fullname,
                Image = report.Image
            };

            return Page();
        }

        public IActionResult OnPostCancel(short TutorId, int Id)
        {
            var report = _reportService.GetReportById(Id);
            if (report != null)
            {
                report.Status = "Cancel";
                _reportService.UpdateStatus(report);
            }
            return RedirectToPage("/Moderator/Index");
        }

        public IActionResult OnPostBan(short TutorId, int Id)
        {
            var report = _reportService.GetReportById(Id);
            if (report != null)
            {
                report.Status = "Approve";
                _reportService.UpdateStatus(report);
                _tutorAccountService.DeleteTutor(TutorId);
            }
            return RedirectToPage("/Moderator/Index");
        }
    }
}

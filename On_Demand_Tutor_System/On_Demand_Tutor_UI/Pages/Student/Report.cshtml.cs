using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Services.ReportServices;

namespace On_Demand_Tutor_UI.Pages.Student
{
    public class ReportModel : PageModel
    {
        private readonly IReportService _reportService;

        public ReportModel(IReportService reportService)
        {
            _reportService = reportService;
        }

        [BindProperty]
        public Report Report { get; set; } = new Report();

        public IActionResult OnGet(int StudentId, int TutorId, int BookingId)
        {
            Report.StudentId = StudentId;
            Report.TutorId = TutorId;
            Report.ServiceId = BookingId; 
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //await _reportService.AddReportAsync(Report);

            return RedirectToPage("/Student/ViewProcessingLearning");
        }
    }
}

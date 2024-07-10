using BusinessObjects.DTO.Report;
using BusinessObjects.Enums.Report;
using On_Demand_Tutor_UI.Pages.AccountPages;
using Services.ReportServices;

namespace On_Demand_Tutor_UI.Pages.Moderator.ComplaintTutor
{
    public class ViewReportModel : AuthenPageModel
    {
        private readonly IReportService _reportService;

        public ViewReportModel(IReportService reportService)
        {
            _reportService = reportService;
        }

        public IList<ReportListDTO> ReportList { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var allReport = _reportService.GetAllReport().Where(x => x.Status.Equals(ReportStatus.Pending));
            var reportList = allReport.OrderByDescending(x => x.Date)
                .Where(x => x.Status.Equals(ReportStatus.Pending))
                .Select(x => new ReportListDTO
                {
                    Id = x.Id,
                    Date = x.Date,
                    Detail = x.Detail,
                    ServiceName = x.Service.Service1,
                    TutorName = x.Tutor.Fullname,
                    StudentName = x.Student.Fullname,
                });
            ReportList = reportList.ToList();
        }
    }
}

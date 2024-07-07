using BusinessObjects.DTO.Report;
using BusinessObjects.Models;
using Repositories.ReportRepositories;
using Repositories.ScheduleRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ReportServices
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportService;

        public ReportService()
        {
           _reportService = new ReportRepository();
        }


        public List<Report> GetAllReport()
        {
            return _reportService.GetAllReport();
        }

       
        public Report GetReportById(int id)
        {
            return _reportService.GetReportById(id);
        }

        public void UpdateStatus(Report report)
        {
            _reportService.UpdateReport(report);
        }
    }
}

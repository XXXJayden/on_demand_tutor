using BusinessObjects.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.ReportRepositories
{
    public class ReportRepository : IReportRepository
    {
        public void AddReport(Report report)
        => ReportDAO.AddReport(report);

        public void DeleteReport(int id)
            => ReportDAO.DeleteReport(id);

        public List<Report> GetAllReport()
            => ReportDAO.GetAllReport();


        public Report GetReportById(int id)
            => ReportDAO.GetReportById(id);

        public void UpdateReport(Report report)
            => ReportDAO.UpdateReport(report);
    }
}

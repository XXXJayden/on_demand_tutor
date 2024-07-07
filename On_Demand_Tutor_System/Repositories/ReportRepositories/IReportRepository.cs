using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.ReportRepositories
{
    public interface IReportRepository
    {
        List<Report> GetAllReport();
        Report GetReportById(int id);
        void AddReport(Report report);
        void UpdateReport(Report report);
        void DeleteReport(int id);

    }
}

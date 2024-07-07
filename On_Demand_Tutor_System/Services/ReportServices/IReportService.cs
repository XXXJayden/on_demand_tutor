using BusinessObjects.DTO.Report;
using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ReportServices
{
    public interface IReportService
    {
        List<Report> GetAllReport();
        Report GetReportById(int id);
        void UpdateStatus(Report report);


    }
}

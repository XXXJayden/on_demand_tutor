using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ReportDAO
    {
        public static List<Report> GetAllReport()
        {
            var listReports = new List<Report>();
            try
            {
                using var context = new OnDemandTutorDbContext();
                listReports = context.Reports
                    .Include(x=>x.Service)
                    .Include(x=>x.Student)
                    .Include(x => x.Tutor)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listReports;
        }

        public static Report GetReportById(int id)
        {
            using var db = new OnDemandTutorDbContext();
            return db.Reports
                .Include(x => x.Service)
                .Include(x => x.Student)
                .Include(x => x.Tutor)
                .SingleOrDefault(x => x.Id == id);
        }

        public static Report GetReportByServiceId(int ServiceId)
        {
            using var db = new OnDemandTutorDbContext();
            return db.Reports.FirstOrDefault(c => c.ServiceId.Equals(ServiceId));
        }
        public static void UpdateReport(Report report)
        {
            using var db = new OnDemandTutorDbContext();
            db.Reports.Update(report);
            db.SaveChanges();
        }

        public static void AddReport(Report report)
        {
            using var db = new OnDemandTutorDbContext();
            db.Reports.Add(report);
            db.SaveChanges();
        }

        public static void DeleteReport(int id)
        {
            using var db = new OnDemandTutorDbContext();
            var report = db.Reports.Find(id);
            if (report != null)
            {
                db.Reports.Remove(report);
                db.SaveChanges();
            }
        }
    }
}

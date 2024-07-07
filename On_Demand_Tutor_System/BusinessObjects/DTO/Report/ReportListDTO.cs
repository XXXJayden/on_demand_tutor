using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO.Report
{
    public class ReportListDTO
    {
        public int Id { get; set; }

        [Display(Name = "Student Name")]
        public string StudentName { get; set; }
        public int TutorId { get; set; }
        [Display(Name = "Tutor Name")]
        public string TutorName { get; set; }
        [Display(Name = "Service Name")]
        public string ServiceName { get; set; }
        public string Status { get; set; }
        public string Date {  get; set; }
        public string Detail {  get; set; }
        public string Image {  get; set; }

    }
}

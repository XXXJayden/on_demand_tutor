using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO.Booking
{
    public class ProcessingTeaching
    {
        public int Id { get; set; }
        [Display(Name = "Student Name")]
        public string StudentName { get; set; }

        [Display(Name = "Student Address")]
        public string StudentAddress { get; set; }

        public string Grade { get; set; }
        public string Phone { get; set; }   

        public int TutorId { get; set; }

        [Display(Name = "Service Name")]
        public string ServiceName { get; set; }

        public string Status { get; set; } = null!;

        public DateOnly? DateStart { get; set; }

        public DateOnly? DateEnd { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO.Student
{
    public class StudentResponse
    {
        public int StudentId { get; set; }

        [Display(Name = "Student Name")]
        public string Fullname { get; set; } = null!;

        [Display(Name = "Phone number")]
        public string Phone { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Grade { get; set; } = null!;
    }
}

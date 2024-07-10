using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO.Tutor
{
    public class TutorServiceResponse
    {
        public int TutorId { get; set; }

        [Display(Name = "Tutor Name")]
        public string? Fullname { get; set; } = null!;

        public string? Email { get; set; } = null!;

        public string? Description { get; set; }

        public string? Major { get; set; } = null!;

        public string? Grade { get; set; } = null!;

        public List<string> Services { get; set; } = new List<string>();
    }
}

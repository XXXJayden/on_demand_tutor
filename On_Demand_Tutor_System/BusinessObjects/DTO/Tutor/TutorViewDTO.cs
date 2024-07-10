using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO.Tutor
{
    public class TutorViewDTO
    {
        public int TutorId { get; set; }
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Grade { get; set; } = default!;
        public string Status { get; set; } = default!;
        public string Major { get; set; } = default!;
    }
}

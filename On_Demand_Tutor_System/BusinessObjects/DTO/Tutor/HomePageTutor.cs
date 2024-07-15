using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO.Tutor
{
    public class HomePageTutor
    {
        public string Fullname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Major { get; set; } = null!;
        public string Avatar { get; set; } = null!;
        public string? Description { get; set; }
        public string Grade { get; set; } = null!;

    }
}

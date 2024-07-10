using BusinessObjects.DTO.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO.Tutor
{
    public class TutorDetailResponse
    {
        public int TutorId { get; set; }
        public string Fullname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Description { get; set; }
        public string Major { get; set; } = null!;
        public string Grade { get; set; } = null!;
        public List<string> Achievements { get; set; } = new List<string>();
        public List<ServiceResponse> Services { get; set; } = new List<ServiceResponse>();
    }
}

using BusinessObjects.Enums.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO.Tutor
{
    public class TutorRegisterDTO
    {
        public string Fullname { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;

        public string Status { get; set; } = User.Active;

        public string? Description { get; set; }

        public string Major { get; set; } = null!;
    }
}

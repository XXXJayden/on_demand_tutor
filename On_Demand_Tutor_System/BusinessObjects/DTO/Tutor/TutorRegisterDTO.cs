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
        [Required(ErrorMessage = "You must enter your name")]
        public string Fullname { get; set; } = null!;


        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = null!;

        public string Status { get; set; } = User.Incomplete;

        [Required(ErrorMessage = "You must enter self introduction")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "You must enter your major")]
        public string Major { get; set; } = null!;

        [Required(ErrorMessage = "You must enter your Grade")]
        public string Grade { get; set; } = null!;
    }
}

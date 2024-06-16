using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO.Student
{
    public class StudentRegisterDTO
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "You must enter your name")]
        public string FullName { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Grade { get; set; }

        public string Status = "Active";
    }
}

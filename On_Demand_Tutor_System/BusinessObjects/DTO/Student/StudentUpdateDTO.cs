using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO.Student
{
    public class StudentUpdateDTO
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        public string? Password { get; set; }

        [Required(ErrorMessage = "You must enter your name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "You must enter your phone number")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "You must enter your address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "You must enter your grade")]
        public string Grade { get; set; }
    }
}

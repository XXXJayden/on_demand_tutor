using BusinessObjects.CustomAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO.Tutor
{
    public class TutorUpdateDTO
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        public string? Password { get; set; }

        [Required(ErrorMessage = "You must enter your name")]
        public string FullName { get; set; }


        [Required(ErrorMessage = "You must enter your major")]
        public string Major { get; set; }
        [Required(ErrorMessage = "You must enter your description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "You must enter your grade")]
        [CustomValidation(typeof(CustomValidationMethods), nameof(CustomValidationMethods.ValidateGrade))]
        public string Grade { get; set; }

    }
}

using BusinessObjects.CustomAttribute;
using BusinessObjects.Enums.User;
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

        [ValidPhoneNumber(ErrorMessage = "Invalid phone number format")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "You must enter your address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "You must enter your grade")]
        [CustomValidation(typeof(StudentRegisterDTO), "ValidateGrade")]
        public string Grade { get; set; }

        [Required(ErrorMessage = "You must enter your current grade")]
        public string Status = UserStatus.Incomplete;

        public static ValidationResult ValidateGrade(string grade, ValidationContext context)
        {
            if (int.TryParse(grade, out int gradeValue) && gradeValue >= 6 && gradeValue <= 12)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Grade must be between 6 and 12");
        }
    }
}

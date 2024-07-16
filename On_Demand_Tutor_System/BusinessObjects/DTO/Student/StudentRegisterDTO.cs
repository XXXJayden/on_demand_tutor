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
        [AdminKeywordValidation(ErrorMessage = "Email can't contain 'admin' keyword")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password is not matched")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "You must enter your name")]
        public string FullName { get; set; }

        [ValidPhoneNumber(ErrorMessage = "Invalid phone number format")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "You must enter your address")]
        [MaxWords(30, ErrorMessage = "Address must be in 30 words")]
        public string Address { get; set; }

        [Required(ErrorMessage = "You must enter your grade")]
        [CustomValidation(typeof(CustomValidationMethods), nameof(CustomValidationMethods.ValidateGrade))]
        public string Grade { get; set; }

        [Required(ErrorMessage = "You must enter your current grade")]
        public string Status = UserStatus.Active;
    }
}

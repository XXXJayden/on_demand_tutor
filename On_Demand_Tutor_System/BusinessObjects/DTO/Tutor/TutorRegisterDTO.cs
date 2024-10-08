﻿using BusinessObjects.CustomAttribute;
using BusinessObjects.DTO.Student;
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
        [AdminKeywordValidation(ErrorMessage = "Email can't contain 'admin' keyword")]
        public string Email { get; set; } = null!;

        public string Status { get; set; } = UserStatus.Incomplete;

        [Required(ErrorMessage = "You must enter self introduction")]
        [MaxWords(30, ErrorMessage = "Introduction must be in 30 words")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "You must enter your major")]
        public string Major { get; set; } = null!;

        [Required(ErrorMessage = "You must enter your grade")]
        [CustomValidation(typeof(CustomValidationMethods), nameof(CustomValidationMethods.ValidateGrade))]
        public string Grade { get; set; }

    }
}

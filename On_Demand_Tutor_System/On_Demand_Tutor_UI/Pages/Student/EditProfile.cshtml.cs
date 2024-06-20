using BusinessObjects.DTO.Student;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using On_Demand_Tutor_UI.Validator;
using Services.Sercurity;
using Services.StudentServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_Demand_Tutor_UI.Pages.Student
{
    public class EditProfileModel : TrimmedPageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly PasswordHasher _hasher;
        private readonly IStudentService _studentService;


        public EditProfileModel(IStudentService studentService, IHttpContextAccessor httpContextAccessor, PasswordHasher hasher)
        {
            _studentService = studentService;
            _httpContextAccessor = httpContextAccessor;
            _hasher = hasher;
        }

        [BindProperty]
        public StudentUpdateDTO Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {

            var userEmail = _httpContextAccessor.HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(userEmail))
            {
                return RedirectToPage("/AccountPages/LoginPage");
            }
            var studentDto = await _studentService.GetStudentByEmailAsync(userEmail);
            if (studentDto == null)
            {
                return NotFound();
            }
            Student = new StudentUpdateDTO
            {
                Email = studentDto.Email,
                Phone = studentDto.Phone,
                FullName = studentDto.Fullname,
                Address = studentDto.Address,
                Grade = studentDto.Grade,
            };

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            TrimModelStrings(Student);
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var userEmail = _httpContextAccessor.HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(userEmail))
            {
                return RedirectToPage("/AccountPages/LoginPage");
            }

            var existingStudent = await _studentService.GetStudentByEmailAsync(userEmail);
            if (existingStudent == null)
            {
                return NotFound();
            }
            existingStudent.Email = Student.Email;
            existingStudent.Fullname = Student.FullName;
            existingStudent.Address = Student.Address;
            existingStudent.Phone = Student.Phone;
            existingStudent.Grade = Student.Grade;

            if (!string.IsNullOrWhiteSpace(Student.Password))
            {
                existingStudent.Password = _hasher.HashPassword(Student.Password);
            }
            await _studentService.UpdateStudentAsync(existingStudent);

            TempData["SuccessMessage"] = "Profile updated successfully.";
            return RedirectToPage();

            return RedirectToPage("/Index");
        }
    }
}

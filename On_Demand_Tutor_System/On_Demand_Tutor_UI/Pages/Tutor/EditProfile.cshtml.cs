using BusinessObjects.DTO.Tutor;
using BusinessObjects.Enums.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using On_Demand_Tutor_UI.Validator;
using Services.Sercurity;
using Services.TutorServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_Demand_Tutor_UI.Pages.Tutor
{
    public class EditProfileModel : TrimmedPageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly PasswordHasher _hasher;
        private readonly FireBaseStorage _fireBaseStorage;
        private readonly IHubContext<SignalR> _hubContext;
        private readonly ITutorAccountService _tutorService;

        public EditProfileModel(ITutorAccountService tutorService, IHttpContextAccessor httpContextAccessor, PasswordHasher hasher, FireBaseStorage fireBaseStorage, IHubContext<SignalR> hubContext)
        {
            _tutorService = tutorService;
            _httpContextAccessor = httpContextAccessor;
            _hasher = hasher;
            _fireBaseStorage = fireBaseStorage;
            _hubContext = hubContext;
        }

        [BindProperty]
        public TutorUpdateDTO TutorProfile { get; set; } = default!;
        public TutorAvatarModel TutorAvatar { get; set; }
        [BindProperty]
        public IFormFile Avatar { get; set; }

        public string Message { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var userEmail = _httpContextAccessor.HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(userEmail))
            {
                return RedirectToPage("/AccountPages/LoginPage");
            }
            var tutorDto = _tutorService.GetTutorByEmail(userEmail);
            if (tutorDto == null)
            {
                return NotFound();
            }
            TutorProfile = new TutorUpdateDTO
            {
                Email = tutorDto.Email,
                Description = tutorDto.Description,
                FullName = tutorDto.Fullname,
                Grade = tutorDto.Grade,
                Major = tutorDto.Major,
            };
            TutorAvatar = new TutorAvatarModel
            {
                Avatar = tutorDto.Avatar,
            };

            return Page();
        }

        public async Task<IActionResult> OnPostUpdateProfileAsync()
        {
            TrimModelStrings(TutorProfile);
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            var userEmail = _httpContextAccessor.HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(userEmail))
            {
                return RedirectToPage("/AccountPages/LoginPage");
            }

            var existingTutor = _tutorService.GetTutorByEmail(userEmail);
            if (existingTutor == null)
            {
                return NotFound();
            }

            existingTutor.Email = TutorProfile.Email;
            existingTutor.Description = TutorProfile.Description;
            existingTutor.Major = TutorProfile.Major;
            existingTutor.Fullname = TutorProfile.FullName;
            existingTutor.Grade = TutorProfile.Grade;

            if (!string.IsNullOrWhiteSpace(TutorProfile.Password))
            {
                existingTutor.Password = _hasher.HashPassword(TutorProfile.Password);
            }

            try
            {
                existingTutor.Status = UserStatus.Pending;
                _tutorService.UpdateTutor(existingTutor);
                TempData["SuccessMessage"] = "Profile updated successfully.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return Page();
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostUploadAvatarAsync()
        {
            var userEmail = _httpContextAccessor.HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(userEmail))
            {
                return RedirectToPage("/AccountPages/LoginPage");
            }

            var existingTutor = _tutorService.GetTutorByEmail(userEmail);
            if (existingTutor == null)
            {
                return NotFound();
            }

            if (Avatar != null)
            {
                var fileName = Path.GetFileName(Avatar.FileName);
                using (var stream = Avatar.OpenReadStream())
                {
                    existingTutor.Avatar = await _fireBaseStorage.UploadFileAsync(stream, fileName);
                }

                try
                {
                    existingTutor.Status = UserStatus.Pending;
                    _tutorService.UpdateTutor(existingTutor);
                    await _hubContext.Clients.All.SendAsync("ReceiveMessage");
                    TempData["SuccessMessage"] = "Avatar uploaded successfully.";
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Error: {ex.Message}";
                    return Page();
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Please select an avatar to upload.";
            }

            return RedirectToPage();
        }
    }
}

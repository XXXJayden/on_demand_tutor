using BusinessObjects.DTO.Tutor;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.ScheduleService;
using Services.Tutors;
using Services.TutorServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_Demand_Tutor_UI.Pages.Student
{
    public class ViewDetailTutorModel : PageModel
    {
        private readonly ITutorAccountService _tutorAccountService;
        private readonly IScheduleService _scheduleService;

        public ViewDetailTutorModel(ITutorAccountService tutorAccountService, IScheduleService scheduleService)
        {
            _tutorAccountService = tutorAccountService;
            _scheduleService = scheduleService;
        }

        public TutorDetailResponse TutorDetails { get; set; } = new TutorDetailResponse();
        public List<string> AvailableSlots { get; set; } = new List<string>();

        public async Task<IActionResult> OnGetAsync(short id, DateOnly? date)
        {
            var tutor = _tutorAccountService.GetTutorById(id);
            if (tutor == null)
            {
                return NotFound();
            }

            TutorDetails = new TutorDetailResponse
            {
                TutorId = tutor.TutorId,
                Fullname = tutor.Fullname,
                Email = tutor.Email,
                Description = tutor.Description,
                Major = tutor.Major,
                Grade = tutor.Grade,
                Achievements = tutor.Achievements.Select(a => a.Certificate).ToList(),
                Services = tutor.TutorServices.Select(ts => new BusinessObjects.DTO.Service.ServiceResponse
                {
                    ServiceName = ts.Service.Service1,
                    Price = ts.Price
                }).ToList()
            };

            if (date.HasValue)
            {
                string dateString = date.Value.ToString("yyyy-MM-dd");
                AvailableSlots = await _scheduleService.GetAvailableSlotsAsync(tutor.TutorId, dateString);
            }

            return Page();
        }

        //public async Task<IActionResult> OnPostFetchSlotsAsync(short tutorId, string date)
        //{
        //    AvailableSlots = await _scheduleService.GetAvailableSlotsAsync(tutorId, date);
        //    return new JsonResult(AvailableSlots);
        //}
    }
}

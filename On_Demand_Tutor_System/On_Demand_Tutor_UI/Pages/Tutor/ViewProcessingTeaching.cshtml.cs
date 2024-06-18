using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using BusinessObjects.DTO.Booking;
using Services.BookingService;

namespace On_Demand_Tutor_UI.Pages.Tutor
{
    public class ViewProcessingTeachingModel : PageModel
    {
        private readonly IBookingService _bookingService;

        public ViewProcessingTeachingModel(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public IList<ProcessingTeaching> ProcessingTeach { get; set; } = default!;

        public async Task OnGetAsync()
        {

            var allbookingList = _bookingService.GetAllBookingTutor();
            var bookingList = allbookingList.OrderByDescending(x => x.DateStart)
                                            .Where(x => x.Status.Equals("Approved"))
                                            .Select(x => new ProcessingTeaching
                                            {
                                                Id = x.Id,
                                                StudentName = x.Student.Fullname,
                                                StudentAddress = x.Student.Address,
                                                Grade = x.Student.Grade,
                                                Phone = x.Student.Phone,
                                                ServiceName = x.Service.Service1,
                                                DateStart = x.DateStart,
                                                DateEnd = x.DateEnd

                                            });
            ProcessingTeach = bookingList.ToList();
        }
    }
}

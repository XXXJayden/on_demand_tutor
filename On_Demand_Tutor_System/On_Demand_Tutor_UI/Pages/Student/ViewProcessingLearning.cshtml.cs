using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using BusinessObjects.DTO.Booking;
using Services.BookingService;

namespace On_Demand_Tutor_UI.Pages.Student
{
    public class ViewProcessingLearningModel : PageModel
    {
        private readonly IBookingService _bookingService;

        public ViewProcessingLearningModel(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public IList<BookingTutorResponse> BookingTutor { get; set; } = default!;

        public async Task OnGetAsync()
        {

            var allbookingList = _bookingService.GetAllBookingTutor();
            var bookingList = allbookingList.OrderByDescending(x => x.DateStart)
                                            .Where(x => x.Status.Equals("Pending"))
                                            .Select(x => new BookingTutorResponse
                                            {
                                                Id = x.Id,
                                                StudentName = x.Student.Fullname,
                                                ServiceName = x.Service.Service1,
                                                DateStart = x.DateStart,
                                                DateEnd = x.DateEnd

                                            });
            BookingTutor = bookingList.ToList();
        }

    }
}

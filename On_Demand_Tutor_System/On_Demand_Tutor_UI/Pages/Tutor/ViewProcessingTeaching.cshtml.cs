using BusinessObjects.DTO.Booking;
using BusinessObjects.Enums.Booking;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.BookingService;
using Services.TutorServices;

namespace On_Demand_Tutor_UI.Pages.Tutor
{
    public class ViewProcessingTeachingModel : PageModel
    {
        private readonly IBookingService _bookingService;
        private readonly ITutorAccountService _tutorService;

        public ViewProcessingTeachingModel(IBookingService bookingService, ITutorAccountService tutorService)
        {
            _bookingService = bookingService;
            _tutorService = tutorService;
        }

        public IList<ProcessingTeachingRespone> ProcessingTeach { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var accountTutor = HttpContext.Session.GetString("UserEmail");
            var allTutor = _tutorService.GetTutorByEmail(accountTutor);
            if (allTutor == null) { return; }
            var allbookingList = _bookingService.GetAllBookingTutor().Where(x => x.TutorId.Equals(allTutor.TutorId));
            var bookingList = allbookingList.OrderByDescending(x => x.DateStart)
                                            .Where(x => x.Status.Equals(BookingStatus.Approve))
                                            .Select(x => new ProcessingTeachingRespone
                                            {
                                                Id = x.Id,
                                                StudentName = x.Student.Fullname,
                                                ServiceName = x.Service.Service1,
                                                StudentAddress = x.Student.Address,
                                                Grade = x.Student.Grade,
                                                Phone = x.Student.Phone,
                                                DateStart = x.DateStart,
                                                DateEnd = x.DateEnd,
                                                PaymentMethods = x.PaymentMethods,
                                                Schedules = x.BookingSchedules.Select(bs => bs.Sc.Slot).ToList(),
                                            });
            ProcessingTeach = bookingList.ToList();
        }

        public async Task<IActionResult> OnPostDoneAsync(int id)
        {
            var booking = _bookingService.GetBookingById(id);
            if (booking == null)
            {
                return NotFound();
            }

            booking.Status = BookingStatus.Complete;
            booking.DateEnd = DateOnly.FromDateTime(DateTime.Now);
            _bookingService.UpdateBooking(booking);

            return RedirectToPage();
        }
    }
}

using BusinessObjects.DTO.Booking;
using BusinessObjects.DTO.Student;
using BusinessObjects.Enums.Booking;
using Microsoft.AspNetCore.Mvc;
using On_Demand_Tutor_UI.Pages.AccountPages;
using Services.BookingService;

namespace On_Demand_Tutor_UI.Pages.Tutor
{
    public class ViewBookingDetailsModel : AuthenPageModel
    {
        private readonly IBookingService _bookingService;

        public ViewBookingDetailsModel(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public IList<BookingTutorResponse> BookingTutor { get; set; } = default!;

        [BindProperty]
        public StudentResponse StudentResponse { get; set; } = new StudentResponse();

        [BindProperty(SupportsGet = true)]
        public int BookingId { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            BookingId = id;

            var booking = _bookingService.GetDetailsBookingById(id);
            if (booking == null)
            {
                return NotFound();
            }


            var student = booking.Student;
            if (student == null)
            {
                return NotFound("Associated student not found for the booking.");
            }

            StudentResponse = new StudentResponse
            {
                StudentId = student.StudentId,
                Fullname = student.Fullname,
                Phone = student.Phone,
                Email = student.Email,
                Address = student.Address,
                Grade = student.Grade
            };

            return Page();
        }

        public async Task<IActionResult> OnPostApproveAsync(int id)
        {
            var booking = _bookingService.GetBookingById(BookingId);
            if (booking == null)
            {
                return NotFound();
            }

            booking.Status = BookingStatus.Approve;
            _bookingService.UpdateBooking(booking);

            return RedirectToPage("/Tutor/ViewStudentRegisted");
        }

        public async Task<IActionResult> OnPostCancelAsync(int id)
        {
            var booking = _bookingService.GetBookingById(BookingId);
            if (booking == null)
            {
                return NotFound();
            }

            booking.Status = BookingStatus.Cancel;
            _bookingService.UpdateBooking(booking);

            return RedirectToPage("/Tutor/ViewStudentRegisted");

        }
    }
}

using BusinessObjects.DTO.Booking;
using BusinessObjects.DTO.VnPayModel;
using BusinessObjects.Enums.Booking;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using On_Demand_Tutor_UI.Pages.AccountPages;
using Services.BookingService;
using Services.FeedBackServices;
using Services.StudentServices;
using Services.Tutors;
using Services.VnPay;
using System.Text.Json;

namespace On_Demand_Tutor_UI.Pages.Student
{
	public class ViewHistoryComplete : AuthenPageModel
	{
		private readonly IBookingService _bookingService;
		private readonly IStudentService _studentService;
		private readonly IFeedBackService _feedbackService;
		private readonly ITutorService _tutorService;
		private readonly IVnPayService _vnPayService;

		public ViewHistoryComplete(IBookingService bookingService, IStudentService studentService, IFeedBackService feedbackService, ITutorService tutorService, IVnPayService vnPayService)
		{
			_bookingService = bookingService;
			_studentService = studentService;
			_feedbackService = feedbackService;
			_tutorService = tutorService;
			_vnPayService = vnPayService;
		}

		public IList<BookingComplete> LearningComplete { get; set; } = default!;

		public async Task OnGetAsync()
		{
			var accountStudent = HttpContext.Session.GetString("UserEmail");
			var allStudent = _studentService.GetStudentByEmail(accountStudent);
			var allbookingList = _bookingService.GetAllBookingTutor().Where(x => x.StudentId.Equals(allStudent.StudentId));
			var bookingList = allbookingList.OrderByDescending(x => x.DateStart)
											.Where(x => x.Status.Equals(BookingStatus.Complete))
											.Select(x => new BookingComplete
											{
												Id = x.Id,
												TutorName = x.Tutor.Fullname,
												TutorId = x.TutorId,
												Email = x.Tutor.Email,
												StudentId = x.StudentId,
												ServiceName = x.Service.Service1,
												ServiceId = x.ServiceId,
												DateStart = x.DateStart,
												DateEnd = x.DateEnd,
												PaymentMethods = x.PaymentMethods,
												Schedules = x.BookingSchedules.Select(bs => bs.Sc.Slot).ToList(),
												Price = _tutorService.GetTutorServicePrice(x.TutorId, x.ServiceId),
												PaymentStatus = x.PaymentStatus,
											});

			LearningComplete = bookingList.ToList();
			TempData["LearningComplete"] = JsonSerializer.Serialize(LearningComplete);

			foreach (var booking in LearningComplete)
			{
				booking.Feedbacks = await _feedbackService.GetFeedBackByBookingId(booking.Id);
			}
		}

		[BindProperty]
		public Feedback FeedbackModel { get; set; }

		public async Task<IActionResult> OnPostAsync()
		{
			await _feedbackService.AddFeedbackAsync(FeedbackModel);
			await OnGetAsync();
			return RedirectToPage();
		}

		public IActionResult OnPostPurchase(int bookingId)
		{

			LearningComplete = JsonSerializer.Deserialize<List<BookingComplete>>(TempData["LearningComplete"].ToString());

			var selectedBooking = LearningComplete.FirstOrDefault(b => b.Id == bookingId);

			if (selectedBooking == null)
			{
				return NotFound();
			}

			var paymentRequest = new VnPaymentRequestModel
			{
				ServiceId = selectedBooking.ServiceId,
				Amount = selectedBooking.Price
			};
			var paymentUrl = _vnPayService.CreatePaymentUrl(HttpContext, paymentRequest);

			HttpContext.Session.SetInt32("PaymentBookingId", bookingId);

			return Redirect(paymentUrl);
		}
	}
}

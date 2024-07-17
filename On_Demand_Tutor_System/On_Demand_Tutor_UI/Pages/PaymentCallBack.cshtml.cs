using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.BookingService;
using Services.VnPay;

namespace On_Demand_Tutor_UI.Pages
{
	public class PaymentCallBackModel : PageModel
	{
		private readonly IBookingService _bookingService;
		private readonly IVnPayService _vnPayService;

		public PaymentCallBackModel(IBookingService bookingService, IVnPayService vnPayService)
		{
			_bookingService = bookingService;
			_vnPayService = vnPayService;
		}

		public IActionResult OnGet()
		{
			int? bookingId = HttpContext.Session.GetInt32("PaymentBookingId");
			if (!bookingId.HasValue)
			{
				TempData["Message"] = "Session expired or invalid booking ID.";
				return RedirectToPage("Error");
			}

			HttpContext.Session.Remove("PaymentBookingId");

			var paymentResponse = _vnPayService.PaymentResponse(HttpContext.Request.Query);
			if (paymentResponse == null || paymentResponse.ResponseCode != "00")
			{
				TempData["Message"] = $"Payment error: {paymentResponse.ResponseCode}";
				return RedirectToPage("/PaymentPages/PaymentFailure");
			}

			_bookingService.UpdateBookingStatusToPaid(bookingId.Value);

			TempData["Message"] = "Payment successful";
			return RedirectToPage("/PaymentPages/SuccessPage");
		}
	}
}

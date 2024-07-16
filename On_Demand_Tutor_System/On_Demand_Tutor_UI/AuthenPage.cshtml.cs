using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace On_Demand_Tutor_UI.Pages.AccountPages
{
    public class AuthenPageModel : PageModel
    {
        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            base.OnPageHandlerExecuting(context);

            var path = HttpContext.Request.Path.Value;
            var userEmail = HttpContext.Session.GetString("UserEmail");
            var userType = HttpContext.Session.GetString("UserType");

            Console.WriteLine($"Path: {path}, UserEmail: {userEmail}, UserType: {userType}");
            if (string.IsNullOrEmpty(userEmail) || string.IsNullOrEmpty(userType))
            {
                context.Result = RedirectToPage("/AccountPages/LoginPage");
                return;
            }

            if (path.Equals("/AccountPages/LoginPage"))
            {
                switch (userType)
                {
                    case "Admin":
                        context.Result = RedirectToPage("/Admin/Admin_Index");
                        return;
                    case "Student":
                        context.Result = RedirectToPage("/Index");
                        return;
                    case "Tutor":
                        context.Result = RedirectToPage("/Tutor/Tutor_Index");
                        return;
                    case "Moderator":
                        context.Result = RedirectToPage("/Moderator/Index");
                        return;
                }
            }

            if (IsAccessDenied(path, userType))
            {
                context.Result = RedirectToPage("/Forbidden");
            }
        }

        private bool IsAccessDenied(string path, string userType)
        {
            if (path.Contains("/Admin") && userType != "Admin")
            {
                return true;
            }
            if (path.Contains("/Tutor") && userType != "Tutor")
            {
                return true;
            }
            if (path.Contains("/Moderator") && userType != "Moderator")
            {
                return true;
            }
            if (path.Contains("/Index") && userType != "Student")
            {
                return true;
            }
            return false;
        }
    }
}
